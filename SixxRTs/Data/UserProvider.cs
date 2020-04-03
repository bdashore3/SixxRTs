using System.Collections.Generic;

namespace SixxRTs.Data
{
    class UserProvider
    {
        // TODO: Make this auto-generate on startup from either a postgres database/JSON file
        private static List<string> twitchNames = new List<string>()
        {
            "kingbrigames",
            "regalbot1"
        };

        public static List<string> GetTwitchUsers()
        {
            return twitchNames;
        }
    }
}
