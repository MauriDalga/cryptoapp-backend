namespace SessionInterface
{
    public interface ISessionService
    {
        bool IsValidAuthorizationHeaderFormat(string authorizationHeader);

        bool AuthenticateUser(string authorizationHeader, string? id, string? queryUserId);

        UserLogged? GetUserLogged();
    }
}