using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Computer
    {
        String id;

        public string ID
        {
            get
            {
                return id;
            }
            //no setter
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
        Array[] licenses;
        int ram;

    }
}
