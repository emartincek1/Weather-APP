﻿namespace weather_web.Models;


public class _5DayForecast
{
    public Headline Headline { get; set; }
    public Dailyforecast[] DailyForecasts { get; set; }
}

public class Headline
{
    public DateTime EffectiveDate { get; set; }
    public int EffectiveEpochDate { get; set; }
    public int Severity { get; set; }
    public string Text { get; set; }
    public string Category { get; set; }
    public DateTime EndDate { get; set; }
    public int EndEpochDate { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}

public class Dailyforecast
{
    public DateTime Date { get; set; }
    public int EpochDate { get; set; }
    public TemperatureF Temperature { get; set; }
    public Day Day { get; set; }
    public Night Night { get; set; }
    public string[] Sources { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}

public class TemperatureF
{
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
}

public class Minimum
{
    public float Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
}

public class Maximum
{
    public float Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
}

public class Day
{
    public int Icon { get; set; }
    public string IconPhrase { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public string PrecipitationIntensity { get; set; }
}

public class Night
{
    public int Icon { get; set; }
    public string IconPhrase { get; set; }
    public bool HasPrecipitation { get; set; }
}

