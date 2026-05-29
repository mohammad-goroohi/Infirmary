using Infirmary.Models.Shared;

namespace Infirmary.Models
{
    public class Generic : BaseEntity
    {
        public string ServiceName { get; set; }
        public IDictionary<string,object> Fields { get; set; }
    }    
}
