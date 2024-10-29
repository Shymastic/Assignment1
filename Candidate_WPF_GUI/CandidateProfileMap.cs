using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_WPF_GUI
{
    public class CandidateProfileMap
    {
        public string CandidateId { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? ProfileShortDescription { get; set; }
        public string? ProfileUrl { get; set; }
        public string? PostingId { get; set; }
        public string? JobPostingTitle { get; set; }
    }
}
