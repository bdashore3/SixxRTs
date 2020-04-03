using System;
using System.Collections.Generic;
using SixxRTs.Helpers;

namespace SixxRTs.Data
{
    class UserProvider
    {
        // TODO: Make this auto-generate on startup from either a postgres database/JSON file
        private static List<string> twitchNames = new List<string>(UsernameReader.CreatorUsernames.Keys);

        public static List<string> GetTwitchUsers()
        {
            return twitchNames;
        }
    }
}
