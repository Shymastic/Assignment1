using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repo.Interface
{
    public interface IHRAccountRepo
    {
        Hraccount GetHraccountByEmail(string email);
        List<Hraccount> GetHraccounts();
    }
}
