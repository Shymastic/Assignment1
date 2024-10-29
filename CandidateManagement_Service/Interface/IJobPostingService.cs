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
        bool UpdateJobPosting(JobPosting jobPosting);
        bool DeleteJobPosting(string Id);
        bool AddJobPosting(JobPosting jobPosting);
        JobPosting? GetJobPosting(string Id);
        JobPosting? GetJobPostingByName(string name);
    }
}
