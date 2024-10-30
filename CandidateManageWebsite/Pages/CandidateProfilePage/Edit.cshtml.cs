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

namespace CandidateManageWebsite.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService _service;
        private readonly IJobPostingService _jobPostingService;
        public EditModel(ICandidateProfileService service, IJobPostingService jobPostingService)
        {
            _service = service;
            _jobPostingService = jobPostingService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _service.GetCandidateProfiles == null)
            {
                return NotFound();
            }

            var candidateprofile = _service.GetCandidateProfile(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = new SelectList(_jobPostingService.GetJobPostings(), "PostingId", "PostingId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _service.UpdateCandidateProfile(CandidateProfile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
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

        private bool CandidateProfileExists(string id)
        {
          return _service.GetCandidateProfile(id)!=null ? true : false;
        }
    }
}
