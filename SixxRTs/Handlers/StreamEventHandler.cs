using System;
using SixxRTs.Helpers;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace SixxRTs.Handler
{
    class StreamEventHandler
    {
        private readonly TweetHelper _tweetHelper;

        public StreamEventHandler(TweetHelper tweetHelper)
        {
            _tweetHelper = tweetHelper;
        }

        // When stream is online, pass the appropriate parameters to TweetHelper
        public async void OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            await _tweetHelper.HandleCooldown(e.Stream.UserName, e.Stream.Title);
        }

        // When the stream is offline, try to remove the cooldown
        public void OnStreamOffline(object sender, OnStreamOfflineArgs e)
        {
            _tweetHelper.RemoveCooldown(e.Stream.UserName);
        }

        // Let the record say that the service IS on
        public void OnServiceStarted(object sender, OnServiceStartedArgs e)
        {
            Console.WriteLine("Currently monitoring all creator livestreams!");
        }
    }
}
