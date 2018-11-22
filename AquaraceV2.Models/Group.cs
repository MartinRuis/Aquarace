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

        private int _maxPlayers;
        private List<Player> _players = new List<Player>();
        private List<GuessedDrivers> _guessedDrivers = new List<GuessedDrivers>();

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

        public void ChangeTitle(string title)
        {
            Title = title;
        }

        public void ChangePrivacy(bool privacy)
        {
            IsPrivate = privacy;
        }

        public List<Player> GetPlayers()
        {
            return _players;
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
                        _players.Add(existingPlayer);
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
