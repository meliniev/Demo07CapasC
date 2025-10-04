using System.Collections.Generic;
using Entity;
using Data;

namespace Business
{
    public class BCustomer
    {
        private DCustomer dCustomer = new DCustomer();

        public void Create(Customer customer) => dCustomer.Create(customer);
        public List<Customer> Read() => dCustomer.Read();
        public void Update(Customer customer) => dCustomer.Update(customer);
        public void Delete(int id) => dCustomer.Delete(id);
    }
}
