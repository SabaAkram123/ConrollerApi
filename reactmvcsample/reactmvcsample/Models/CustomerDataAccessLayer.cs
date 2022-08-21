using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace reactmvcsample.Models

{
    public class CustomerDataAccessLayer
    {
        ONBORADING_TASK_DemoContext db = new ONBORADING_TASK_DemoContext();
        public IEnumerable<CustomerTable> GetAllCustomers()
        {
            try
            {
                return db.CustomerTables.ToList();
            }
            catch
            {
                throw;
            }
        }
        // Creating new customer record
        public int AddCustomer(CustomerTable customer)
        {
            try
            {
                db.CustomerTables.Add(customer);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        // Update Customer record  

        
        public  int UpdateCustomer(CustomerTable customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }
        // update record of customer  based on ID
        public CustomerTable UpdateCustomerData(int Id)
        {
            try
            {
               
                
                    CustomerTable customer = db.CustomerTables.Where(c => c.Id == Id).SingleOrDefault(); 
                    return customer;
                
            }
            catch
            {
                throw;
            }
        }
            //To Delete the record of a customer
            public int DeleteCustomer(int Id)
            {
                try
                {
                    CustomerTable cus = db.CustomerTables.Where(x => x.Id == Id).FirstOrDefault<CustomerTable>(); ;
                    db.CustomerTables.Remove(cus);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    throw;
                }
            }
    }
}
