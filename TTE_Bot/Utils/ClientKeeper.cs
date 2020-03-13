using System;
using System.Threading.Tasks;
using TTE_Bot.Helpers.Security;

namespace TTE_Bot.Utils
{
  class ClientKeeper
  {
    public static async Task Launch(string credsPath)
    {
      await CredentialsKeeper.ReadCreds(credsPath);

      Console.WriteLine("Ready as can be");

      await Task.Delay(-1);
    }
  }
}
