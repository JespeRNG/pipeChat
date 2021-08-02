using Chat.BLL.DTO;
using Chat.DAL;

namespace Chat.BLL
{
    public class RegistartionService : IRegistrationService
    {
        public RegistrationResult RegisterUser(CreateUserDTO dto)
        {
            var repository = new EntityFrameworkRepository();
            var password = new PasswordProcessing();

            if (!repository.IsUserExist(dto.Username))
            {
                string salt = password.GenerateSalt();
                repository.AddToDataBase(dto.Email, dto.Username, password.GetHashCode(dto.Password, salt), salt,
                    dto.LastName, dto.FirstName);
                return RegistrationResult.Succeeded();
            }
            return RegistrationResult.Failed();
        }
    }
}