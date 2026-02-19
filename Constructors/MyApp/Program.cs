using System;

namespace ConstructorExample
{
    class Car
    {
        // Fields (Data members)
        public string model;
        public int year;

        // 1. Default Constructor (No parameters)
        // This runs if you don't provide any values when creating the object.
        public Car()
        {
            model = "Unknown";
            year = 0;
            Console.WriteLine("Default Constructor called: Car created with default values.");
        }

        // 2. Parameterized Constructor
        // This allows you to assign specific values at the time of object creation.
        public Car(string modelName, int modelYear)
        {
            model = modelName; // Assigning parameter value to field
            year = modelYear;
            Console.WriteLine("Parameterized Constructor called: Car object initialized.");
        }

        // Method to display car details
        public void DisplayDetails()
        {
            Console.WriteLine($"Car Model: {model}, Year: {year}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating an object using the Default Constructor
            Car car1 = new Car();
            car1.DisplayDetails();

            Console.WriteLine("--------------------------");

            // Creating an object using the Parameterized Constructor
            // This passes "Toyota" and 2024 to the constructor immediately.
            Car car2 = new Car("Toyota Corolla", 2024);
            car2.DisplayDetails();
        }
    }
}