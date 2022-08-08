using System;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService
{
    public class DataEntry
    {
        private readonly IConfiguration _config;
        private double _baseDeliveryCost;
        private List<Package> _packages;

        public DataEntry(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void Run()
        {
            //Display a user guide in inputting values
            Utility.ReadMe();

            _packages = new List<Package>();
            //package cannot be empty or zero
            int numberofPackage = 1;
            string packageId = "";
            double packageWeight = 0D;
            double distance = 0D;
            string offerCode;

            //Enter values
            _baseDeliveryCost = EvaluateInput<double>("Base Delivery Cost: ", _baseDeliveryCost);
            numberofPackage = EvaluateInput<int>("Number of Package: ", numberofPackage);

            for (int i = 1; i <= numberofPackage; i++)
            {
                Package newPackage = new Package();

                packageId = EvaluateInput<string>($"PackageID{i}: ", packageId);
                newPackage.PackageID = packageId;

                packageWeight = EvaluateInput<double>($"Weight{i}: ", packageWeight);
                newPackage.Weight = packageWeight;

                distance = EvaluateInput<double>($"Distance{i}: ", distance);
                newPackage.Distance = distance;

                Console.Write($"OfferCode{i}: ");
                offerCode = Console.ReadLine();
                newPackage.OfferCode = offerCode;

                _packages.Add(newPackage);
            }

            //Display calculation result
            DisplayOutput(_baseDeliveryCost, _packages);
        }

        //Overloading EvaluateInput method
        public string EvaluateInput(string prompt, string arg)
        {
            string value = "";
            Type type = arg.GetType();

            Console.Write(prompt);

            //record the original cursor position
            var inputCursorLeft = Console.CursorLeft;
            var inputCursorTop = Console.CursorTop;

            var input = Console.ReadLine();
            if (type == typeof(string))
            {
                while (String.IsNullOrEmpty(input) || String.Equals(input, " "))
                {
                    Utility.ClearInput(inputCursorLeft, inputCursorTop);
                    input = Console.ReadLine();
                }
            }

            value = input;
            return value;
        }

        public double EvaluateInput(string prompt, double arg)
        {
            double value = 0;
            bool valid;
            Type type = arg.GetType();

            Console.Write(prompt);

            //record the original cursor position
            var inputCursorLeft = Console.CursorLeft;
            var inputCursorTop = Console.CursorTop;

            var input = Console.ReadLine();

            if (type == typeof(double))
            {
                double dblVal = 0;
                valid = double.TryParse(input, out dblVal);
                if (dblVal <= 0)
                {
                    valid = false;
                }
                while ((!valid))
                {
                    Utility.ClearInput(inputCursorLeft, inputCursorTop);
                    valid = double.TryParse(Console.ReadLine(), out dblVal) && dblVal > 0;
                }
                value = dblVal;
            }
            return value;
        }

        public int EvaluateInput(string prompt, int arg)
        {
            int maxPackage = Convert.ToInt32(_config["MaxNumberOfPackageAlowed"]);
            int value = 0;
            bool valid;
            Type type = arg.GetType();

            Console.Write(prompt);

            //record the original cursor position
            var inputCursorLeft = Console.CursorLeft;
            var inputCursorTop = Console.CursorTop;

            var input = Console.ReadLine();

            if (type == typeof(int))
            {
                int inputVal = 0;
                valid = Int32.TryParse(input, out inputVal);
                if (inputVal <= 0 || inputVal > maxPackage)
                {
                    valid = false;
                }
                while (!valid)
                {
                    Utility.ClearInput(inputCursorLeft, inputCursorTop);
                    valid = Int32.TryParse(Console.ReadLine(), out inputVal) && Enumerable.Range(1, maxPackage).Contains(inputVal);
                }
                value = inputVal;
            }
            return value;
        }

        //Simplyfying EvaluateInput using Generics
        public T EvaluateInput<T>(string prompt, T arg)
        {
            int maxPackage = Convert.ToInt32(_config["MaxNumberOfPackageAlowed"]);
            object value = null;
            bool valid;
            Type type = arg.GetType();

            Console.Write(prompt);

            //record the original cursor position
            var inputCursorLeft = Console.CursorLeft;
            var inputCursorTop = Console.CursorTop;

            var input = Console.ReadLine();

            if (type == typeof(string))
            {
                while (String.IsNullOrEmpty(input) || String.Equals(input, " "))
                {
                    Utility.ClearInput(inputCursorLeft, inputCursorTop);
                    input = Console.ReadLine();
                }
                value = input;
            }
            else if (type == typeof(double))
            {
                double dblVal = 0;
                valid = double.TryParse(input, out dblVal);
                if (dblVal <= 0)
                {
                    valid = false;
                }
                while ((!valid))
                {
                    Utility.ClearInput(inputCursorLeft, inputCursorTop);
                    valid = double.TryParse(Console.ReadLine(), out dblVal) && dblVal > 0;
                }
                value = dblVal;
            }
            else if (type == typeof(int))
            {
                int inputVal = 0;
                valid = Int32.TryParse(input, out inputVal);
                if (inputVal <= 0 || inputVal > maxPackage)
                {
                    valid = false;
                }
                while (!valid)
                {
                    Utility.ClearInput(inputCursorLeft, inputCursorTop);
                    valid = Int32.TryParse(Console.ReadLine(), out inputVal) && Enumerable.Range(1, maxPackage).Contains(inputVal);
                }
                value = inputVal;
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public void DisplayOutput(double baseCost, List<Package> packages)
        {
            Delivery delivery = new Delivery();

            //Add some space to display output clearly
            Console.WriteLine(" ");
            Console.WriteLine("Output:");

            foreach (var item in packages)
            {
                var deliveryCost = delivery.CalculateDeliveryCost(item, baseCost);
                var discount = delivery.CalculateDiscount(deliveryCost, item);
                var totalDeliveryCost = (decimal)deliveryCost - discount;

                Console.WriteLine($"{item.PackageID} {String.Format("{0:0.00}", discount)} {String.Format("{0:0.00}", totalDeliveryCost)}");
            }
        }
    }
}
