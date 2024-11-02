using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;

namespace CandidateManageWebsite.Pages.JobPostingPage
{
    public class EditModel : PageModel
    {
        private readonly IJobPostingService _service;

        public EditModel(IJobPostingService jobPostingService)
        {
            _service = jobPostingService;
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        public IActionResult OnGetAsync(string id)
        {
            if (id == null || _service.GetJobPosting(id) == null)
            {
                return NotFound();
            }

            var jobposting = _service.GetJobPosting(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            JobPosting = jobposting;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _service.UpdateJobPosting(JobPosting);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostingExists(JobPosting.PostingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobPostingExists(string id)
        {
          return _service.GetJobPosting(id)!=null ? true : false;
        }
    }
}
