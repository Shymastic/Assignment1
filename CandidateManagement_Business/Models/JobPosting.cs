using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidateManagement_BusinessObject.Models
{
    public partial class JobPosting
    {
        public JobPosting()
        {
            CandidateProfiles = new HashSet<CandidateProfile>();
        }

        [Required(ErrorMessage = "Posting ID is required")]
        public string PostingId { get; set; } = null!;

        [Required(ErrorMessage = "Job posting title is required")]
        [StringLength(100, ErrorMessage = "Job posting title cannot exceed 100 characters")]
        public string JobPostingTitle { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Posted date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime? PostedDate { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
    }
}
