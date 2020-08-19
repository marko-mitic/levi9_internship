using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarks.Tools.Auth
{
    public interface IAuthManager
    {
        string GenerateToken(String id, String role);
        (byte[], byte[]) CreatePasswordHashAndSalt(string password);
        bool VerifyPaswordHash(string password, byte[] salt, byte[] passwordHash);
    }
}
