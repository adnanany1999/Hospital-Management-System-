using System.ComponentModel.DataAnnotations;

namespace Hospital2.Models.Patients
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordId { get; set; }

        [Required]
        [Display(Name = "Date of Visit")]
        [DataType(DataType.Date)]
        public DateTime DateOfVisit { get; set; }

        [Required]
        [Display(Name = "Doctor's Name")]
        public string? DoctorName { get; set; }

        [Display(Name = "Symptoms")]
        public string? Symptoms { get; set; }

        [Display(Name = "Diagnosis")]
        public string? Diagnosis { get; set; }

        [Display(Name = "Prescription")]
        public string? Prescription { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        // Foreign Key for Patient
        public int PatientId { get; set; }

        // Navigation property for the relationship between MedicalRecord and Patient
        public Patient? Patient { get; set; }
    }
}
