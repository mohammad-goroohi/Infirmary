using System.Text.RegularExpressions;

namespace Infirmary.Models.Shared
{
    public class DataGridConfig
    {
        public string Title { get; set; } = string.Empty;
        public List<DataGridColumn> Columns { get; set; } = new List<DataGridColumn>();
        public List<DataGridRowActionGroup> GroupActions { get; set; } = new List<DataGridRowActionGroup>();
        public Func<Task<List<object>>>? LoadDataAsync { get; set; }
        public NewRowButtonDataGridConfig NewRowButtonDataGridConfig { get; set; } = new NewRowButtonDataGridConfig();
        public EditRowButtonDataGridConfig EditRowButtonDataGridConfig { get; set; } = new EditRowButtonDataGridConfig();
        public DeleteRowButtonDataGridConfig DeleteRowButtonDataGridConfig { get; set; } = new DeleteRowButtonDataGridConfig();
    }
    public class DataGridColumn
    {
        public string Title { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;

        public string Scope { get; set; } = "col";
        public string Style { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
    }
    public class DataGridRowActionGroup
    {
        public string Width { get; set; } = "200px";
        public List<DataGridRowAction> Actions { get; set; } = new List<DataGridRowAction>();
    }
    public class DataGridRowAction
    {
        public string IconClass { get; set; } = IconsClass.fa_pen_to_square;
        public string ButtonClass { get; set; } = ButtonsClass.btn_primary;
        public Action<Dictionary<string, string>> OnClick { get; set; }

    }
    public static class IconsClass
    {
        public static string fa_pen_to_square { get; set; } = "fa-pen-to-square";
    }
    public static class ButtonsClass
    {
        public static string btn_primary { get; set; } = "btn-primary";
    }

    public class ItemField
    {
        public string Title { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;

        public string Scope { get; set; } = "col";
        public string Style { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;

        public ModelEditorValueType ValuType { get; set; }
        public string Value { get; set; }
        public List<ValidationItemField> ValidationRules { get; set; } = new List<ValidationItemField>();
        public string ErrorMessage { get; set; }
    }
    public abstract class ValidationItemField
    {
        public string ErrorMessage { get; set; }
        public abstract bool IsValid(string Value);
    }
    public class Required : ValidationItemField
    {
        public override bool IsValid(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return false;
            }
            return true;
        }
    }     
    public class MinLength : ValidationItemField
    {
        public int Length { get; set; }
        public override bool IsValid(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                Value = string.Empty;
            }
            if (Value.Length<Length)
            {
                return false;
            }
            return true;
        }
    }
    public class MaxLength : ValidationItemField
    {
        public int Length { get; set; }
        public override bool IsValid(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                Value = string.Empty;
            }
            if (Value.Length > Length)
            {
                return false;
            }
            return true;
        }
    }
    public class Regex : ValidationItemField
    {
        public string Pattern { get; set; }
        public override bool IsValid(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return true;
            }
            var Reg = new System.Text.RegularExpressions.Regex(Pattern);
            return Reg.IsMatch(Value);
        }
    }
    public class SelectiveItemField : ItemField
    {
        public List<SelectItem> Items { get; set; } = new List<SelectItem>();
    }
    public enum ModelEditorValueType
    {
        Text,
        Number,
        Selective,
        Hidden,
        Readonly,
        Password,
        CheckBox,
        Date,
        Time
    }
    public class InputModal
    {
        public string Title { get; set; }
        public string Size { get; set; } = ModalSize.Default;
        public int ColumnCount { get; set; } = 2;
        public Func<Dictionary<string, string>, bool> OnSubmit { get; set; }
        public List<ItemField> Fields { get; set; }
    }
    public static class ModalSize
    {
        public static string modal_sm { get; set; } = "modal-sm";
        public static string Default { get; set; } = "";
        public static string modal_lg { get; set; } = "modal-lg";
        public static string modal_xl { get; set; } = "modal-xl";
        public static string modal_fullscreen { get; set; } = "modal-fullscreen";
    }
    public class ConfirmModal
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Action OnConfirm { get; set; }
    }
    public class NewRowButtonDataGridConfig
    {
        public Func<InputModal> OnOpenModal { get; set; }
        public string ButtonTitle { get; set; }
        public bool IsShow { get; set; }
    }
    public class EditRowButtonDataGridConfig
    {
        public Func<Dictionary<string, string>, InputModal> OnOpenModal { get; set; }
    }
    public class DeleteRowButtonDataGridConfig
    {
        public Func<Dictionary<string, string>, ConfirmModal> OnOpenModal { get; set; }
    }
    public class SelectItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
    }
}
