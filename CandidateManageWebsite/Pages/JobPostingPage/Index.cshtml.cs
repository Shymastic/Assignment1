using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;

namespace CandidateManageWebsite.Pages.JobPostingPage
{
    public class IndexModel : PageModel
    {
        private readonly IJobPostingService _service;

        public IndexModel(IJobPostingService jobPostingService)
        {
            _service = jobPostingService;
        }

        public IList<JobPosting> JobPosting { get;set; } = default!;

        public void OnGetAsync()
        {
            JobPosting =  _service.GetJobPostings();
        }
    }
}
