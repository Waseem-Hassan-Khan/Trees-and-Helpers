using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Abstraction;

namespace Trees.ClubMemberShipApplication.Data
{
    public class LoginUser : ILogin
    {
            public Users Login(string emailAddress, string password)
            {
                Users user = null;

                using (var dbContext = new ClubMembershipDBContext())
                {
                    user = 
                    dbContext.Users.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == 
                    emailAddress.Trim().ToLower() && u.Password.Equals(password));
                }
                return user;
            }
    }
}
