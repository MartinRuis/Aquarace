using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class Race
    {
        private int iD;
        private List<Driver> drivers;

        public int ID { get => iD; set => iD = value; }
        public List<Driver> Drivers { get => drivers; set => drivers = value; }
}
