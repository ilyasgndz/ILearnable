  public static string GetEpochTime(DateTime date)
  {
      var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds).ToString(CultureInfo.InvariantCulture);
  }
