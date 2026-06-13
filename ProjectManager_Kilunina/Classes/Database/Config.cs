using Microsoft.EntityFrameworkCore;
using System;

namespace ProjectManager_Kilunina.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=localhost;uid=root;pwd=;database=ProjectManager;";

        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
