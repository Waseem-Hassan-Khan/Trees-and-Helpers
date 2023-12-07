using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Abstraction
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }
    public abstract class AbstractClass
    {
        public abstract void register(string name, int age, string password, out string Message);
        public abstract void authenticate(string name, string password, out string Token, out string Message);
    }

    public class UserAuth : AbstractClass
    {
        private List<User> users = new List<User>();
        public override void authenticate(string name, string password, out string Token, out string Message)
        {
            if (name == null || password == null)
            {
                Token = "Unauthorized";
                Message = "Login failed";
            }
            else
            {
                var check = users.FirstOrDefault(u=>u.Name==name && u.Password ==password);
                if (check == null) {
                    Message = "Incorrect Name or Password";
                    Token = string.Empty;
                    return;
                }
                string genToken = $"{name}{password}";
                byte[] dataBytes = Encoding.UTF8.GetBytes(genToken);
                using (var sha256 = SHA256.Create())
                {
                    byte[] hashedData = sha256.ComputeHash(dataBytes);
                    string token = BitConverter.ToString(hashedData).Replace("-", "").ToLower();
                    Token = $"Token: {token}";
                    Message = "User Login Success";
                }
            }
        }

        public override void register(string name, int age, string password, out string Message)
        {
            if (name != null && age > 0 && password != null)
            {
                users.Add(new User { Name = name, Age = age, Password = password });
                Message = "User Registration Successfull!";
            }
            else
            {
                Message = "Registration failed";
            }
        }
    }
}
