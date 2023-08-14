using BurgerApp.Models;
using BurgerApp.Models.Enums;

namespace BurgerApp



{
    public static class StaticDb
    {
        public static List<Burger> Burgers = new List<Burger>()


       {
        new Burger()
        {
        Id = 1,
        Name = "Classic Burger",
        Price = 250,
        IsVegeterian = false,
        IsVegan = false,
        HasFries = true
        },
        new Burger()
            {
            Id = 2,
            Name = "Cheese Burger",
            Price = 300,
            IsVegeterian = false,
            IsVegan = false,
            HasFries = true
            },

		new Burger()
			{
			Id = 3,
			Name = "Vegeterian Burger",
			Price = 270,
			IsVegeterian = true,
		    IsVegan = false,
			HasFries = true
			},
		new Burger()
			{
			Id = 4,
			Name = "Vegan Burger",
			Price = 280,
			IsVegeterian = true,
		    IsVegan = true,
			HasFries = true
			}

	 };

		public static int UserId = 2;
		public static List<User> Users = new List<User>()
		{
			new User()
			{
				Id = 1,
				Name = "Bob",
				LastName = "Bobsky",
				PhoneNumber = "54623462"
			},
			new User()
			{
				Id = 2,
				Name = "Kate",
				LastName = "Katesky",
				PhoneNumber = "54677462"
			}
		};


		public static int OrderId = 2;
		public static List<Order> Orders = new List<Order>()
		{
			new Order()
			{
				Id = 1,
				UserId = 1,
				BurgerId = 1,
				User = Users.First(x => x.Id == 1),
				Burger = Burgers.First(x => x.Id == 1),
				PaymentMethod = PaymentMethod.Cash
			},
			new Order()
			{
				Id = 2,
				UserId = 2,
				BurgerId = 2,
				User = Users.First(x => x.Id == 2),
				Burger = Burgers.First(x => x.Id == 2),
				PaymentMethod = PaymentMethod.Cash
			}
		};


	}
}
