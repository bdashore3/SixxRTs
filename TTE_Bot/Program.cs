using TTE_Bot.Utils;

namespace TTE_Bot
{
  class Program
  {
    static void Main(string[] args)
    {
      ClientKeeper.Launch(args[0]).ConfigureAwait(false).GetAwaiter().GetResult();
    }
  }
}
