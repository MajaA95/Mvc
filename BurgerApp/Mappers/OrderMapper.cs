using BurgerApp.Models;
using BurgerApp.ViewModels;

namespace BurgerApp.Mappers
{
	public static class OrderMapper
	{
		public static OrderListViewModel OrderToOrderListViewModel(Order orderDb)
		{
			return new OrderListViewModel
			{
				BurgerName = orderDb.Burger.Name,
				UserFullName = $"{orderDb.User.Name} {orderDb.User.LastName}"
			};
		}

		public static OrderDetailsViewModel OrderToOrderDetailsViewModel (Order orderDb)
		{
			return new OrderDetailsViewModel
			{
				UserFullName = $"{orderDb.User.Name} {orderDb.User.LastName}",
				BurgerName = orderDb.Burger.Name,
				OrderPrice = orderDb.Burger.Price,
				PaymentMethod = orderDb.PaymentMethod.ToString()
			};
		}
	}
}
