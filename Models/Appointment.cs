using System.ComponentModel.DataAnnotations;

namespace Hospital2.Models
{
    public class Appointment
    {
        [Key]
        public int AID { get; set; }  // Appointment ID
        public SectionType Section { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
    }

    public enum SectionType
    {
        Neurology,
        Dentistry,
        Cardiology,
        Pediatrics,
        Pulmonolog,
        Ophthalmolog,
        Diagnostics
    }
}
