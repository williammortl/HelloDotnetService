namespace HelloDotnetService.Db
{
    using HelloDotnetService.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Static database
    /// </summary>
    public static class Database
    {

        /// <summary>
        /// The database
        /// </summary>
        private static Dictionary<int, Person> database = new Dictionary<int, Person>()
        {
            { 0, new Person
                {
                    Name = "William Mortl",
                    Address = "9th St",
                    Phone = "6305551212"
                }
            },
            { 1, new Person
                {
                    Name = "Linda Mortl",
                    Address = "Navarro St",
                    Phone = "4805551212"
                }
            },
            { 2, new Person
                {
                    Name = "Karin Linnersund",
                    Address = "Denver West Ct",
                    Phone = "3035551212"
                }
            }
        };

        /// <summary>
        /// Get a person by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>person or null</returns>
        public static Person GetPersonByID(int id)
        {
            Person retVal = null;
            if (Database.database.ContainsKey(id))
            {
                retVal = Database.database[id];
            }
            return retVal;
        }

        /// <summary>
        /// Adds a person to the db
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="person">person</param>
        public static void AddPerson(int id, Person person)
        {
            Database.database[id] = person;
        }
    }
}
