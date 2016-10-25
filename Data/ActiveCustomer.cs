using Bangazon.Models;

namespace BangazonWeb.Data
{
	public class ActiveCustomer
	{
		// Make the class a singleton to maintain state across all uses

		//Line 10 is a property called "_instance" that internally creates an instance of its containing class (i.e., a property that creates an instance of the class to which that same property belongs)
		private static ActiveCustomer _instance;
		public static ActiveCustomer instance
		{
			get {
				// First time an instance of this class is requested
				if (_instance == null) {
					_instance = new ActiveCustomer ();
				}
				return _instance;
			}
		}

		// To track the currently active customer - selected by user
		public Customer Customer { get; set; }
//ActiveCustomer.ActiveCustomer.Customer
	}
}

