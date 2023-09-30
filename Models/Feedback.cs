namespace Hospital2.Models
{
    public class Feedback
    {
        public int Id { get; set; }  // Primary Key for the feedback
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
    }
}
