using CandidateManagement_BusinessObject;
using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO.DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;
        private static HRAccountDAO instance;
        public HRAccountDAO()
        {
            context = new();
        }
        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new();
                }
                return instance;
            }
        }
        public Hraccount GetHraccountByEmail(string email)
        {
            return context.Hraccounts.SingleOrDefault(c => c.Email == email);
        }
        public List<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
    }
}
