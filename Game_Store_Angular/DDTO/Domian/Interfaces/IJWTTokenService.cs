using Game_Store_Angular.DDTO.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.DDTO.Domian.Interfaces
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);

    }
}
