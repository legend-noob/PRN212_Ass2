using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Delete(Customer customer) => CustomerDAO.GetInstance().Delete(customer);


        public IEnumerable<Customer> GetMembers() => CustomerDAO.GetInstance().GetMembers();

        public Customer GetUserByEmailAndPassword(string email, string password) => CustomerDAO.GetInstance().GetUserByEmailAndPassword(email, password);

        public void Insert(Customer customer) => CustomerDAO.GetInstance().Insert(customer);

        public bool Login(string username, string password) => CustomerDAO.GetInstance().Login(username, password);

        public void Update(Customer customer) => CustomerDAO.GetInstance().Update(customer);

        public IEnumerable<Customer> GetUserByName(string name) => CustomerDAO.GetInstance().GetUsersByName(name);
    }
}
