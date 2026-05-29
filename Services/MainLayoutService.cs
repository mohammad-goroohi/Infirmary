using QuizWebAssembly.Models;

namespace QuizWebAssembly.Services
{
    public class MainLayoutService : CrudService<MenuItem>
    {
        public MainLayoutService()
        {
            Create(new MenuItem
            {
                Title = "داشبورد",
                Href = "/Dashboard",
                Icon = "fa-solid fa-gauge-high",
            });

            Create(new MenuItem
            {
                Title = "تنظیمات سیستم",
                Icon = "fa-solid fa-users",
                ElementId = "menuSystemConfiguration",
                MenuLevelType = MenuLevelType.Has2Level,
                Children = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Title = "لیست کاربران",
                        Href = "/Admin/Users",
                    },                    new MenuItem
                    {
                        Title = "لیست نقش ها",
                        Href = "/Admin/Roles",
                    },
                }
            });
        }
    }
}
