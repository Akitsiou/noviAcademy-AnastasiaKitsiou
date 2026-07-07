using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRegistry
{
    public class InMemoryPlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players = new List<Player>();

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public Player? FindPlayer(Guid playerId)
        {
            return _players.FirstOrDefault(p => p.Id == playerId);
        }

        public void DeletePlayer(Guid playerId)
        {
            var player = _players.FirstOrDefault(p => p.Id == playerId);
            if (player != null)
            {
                _players.Remove(player);
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _players;
        }
    }
}