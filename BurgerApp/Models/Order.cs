using BurgerApp.Models.Enums;

namespace BurgerApp.Models
{
	public class Order
	{
		//ORDER PROPERTIES, MAPPERS(to get the order),VIEW MODELS(what is displayed and not what is your domain model), ORDERCONTROLLER (GETALL,DETAILS,VIEWBAG??-only transfers data from controller to view) CLASS 3
		public int Id { get; set;}
		public int UserId { get; set; }
		public int BurgerId { get; set; }
		public User User { get; set; }
		public Burger Burger { get; set;}

		public PaymentMethod PaymentMethod { get; set; }





	}
}
