using EnergyEndpointManager.Services.Builders;
using EnergyEndpointManager.Services.ViewModels;
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

                string serialNumber;
                switch (inputInt)
                {
                    case 1:
                        {
                            PrintHeader();

                            Console.Write("Endpoint Serial Number: ");
                            serialNumber = Console.ReadLine();
                            Console.Write("Meter Model Id (16-NSX1P2W, 17-NSX1P3W, 18-NSX2P3W, 19-NSX3P4W): ");
                            var meterModelId = Console.ReadLine();
                            Console.Write("Meter Number: ");
                            var meterNumber = Console.ReadLine();
                            Console.Write("Meter Firmware Version: ");
                            var meterFirmwareVersion = Console.ReadLine();
                            Console.Write("Switch State (0-Disconnected, 1-Connected, 2-Armed): ");
                            var switchState = Console.ReadLine();

                            service.InsertEndpoint(serialNumber, int.Parse(meterModelId), int.Parse(meterNumber), meterFirmwareVersion, int.Parse(switchState));

                            Console.WriteLine();
                            Console.WriteLine("Endpoint created!");
                            Console.ReadLine();

                            break;
                        }
                    case 2:
                        {
                            PrintHeader();

                            Console.Write("Endpoint Serial Number: ");
                            serialNumber = Console.ReadLine();
                            Console.Write("Switch State (0-Disconnected, 1-Connected, 2-Armed): ");
                            var switchState = Console.ReadLine();

                            service.EditEndpoint(serialNumber, int.Parse(switchState));

                            Console.WriteLine();
                            Console.WriteLine("Endpoint updated!");
                            Console.ReadLine();

                            break;
                        }
                    case 3:
                        {
                            PrintHeader();

                            Console.Write("Endpoint Serial Number: ");
                            serialNumber = Console.ReadLine();

                            service.DeleteEndpoint(serialNumber);

                            Console.WriteLine();
                            Console.WriteLine("Endpoint deleted!");
                            Console.ReadLine();

                            break;
                        }
                    case 4:
                        var endpoints = service.ListEndpoints();

                        PrintHeader();

                        if (endpoints.Count == 0)
                        {
                            Console.WriteLine("No endpoints registered");
                            Console.ReadLine();
                            break;
                        }

                        foreach(var endp in endpoints)
                        {
                            PrintEndpoint(endp);
                        }
                        Console.ReadLine();

                        break;
                    case 5:
                        {
                            PrintHeader();

                            Console.Write("Endpoint Serial Number: ");
                            serialNumber = Console.ReadLine();
                            Console.WriteLine();

                            var energyEndpoint = service.FindEndpoint(serialNumber);
                            PrintEndpoint(energyEndpoint);
                            Console.ReadLine();

                            break;
                        }
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

        private static void PrintEndpoint(EnergyEndpointViewModel viewModel)
        {
            Console.WriteLine(string.Format("{0}: {1}", "Endpoint Serial Number", viewModel.SerialNumber));
            Console.WriteLine(string.Format("{0}: {1}", "Meter Model Id", viewModel.MeterModelId));
            Console.WriteLine(string.Format("{0}: {1}", "Meter Number", viewModel.MeterNumber));
            Console.WriteLine(string.Format("{0}: {1}", "Meter Firmware Version", viewModel.MeterFirmwareVersion));
            Console.WriteLine(string.Format("{0}: {1}", "Switch State", viewModel.SwitchState));
            Console.WriteLine();
        }
    }
}