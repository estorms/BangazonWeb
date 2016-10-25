using System.Linq;
using System.Threading.Tasks;
using BangazonWeb.Data;
using BangazonWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BangazonWeb.Controllers
{
    public class CustomerController : Controller
    {
        private BangazonContext context;
        public CustomerController(BangazonContext ctx)
        {
            context = ctx;
        }

        public ActionResult Menu() {
            MenuViewModel model = new MenuViewModel(context);

            return PartialView(model);
        }

        [HttpPost]
        //Line 24 indicates that the following code contains the logic for explicitly responding to a post SENT from the front-end 
        public IActionResult Activate([FromBody]int CustomerId)
        {
          var customer = context.Customer.SingleOrDefault(c => c.CustomerId == CustomerId);

          if (customer == null)
          {
            return NotFound();
          }

          //Line 36 sets the property of customer on the current instance of the ActiveCustomter class. So the customer in the predicate of this statement equals the active customer selected, as identified by cycling through the customer ID passed in above
          
          //INSTANCE RETURNS AN **OBJECT** IN MEMORY, RATHER THAN A PROPERTY ON THE CLASS OF ACTIVE CUSTOMER
          ActiveCustomer.instance.Customer = customer;





          string json = "{'result': 'true'}";
          return new ContentResult { Content = json, ContentType = "application/json" };
        }
    }
}
