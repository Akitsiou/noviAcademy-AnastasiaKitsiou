using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRegistry
{
    public class InMemoryWalletRepository : IWalletRepository
    {
        private readonly List<Wallet> _wallets = new List<Wallet>(); // Λίστα που κρατάει όλα τα πορτοφόλια


        public void Add(Wallet wallet, Guid playerId)
        {
            _wallets.Add(wallet);
        }

        public IEnumerable<Wallet> GetByPlayer(Guid playerId) {

            return _wallets.Where(w => w.PlayerId == playerId).ToList(); // Πρέπει να ικανοποιεί την συνθήκη 
        }
    }
}
