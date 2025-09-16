﻿
namespace ArrayELearnApi.Application.Interfaces.Auth
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}
