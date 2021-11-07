using EnergyEndpointManager.Services.Builders;
using EnergyEndpointManager.Services.Interfaces;
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
                            InsertNewEndpoint(service);
                            break;
                        }
                    case 2:
                        {
                            EditEndpoint(service);
                            break;
                        }
                    case 3:
                        {
                            DeleteEndpoint(service);
                            break;
                        }
                    case 4:
                        {
                            ListAllEndpoints(service);
                            break;
                        }
                    case 5:
                        {
                            ListSpecificEndpoint(service);
                            break;
                        }
                    case 6:
                        {
                            PrintHeader();

                            Console.Write("Do you want to exit the application? (Y/N)  ");
                            var choice = Console.ReadLine();
                            if (choice.ToUpper() != "Y")
                            {
                                inputString = "";
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("The input is invalid.");
                            Console.ReadLine();
                            break;
                        }
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

        private static void InsertNewEndpoint(IEnergyEndpointManagerService service)
        {
            int meterModelIdInt;
            int meterNumberInt;
            int switchStateInt;

            PrintHeader();

            Console.Write("Endpoint Serial Number: ");
            var serialNumber = Console.ReadLine();

            Console.Write("Meter Model Id (16-NSX1P2W, 17-NSX1P3W, 18-NSX2P3W, 19-NSX3P4W): ");
            var meterModelId = Console.ReadLine();
            if (!int.TryParse(meterModelId, out meterModelIdInt) || meterModelIdInt < 16 || meterModelIdInt > 19)
            {
                Console.WriteLine();
                Console.WriteLine("Meter Model Id must be a number between 16 and 19");
                Console.ReadLine();
                return;
            }

            Console.Write("Meter Number: ");
            var meterNumber = Console.ReadLine();
            if (!int.TryParse(meterNumber, out meterNumberInt))
            {
                Console.WriteLine();
                Console.WriteLine("Meter Number must be a number");
                Console.ReadLine();
                return;
            }

            Console.Write("Meter Firmware Version: ");
            var meterFirmwareVersion = Console.ReadLine();

            Console.Write("Switch State (0-Disconnected, 1-Connected, 2-Armed): ");
            var switchState = Console.ReadLine();
            if (!int.TryParse(switchState, out switchStateInt) || switchStateInt < 0 || switchStateInt > 2)
            {
                Console.WriteLine();
                Console.WriteLine("Switch State must be a number between 0 and 2");
                Console.ReadLine();
                return;
            }

            var response = service.InsertEndpoint(serialNumber, meterModelIdInt, meterNumberInt, meterFirmwareVersion, switchStateInt);
            if (!response.Success)
            {
                Console.WriteLine();
                Console.WriteLine(response.Error);
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Endpoint created!");
            Console.ReadLine();
        }

        private static void EditEndpoint(IEnergyEndpointManagerService service)
        {
            PrintHeader();

            Console.Write("Endpoint Serial Number: ");
            var serialNumber = Console.ReadLine();

            var response = service.FindEndpoint(serialNumber);
            if (!response.Success)
            {
                Console.WriteLine();
                Console.WriteLine(response.Error);
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            PrintEndpoint(response.EnergyEndpoint);

            Console.Write("Switch State (0-Disconnected, 1-Connected, 2-Armed): ");
            var switchState = Console.ReadLine();
            int switchStateInt;

            if (!int.TryParse(switchState, out switchStateInt) || switchStateInt < 0 || switchStateInt > 2)
            {
                Console.WriteLine();
                Console.WriteLine("Switch State must be a number between 0 and 2");
                Console.ReadLine();
                return;
            }

            var respondeEdit = service.EditEndpoint(serialNumber, int.Parse(switchState));
            if (!respondeEdit.Success)
            {
                Console.WriteLine();
                Console.WriteLine(respondeEdit.Error);
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Endpoint updated!");
            Console.ReadLine();
        }

        private static void DeleteEndpoint(IEnergyEndpointManagerService service)
        {
            PrintHeader();

            Console.Write("Endpoint Serial Number: ");
            var serialNumber = Console.ReadLine();

            var response = service.FindEndpoint(serialNumber);
            if (!response.Success)
            {
                Console.WriteLine();
                Console.WriteLine(response.Error);
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            PrintEndpoint(response.EnergyEndpoint);

            Console.Write("Do you confirm the deletion of the endpoint? (Y/N)  ");
            var choice = Console.ReadLine();
            if (choice.ToUpper() != "Y")
            {
                Console.WriteLine();
                Console.WriteLine("Deletion cancelled!");
                Console.ReadLine();
                return;
            }

            var respondeDelete = service.DeleteEndpoint(serialNumber);
            if (!respondeDelete.Success)
            {
                Console.WriteLine();
                Console.WriteLine(respondeDelete.Error);
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Endpoint deleted!");
            Console.ReadLine();
        }

        private static void ListAllEndpoints(IEnergyEndpointManagerService service)
        {
            PrintHeader();

            var response = service.ListEndpoints();
            if (!response.Success)
            {
                Console.WriteLine();
                Console.WriteLine(response.Error);
                Console.ReadLine();
                return;
            }

            if (response.EnergyEndpoints.Count == 0)
            {
                Console.WriteLine("No endpoints registered");
                Console.ReadLine();
                return;
            }

            foreach (var endp in response.EnergyEndpoints)
            {
                PrintEndpoint(endp);
            }
            Console.ReadLine();
        }

        private static void ListSpecificEndpoint(IEnergyEndpointManagerService service)
        {
            PrintHeader();

            Console.Write("Endpoint Serial Number: ");
            var serialNumber = Console.ReadLine();
            Console.WriteLine();

            var response = service.FindEndpoint(serialNumber);
            if (!response.Success)
            {
                Console.WriteLine();
                Console.WriteLine(response.Error);
                Console.ReadLine();
                return;
            }

            PrintEndpoint(response.EnergyEndpoint);
            Console.ReadLine();
        }
    }
}