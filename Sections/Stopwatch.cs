using SimHub.Plugins;
using System;

namespace DahlDesign.Plugin.Categories
{
    /// <summary>
    /// TRIGGERED STOPWATCH
    /// </summary>
    public class Stopwatch : SectionBase
    {
        public Stopwatch(DahlDesign dahlDesign) : base(dahlDesign) { }

        //class variables
        bool watchOn = false;
        bool watchReset = false;
        TimeSpan watchTimer = new TimeSpan(0);
        bool watchStopper = false;
        bool watchSplit = false;
        TimeSpan watchSplitTime = new TimeSpan(0);
        double watchResult = 0;
        double watchSnap = 0;

        /// <summary>
        /// Class initialization, called once at game start
        /// </summary>
        /// <param name="pluginManager"></param>
        public override void Init(PluginManager pluginManager)
        {
            Base.AttachDelegate("StopWatchSplit", () => watchSplitTime);
            Base.AttachDelegate("StopWatch", () => TimeSpan.FromSeconds(watchResult));
        }

        /// <summary>
        /// Called 60 times per second by SimHub
        /// </summary>
        public override void DataUpdate()
        {
            // -- Idle clock
            if (!watchOn && watchReset)
            {
                watchTimer = Globals.globalClock;
                watchResult = 0;
            }

            // -- Clock is started
            if (watchOn)
            {
                watchReset = false;
                watchResult = Globals.globalClock.TotalSeconds - watchTimer.TotalSeconds + watchSnap;
                watchStopper = true;
            }

            //Split is captured
            if (watchOn && watchSplit)
            {
                if (watchSplitTime.TotalSeconds == 0)
                {
                    watchSplitTime = TimeSpan.FromSeconds(watchResult);
                }
                else
                {
                    watchSplitTime = TimeSpan.FromSeconds(0);
                }
                watchSplit = false;
            }

            // --Clock is stopped, begin clocking the waiting time
            if (!watchOn && !watchReset)
            {
                watchTimer = Globals.globalClock;
                if (watchStopper)
                {
                    watchSnap = watchResult;
                    watchStopper = false;
                }
            }
        }

        public void Reset()
        {
            watchTimer = Globals.globalClock;
            watchSnap = 0;
            watchReset = true;
            watchResult = 0;
            watchSplit = false;
        }

        public void ToggleWatch()
        {
            watchOn = !watchOn;
        }

        public void SetSplit()
        {
            watchSplit = true;
        }
    }
}
