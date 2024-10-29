using CandidateManagement_BusinessObject.Models;

namespace CandidateManagement_Repo.Interface
{
    public interface IJobPostingRepo
    {
        List<JobPosting> GetJobPostings();
        bool UpdateJobPosting(JobPosting jobPosting);
        bool DeleteJobPosting(string Id);
        bool AddJobPosting(JobPosting jobPosting);
        JobPosting? GetJobPosting(string Id);
        JobPosting? GetJobPostingByName(string Name);
    }
}
