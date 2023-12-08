using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Abstraction;

namespace Trees.ClubMemberShipApplication.Data
{
    public interface ILogin
    {
        Users Login(string emailAddress, string password);
    }
}
