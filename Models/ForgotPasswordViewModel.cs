namespace Hospital2.Models
{
    public class ForgotPasswordViewModel
    {
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? OldPassword { get; set; }  // Note: It's not typical to ask for the old password in a forgot password process.
        public string? NewPassword { get; set; }
    }
}
