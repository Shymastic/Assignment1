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
    public class DeleteModel : PageModel
    {
        private readonly IJobPostingService _service;

        public DeleteModel(IJobPostingService jobPostingService)
        {
            _service = jobPostingService;
        }

        [BindProperty]
      public JobPosting JobPosting { get; set; } = default!;

        public IActionResult OnGetAsync(string id)
        {
            if (id == null ||_service.GetJobPosting(id) == null)
            {
                return NotFound();
            }

            var jobposting = _service.GetJobPosting(id);

            if (jobposting == null)
            {
                return NotFound();
            }
            else 
            {
                JobPosting = jobposting;
            }
            return Page();
        }

        public IActionResult OnPostAsync(string id)
        {
            if (id == null ||_service.GetJobPosting(id) == null)
            {
                return NotFound();
            }
            var jobposting = _service.GetJobPosting(id);

            if (jobposting != null)
            {
                JobPosting = jobposting;
                _service.DeleteJobPosting(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
