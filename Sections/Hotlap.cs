using System;
using SimHub.Plugins;

namespace DahlDesign.Plugin.Categories
{
    /// <summary>
    /// Hotlap live position
    /// </summary>
    public class HotLap : SectionBase
    {

        public HotLap(DahlDesign dahlDesign) : base(dahlDesign) { }

        //class variables
        int hotLapPosition = 0;

        /// <summary>
        /// Class initialization, called once at game start
        /// </summary>
        /// <param name="pluginManager"></param>
        public override void Init(PluginManager pluginManager)
        {
            Base.AttachDelegate("HotLapLivePosition", () => hotLapPosition);
        }

        /// <summary>
        /// Called 60 times per second by SimHub
        /// </summary>
        public override void DataUpdate()
        {
            if (Base.counter != 17)
                return;

            var estimatedLapTime = (TimeSpan)(Base.GetProp("PersistantTrackerPlugin.EstimatedLapTime")); //EstimatedLapTime

            int position = 0;
            for (int i = 0; i < GameData.Opponents.Count; i++)
            {
                if (estimatedLapTime.TotalSeconds > 0 && GameData.Opponents[i].BestLapTime.TotalSeconds > 0 && 
                    estimatedLapTime.TotalSeconds > GameData.Opponents[i].BestLapTime.TotalSeconds && 
                    GameData.Opponents[i].CarClass == GameData.CarClass && !GameData.Opponents[i].IsPlayer)
                {
                    position++;
                }

            }
            if (GameData.Opponents.Count > 1 && !(GameData.SessionTypeName == "Race" && GameData.CurrentLap == 1))
            {
                position++;
            }

            if (estimatedLapTime.TotalSeconds == 0)
            {
                position = 0;
            }

            hotLapPosition = position;
        }
    }
}
