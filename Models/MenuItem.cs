using QuizWebAssembly.Models.Shared;

namespace QuizWebAssembly.Models
{
    public class MenuItem : BaseEntity
    {
        public string ElementId { get; set; }
        public string? Title { get; set; }
        public string? Href { get; set; }
        public string Icon { get; set; }
        public MenuLevelType MenuLevelType { get; set; }
        public IEnumerable<MenuItem> Children { get; set; }

        public MenuItem Parent { get; set; }
    }
    public enum MenuLevelType
    {
        OnlyOneLevel,
        Has2Level,
    }
}
