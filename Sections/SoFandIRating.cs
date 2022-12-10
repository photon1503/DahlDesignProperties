using System;
using System.Collections.Generic;
using SimHub.Plugins;

namespace DahlDesign.Plugin.Categories
{
    /// <summary>
    /// SoF AND IR LOSS/GAIN
    /// </summary>
    public class SofandIRating : SectionBase
    {

        public SofandIRating(DahlDesign dahlDesign) : base(dahlDesign) { }

        //class variables
        double SoF = 0;
        double IRchange = 0;

        /// <summary>
        /// Class initialization, called once at game start
        /// </summary>
        /// <param name="pluginManager"></param>
        public override void Init(PluginManager pluginManager)
        {
            // Delegates
            Base.AttachDelegate("SoF", () => SoF);
            Base.AttachDelegate("IRchange", () => IRchange);

            // Initialize variables
            Initialize();
        }

        /// <summary>
        /// Called 60 times per second by SimHub
        /// </summary>
        public override void DataUpdate()
        {
            if (GameDataAll.GameName != "IRacing")
                return;

            if (Base.counter != 8)
                return;

            List<double?> iratings = new List<double?> { };
            double weight = 1600 / Math.Log(2);
            double posCorr = (GameData.PlayerClassOpponentsCount / 2 - Globals.realPosition) / 100;

            for (int i = 0; i < GameData.Opponents.Count; i++)
            {
                if (GameData.Opponents[i].CarClass == GameData.CarClass)
                {
                    iratings.Add(GameData.Opponents[i].IRacing_IRating);
                }
                else
                {
                    iratings.Add(0);
                }
            }

            List<double> filtered = new List<double> { };
            double valueHolder = 0;

            for (int a = 0; a < iratings.Count; a++)
            {
                valueHolder = Convert.ToDouble(iratings[a]);
                if (valueHolder != 0)
                {
                    filtered.Add(valueHolder);
                }
            }

            double sum = 0;
            double IRscore = 0;

            if (filtered.Count >= GameData.PlayerClassOpponentsCount)
            {
                for (int e = 0; e < GameData.PlayerClassOpponentsCount; e++)
                {
                    sum += Math.Pow(2, -filtered[e] / 1600);
                    IRscore += (1 - Math.Exp(-Globals.myIR / weight)) * Math.Exp(-filtered[e] / weight) / ((1 - Math.Exp(-filtered[e] / weight)) * Math.Exp(-Globals.myIR / weight) + (1 - Math.Exp(-Globals.myIR / weight)) * Math.Exp(-filtered[e] / weight));
                }
            }

            if (IRscore != 0)
            {
                IRscore = IRscore - 0.5;
            }

            SoF = 0;

            if (sum != 0)
            {
                SoF = Math.Round(weight * Math.Log(GameData.PlayerClassOpponentsCount / sum));
                if (GameData.SessionTypeName == "Race" && !Globals.raceFinished && Globals.sessionState > 3)
                {
                    IRchange = Math.Round((GameData.PlayerClassOpponentsCount - Globals.realPosition - IRscore - posCorr) * 200 / GameData.PlayerClassOpponentsCount);
                }
            }
        }

        public void Initialize()
        {
            IRchange=0;
        }
    }
}
