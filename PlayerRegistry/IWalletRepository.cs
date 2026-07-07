using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRegistry
{
    public interface IWalletRepository
    {
        void Add(Wallet wallet, Guid playerId);
        IEnumerable<Wallet> GetByPlayer(Guid playerId);
    }
}
