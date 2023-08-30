using BurgerApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BurgerApp.ViewModels
{
	public class OrderViewModel
	{
		public int OrderId { get; set; }

		[Display(Name = "Burger Name")]
		public string BurgerName { get; set; }


		[Display(Name = "User")]
		public int UserId { get; set; }


		[Display(Name = "Payment Method")]
		public PaymentMethod PaymentMethod { get; set; }


		[Display(Name = "Is order delivered")]
		public bool Delivered { get; set; }
	}
}
