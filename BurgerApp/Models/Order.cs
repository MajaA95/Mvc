using BurgerApp.Models.Enums;

namespace BurgerApp.Models
{
	public class Order
	{ 
	
		public int Id { get; set;}
		public int UserId { get; set; }
		public int BurgerId { get; set; }
		public User User { get; set; }
		public Burger Burger { get; set;}


		public PaymentMethod PaymentMethod { get; set; }
		public bool IsDelivered { get; set;}
	}
}
