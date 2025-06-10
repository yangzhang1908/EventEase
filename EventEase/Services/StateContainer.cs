using System.Collections.Concurrent;

namespace EventEase.Services;

public class StateContainer
{
    // User session management
    private ConcurrentDictionary<string, UserSession> _activeSessions = new();

    // Current user state
    private string _currentEmail = string.Empty;
    public string CurrentEmail
    {
        get => _currentEmail;
        set
        {
            _currentEmail = value;
            NotifyStateChanged();
        }
    }

    // Track if user is logged in
    public bool IsLoggedIn => !string.IsNullOrEmpty(_currentEmail);

    // Session management methods
    public void CreateSession(string email)
    {
        CurrentEmail = email;
        _activeSessions[email] = new UserSession
        {
            Email = email,
            LoginTime = DateTime.Now
        };
    }

    public bool HasActiveSession(string email)
    {
        return _activeSessions.ContainsKey(email);
    }

    public void EndSession()
    {
        if (!string.IsNullOrEmpty(CurrentEmail))
        {
            _activeSessions.TryRemove(CurrentEmail, out _);
            CurrentEmail = string.Empty;
            NotifyStateChanged();
        }
    }

    // State change notification
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();

    // User session model
    public class UserSession
    {
        public string Email { get; set; } = string.Empty;
        public DateTime LoginTime { get; set; }
        public List<string> RegisteredEvents { get; set; } = new();
    }
}
