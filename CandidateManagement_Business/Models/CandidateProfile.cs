using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidateManagement_BusinessObject.Models
{
    public partial class CandidateProfile
    {
        [Required(ErrorMessage = "Candidate ID is required")]
        public string CandidateId { get; set; } = null!;

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
        public string Fullname { get; set; } = null!;

        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime? Birthday { get; set; }

        [StringLength(300, ErrorMessage = "Profile short description cannot exceed 300 characters")]
        public string? ProfileShortDescription { get; set; }

        public string? ProfileUrl { get; set; }

        public string? PostingId { get; set; }

        public virtual JobPosting? Posting { get; set; }
    }
}
