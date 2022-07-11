using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsView
    {
        UserService userService;
        public FriendsView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Друзья");
            var friends = userService.Friends(user);

            if (friends.Count() == 0)
            {
                Console.WriteLine("Друзей нет");
                return;
            }

            friends.ToList().ForEach(user =>
            {
                Console.WriteLine($"{user.firstname} {user.lastname} {user.email}");
            });
        }
    }
}
