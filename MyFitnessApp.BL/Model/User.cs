using System;

namespace MyFitnessApp.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        #region Properties
        public string Name { get; }
        public DateTime Birthday { get;  }
        public Gender Gender { get; }
        public double Height { get; set; }
        public double Weight { get; set; }
        #endregion

        /// <summary>
        /// New user creating
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthday"></param>
        /// <param name="gender"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        public User(string name,
                    DateTime birthday,
                    Gender gender,
                    double height,
                    double weight)
        {
            #region Checking condition
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The name cannot be empty.", nameof(name));
            }

            if(birthday >= DateTime.Now)
            {
                throw new ArgumentNullException("The birthday cannot be greater than now.", nameof(birthday));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("The gender cannot be null.", nameof(gender));
            }

            if(weight <= 0)
            {
                throw new ArgumentNullException("The weight cannot be 0.", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentNullException("The height cannot be 0.", nameof(height));
            }
            #endregion

            Name = name;
            Birthday = birthday;
            Gender = gender;
            Height = height;
            Weight = weight;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
