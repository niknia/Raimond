namespace Dkd.Infra.Repository;

public interface IConcurrency
{
    /// <summary>
    /// Concurrency control column
    /// </summary>
    public byte[] RowVersion { get; set; }
}
