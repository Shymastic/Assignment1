using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;

namespace CandidateManageWebsite.Pages.JobPostingPage
{
    public class CreateModel : PageModel
    {
        private readonly IJobPostingService _service;

        public CreateModel(IJobPostingService jobPostingService)
        {
            _service = jobPostingService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
          if (!ModelState.IsValid ||_service.GetJobPosting(JobPosting.PostingId) == null || JobPosting == null)
            {
                return Page();
            }

            _service.AddJobPosting(JobPosting);

            return RedirectToPage("./Index");
        }
    }
}
