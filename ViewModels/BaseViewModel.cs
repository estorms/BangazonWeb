using System.Collections.Generic; //need this for IEnumerable
using System.Linq; //need this for query-type language (where/when)
using Bangazon.Models; //this gives us access to our models
using BangazonWeb.Data; //this gives us access to our context (BangazonContext)
using Microsoft.AspNetCore.Mvc.Rendering; //need this to access SelectListItem (and presumably other HTML elements if/when we need to reference them)


namespace BangazonWeb.ViewModels
{
  //We are creating the ViewModels (could be "monkeybutt", CBMB) class, a custom class with a customerId, class has get/set included and SelectListItem, which populates dropdown

  //The view model allows us to pass an object to the view
  public class BaseViewModel
  //BaseViewModel class is to allow injected information to be inherited by other views, from which all other derived viewmodel classes inherit
  {
    //Here we are setting a property on our BaseViewModel class that consists of a collection of customer Id's (strongly typed as IEnumerable and only accepting SelectListItems, each of which is a key:value pair)
    public IEnumerable<SelectListItem> CustomerId { get; set; }

    //Here we are establishing that BangazonContext is a private property on the class of BaseViewModel
    private BangazonContext context;

    //Here we are establishing that singleton is a property of type ActiveCustomer on our BaseViewModel class
    private ActiveCustomer singleton = ActiveCustomer.Instance;
    public Customer ChosenCustomer 
    {
      get
      {
        // Get the current value of the customer property of our singleton
        Customer customer = singleton.Customer;

        // If no customer has been chosen yet, it's value will be null
        if (customer == null)
        {
          // Return fake customer for now
          return new Customer () {
            FirstName = "Create",
            LastName = "Account"
          };
        }

        // If there is a customer chosen, return it
        return customer;
      }
      set
      {
        if (value != null)
        {
          singleton.Customer = value;
        }
      }
    }

    //This
    public BaseViewModel(BangazonContext ctx)
    {
        context = ctx;
        this.CustomerId = context.Customer
            .OrderBy(l => l.LastName)
            .AsEnumerable()
            .Select(li => new SelectListItem { 
                Text = $"{li.FirstName} {li.LastName}",
                Value = li.CustomerId.ToString()
            });
    }
    public BaseViewModel() { }
  }
}