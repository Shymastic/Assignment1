using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_WPF_GUI
{
    public static class CandidateProfileMapper
    {
        public static CandidateProfileMap ToCandidateProfileDTO(CandidateProfile model)
        {
            return new CandidateProfileMap
            {
                CandidateId = model.CandidateId,
                Fullname = model.Fullname,
                Birthday = model.Birthday,
                ProfileShortDescription = model.ProfileShortDescription,
                ProfileUrl = model.ProfileUrl,
                PostingId = model.PostingId,
                JobPostingTitle = model.Posting?.JobPostingTitle,
            };
        }
    }
}
