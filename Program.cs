using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace SQLDogs
{
    class Program
    {
        static void Main(string[] args)
        {
          var aDog = new Dog() { Id = 1, DogName = "Kalle", Birthday = "2009" };

            var db = new DBRepository("Server=40.85.84.155;Database=SKK27;User=Student27;Password=zombie-virus@2020;");
        

//List all players in the db
            Console.WriteLine("Dogs from start");
            displayDogList(db);
/*
            //Add a players and list all players in the db
            Console.WriteLine("Adding a dog");
            db.AddDog(aDog);
            displayDogList(db);
*//*
            //Change the players name and list all players in the db
            Console.WriteLine("Change dog name (but db not yet updated)");
            aDog.DogName = "Zlatan";
            displayDogList(db);
/*
            //Add update a players namn and list all players in the db
            Console.WriteLine("Updating a dog");
            db.UpdateDog(aDog);
            displayDogList(db);

            //Remove a dog and list all players in the db
            Console.WriteLine("Removing a dog");
            db.RemoveDog(aDog.RegNr);
            displayDogList(db);
*/
        }

        private static void displayDogList(DBRepository db)
        {
            foreach (var dog in db.GetDogs())
            {
                Console.WriteLine($"{dog.Id} Namn:{dog.DogName} Födelsedag:{dog.Birthday} Ras:{dog.Breed} Kön:{dog.Gender}");
            }
        }
    }

    class DBRepository
    {
        private readonly string connectionString;
        
        public DBRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Dog> GetDogs()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Dog>("SELECT Id, RegNr, DogName, Birthday, Breed, Gender, Size, ChipNr, Hair, Color, Father, Mother FROM Dogs");
            }
        }
/*
        public void AddDog(Dog dog)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO Dogs (RegNr, FirstName) values (@RegNr, @DogName)", dog);
            }
        }

        public void UpdateDog(Dog dog)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("UPDATE Dogs SET DogName = @DogName WHERE RegNr = @RegNr", dog);
            }
        }

        public void RemoveDog(int playerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("DELETE FROM Dogs WHERE RegNr = @RegNr", new { RegNr = playerId });
            }
        }*/

    }

    class Dog
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public string DogName { get; set; }
        public string Birthday { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }

        public int Size { get; set; }

        public int ChipNr { get; set; }

        public string Hair { get; set; }
        public string Color { get; set; }

        public string Father { get; set; }
        public string  Mother { get; set; }
    }
}
