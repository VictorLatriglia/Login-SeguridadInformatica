using Login.Models;
using System.Security.Cryptography;
using System.Text;

namespace Login.Services
{
    public class DataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private string CalculateHash(string data)
        {
            string hash = "";
            using (SHA256 sha256 = SHA256.Create())
            {
                 hash = Convert.ToBase64String(sha256.ComputeHash(Encoding.ASCII.GetBytes(data + "qwerty")));
            }
            return hash;
        }

        public bool AddUser(UserSavedInformation user)
        {
            Console.WriteLine($"Pass: {user.Password}");
            user.Password = CalculateHash(user.Password);
            Console.WriteLine($"NewPass: {user.Password}");
            _dbContext.UserSavedInformation.Add(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CheckIfPasswordIsCorrect(string userEmail, string password)
        {
            var user = _dbContext.UserSavedInformation.FirstOrDefault(x => x.Email == userEmail);
            if (user == null)
                return false;
            Console.WriteLine($"Saved Pass: {user.Password}");
            string calculatedHash = CalculateHash(password);
            Console.WriteLine($"Calculated Pass: {calculatedHash}");
            return calculatedHash == user.Password;
        }
    }
}
