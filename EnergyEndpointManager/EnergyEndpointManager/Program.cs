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
                            int meterModelIdInt;
                            int meterNumberInt;
                            int switchStateInt;

                            PrintHeader();

                            Console.Write("Endpoint Serial Number: ");
                            serialNumber = Console.ReadLine();

                            Console.Write("Meter Model Id (16-NSX1P2W, 17-NSX1P3W, 18-NSX2P3W, 19-NSX3P4W): ");
                            var meterModelId = Console.ReadLine();
                            if (!int.TryParse(meterModelId, out meterModelIdInt) || meterModelIdInt < 16 || meterModelIdInt > 19)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Meter Model Id must be a number between 16 and 19");
                                Console.ReadLine();
                                break;
                            }

                            Console.Write("Meter Number: ");
                            var meterNumber = Console.ReadLine();
                            if (!int.TryParse(meterNumber, out meterNumberInt))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Meter Number must be a number");
                                Console.ReadLine();
                                break;
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
                                break;
                            }

                            var response = service.InsertEndpoint(serialNumber, meterModelIdInt, meterNumberInt, meterFirmwareVersion, switchStateInt);
                            if (!response.Success)
                            {
                                Console.WriteLine();
                                Console.WriteLine(response.Error);
                                Console.ReadLine();
                                break;
                            }

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

                            var response =  service.FindEndpoint(serialNumber);
                            if (!response.Success)
                            {
                                Console.WriteLine();
                                Console.WriteLine(response.Error);
                                Console.ReadLine();
                                break;
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
                                break;
                            }

                            var respondeEdit = service.EditEndpoint(serialNumber, int.Parse(switchState));
                            if (!respondeEdit.Success)
                            {
                                Console.WriteLine();
                                Console.WriteLine(response.Error);
                                Console.ReadLine();
                                break;
                            }

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

                            var response = service.FindEndpoint(serialNumber);
                            if (!response.Success)
                            {
                                Console.WriteLine();
                                Console.WriteLine(response.Error);
                                Console.ReadLine();
                                break;
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
                                break;
                            }

                            var respondeDelete = service.DeleteEndpoint(serialNumber);
                            if (!respondeDelete.Success)
                            {
                                Console.WriteLine();
                                Console.WriteLine(response.Error);
                                Console.ReadLine();
                                break;
                            }

                            Console.WriteLine();
                            Console.WriteLine("Endpoint deleted!");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            var response = service.ListEndpoints();

                            PrintHeader();

                            if (response.EnergyEndpoints.Count == 0)
                            {
                                Console.WriteLine("No endpoints registered");
                                Console.ReadLine();
                                break;
                            }

                            foreach (var endp in response.EnergyEndpoints)
                            {
                                PrintEndpoint(endp);
                            }
                            Console.ReadLine();

                            break;
                        }
                    case 5:
                        {
                            PrintHeader();

                            Console.Write("Endpoint Serial Number: ");
                            serialNumber = Console.ReadLine();
                            Console.WriteLine();

                            var response = service.FindEndpoint(serialNumber);
                            PrintEndpoint(response.EnergyEndpoint);
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