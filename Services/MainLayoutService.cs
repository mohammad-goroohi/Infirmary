using Infirmary.Models;

namespace Infirmary.Services
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
                Title = "پذیرش بیماران",
                Icon = "fa-solid fa-person-walking-arrow-righ",
                ElementId = "menuClinicSystem",
                MenuLevelType = MenuLevelType.Has2Level,
                Children = new List<MenuItem>
    {
        new MenuItem
        {
            Title = "نوبت دهی",
            Href = "/Clinic/Appointments",
            Icon = "fa-solid fa-calendar-check",
        },
        new MenuItem
        {
            Title = "پرونده بیماران",
            Href = "/Clinic/Patients",
            Icon = "fa-solid fa-folder-open",
        },
        new MenuItem
        {
            Title = "ویزیت پزشک",
            Href = "/Clinic/DoctorVisit",
            Icon = "fa-solid fa-user-doctor",
        },
        new MenuItem
        {
            Title = "داروخانه",
            Href = "/Clinic/Pharmacy",
            Icon = "fa-solid fa-capsules",
        },
        new MenuItem
        {
            Title = "آزمایشگاه",
            Href = "/Clinic/Laboratory",
            Icon = "fa-solid fa-flask-vial",
        },
        new MenuItem
        {
            Title = "تصویربرداری",
            Href = "/Clinic/Imaging",
            Icon = "fa-solid fa-x-ray",
        },
        new MenuItem
        {
            Title = "صورتحساب و پرداخت",
            Href = "/Clinic/Billing",
            Icon = "fa-solid fa-file-invoice-dollar",
        },
        new MenuItem
        {
            Title = "گزارشات",
            Href = "/Clinic/Reports",
            Icon = "fa-solid fa-chart-line",
        },
        new MenuItem
        {
            Title = "تعاریف پایه",
            Href = "/Clinic/Settings",
            Icon = "fa-solid fa-gears",
        },
    }
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
