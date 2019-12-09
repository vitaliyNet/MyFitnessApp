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
        /// application user
        /// </summary>
        public User User { get; }

        /// <summary>
        /// creation of new user controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, DateTime birthday, 
                                string genderName, double height, 
                                double weight)
        {
            // TODO: checking

            var gender = new Gender(genderName);
            User = new User(userName, birthday, gender, height, weight);
        }

        /// <summary>
        /// Loading users data
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var userFormatter = new BinaryFormatter();

            using (var userFileStream = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (userFormatter.Deserialize(userFileStream) is User user)
                {
                    User = User;
                };

                // TODO: What to do if no user was read.
            }
        }

        /// <summary>
        /// storing users data
        /// </summary>
        public void Save()
        {
            var userFormatter = new BinaryFormatter();
            using (var userFile = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                userFormatter.Serialize(userFile, User);
            }
        }
    }
}
