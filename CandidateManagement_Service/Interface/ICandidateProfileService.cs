using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service.Interface
{
    public interface ICandidateProfileService
    {
        List<CandidateProfileDTO> GetCandidateProfiles();
        bool DeleteCandidateProfile(string Id);
        CandidateProfile GetCandidateProfile(string id);
        bool UpdateCandidateProfile(CandidateProfile CandidateProfile);
        bool AddCandidateProfile(CandidateProfile CandidateProfile);
    }
}
