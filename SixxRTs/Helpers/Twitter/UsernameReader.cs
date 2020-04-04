using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SixxRTs.Helpers
{
    public class UsernameReader
    {
        public static ConcurrentDictionary<string, string> CreatorUsernames = new ConcurrentDictionary<string, string>();
        public static async Task<bool> ReadUsernames(string path)
        {
            // Read credentials as Token and DevID into a struct object from creds.json
            string usernames = "";
            using (FileStream fs = File.OpenRead(path))
            using (StreamReader sr = new StreamReader(fs))
                usernames = await sr.ReadToEndAsync();

            CreatorUsernames = JsonConvert.DeserializeObject<ConcurrentDictionary<string, string>>(usernames);
            return true;
        }

    }
}
