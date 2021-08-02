using System.Runtime.Serialization.Formatters;
using Chat.BLL;
using Chat.DAL;

namespace Chat.BLL
{
    public class IdentityService : IIdentityService
    {
        public IdentityResult VerifyCredential(string username, string password)
        {
            var repository = new EntityFrameworkRepository();

            if (repository.IsUserExist(username))
            {
                int userId = repository.FindUser(username, password);
                if (userId != 0)
                {
                    return IdentityResult.Succeeded(userId);
                }
            }
            return IdentityResult.NotFound();
        }
    }
}