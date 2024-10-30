using CandidateManagement_BusinessObject;
using CandidateManagement_BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO.DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;
        public CandidateProfileDAO()
        {
            context = new();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new();
                }
                return instance;
            }
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.Include(c=>c.Posting).ToList();
        }
        public CandidateProfile GetCandidateProfile(string id) {
            return context.CandidateProfiles.SingleOrDefault(c => c.CandidateId == id);
        }
        public bool AddCandidateProfile(CandidateProfile CandidateProfile)
        {
            var isSuccess = false;
            try
            {
                if (CandidateProfile == null && GetCandidateProfile(CandidateProfile.PostingId) == null) { }
                {
                    context.CandidateProfiles.Add(CandidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex) { }
            return isSuccess;
        }
        public bool DeleteCandidateProfile(string Id)
        {
            var isSuccess = false;
            var JobPost = GetCandidateProfile(Id);
            try
            {
                if (JobPost != null) { }
                {
                    context.CandidateProfiles.Remove(JobPost);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex) { }
            return isSuccess;
        }
        public bool UpdateCandidateProfile(CandidateProfile CandidateProfile)
        {
            var isSuccess = false;
            try
            {
                if (CandidateProfile != null && GetCandidateProfile(CandidateProfile.PostingId) != null) { }
                {
                    context.CandidateProfiles.Update(CandidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex) { }
            return isSuccess;
        }
    }
}
