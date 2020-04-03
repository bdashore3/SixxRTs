using System;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace SixxRTs.Handler
{
    class StreamEventHandler
    {
        // TODO: Use TweetHelper to tweet that the stream is live!
        public void OnStreamOnline(object sender, OnStreamOnlineArgs e)
        {
            Console.WriteLine("Got online notification!");
            Console.WriteLine("Channel: " + e.Channel);
        }

        public void OnServiceStarted(object sender, OnServiceStartedArgs e)
        {
            Console.WriteLine("Currently monitoring all creator livestreams!");
        }
    }
}
