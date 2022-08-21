using Microsoft.AspNetCore.Mvc;
using reactmvcsample.Models;

namespace reactmvcsample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();
       
        [HttpGet]
        [Route("api/Customer/Index")]
        public IEnumerable<CustomerTable> Index()
        {
            return objcustomer.GetAllCustomers();
        }
        [HttpPost]
        [Route("api/Customer/Create")]
        public int Create( CustomerTable customer)
        {
            return objcustomer.AddCustomer(customer);
        }
        [HttpGet]
        [Route("api/Customer/Details/{id}")]
        public CustomerTable Details(int id)
        {
            return objcustomer.UpdateCustomerData(id);
        }
        [HttpPut]
        [Route("api/Customer/Edit")]
        public int Edit(CustomerTable customer)
        {
            return objcustomer.UpdateCustomer(customer);
        }
        [HttpDelete]
        [Route("api/Customer/Delete/{id}")]
        public int Delete(int id)
        {
            return objcustomer.DeleteCustomer(id);
        }

    }
}
