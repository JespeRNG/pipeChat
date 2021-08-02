namespace Chat.BLL
{
    public class RegistrationResult
    {
        public bool Success { get; }

        private RegistrationResult(bool success)
        {
            Success = success;
        }
        public static RegistrationResult Succeeded()
        {
            return new RegistrationResult(success: true);
        }
        public static RegistrationResult Failed()
        {
            return new RegistrationResult(success: false);
        }
    }
}