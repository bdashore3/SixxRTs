﻿using System.Collections.Generic;

namespace SixxRTs.Data
{
  class UserProvider
  {
    private static List<string> twitchNames = new List<string>()
    {
      "kingbrigames",
      "AyeGooFyz"
    };

    public static List<string> GetTwitchUsers()
    {
      return twitchNames;
    }
  }
}