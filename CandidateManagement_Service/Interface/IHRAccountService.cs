using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service.Interface
{
    public interface IHRAccountService
    {
        Hraccount GetHraccountByEmail(string email);
        List<Hraccount> GetHraccounts();
    }
}
