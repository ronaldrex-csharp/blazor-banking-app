using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBankingApplication.Application.Services;
/// <summary>
/// Document Use Case: Authentication Service
/// </summary>
public class AuthService
{
    public bool IsAuthenticated { get; private set; }
    public string? Username { get; private set; }

    public event Action? OnChange;

    public bool Login(string username, string password)
    {
        if (username == "admin" && password == "password")
        {
            IsAuthenticated = true;
            Username = username;
            NotifyStateChanged();
            return true;
        }

        return false;
    }

    public void Logout()
    {
        IsAuthenticated = false;
        Username = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}