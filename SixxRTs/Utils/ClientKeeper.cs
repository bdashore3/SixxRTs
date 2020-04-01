using System;
using System.Threading.Tasks;
using SixxRTs.Data;
using SixxRTs.Handler;
using SixxRTs.Helpers.Security;
using Tweetinvi;
using TwitchLib.Api;
using TwitchLib.Api.Services;

namespace SixxRTs.Utils
{
  class ClientKeeper
  {
    private static LiveStreamMonitorService monitor;
    private static TwitchAPI twitchAPI;

    public static async Task Launch(string credsPath)
    {
      await CredentialsKeeper.ReadCreds(credsPath);

      SetCreds();

      Task.Run(() => BindHandlers());

      await Task.Delay(-1);
    }

    private static void SetCreds()
    {
      Auth.SetUserCredentials(
        CredentialsKeeper.C_API_K,
        CredentialsKeeper.C_API_S_K,
        CredentialsKeeper.TOKEN,
        CredentialsKeeper.TOKEN_S);
    }

    private static async Task BindHandlers()
    {
      twitchAPI = new TwitchAPI();
      twitchAPI.Settings.ClientId = CredentialsKeeper.TWITCH_CID;

      monitor = new LiveStreamMonitorService(twitchAPI, 60);

      Console.WriteLine("Starting binds");

      monitor.SetChannelsByName(UserProvider.GetTwitchUsers());
      monitor.OnStreamOnline += StreamEventHandler.OnStreamOnline;
      monitor.OnStreamOffline += StreamEventHandler.OnStreamOffline;
      monitor.OnServiceStarted += StreamEventHandler.OnServiceStarted;

      monitor.Start();

      Console.WriteLine("Binds finished");
    }
  }
}
