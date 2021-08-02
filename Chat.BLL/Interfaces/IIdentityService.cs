namespace Chat.BLL
{
    public interface IIdentityService
    {
        IdentityResult VerifyCredential(string username, string password);
    }
}