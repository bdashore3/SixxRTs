using SixxRTs.Utils;

namespace SixxRTs
{
  class Program
  {
    static void Main(string[] args)
    {
      ClientKeeper.Launch(args[0]).ConfigureAwait(false).GetAwaiter().GetResult();
    }
  }
}
