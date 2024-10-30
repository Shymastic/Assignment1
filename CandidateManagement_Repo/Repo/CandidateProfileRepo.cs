using CandidateManagement_BusinessObject.Models;
using CandidateManagement_DAO.DAO;
using CandidateManagement_Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repo.Repo
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile CandidateProfile)
        {
            return CandidateProfileDAO.Instance.AddCandidateProfile(CandidateProfile);
        }

        public bool DeleteCandidateProfile(string Id)
        {
           return CandidateProfileDAO.Instance.DeleteCandidateProfile(Id);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return CandidateProfileDAO.Instance.GetCandidateProfile(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
            => CandidateProfileDAO.Instance.GetCandidateProfiles();

        public bool UpdateCandidateProfile(CandidateProfile CandidateProfile)
        {
           return CandidateProfileDAO.Instance.UpdateCandidateProfile(CandidateProfile);
        }

    }

}
