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
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo _repo;

        public JobPostingService()
        {
            _repo = new JobPostingRepo();
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return _repo.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(string Id)
        {
            return _repo.DeleteJobPosting(Id);
        }

        public JobPosting GetJobPosting(string Id)
        {
           return _repo.GetJobPosting(Id);
        }

        public List<JobPosting> GetJobPostings()
        {
            return _repo.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return _repo.UpdateJobPosting(jobPosting);
        }
    }
}
