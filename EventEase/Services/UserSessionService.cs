namespace EventEase.Services;

public class UserSessionService
{
    private bool _isLoggedIn;
    private readonly Dictionary<string, object> _sessionData = new();

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        set => _isLoggedIn = value;
    }

    public T GetSessionData<T>(string key)
    {
        if (_sessionData.ContainsKey(key))
        {
            return (T)_sessionData[key];
        }
        return default;
    }

    public void SetSessionData<T>(string key, T value)
    {
        if (_sessionData.ContainsKey(key))
        {
            _sessionData[key] = value;
        }
        else
        {
            _sessionData.Add(key, value);
        }
    }

    public void ClearSessionData()
    {
        _sessionData.Clear();
    }
}