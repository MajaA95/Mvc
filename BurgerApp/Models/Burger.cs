namespace BurgerApp.Models
{
    public class Burger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsVegeterian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
    }
}
