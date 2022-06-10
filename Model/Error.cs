namespace EvernoteClone.Model
{
    public class ErrorDetails
    {
        public int code { get; set; }
        public string? message { get; set; }
    }

    public class Error
    {
        public ErrorDetails? error { get; set; }
    }
}
