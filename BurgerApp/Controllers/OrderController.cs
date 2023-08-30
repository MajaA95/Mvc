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

            List<Order> ordersDb = StaticDb.Orders;


			List<OrderListViewModel> orderListViewModels =
				ordersDb.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();

			return View(orderListViewModels);
		}



		public IActionResult DetailsExample(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            //we need to send title that will be displayed in the header tag
            ViewData["Title"] = "Order details";
            ViewData["DateTime"] = DateTime.Now.ToShortDateString();

            //we need to map from domain model (entity from db) to view model
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);

     
            ViewBag.User = orderDb.User;


            // we want to send: user fullname, pizza name, price, payment method
            return View(orderDetailsViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                //return the GeneralError view. First look in Order folder, then in Shared folder
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "You must provide an id to view details!"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewData["Title"] = "Order details";

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "Id is invalid"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        //Create order
        //this is the method that reacts to GET request
        //returns the view with a form in which we will enter data for the new order
        public IActionResult CreateOrder()
        {
            //we have an empty object, to send it to the view
            //so we can fill data in its properties via the form in the view
            OrderViewModel orderViewModel = new OrderViewModel();

            //we have to send all existing users, so that they are shown in dropdown
            //we are sending list of viewmodels
            ViewBag.Users = StaticDb.Users.Select(x => UserMapper.ToUserDropDownViewModel(x)).ToList();

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderViewModel orderViewModel)
        {
            //create new Order with data from the model

            //in order to create order and send to the database
            //we must check the negative scenarios

            //we must check if there is a user with the given UserId in the db
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            //we must check if there is a pizza with the given name in the db
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            Order newOrder = new Order
            {
                Id = ++StaticDb.OrderId,
                IsDelivered = orderViewModel.Delivered,
                BurgerId = burgerDb.Id,
                Burger = burgerDb,
                UserId = orderViewModel.UserId,
                User = userDb,
                PaymentMethod = orderViewModel.PaymentMethod
            };
            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("GetAllOrders");
        }

        //Edit order
        //this is the action that will the return view with form for editing order
        //this action will be called when we click on an Edit link in Orders table
        public IActionResult EditOrder(int id)
        {
            Order orderForEdit = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderForEdit == null)
            {
                return View("ResourceNotFound");
            }

            ViewBag.Users = StaticDb.Users.Select(x => UserMapper.ToUserDropDownViewModel(x)).ToList();

            //we need to send viewmodel, but filled with data for edit
            OrderViewModel orderViewModel = OrderMapper.OrderToOrderViewModel(orderForEdit);

            return View(orderViewModel);
        }

        //this action will be called when we click Save on the Edit form
        [HttpPost]
        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            //1. we need to find the order for edit
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.OrderId);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            //we must check if there is a user with the given UserId in the db
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            //we must check if there is a pizza with the given name in the db
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x => x.Name == orderViewModel.BurgerName);
            if (burgerDb == null)
            {
                return View("ResourceNotFound");
            }

            //2. we need to edit the data and save it to db
            orderDb.PaymentMethod = orderViewModel.PaymentMethod;
            orderDb.IsDelivered = orderViewModel.Delivered;
            orderDb.BurgerId = burgerDb.Id;
            orderDb.Burger = burgerDb;
            orderDb.UserId = orderViewModel.UserId;
            orderDb.User = userDb;

            return RedirectToAction("GetAllOrders");
        }
    }
}