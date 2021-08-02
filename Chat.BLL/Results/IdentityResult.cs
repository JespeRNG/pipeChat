namespace Chat.BLL
{
    public class IdentityResult
    {
        public bool Success { get; }
        public int? UserId { get; }

        private IdentityResult(bool success, int? userId)
        {
            Success = success;
            UserId = userId;
        }

        public static IdentityResult Succeeded(int userId)
        {
            return new IdentityResult(success: true, userId: userId);
        }
        public static IdentityResult NotFound()
        {
            return new IdentityResult(success: false, userId: null);

        }
    }
}