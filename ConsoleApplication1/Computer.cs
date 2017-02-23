using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Computer
    {
        String id;

        public string ID
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }
        Boolean hasAntenna;

        public Boolean HasAntenna
        {
            get
            {
                return hasAntenna;
            }
            set
            {
                hasAntenna = value;
            }
        }
        Double driveCapacity;

        public Double DriveCapacity
        {
            get
            {
                return driveCapacity;
            }
            set
            {
                if (value >= 0)
                {
                    driveCapacity = value;
                }
            }
        }
        int?[] licenses;

        public int?[] Licenses
        {
            get
            {
                return licenses;
            }
            set
            {
                licenses = value;
            }
        }

        int ram;

        public int Ram
        {
            get
            {
                int notAvail = 0;
                if (hasAntenna)
                {
                    notAvail += 100;
                    for (int i = 0; i < licenses.Length; i++)
                    {
                        if (!(licenses[i] >= 0))
                        {
                            notAvail += 10;
                        }
                    }
                }
                else
                {
                    notAvail += 50;
                    for (int i = 0; i < licenses.Length; i++)
                    {
                        if (!(licenses[i] >= 0))
                        {
                            notAvail += 10;
                        }
                    }
                }
                return ram - notAvail;
            }
            set
            {
                if (value >= 1000)
                {
                    ram = value;
                }
            }
        }

        public Computer(String id, Boolean hasAntenna, Double driveCap, int?[] licenses, int ram)
        {
            this.id = id;
            this.hasAntenna = hasAntenna;
            this.driveCapacity = driveCap;
            this.licenses = licenses;
            this.ram = ram;
        }

        public String toString()
        {
            return ("ID: " + id + "\nHas antenna: " + hasAntenna + "\nHard drive: " + driveCapacity
                + "\nLicenses: " + licenses.ToString() + "\nRAM: " + ram);
        }
    }
}
