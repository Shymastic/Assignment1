using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service.Interface
{
    public interface IJobPostingService
    {
        List<JobPosting> GetJobPostings();
        public bool UpdateJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(string Id);
        public bool AddJobPosting(JobPosting jobPosting);
        public JobPosting GetJobPosting(string Id);
    }
}
