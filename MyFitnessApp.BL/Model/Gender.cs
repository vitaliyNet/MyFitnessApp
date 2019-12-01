using System;

namespace MyFitnessApp.BL.Model
{
    /// <summary>
    /// Gender.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Name of gender
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// New gender creation
        /// </summary>
        /// <param name="name">gender name</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The name cannot be empty.", nameof(name));
            }
            Name = name;
        }
        /// <summary>
        /// Getting gender name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name; 
        }
    }
}