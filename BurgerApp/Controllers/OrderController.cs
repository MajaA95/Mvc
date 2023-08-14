using BurgerApp.Mappers;
using BurgerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BurgerApp.Models;
using System.Xml.Linq;


namespace BurgerApp.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult GetAllOrders()
		{
			List<Order> OrdersDb = StaticDb.Orders;

			List<OrderListViewModel> OrderListViewModels =
				OrdersDb.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();
			return View(OrderListViewModels);
		}

		public IActionResult Details (int? id)
		{
			if(id == null)
			{ 
				return RedirectToAction("Error", "Home");
			}

			Order OrderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
			if(OrderDb == null)
			{
				return RedirectToAction("Error", "Home");
			}


            //we need to send title that will be displayed in the header tag ??????????
            ViewData["Title"] = "Order details";
            ViewData["DateTime"] = DateTime.Now.ToShortDateString();

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(OrderDb);

            ViewBag.User = OrderDb.User;

            return View(orderDetailsViewModel);
        }
	}
}
