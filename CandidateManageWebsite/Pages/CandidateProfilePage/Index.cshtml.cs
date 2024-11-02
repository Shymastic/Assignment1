using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;
using CandidateManagement_Service;

namespace CandidateManageWebsite.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _service;

        public IndexModel(ICandidateProfileService service)
        {
            _service = service;
        }

        public IList<CandidateProfileDTO> CandidateProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetCandidateProfiles != null)
            {
                CandidateProfile = _service.GetCandidateProfiles();
            }
        }
    }
}
