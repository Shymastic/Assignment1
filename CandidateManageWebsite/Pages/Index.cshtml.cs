using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManageWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHRAccountService _service;
        public IndexModel(ILogger<IndexModel> logger, IHRAccountService service)
        {
            _logger = logger;
            _service = service;
        }
        [BindProperty]
        public Hraccount Hraccount { get; set; } = default!;
        public IActionResult OnPost()
        {
            var Email = Hraccount.Email;
            var Password = Hraccount.Password;
            
            if (_service.GetHraccounts != null)
            {
                var account = _service.GetHraccountByEmail(Email);
                if (account.MemberRole != 3)
                {


                    if (account != null && account.Password.Equals(Password))
                    {
                        HttpContext.Session.SetString("Role", account.MemberRole.ToString());
                        return RedirectToPage("./CandidateProfilePage/Index");

                    }
                    return Unauthorized();
                }
            }
            return NotFound("Username, Password being Incorrect") ;
        }
    }
}
