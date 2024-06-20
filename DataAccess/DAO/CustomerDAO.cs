using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        private static readonly object lockObject = new object();

        private CustomerDAO()
        {
        }

        public static CustomerDAO GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                }
            }
            return instance;
        }

        public bool Login(string username, string password)
        {
            using (var context = new FUMiniHotelManagementContext())
            {
                var customer = context.Customers.FirstOrDefault(a => a.EmailAddress == username && a.Password == password);
                if (customer != null)
                {
                    return true;
                }
                return false;
            }
        }

        public Customer GetUserByEmailAndPassword(string email, string password)
        {
            Customer? customer;
            try
            {
                var context = new FUMiniHotelManagementContext();
                customer = context.Customers.SingleOrDefault(customer => customer.EmailAddress == email && customer.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public IEnumerable<Customer> GetMembers()
        {
            IEnumerable<Customer> customers;
            try
            {
                var context = new FUMiniHotelManagementContext();
                customers = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public Customer GetMemberByEmail(string email)
        {
            Customer customer;
            try
            {
                var context = new FUMiniHotelManagementContext();
                customer = context.Customers.SingleOrDefault(customer => customer.EmailAddress == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public void Insert(Customer customer)
        {
            try
            {
                var context = new FUMiniHotelManagementContext();
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Customer customer)
        {
            try
            {
                var context = new FUMiniHotelManagementContext();
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                var context = new FUMiniHotelManagementContext();
                context.Customers.Update(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Customer> GetUsersByName(string name)
        {
            IEnumerable<Customer> customers;
            try
            {
                var context = new FUMiniHotelManagementContext();
                customers = context.Customers.Where(c => c.CustomerFullName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }
    }
}
