
namespace Dkd.Shared.WebApi.AutoWrapper.Filters
{
    public class AutoWrapIgnoreAttribute : Attribute
    {
        public bool ShouldLogRequestData{ get; set; } = true;

        public AutoWrapIgnoreAttribute(){}
    }
}
