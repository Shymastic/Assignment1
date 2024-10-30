using CandidateManagement_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO.DAO
{
    public class BaseDAO<T> where T : class
    {
        private readonly CandidateManagementContext context;
        private static BaseDAO<T> instance;
        public BaseDAO()
        {
            context = new();
        }
        public static BaseDAO<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new BaseDAO<T>();
                return instance;
            }
        }
    }
}
