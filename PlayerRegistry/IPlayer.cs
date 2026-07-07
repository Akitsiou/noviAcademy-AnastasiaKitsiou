using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRegistry
{
    public interface IPlayer
    {
        Guid Id { get; }
        string Name { get; }
        int Score { get; }
    }
}
