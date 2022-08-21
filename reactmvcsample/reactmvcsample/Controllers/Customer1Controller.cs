using Microsoft.AspNetCore.Mvc;
using reactmvcsample.Models;

namespace reactmvcsample.Controllers
{
    public class Customer1Controller : Controller
    {

        private ONBORADING_TASK_DemoContext db = new ONBORADING_TASK_DemoContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllCustomers()
        {
            var Customerdatalist = db.CustomerTables.ToList();

            return Json(new { success = true, data = Customerdatalist, responseText = "Successfully show all list of customers" });
        }
        [HttpPost]
        public JsonResult CreateNewCustomers(CustomerTable customer)
        {
            try
            {
                db.CustomerTables.Add(customer);
                db.SaveChanges();
                Console.Write("Successully Added");
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");

                return Json(new { data = "Failing to create new customer" });
            }
            return Json(new { success = true, data = "Success created" });

        }
        [HttpPut]
        public JsonResult UpdateCustomer(CustomerTable customer)
        {
            try
            {
                var updatecustomer= db.CustomerTables.Where(x => x.Id == customer.Id).Select(x => x).FirstOrDefault();
                updatecustomer.Name = customer.Name;
                updatecustomer.Address = customer.Address;
                db.SaveChanges();

                return Json(new { success = true, data = "updated Suceesfully" });

            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return Json(new { success = false, data = "fail to Update record" });

            }
        }

        [HttpGet]
        // update record of customer  based on ID
        public JsonResult UpdateCustomerData(int Id)
        {
            try
            {


                CustomerTable cus = db.CustomerTables.Where(c => c.Id == Id).SingleOrDefault();
                return Json(new { success = true, data = cus, responseText = "Successfully show list of customer base on ID" });

            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");

                return Json(new { success = false, data = "not found" });

            }
        }

        [HttpDelete]
        //To Delete the record of a customer
        public JsonResult DeleteCustomer(int Id)
        {
            try
            {
                CustomerTable cus1 = db.CustomerTables.Where(x => x.Id == Id).FirstOrDefault<CustomerTable>(); ;
                db.CustomerTables.Remove(cus1);
                db.SaveChanges();
                return Json(new { success = true, responseText = "Successfully Deleted" });
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");

                return Json(new { success = false,  responseText = " not Successfully Deleted" });

            }
        }
    }
}
