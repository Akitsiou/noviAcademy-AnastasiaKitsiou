using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRegistry
{
    public interface IPlayerRepository
    {
        void AddPlayer(Player player);
        Player? FindPlayer(Guid playerId);

        void DeletePlayer(Guid playerId);
        IEnumerable<Player> GetAllPlayers(); // Εμφανίζω όλους τους παίκτες
    }
}
