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
            //computers[nextSpace++] = myPC;

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
                            int read = int.Parse(Console.ReadLine());
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
                        string p = Console.ReadLine();
                        int pos = int.Parse(p);
                        Console.WriteLine(computers[pos] ?? prototype);//is null
                        break;
                    case 4://Summary of all computer statistics
                        Console.WriteLine("Average RAM of all computers: " + getAverageRam(computers, 0, totalComputers, prototype));
                        Console.WriteLine("Percent of computers that have an antenna: " + getPctAntennas(computers, 0, totalComputers, prototype));
                        Console.WriteLine("Average hard drive capacity: " + getHDCap(computers, 0, totalComputers, prototype));
                        Console.WriteLine("Average number of licenses for all computers: " + getAvgLicenses(computers, 0, totalComputers, prototype));
                        Console.WriteLine("Average number of licenses for each program: " + getAvgProgramLicenses(computers, 0, totalComputers, prototype));
                        break;
                    case 5://summary of specific indexes
                        Console.WriteLine("Enter the start index and end index (base 1) separated by the enter key.");
                        int start = int.Parse(Console.ReadLine());
                        int end = int.Parse(Console.ReadLine());
                        Console.WriteLine("Average RAM of all computers: " + getAverageRam(computers, start, end, prototype));
                        Console.WriteLine("Percent of computers that have an antenna: " + getPctAntennas(computers, start, end, prototype));
                        Console.WriteLine("Average hard drive capacity: " + getHDCap(computers, start, end, prototype));
                        Console.WriteLine("Average number of licenses for all computers: " + getAvgLicenses(computers, start, end, prototype));
                        Console.WriteLine("Average number of licenses for each program: " + getAvgProgramLicenses(computers, start, end, prototype));
                        break;
                }
                Console.WriteLine("\n");
                choice = menu();
            }
            Environment.Exit(0);//exit
        }

        public static int menu()
        {
            Console.WriteLine("Manage your computers\n1. Add a computer\n2. Save you prototype computer\n" +
                "3. View summary of a computer\n4. View stats on all computers in your system \n5. View stats on a subset of computers" +
               "\n6. Exit ");
            string c = Console.ReadLine();
            int choice = int.Parse(c);
            return choice;
        }

        public static Computer addNewComputer()
        {
            Console.WriteLine("Enter the computer ID.");
            String id = Console.ReadLine();
            Console.WriteLine("Enter true if the device has an antenna, and false it not. If this is not relevant, enter nr.");
            string a = Console.ReadLine();
            Boolean? ant;
            if (a.Equals("nr"))
            {
                ant = null;
            }
            else
            {
                ant = Boolean.Parse(a);
            }

            Console.WriteLine("Enter the hard drive capacity. If this is irrelevant, enter nr.");
            string h = Console.ReadLine();
            double? hd;
            if (h.Equals("nr"))
            {
                hd = null;
            }
            else
            {
                hd = double.Parse(h);
            }

            Console.WriteLine("Enter values(int, none or 0) for the licenses of your software, separated by the enter key.");
            int?[] licenses = new int?[5];
            for (int i = 0; i < 5; i++)
            {
                string ln = Console.ReadLine();
                if (ln.Equals("none"))
                {
                    licenses[i] = null;
                }
                else
                {
                    licenses[i] = int.Parse(ln);
                }
            }
            Console.WriteLine("Enter the size of the computer's RAM.");
            string r = Console.ReadLine();
            int ram = int.Parse(r);

            Computer pc = new Computer(id, ant, hd, licenses, ram);
            return pc;
        }

        public static double getAverageRam(Computer[] list, int start, int end, Computer prot)
        {
            double avg;
            int total = 0;
            for (int i = start; i < end; i++)
            {
                total += list[i].Ram;//TODO
            }
            avg = total / ((end - start) + 1);
            return avg;
        }


        private static double getPctAntennas(Computer[] computers, int start, int end, Computer prot)
        {
            double withAntennas = 0;
            for (int j = start; j < end; j++)
            {
                if (computers[j].HasAntenna ?? prot.HasAntenna == true)//not implicit use of Boolean
                {
                    ++withAntennas;
                }
            }
            return (withAntennas * 100) / ((end - start) + 1);//percent of total
        }

        public static double? getHDCap(Computer[] computers, int start, int end, Computer prot)
        {
            double? total = 0;
            for (int g = start; g < end; g++)
            {
                total += computers[g].DriveCapacity ?? prot.DriveCapacity;
            }
            return total / ((end - start) + 1);
        }

        public static double? getAvgLicenses(Computer[] computers, int start, int end, Computer prot)
        {
            double? total = 0;
            for (int i = start; i < end; i++)
            {
                for (int j = 0; j < computers[i].Licenses.Length; j++)
                {
                    total += computers[i].Licenses[j] ?? prot.Licenses[j];
                }
            }
            return total / ((end - start) + 1);
        }

        public static double?[] getAvgProgramLicenses(Computer[] comps, int start, int end, Computer prot)
        {
            double?[] licenses = new double?[5];
            int[] installed = new int[5];
            for (int i = start; i < end; i++)
            {
                for (int k = 0; k < comps[i].Licenses.Length; k++)
                {
                    licenses[k] += comps[i].Licenses[k] ?? prot.Licenses[k];
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

