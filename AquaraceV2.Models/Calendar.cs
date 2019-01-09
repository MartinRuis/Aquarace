using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class Calendar
    {
        private int raceID;
        private string raceLocation;
        private int fastestRoundDriverId;
        private DateTime dateOfRace;

        public int RaceID { get => raceID; set => raceID = value; }
        public string RaceLocation { get => raceLocation; set => raceLocation = value; }
        public int FastestRoundDriverId { get => fastestRoundDriverId; set => fastestRoundDriverId = value; }
        public DateTime DateOfRace { get => dateOfRace; set => dateOfRace = value; }
    }
}
