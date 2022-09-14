using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace Cinema
{
    public static class Settings
    {
        public static string Secret = "asdf879sad89ifsa89df87asd@#f98asd98fas09&%asdf09as789&!@saASDFASD4h6l786j5hre5eqb4w6mj7entrbdzgndfhme6e564eh!@#$%()padsdgfhghfgdfsdlkijmnutvfcdxsdfrsteh647asrtyurjythrsgdrfssadsghytdsfgdvwfeghhsdaregsrte5h4ae5gaegARDGAERGDFgaASDA(L___HYTasdffdbdfbdbdfbfff";

        public static class Database
        {
            public static string host = "DANIEL-PC\\SQLEXPRESS";
            public static string catalog = "cinema";
            public static string username = "sa";
            public static string password = "";
            public static string SqlServer = "Data Source=" + Database.host + ";Initial Catalog=" + Database.catalog + "; user id=" + Database.username + ";password=" + Database.password + ";";
        }

    }
}
