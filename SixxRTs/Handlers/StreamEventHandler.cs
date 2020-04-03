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
        public void OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            _tweetHelper.StreamLive(e.Stream.UserName, e.Stream.Title);
        }

        // Let the record say that the service IS on
        public void OnServiceStarted(object sender, OnServiceStartedArgs e)
        {
            Console.WriteLine("Currently monitoring all creator livestreams!");
        }
    }
}
