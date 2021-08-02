using Chat.BLL.DTO;

namespace Chat.BLL
{
    public interface IRegistrationService
    {
        RegistrationResult RegisterUser(CreateUserDTO dto);
    }
}