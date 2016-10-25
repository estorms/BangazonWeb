using Bangazon.Models;
using BangazonWeb.Data;

//VIEW MODEL IS $SCOPE

namespace BangazonWeb.ViewModels
{
  //In this class (ProductDetail), we are inheriting from the BaseViewModel, which contains info that populates the user dropdown and makes it available to all derived classes.
  public class ProductDetail : BaseViewModel
  {
    public Product Product { get; set; } //this could read Product ChosenProduct (i.e., the product for which the view is rendering the detail)

    public ProductDetail(BangazonContext ctx) : base(ctx) { } //this is a custom constructor for each instance of the ProductDetail class, and we are passing in BangazonContext as an argument to BaseViewModel every time the class is instantiated

   
    }
}