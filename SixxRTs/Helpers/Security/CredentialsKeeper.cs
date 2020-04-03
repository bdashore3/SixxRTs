using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace SixxRTs.Helpers.Security
{
  class CredentialsKeeper
  {
    public static string ConsumerKey { get; private set; }
    public static string ConsumerSecret { get; private set; }
    public static string AuthToken { get; private set; }
    public static string AuthSecret { get; private set; }
    public static string TwitchId { get; private set; }
    public static string TwitchSecret { get; private set; }

    // This struct might show warnings about no initialized value
    // It is assigned by the JSON read operation in ReadCreds()
#pragma warning disable 0649
    private struct CredsJson
    {
      [JsonProperty("ConsumerKey")]
      public string ConsumerKey;

      [JsonProperty("ConsumerSecret")]
      public string ConsumerSecret;

      [JsonProperty("AuthToken")]
      public string AuthToken;

      [JsonProperty("AuthSecret")]
      public string AuthSecret;

      [JsonProperty("TwitchId")]
      public string TwitchId;
      [JsonProperty("TwitchSecret")]
      public string TwitchSecret;
    }
#pragma warning restore 0649

    public static async Task<bool> ReadCreds(string path)
    {
      // Read credentials as Token and DevID into a struct object from creds.json
      string info = "";
      using (FileStream fs = File.OpenRead(path))
      using (StreamReader sr = new StreamReader(fs))
        info = await sr.ReadToEndAsync();

      CredsJson creds = JsonConvert.DeserializeObject<CredsJson>(info);
      ConsumerKey = creds.ConsumerKey;
      ConsumerSecret = creds.ConsumerSecret;
      AuthToken = creds.AuthToken;
      AuthSecret = creds.AuthSecret;
      TwitchId = creds.TwitchId;
      TwitchSecret = creds.TwitchSecret;
      return true;
    }
  }
}
