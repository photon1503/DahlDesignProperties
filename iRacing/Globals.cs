using System;

static class Globals
{
    static public TimeSpan globalClock;
    static public  string aheadGlobal = "";
    static public int  realPosition = 0;
    static public string  behindGlobal = "";
    static public int myIR = 0;
    static public bool raceFinished = false;
    static public int sessionState;
    static public int trackLocation;
    static public double awayFromPits = 0;
}