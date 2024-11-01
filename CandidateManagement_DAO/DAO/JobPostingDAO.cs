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
    public class JobPostingDAO
    {
        private CandidateManagementContext context;
        private static JobPostingDAO instance;
        public JobPostingDAO()
        {
            context = new();
        }
        public static JobPostingDAO Instance
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
        public JobPosting? GetJobPosting(string Id)
        {
            return context.JobPostings.AsNoTracking().SingleOrDefault(c => c.PostingId == Id);
        }
        public JobPosting? GetJobPostingWithTracking(string id)
        {

            return context.JobPostings.SingleOrDefault(c => c.PostingId == id);
        }
        public List<JobPosting> GetJobPostings()
        {
            return context.JobPostings.AsNoTracking().ToList();
        }
        public JobPosting? GetJobPostingByName(string name)
        {
            return context.JobPostings.SingleOrDefault(c=>c.JobPostingTitle == name);
        }
      
        public bool AddJobPosting(JobPosting jobPosting)
        {
            var isSuccess = false;
            try
            {              
                if (jobPosting != null & GetJobPosting(jobPosting.PostingId) == null) 
                {
                    context.JobPostings.Add(jobPosting);
                    context.SaveChanges();
                    isSuccess = true; context.Entry(jobPosting).State = EntityState.Detached;
                }
            }
            catch (Exception ex) {  }
            return isSuccess;
        }
        public bool DeleteJobPosting(string Id)
        {
            var isSuccess = false;
            var JobPost = GetJobPosting(Id);
            try
            {
                if (JobPost != null) 
                {
                    context.JobPostings.Remove(JobPost);
                    context.SaveChanges();
                    isSuccess = true;
                    context.Entry(JobPost).State = EntityState.Detached;
                }
            }
            catch (Exception ex) { }
            return isSuccess;
        }
        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            var isSuccess = false;
            try
            {
                if (jobPosting != null)
                {
                    var existingJobPost = GetJobPostingWithTracking(jobPosting.PostingId);
                    if (existingJobPost != null)
                    {
                        context.Entry(existingJobPost).CurrentValues.SetValues(jobPosting);
                        context.SaveChanges();
                        isSuccess = true;
                        context.Entry(existingJobPost).State = EntityState.Detached;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating JobPosting: {ex.Message}");
            }
            return isSuccess;
        }
    }
}
