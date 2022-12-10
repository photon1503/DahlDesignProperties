using System;
using SimHub.Plugins;

namespace DahlDesign.Plugin.Categories
{
    /// <summary>
    /// TOFF TRACK REGISTRATION
    /// </summary>
    public class OffTrack : SectionBase
    {

        public OffTrack(DahlDesign dahlDesign) : base(dahlDesign) { }

        //class variables
        bool offTrack = false;
        public TimeSpan offTrackTimer = new TimeSpan(0);

        /// <summary>
        /// Class initialization, called once at game start
        /// </summary>
        /// <param name="pluginManager"></param>
        public override void Init(PluginManager pluginManager)
        {
            Base.AttachDelegate("TrackEntry", () => offTrack);
        }

        public void Initialize()
        {
            offTrack = false;
            offTrackTimer = Globals.globalClock;
        }

        /// <summary>
        /// Called 60 times per second by SimHub
        /// </summary>
        public override void DataUpdate()
        {
            if ((GameData.SessionTypeName == "Race" || GameData.SessionTypeName == "Practice" || GameData.SessionTypeName == "Open Qualify") && Globals.sessionState > 3)
            {
                if ((Globals.trackLocation != 0 && !(GameData.IsInPit != 1 && GameData.SpeedLocal < 10) && !(Globals.awayFromPits > 2 && GameData.StintOdo < 400 && GameData.StintOdo > 20)) || ((GameData.CurrentLap == 1 || GameData.CurrentLap == 0) && GameData.StintOdo < 400 && GameData.SessionTypeName == "Race"))
                {
                    offTrackTimer = Globals.globalClock;
                }
                if (Globals.globalClock.TotalSeconds - offTrackTimer.TotalSeconds > 1 && GameData.SpeedLocal < 150)
                {
                    offTrack = true;
                }
                if (offTrack && Globals.globalClock.TotalSeconds - offTrackTimer.TotalSeconds < 1 && GameData.SpeedLocal > 50)
                {
                    offTrack = false;
                }
            }
        }
    }
}
