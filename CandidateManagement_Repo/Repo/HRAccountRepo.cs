using CandidateManagement_BusinessObject.Models;
using CandidateManagement_DAO.DAO;
using CandidateManagement_Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repo.Repo
{
    public class HRAccountRepo : IHRAccountRepo
    {

        public Hraccount GetHraccountByEmail(string email)
            => HRAccountDAO.Instance.GetHraccountByEmail(email);
        public List<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
    }
}
