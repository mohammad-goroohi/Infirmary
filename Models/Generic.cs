using Infirmary.Models.Shared;

namespace Infirmary.Models
{
    public record Property(string Name,string Title);
    public class Generic : BaseEntity
    {
        public string ServiceName { get; set; }
        public IDictionary<Property, object> Fields { get; set; }

        public string DataGridTitle { get; set; }
        public string DataGridNewRowButtonTitle { get; set; }
    }    
}
