using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace SixxRTs.Helpers
{
    // TODO: Post a tweet when a creator's stream goes live (May not need to be async?)
    class TweetHelper
    {
        private ConcurrentDictionary<string, long> cooldown = new ConcurrentDictionary<string, long>();

        /*
         * Handle cooldowns so that twitter doesn't post every time a streamer dis/reconnects
         * A good cooldown time to use is 2 hours since most streams last from 2-5 hours at a time.
         *
         * Store the time once the stream tweet is posted and don't update it
         */
        public void HandleCooldown(string twitchUsername, string title) 
        {
            // Cooldown may not have been removed the last time
            RemoveCooldown(twitchUsername);

            long curTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            if (!cooldown.ContainsKey(twitchUsername))
            {
                StreamLive(twitchUsername, title);
                cooldown[twitchUsername] = curTime;
            }
            else 
            {
                Console.WriteLine("A going live tweet has already been posted!");
            }
        }

        /*
         * Remove the cooldown if the existing time between the first
         * going live tweet has passed
         * 
         * This check exists because every time a user disconnects and reconnects
         * the cooldown will reset once they go live again. The check prevents this.
         */
        public void RemoveCooldown(string twitchUsername)
        {
            long curTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            long diffTime = curTime - cooldown[twitchUsername];
            if (diffTime < 5400)
            {
                Console.WriteLine("Cooldown is active! Not removing!");
                return;
            }

            cooldown.TryRemove(twitchUsername, out long value);
        }

        // Tweet that the stream is live!
        private void StreamLive(string twitchUsername, string title) 
        {
            string twitterUsername = UsernameReader.CreatorUsernames[twitchUsername];
            Tweet.PublishTweet($"Everyone! @{twitterUsername} is now LIVE with stream title: {title}\n\nGo support at https://twitch.tv/{twitchUsername}!");
        }
    }
}
