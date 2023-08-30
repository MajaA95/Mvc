using BurgerApp.Models;
using BurgerApp.ViewModels;

namespace BurgerApp.Mappers
{
    public static class UserMapper
    {
        public static UserDropDownViewModel ToUserDropDownViewModel(User userDb)
        {
            return new UserDropDownViewModel
            {
                Id = userDb.Id,
                FullName = $"{userDb.FirstName} {userDb.LastName}"
            };
        }
    }
}