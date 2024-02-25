namespace CVLab.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        Task<bool> AuthenticateAsync(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private bool _isAuthenticated = false;

        public bool IsAuthenticated => _isAuthenticated;

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            if (username == "admin" && password == "Admin")
            {
                _isAuthenticated = true;
            }
            return _isAuthenticated;
        }
    }
}