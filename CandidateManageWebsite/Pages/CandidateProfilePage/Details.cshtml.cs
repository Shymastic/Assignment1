using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;

namespace CandidateManageWebsite.Pages.CandidateProfilePage
{
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileService _service;

        public DetailsModel(ICandidateProfileService service)
        {
            _service = service;
        }

        public CandidateProfile CandidateProfile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _service.GetCandidateProfiles == null)
            {
                return NotFound();
            }

            var candidateprofile =  _service.GetCandidateProfile(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            else 
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }
    }
}
