using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[] licenses = new int?[5];
            licenses[0] = 2;
            licenses[1] = null;
            licenses[2] = 0;
            licenses[3] = null;
            licenses[4] = null;

            Computer myPC = new Computer("SoraMalka2017", true, 1500.00, licenses, 2000);
            Computer prototype = new Computer("Prototype", false, 0, null, 0);

            Computer[] computers = new Computer[10];
            int totalComputers = 0;
            int nextSpace = 0;
            computers[nextSpace++] = myPC;
           
            int choice = menu();
            while (choice < 6 && choice > 0)
            {
                switch (choice)
                {
                    case 1://add a computer
                        Computer pc = addNewComputer();
                        computers[nextSpace++] = pc;
                        totalComputers++;
                        Console.WriteLine("Computer successfully added.");
                        break;
                    case 2://set prototype
                        Console.WriteLine("Enter true if the device has an antenna, and false it not.");
                        prototype.HasAntenna = Boolean.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the hard drive capacity.");
                        prototype.DriveCapacity = Console.Read();
                        Console.WriteLine("Enter values(-1 if the software isn't installed, or a value of 0 and up for number of licenses)" +
                            " for the licenses of your software, separated by the enter key.");
                        int?[] lics = new int?[5];
                        for (int i = 0; i < lics.Length; i++)
                        {//set 5 values of 
                            int read = Console.Read();
                            if (read < 0)
                            {
                                licenses[i] = null;
                            }
                            else
                            {
                                licenses[i] = Console.Read();
                            }
                        }

                        prototype.Licenses = lics;
                        Console.WriteLine("Enter the size of the computer's RAM.");
                        prototype.Ram = Console.Read();
                        break;
                    case 3://view specs of a specific computer by array index
                        Console.WriteLine("Enter the list number of the computer (0 based).");
                        int pos = Console.Read();
                        Console.WriteLine(computers[pos] ?? prototype);//is null
                        break;
                    case 4://Summary of all computer statistics
                        Console.WriteLine("Average RAM of all computers: " + getAverageRam(computers, 0, totalComputers));
                        Console.WriteLine("Percent of computers that have an antenna: " + getPctAntennas(computers, 0, totalComputers));
                        Console.WriteLine("Average hard drive capacity: " + getHDCap(computers, 0, totalComputers));
                        Console.WriteLine("Average number of licenses for all computers: " + getAvgLicenses(computers, 0, totalComputers));
                        Console.WriteLine("Average number of licenses for each program: " + getAvgProgramLicenses(computers, 0, totalComputers));
                        break;
                    case 5://summary of specific indexes
                        Console.WriteLine("Enter the start index and end index (0 base) separated by the enter key.");
                        int start = Console.Read();
                        int end = Console.Read();
                        Console.WriteLine("Average RAM of all computers: " + getAverageRam(computers, start, end));
                        Console.WriteLine("Percent of computers that have an antenna: " + getPctAntennas(computers, start, end));
                        Console.WriteLine("Average hard drive capacity: " + getHDCap(computers, start, end));
                        Console.WriteLine("Average number of licenses for all computers: " + getAvgLicenses(computers, start, end));
                        Console.WriteLine("Average number of licenses for each program: " + getAvgProgramLicenses(computers, start, end));
                        break;
                }
                choice = menu();
            }
            Console.ReadKey();//exit
        }

        public static int menu()
        {
            Console.WriteLine("Manage your computers\n1. Add a computer\n2. Save you prototype computer\n" +
                "3. View summary of a computer\n4. View stats on all computers in your system \n5. View stats on a subset of computers" +
               "\n6. Exit ");
            int choice = Console.Read();
            return choice;
        }

        public static Computer addNewComputer()
        {
            Console.WriteLine("Enter the computer ID.");
            String id = Console.ReadLine();
            Console.WriteLine("Enter true if the device has an antenna, and false it not.");
            Boolean ant = Boolean.Parse(Console.ReadLine());
            Console.WriteLine("Enter the hard drive capacity.");
            Double hd = Console.Read();
            Console.WriteLine("Enter values(int, null or 0) for the licenses of your software, separated by the enter key.");
            int?[] licenses = new int?[5];
            licenses[0] = Console.Read();
            licenses[1] = Console.Read();
            licenses[2] = Console.Read();
            licenses[3] = Console.Read();
            licenses[4] = Console.Read();
            Console.WriteLine("Enter the size of the computer's RAM.");
            int ram = Console.Read();

            Computer pc = new Computer(id, ant, hd, licenses, ram);
            return pc;
        }

        public static double getAverageRam(Computer[] list, int start, int end)
        {
            double avg;
            int total = 0;
            for (int i = start; i <= end; i++)
            {
                total += list[i].Ram;
            }
            avg = total / ((end - start) + 1);
            return avg;
        }


        private static double getPctAntennas(Computer[] computers, int start, int end)
        {
            double withAntennas = 0;
            for (int j = start; j <= end; j++)
            {
                if (computers[j].HasAntenna)
                {
                    ++withAntennas;
                }
            }
            return (withAntennas * 100) / ((end - start) + 1);//percent of total
        }

        public static double getHDCap(Computer[] computers, int start, int end)
        {
            double total = 0;
            for (int g = start; g <= end; g++)
            {
                total += computers[g].DriveCapacity;
            }
            return total / ((end - start) + 1);
        }

        public static double getAvgLicenses(Computer[] computers, int start, int end)
        {
            double total = 0;
            for (int i = start; i <= end; i++)
            {
                for (int j = 0; j < computers[i].Licenses.Length; j++)
                {
                    total += computers[i].Licenses[j] ?? 0;
                }
            }
            return total / ((end - start) + 1);
        }

        public static double[] getAvgProgramLicenses(Computer[] comps, int start, int end)
        {
            double[] licenses = new double[5];
            int[] installed = new int[5];
            for (int i = start; i <= end; i++)
            {
                for (int k = 0; k < comps[i].Licenses.Length; k++)
                {
                    licenses[k] += comps[i].Licenses[k] ?? 0;
                    if (comps[i].Licenses[k].HasValue)
                    {
                        installed[k]++;
                    }
                }
            }
            for (int p = 0; p < licenses.Length; p++)
            {
                licenses[p] /= installed[p];//divide programs installed by all licenses
            }
            return licenses;
        }

    }

}

