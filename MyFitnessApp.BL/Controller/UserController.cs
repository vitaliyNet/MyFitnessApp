using MyFitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessApp.BL.Controller
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// application users
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; set; }
        public bool IsUserNew { get; } = false;
        /// <summary>
        /// creation of new user controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("user name can't be null", nameof(userName));
            }

            Users = GetUserData();

            CurrentUser = Users.FirstOrDefault(a => a.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsUserNew = true;
                Save();
            }
        }
        
        /// <summary>
        /// Loading list of users
        /// </summary>
        /// <returns></returns>
        private List<User> GetUserData()
        {
            var userFormatter = new BinaryFormatter();

            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && userFormatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        /// <summary>
        /// storing users data
        /// </summary>
        private void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        public void SetNewUser(string genderName, DateTime birthday, double height = 1, double weight = 1)
        {
            //TODO create data checking 

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.Birthday = birthday;
            CurrentUser.Height = height;
            CurrentUser.Weight = weight;
            Save();
        }
    }
}
