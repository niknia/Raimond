namespace Dkd.Infra.Helper.Internal;

/// <summary>
/// Consistent Hashing Algorithm
/// </summary>
public sealed class HashConsistentGenerater
{
    /// <summary>
    /// Real node information
    /// </summary>
    private readonly List<string> _nodes = [];

    /// <summary>
    /// Virtual node information (int type is mainly used for binary search when getting virtual nodes)
    /// </summary>
    private readonly List<int> _virtualNode = [];

    /// <summary>
    /// Virtual node and real node mapping, after getting the virtual node, can return the real node in O(1) time complexity
    /// </summary>
    private readonly Dictionary<int, string> _virtualNodeAndNodeMap = [];

    /// <summary>
    /// Virtual node multiplier
    /// </summary>
    private int _virtualNodeMultiple = 100;

    internal HashConsistentGenerater()
    {
    }

    /// <summary>
    /// Add node
    /// </summary>
    /// <param name="hosts">Node collection</param>
    /// <returns>Operation result</returns>
    public bool AddNode(params string[] hosts)
    {
        if (hosts == null || hosts.Length == 0)
        {
            return false;
        }
        _nodes.AddRange(hosts); //First add nodes to real node information
        foreach (var item in hosts)
        {
            for (var i = 1; i <= _virtualNodeMultiple; i++) //This loop adds from 1 to 1000 for real IP strings like "192.168.3.1", as virtual nodes. 192.168.3.11, 192.168.3.11000
            {
                var currentHash = GetHashCode(item + i) & int.MaxValue; //Calculate a hash, using custom hash algorithm because string's default hash implementation doesn't guarantee getting the same value for the same string. Bitwise AND with int.MaxValue is to set the obtained hash value as a positive number
                if (_virtualNodeAndNodeMap.TryAdd(currentHash, item)) //Because hash might be duplicated, if current hash is already in virtual node and real node mapping, use the first added one, no need to add again
                {
                    _virtualNode.Add(currentHash); //Add current virtual node to virtual nodes
                }
            }
        }
        _virtualNode.Sort(); //After operation, perform a mapping, for using binary search when finding virtual nodes based on key's hash value later
        return true;
    }

    /// <summary>
    /// Remove node
    /// </summary>
    /// <param name="host">Specified node</param>
    /// <returns></returns>
    public bool RemoveNode(string host)
    {
        if (!_nodes.Remove(host)) //If removing specified node from real node collection fails, no need for subsequent operations, return directly
        {
            return false;
        }
        for (var i = 1; i <= _virtualNodeMultiple; i++)
        {
            var currentHash = GetHashCode(host + i) & int.MaxValue; //Calculate a hash, using custom hash algorithm because string's default hash implementation doesn't guarantee getting the same value for the same string. Bitwise AND with int.MaxValue is to set the obtained hash value as a positive number
            if (_virtualNodeAndNodeMap.TryGetValue(currentHash, out var value) && value == host) //Because hash might be duplicated, after checking if hash exists in virtual node and node mapping, also need to check if node obtained through current hash value matches specified node, if not, prove this virtual node doesn't belong to current hash value
            {
                _virtualNode.Remove(currentHash); //Remove from virtual nodes
                _virtualNodeAndNodeMap.Remove(currentHash); //Remove from virtual node and real IP mapping
            }
        }
        _virtualNode.Sort(); //After operation, perform a mapping, for using binary search when finding virtual nodes based on key's hash value later
        return true;
    }

    /// <summary>
    /// Get all nodes
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllNodes()
    {
        var nodes = new List<string>(_nodes.Count);
        nodes.AddRange(_nodes);
        return nodes;
    }

    /// <summary>
    /// Get node count
    /// </summary>
    /// <returns></returns>
    public int GetNodesCount()
    {
        return _nodes.Count;
    }

    /// <summary>
    /// Reset virtual node multiplier
    /// </summary>
    /// <param name="multiple"></param>
    public void ReSetVirtualNodeMultiple(int multiple)
    {
        if (multiple < 0 || multiple == _virtualNodeMultiple)
        {
            return;
        }
        var nodes = new List<string>(_nodes.Count);
        nodes.AddRange(_nodes); //Copy existing real nodes
        _virtualNodeMultiple = multiple; //Set multiplier
        _nodes.Clear();
        _virtualNode.Clear();
        _virtualNodeAndNodeMap.Clear(); //Clear data
        AddNode(nodes.ToArray()); //Re-add
    }

    /// <summary>
    /// Get node
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetNode(string key)
    {
        var hash = GetHashCode(key) & int.MaxValue;
        var start = 0;
        var end = _virtualNode.Count - 1;
        while (end - start > 1)
        {
            var index = (start + end) / 2;
            if (_virtualNode[index] > hash)
            {
                end = index;
            }
            else if (_virtualNode[index] < hash)
            {
                start = index;
            }
            else
            {
                start = end = index;
            }
        }
        return _virtualNodeAndNodeMap[_virtualNode[start]];
    }

    private static int GetHashCode(string key, int nTime = 0)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var digest = MD5.HashData(keyBytes);
        var rv = (long)(digest[3 + nTime * 4] & 0xFF) << 24
                        | (long)(digest[2 + nTime * 4] & 0xFF) << 16
                        | (long)(digest[1 + nTime * 4] & 0xFF) << 8
                        | (long)digest[0 + nTime * 4] & 0xFF;
        return (int)(rv & 0xffffffffL);
    }
}
