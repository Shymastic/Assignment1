using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;

namespace CandidateManageWebsite.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService _service;
        private readonly IJobPostingService _jobPostingService;

        public CreateModel(ICandidateProfileService service, IJobPostingService jobPostingService)
        {
            _service = service;
            _jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(_jobPostingService.GetJobPostings(), "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _service.GetCandidateProfiles == null || CandidateProfile == null)
            {
                return Page();
            }

            _service.AddCandidateProfile(CandidateProfile);
            return RedirectToPage("./Index");
        }
    }
}
