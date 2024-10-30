using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repo.Interface
{
    public interface ICandidateProfileRepo
    {
        List<CandidateProfile> GetCandidateProfiles();
        CandidateProfile GetCandidateProfile(string id);
        bool DeleteCandidateProfile(string Id);
        bool UpdateCandidateProfile(CandidateProfile CandidateProfile);
        bool AddCandidateProfile(CandidateProfile CandidateProfile);
    }
}
