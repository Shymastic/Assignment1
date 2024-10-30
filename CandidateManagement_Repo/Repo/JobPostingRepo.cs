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
    public class JobPostingRepo : IJobPostingRepo
    {
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return JobPostingDAO.Instance.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(string Id)
        {
            return JobPostingDAO.Instance.DeleteJobPosting(Id);
        }

        public JobPosting GetJobPosting(string Id)
        {
            return JobPostingDAO.Instance.GetJobPosting(Id);
        }

        public List<JobPosting> GetJobPostings() 
            => JobPostingDAO.Instance.GetJobPostings();

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
        }
    }
}
