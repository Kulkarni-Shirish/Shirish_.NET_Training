namespace AddSubtractMvc.Models
{
    // ViewModel used to display error information, including the request ID for troubleshooting
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
