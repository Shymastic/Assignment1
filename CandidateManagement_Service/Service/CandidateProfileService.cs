using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Repo.Interface;
using CandidateManagement_Repo.Repo;
using CandidateManagement_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service.Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo _repo;

        public CandidateProfileService()
        {
            _repo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile CandidateProfile)
        {
            return _repo.AddCandidateProfile(CandidateProfile);
        }

        public bool DeleteCandidateProfile(string Id)
        {
            return _repo.DeleteCandidateProfile(Id);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return _repo.GetCandidateProfile(id);
        }

        public  List<CandidateProfile> GetCandidateProfiles()
        {
            return _repo.GetCandidateProfiles();
        }

        public bool UpdateCandidateProfile(CandidateProfile CandidateProfile)
        {
            return _repo.UpdateCandidateProfile(CandidateProfile);
        }
    }
}
