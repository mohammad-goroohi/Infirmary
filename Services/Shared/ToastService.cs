namespace Infirmary.Services.Shared
{

    public class ToastService
    {
        public event Action<ToastRequest>? OnShow;

        public void Show(string message, ToastLevel level = ToastLevel.Info, int durationMs = 3000, string? title = null)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            var req = new ToastRequest
            {
                Message = message,
                Title = title,
                Level = level,
                DurationMs = Math.Max(1000, durationMs)
            };
            OnShow?.Invoke(req);
        }
    }


    // IToastService.cs
    public enum ToastLevel { Success, Info, Warning, Error }

    public sealed class ToastRequest
    {
        public string Message { get; init; } = "";
        public string? Title { get; init; }
        public ToastLevel Level { get; init; } = ToastLevel.Info;
        public int DurationMs { get; init; } = 3000;
    }
}
