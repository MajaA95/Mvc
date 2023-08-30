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
				Id = orderDb.Id,
				BurgerName = orderDb.Burger.Name,
				UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
			};
		}

		public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order orderDb)
		{
			return new OrderDetailsViewModel
			{
				UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
				BurgerName = orderDb.Burger.Name, 
				OrderPrice = orderDb.Burger.Price,
				PaymentMethod = orderDb.PaymentMethod.ToString(),
				IsDelivered = orderDb.IsDelivered
			};
		}
		public static OrderViewModel OrderToOrderViewModel(Order orderDb)
		{
			return new OrderViewModel
			{
				OrderId = orderDb.Id,
				Delivered = orderDb.IsDelivered,
				PaymentMethod = orderDb.PaymentMethod,
				BurgerName = orderDb.Burger.Name,
				UserId = orderDb.UserId
			};
		}
	}
}
