using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Repo.Interface;
using CandidateManagement_Repo.Repo;
using CandidateManagement_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Service.Service
{
    public class HRAccountService : IHRAccountService
    {
        private readonly IHRAccountRepo _repo;


        public HRAccountService()
        {
            _repo = new HRAccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return _repo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            throw new NotImplementedException();
        }
    }
}
