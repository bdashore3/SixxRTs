using System;
using System.Threading.Tasks;
using SixxRTs.Data;
using SixxRTs.Handler;
using SixxRTs.Helpers.Security;
using Tweetinvi;
using TwitchLib.Api;
using TwitchLib.Api.Services;

namespace SixxRTs
{
    class RtBot
    {
        // Variables for Dependency Injection
        private readonly StreamEventHandler _eventHandler;

        // DI constructor
        public RtBot(StreamEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        // Method to start the bot (May not be needed due to async main() method)
        public async Task Launch(string credsPath)
        {
            await CredentialsKeeper.ReadCreds(credsPath);

            SetCreds();

            StartApi();

            await Task.Delay(-1);
        }

        // Set the credentials for Twitter. TODO: Move this to CredentialsKeeper
        private static void SetCreds()
        {
            Auth.SetUserCredentials(
              CredentialsKeeper.ConsumerKey,
              CredentialsKeeper.ConsumerSecret,
              CredentialsKeeper.AuthToken,
              CredentialsKeeper.AuthSecret);
        }

        // Start the Twitch API service to monitor Livestreams
        private void StartApi()
        {
            TwitchAPI twitchAPI = new TwitchAPI();
            twitchAPI.Settings.ClientId = CredentialsKeeper.TwitchId;
            twitchAPI.Settings.AccessToken = CredentialsKeeper.TwitchSecret;

            LiveStreamMonitorService monitor = new LiveStreamMonitorService(twitchAPI, 60);

            Console.WriteLine("Starting Twitch API services");

            monitor.SetChannelsByName(UserProvider.GetTwitchUsers());
            monitor.OnStreamOnline += _eventHandler.OnStreamOnline;
            monitor.OnServiceStarted += _eventHandler.OnServiceStarted;

            monitor.Start();

            Console.WriteLine("Twitch API services started");
        }
    }
}
