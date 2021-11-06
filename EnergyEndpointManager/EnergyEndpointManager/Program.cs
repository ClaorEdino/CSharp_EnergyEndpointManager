using EnergyEndpointManager.Services.Builders;
using System;

namespace EnergyEndpointManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = EnergyEndpointManagerServiceBuilder.Build();
            var inputString = "";

            while (inputString != "6")
            {
                PrintHeader();

                Console.WriteLine("1) Insert a new endpoint");
                Console.WriteLine("2) Edit an existing endpoint");
                Console.WriteLine("3) Delete an existing endpoint");
                Console.WriteLine("4) List all endpoints");
                Console.WriteLine("5) Find a endpoint by \"Endpoint Serial Number\"");
                Console.WriteLine("6) Exit");
                Console.WriteLine();

                int inputInt = 0;
                inputString = Console.ReadLine();

                if (!int.TryParse(inputString, out inputInt))
                {
                    Console.WriteLine("The input is invalid.");
                    Console.ReadLine();
                    continue;
                }

                switch (inputInt)
                {
                    case 1:
                        service.InsertEndpoint();
                        break;
                    case 2:
                        service.EditEndpoint();
                        break;
                    case 3:
                        service.DeleteEndpoint();
                        break;
                    case 4:
                        service.ListEndpoints();
                        break;
                    case 5:
                        service.FindEndpoint();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("The input is invalid.");
                        Console.ReadLine();
                        break;
                }
            }

            PrintHeader();
            Console.WriteLine("Goodbye!");
            Console.WriteLine();
        }

        private static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("/////////////////////////////");
            Console.WriteLine("///Energy Endpoint Manager///");
            Console.WriteLine("/////////////////////////////");
            Console.WriteLine();
        }
    }
}