using BusinessLogicAdapter;
using SessionInterface;

namespace Session
{
    public class SessionService : ISessionService
    {
        private readonly UserLogged? _userLogged;
        private readonly SessionLogicAdapter _sessionLogicAdapter;

        public SessionService(SessionLogicAdapter sessionLogicAdapter)
        {
            _sessionLogicAdapter = sessionLogicAdapter;
        }

        public bool AuthenticateUser(string authorizationHeader, string? id, string? queryUserId)
        {
            return _sessionLogicAdapter.IsValidToken(authorizationHeader, id, queryUserId);
        }

        public UserLogged? GetUserLogged()
        {
            return _userLogged;
        }

        public bool IsValidAuthorizationHeaderFormat(string authorizationHeader)
        {
            return !string.IsNullOrEmpty(authorizationHeader);
        }
    }
}