using System;

namespace MyFitnessApp.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// geting user's age
        /// </summary>
        public int Age
        {
            get
            {
                var dateNow = DateTime.Today;
                int age = dateNow.Year - Birthday.Year;
                if (Birthday > dateNow.AddYears(-age)) age--;
                return age;
            }
        }
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

            if (birthday >= DateTime.Now)
            {
                throw new ArgumentNullException("The birthday cannot be greater than now.", nameof(birthday));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("The gender cannot be null.", nameof(gender));
            }

            if (weight <= 0)
            {
                throw new ArgumentNullException("The weight cannot be 0.", nameof(weight));
            }
            if (height <= 0)
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

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name can't be empty", nameof(name));
            Name = name;
        }

        public override string ToString()
        {
            return Name + ": " + Age;
        }
    }
}
