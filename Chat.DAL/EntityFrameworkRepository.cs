using System.Linq;
using Chat.DAL.Entities;

namespace Chat.DAL
{
    public class EntityFrameworkRepository
    {
        public void AddToDataBase(string eMail, string username, string password, string salt, string LastName, string FirstName)
        {
            using (var _context = new ChatContext())
            {
                var user = new User();
                var img = new ProfilePhoto();

                user.Username = username;
                user.Password = password;
                user.Email = eMail;
                user.LastName = LastName;
                user.FirstName = FirstName;
                user.Salt = salt;
                user.ProfilePhotoId = null;
                _context.Users.Add(user);
                _context.SaveChanges();

                var createdUser = _context.Users.Local.FirstOrDefault(x => x.Username == username);

                img.Path = "-";
                img.UserId = createdUser.Id;
                _context.ProfilePhotos.Add(img);
                _context.SaveChanges();

                var imageId = _context.ProfilePhotos.Local.FirstOrDefault(x => x.UserId == createdUser.Id).Id;
                createdUser.ProfilePhotoId = imageId;
                _context.SaveChanges();
            }
        }

        public int FindUser(string name, string password)
        {
            using (ChatContext _context = new ChatContext())
            {
                var user = _context.Users.Where(x => x.Username == name).FirstOrDefault();
                var passProc = new PasswordProcessing();

                if (user.Password == passProc.GetHashCode(password, user.Salt))
                {
                    return user.Id;
                }
                return 0;
            }
        }

        public bool IsUserExist(string username)
        {
            using (var _context = new ChatContext())
            {
                return _context.Users.Any(x => x.Username == username);
            }
            return false;
        }
    }
}