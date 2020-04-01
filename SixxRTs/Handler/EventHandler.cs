using System;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace SixxRTs.Handler
{
  class StreamEventHandler
  {
    // TODO: Use TweetHelper to tweet about the stream
    public static void OnStreamOnline(object sender, OnStreamOnlineArgs e)
    {
      Console.WriteLine("Got online notification!");
      Console.WriteLine("Channel: " + e.Channel);
    }

    // TODO: Maybe use TweetHelper to thank people for joining?
    public static void OnStreamOffline(object sender, OnStreamOfflineArgs e)
    {
      Console.WriteLine("Got offline notification!");
      Console.WriteLine("Channel: " + e.Channel);
    }

    public static void OnServiceStarted(object sender, OnServiceStartedArgs e)
    {
      Console.WriteLine("Monitor Service is UP!");
    }
  }
}
