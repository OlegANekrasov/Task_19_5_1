using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            var addFriendData = new AddFriendData();

            Console.Write("Почтовый адрес друга:");
            addFriendData.Email = Console.ReadLine();

            try
            {
                this.userService.AddFriend(user, addFriendData);

                SuccessMessage.Show("Друг успешно добавлен."); 
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Почтового адреса не существует.");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Неправильный формат почтового адреса.");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга.");
            }
        }
    }
}
