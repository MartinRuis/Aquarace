using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class Group
    {
        public string Title { get; private set; }
        public bool IsPrivate { get; private set; }
        public int ID { get; private set; }

        private int _maxPlayers;
        private List<Player> _players = new List<Player>();
        private List<GuessedDriver> _guessedDrivers = new List<GuessedDriver>();

        /// <summary>
        /// When you create a new group you must set the title.
        /// By default the groups privacy is false and maximum amount of players is five.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isPrivate"></param>
        public Group(string title, bool privacy = false, int maxAmountOfPlayers = 5)
        {
            Title = title;
            IsPrivate = privacy;
            _maxPlayers = maxAmountOfPlayers;
        }

        public void SetGroupID(int id)
        {
            ID = id;
        }
        public void ChangeTitle(string title)
        {
            Title = title;
        }

        public void ChangePrivacy(bool privacy)
        {
            IsPrivate = privacy;
        }

        public int GetMaxPlayers()
        {
            return _maxPlayers;
        }

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public List<GuessedDriver> GetDrivers()
        {
            return _guessedDrivers;
        }

        public void AddOneOrMultiplePlayers(List<Player> players)
        {
            if (players.Count <= _maxPlayers)
            {
                foreach (Player player in players)
                {
                    Player existingPlayer = _players.FirstOrDefault(x => x.ID == player.ID);
                    if (existingPlayer == null)
                    {
                        _players.Add(player);
                    }
                }
            }
        }

        public void RemoveOneOrMultiplePlayers(List<Player> players)
        {
            foreach (Player player in players)
            {
                Player existingPlayer = _players.FirstOrDefault(x => x == player);
                if(existingPlayer != null) {
                    _players.Remove(existingPlayer);
                }
            }
        }


    }
}
