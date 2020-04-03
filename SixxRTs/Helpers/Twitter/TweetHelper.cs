using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace SixxRTs.Helpers
{
    // TODO: Post a tweet when a creator's stream goes live (May not need to be async?)
    class TweetHelper
    {
        public void PostTweet(string message)
        {
            Tweet.PublishTweet(message);
        }

        public void StreamLive(string twitchUsername, string title) 
        {
            string twitterUsername = UsernameReader.CreatorUsernames[twitchUsername];
            Tweet.PublishTweet($"Everyone! @{twitterUsername} is now LIVE with stream title: {title}\n\nGo support at https://twitch.tv/{twitchUsername}!");
        }
    }
}
