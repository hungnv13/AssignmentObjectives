using Models;
using AssignmentObjectives.Repository;
using System.Collections.Generic;

namespace ManageHotel.Service
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepo.AddCustomer(customer);
        }

        public Customer GetCustomerByID(int id)
        {
            return _customerRepo.GetCustomerById(id);
        }

        public void DeleteCustomerByID(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepo.UpdateCustomer(customer);
        }
    }
}
