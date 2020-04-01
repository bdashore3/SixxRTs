using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace SixxRTs.Helpers.Security
{
  class CredentialsKeeper
  {
    public static string C_API_K { get; private set; }
    public static string C_API_S_K { get; private set; }
    public static string TOKEN { get; private set; }
    public static string TOKEN_S { get; private set; }
    public static string TWITCH_CID { get; private set; }

    // This struct might show warnings about no initialized value
    // It is assigned by the JSON read operation in ReadCreds()
#pragma warning disable 0649
    private struct CredsJson
    {
      [JsonProperty("C_API_K")]
      public string C_API_K;

      [JsonProperty("C_API_S_K")]
      public string C_API_S_K;

      [JsonProperty("Token")]
      public string TOKEN;

      [JsonProperty("Token_S")]
      public string TOKEN_S;

      [JsonProperty("Twitch_CID")]
      public string TWITCH_CID;
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
      C_API_K = creds.C_API_K;
      C_API_S_K = creds.C_API_S_K;
      TOKEN = creds.TOKEN;
      TOKEN_S = creds.TOKEN_S;
      TWITCH_CID = creds.TWITCH_CID;
      return true;
    }
  }
}
