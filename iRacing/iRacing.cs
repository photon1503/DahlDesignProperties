using System;
using System.Collections.Generic;
using System.Linq;
using SimHub.Plugins;
using DahlDesign.Plugin.Categories;
using IRacingReader;

namespace DahlDesign.Plugin.iRacing
{
    public class Data
    {
        private readonly DahlDesign Base;
        iRacingSpotter iRacingSpotter = new iRacingSpotter();
        iRacing.Properties p;


        #region Variables

        //CSV file adress
        string csvAdress = "";
        int csvIndex = 0;

        // iRacing variables
        TimeSpan globalClock;
        int incidents;
        int pitStall;
        bool boost;
        int MGU;
        double battery;
        int DRSState;
        double slipLF;
        double slipRF;
        double slipLR;
        double slipRR;
        double trackPosition;
        int completedLaps;
        int currentLap;
        int totalLaps;
        TimeSpan currentLapTime;
        int pit;
        int pitLimiter;
        string gear;
        double fuelAvgLap;
        int black;
        int white;
        int checkered;
        TimeSpan lastLapTime;
        string carModel;
        string track;
        string session;
        TimeSpan timeLeft;
        double pitLocation;
        double trackLength;
        double defaultRevLim;
        int pitSpeedLimit;
        int ERSlimit;
        int sessionNumber;
        string trackConfig;
        int greenFlag;
        bool TCswitch;
        bool ABSswitch;
        int ABS;
        int TC;
        int surface;
        double stintLength;
        int opponents;
        int classOpponents;
        double fuel;
        int sessionState;
        int trackLocation;
        double wingFront;
        double wingRear;
        int tape;
        float[] BestLapTimes;
        int PWS;
        double gearRatio;
        bool onJokerLap;
        int myCarIdx;
        bool furled;
        double LRShockVel;
        double RRShockVel;
        TimeSpan estimatedLapTime;
        string myClass;
        int myPosition;
        double throttle;
        double brake;
        double clutch;
        double speed;
        double rpm;
        double plannedFuel;
        double maxFuel;
        int cam;
        int pitInfo;




        // iRacing variables
        TimeSpan globalClock;
        int incidents;
        int pitStall;
        bool boost;
        int MGU;
        double battery;
        int DRSState;
        double slipLF;
        double slipRF;
        double slipLR;
        double slipRR;
        double trackPosition;
        int completedLaps;
        int currentLap;
        int totalLaps;
        TimeSpan currentLapTime;
        int pit;
        int pitLimiter;
        string gear;
        double fuelAvgLap;
        int black;
        int white;
        int checkered;
        TimeSpan lastLapTime;
        string carModel;
        string track;
        string session;
        TimeSpan timeLeft;
        double pitLocation;
        double trackLength;
        double defaultRevLim;
        int pitSpeedLimit;
        int ERSlimit;
        int sessionNumber;
        string trackConfig;
        int greenFlag;
        bool TCswitch;
        bool ABSswitch;
        int ABS;
        int TC;
        int surface;
        double stintLength;
        int opponents;
        int classOpponents;
        double fuel;
        int sessionState;
        int trackLocation;
        double wingFront;
        double wingRear;
        int tape;
        int PWS;
        double gearRatio;
        bool onJokerLap;
        int myCarIdx;
        bool furled;
        double LRShockVel;
        double RRShockVel;
        TimeSpan estimatedLapTime;
        string myClass;
        int myPosition;
        double throttle;
        double brake;
        double clutch;
        double speed;
        double rpm;
        double plannedFuel;
        double maxFuel;
        int cam;
        int pitInfo;




        //Declaring global variables

        double propAccelerationTo100KPH = 0;
        double propAccelerationTo200KPH = 0;
        int propHotLapLivePosition = 0;
        int propERSTarget = 0;
        int propERSCharges = 0;
        bool propPitEntry = false;
        bool propPitSpeeding = false;

        double[,] propLapSectorDelta = new double[7, 5] { {0,0,0,0,0},
                                                        {0,0,0,0,0},
                                                        {0,0,0,0,0},
                                                        {0,0,0,0,0},
                                                        {0,0,0,0,0},
                                                        {0,0,0,0,0},
                                                        {0,0,0,0,0}};

        string propMyClassColor = "";
        int myClassColorIndex = 0;

        double propSoF = 0;
        int DRSleft = 0;
        string propDRSpush = "";
        string propDRSpush = "";

        List<pitOpponents> pitStopOpponents = new List<pitOpponents> { };
        List<pitOpponents> finalList = new List<pitOpponents> { };

        int trackSections = 60;
        List<double> realGapOpponentDelta = new List<double> { };
        List<double> realGapOpponentRelative = new List<double> { };

        List<List<TimeSpan>> realGapPoints = new List<List<TimeSpan>> { };
        List<List<bool>> realGapLocks = new List<List<bool>> { };
        List<List<bool>> realGapChecks = new List<List<bool>> { };

        int propLapStatus = 1;
        List<double> lapDeltaCurrent = new List<double> { };
        List<double> lapDeltaLast = new List<double> { };
        List<double> lapDeltaSessionBest = new List<double> { };
        List<double> lapDeltaRecord = new List<double> { };

        List<double> lapDeltaLastChange = new List<double> { };
        List<double> lapDeltaSessionBestChange = new List<double> { };
        List<double> lapDeltaLapRecordChange = new List<double> { };
        List<double> lastChunks = new List<double> { };
        List<double> SBChunks = new List<double> { };
        List<double> LRChunks = new List<double> { };
        bool findLapRecord = true;

        int myDeltaIndexOld = -1;
        int lapDeltaSections = 120;
        int deltaChangeChunks = 20;

        bool pitMenuRequirementMet = false;
        float plannedLFPressure = 0;
        float plannedRFPressure = 0;
        float plannedLRPressure = 0;
        float plannedRRPressure = 0;

        bool propOvertakeMode = false;
        int roadOff = 0;
        bool outLap = false;
        double cutoff = 0.02;
        bool propIRIdle = true;
        bool statusReadyToFetch = false;
        bool lineCross = false;


        int currentSector = 0;
        bool sector1to2 = false;
        bool sector2to3 = false;
        bool sectorExempt = false;
        double currentSector1Time = 0;
        double currentSector2Time = 0;
        double currentSector3Time = 0;
        int currentSector1Status = 0;
        int currentSector2Status = 0;
        int propCurrentSector3Status = 0;
        int lastSectorStatusHolder = 0;
        int sector1StatusHolder = 0;
        double sector1TimeHolder = 0;
        int sector2Incidents = 0;
        int sector3Incidents = 0;
        bool currentLapTimeStarted = false;
        TimeSpan optimalLapTime = new TimeSpan(0);

        double oneThird = 1d / 3d;
        double twoThirds = 2d / 3d;

        TimeSpan propLapRecord = new TimeSpan(0);
        TimeSpan sessionBestLap = new TimeSpan(0);
        double propSessionBestSector1 = 0;
        double propSessionBestSector2 = 0;
        double propSessionBestSector3 = 0;
        double sector1Pace = 0;
        double sector2Pace = 0;
        double sector3Pace = 0;

        int propCurrentTape = 0;
        int currentPWS = 0;
        double propCurrentFrontWing = 0;
        double propCurrentRearWing = 0;

        TimeSpan lastLapHolder;
        TimeSpan lastLapChecker;
        static TimeSpan listFiller = new TimeSpan(0);
        List<TimeSpan> propLapTimeList = new List<TimeSpan> { listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller };
        List<double> propSector1TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> propSector2TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> propSector3TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };

        int lastStatusHolder = 0;
        List<int> propLapStatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> propSector1StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> propSector2StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> propSector3StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };

        List<double> propFuelTargetDeltas = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        double fuelTargetDeltaCumulative = 0;
        double fuelTargetDelta = 0;

        string classLeaderName = "";
        double? classLeaderRealGap = 0;

        string carModelHolder = "";
        string trackHolder = "";
        public string sessionHolder { get; set; } = "";
        bool propBoxApproach = false;
        List<double?> carAheadGap = new List<double?> { };
        List<double?> carAheadRaceGap = new List<double?> { };
        List<string> carAheadName = new List<string> { };
        List<bool> carAheadIsInPit = new List<bool> { };
        List<bool> carAheadIsClassLeader = new List<bool> { };
        List<string> carAheadClassColor = new List<string> { };
        List<int> carAheadClassDifference = new List<int> { };
        List<int> carAheadPosition = new List<int> { };
        List<bool> carAheadIsAhead = new List<bool> { };
        List<string> carAheadLicence = new List<string> { };
        List<long> carAheadiRating = new List<long> { };
        List<TimeSpan> carAheadBestLap = new List<TimeSpan> { };
        List<long> carAheadJokerLaps = new List<long> { };
        List<int> carAheadLapsSincePit = new List<int> { };
        List<int> carAheadP2PCount = new List<int> { };
        List<bool> carAheadP2PStatus = new List<bool> { };
        List<double?> carAheadRealGap = new List<double?> { };
        List<double?> carAheadRealRelative = new List<double?> { };

        string aheadGlobal = "";

        List<double?> carBehindGap = new List<double?> { };
        List<double?> carBehindRaceGap = new List<double?> { };
        List<string> carBehindName = new List<string> { };
        List<bool> carBehindIsInPit = new List<bool> { };
        List<bool> carBehindIsClassLeader = new List<bool> { };
        List<string> carBehindClassColor = new List<string> { };
        List<int> carBehindClassDifference = new List<int> { };
        List<int> carBehindPosition = new List<int> { };
        List<bool> carBehindIsAhead = new List<bool> { };
        List<string> carBehindLicence = new List<string> { };
        List<long> carBehindiRating = new List<long> { };
        List<TimeSpan> carBehindBestLap = new List<TimeSpan> { };
        List<long> carBehindJokerLaps = new List<long> { };
        List<int> carBehindLapsSincePit = new List<int> { };
        List<int> carBehindP2PCount = new List<int> { };
        List<bool> carBehindP2PStatus = new List<bool> { };
        List<double?> carBehindRealGap = new List<double?> { };
        List<double?> carBehindRealRelative = new List<double?> { };

        string behindGlobal = "";

        List<int> sessionCarsLap = new List<int> { };
        List<int> sessionCarsLapsSincePit = new List<int> { };

        double propPitBox = 0;
        double awayFromPits = 0;
        bool hasPitted = false;
        bool hasApproached = false;

        int propValidStintLaps = 0;
        int propInvalidStintLaps = 0;
        TimeSpan stintTimer = new TimeSpan(0);
        TimeSpan pushTimer = new TimeSpan(0);
        TimeSpan stintTimeTotal = new TimeSpan(0);
        int stintLapsTotal = 0;
        bool stintLapsCheck = false;

        int qualyPosition = 0;
        bool propRaceFinished = false;

        double? aheadGap = 0;
        string aheadClass = "";
        int aheadClassPosition = 0;

        int propRealPosition = 0;
        int propHotLapPosition = 0;
        bool isRaceLeader = false;
        List<string> finishedCars = new List<string> { };

        double myExpectedLapTime = 0;
        double? leaderDecimal = 0;
        double? lapLapsRemaining = 0;
        double? timeLapsRemaining = 0;
        bool lapRaceFinished = false;
        bool timeRaceFinished = false;
        bool timedOut = false;
        bool timeBasedChecker = false;
        int? timeLapCounter = 0;
        bool propWarmup = false;
        int propQLap1Status = 0;
        int propQLap2Status = 0;
        TimeSpan qLap1Time = new TimeSpan(0);
        TimeSpan qLap2Time = new TimeSpan(0);
        bool qLapStarted2 = false;

        bool isLapLimited = false;
        bool isTimeLimited = false;

        double pace = 0;
        double? remainingLaps = 0;

        int myIR = 0;
        double propIRchange = 0;

        bool propJokerThisLap = false;
        int propJokerLapCount = 0;
        bool jokerLapChecker = false;

        //Track parameters
        public int propTrackType = 0; //Track type: 0 = Road, 1-3 = RX, 4 = Dirt road w/o joker, 5 = Dirt Oval, 6 = Short oval, 7 = oval, 8 = super speedway
        bool hasExempt = false;
        double exemptOne = 0;
        double exemptOneMargin = 0;
        double exemptTwo = 0;
        double exemptTwoMargin = 0;
        bool hasCutOff = false;
        double cutoffValue = 0;
        double pitStopBase = 0;
        double pitStopMaxSpeed = 0;
        double pitStopCornerSpeed = 0;
        double pitStopBrakeDistance = 0;
        double pitStopAcceleration = 0;
        bool trackHasAnimatedCrew = false;
        string pitFastSide = "Right";

        //Car parameters
        string carId = "";
        bool propHasAntiStall = false;
        bool propHasDRS = false;
        bool hasTCtog = false;
        bool hasTCtimer = false;
        int TCoffPosition = -1;
        bool propHasABS = false;
        bool propABStoggle = false;
        bool hasTC = false;
        bool hasABStog = false;
        int ABSoffPosition = -1;
        int propMapHigh = -1;
        int propMapLow = -1;
        bool hasNoBoost = false;
        bool propHasOvertake = false;
        string propRotaryType = "Single";
        string propDashType = "Default";
        int propShiftPoint1 = 0;
        int propShiftPoint2 = 0;
        int propShiftPoint3 = 0;
        int propShiftPoint4 = 0;
        int propShiftPoint5 = 0;
        int propShiftPoint6 = 0;
        int propShiftPoint7 = 0;
        int propCurrentShiftPoint = 0;
        double shiftPointAdjustment = 0;
        double propShiftLightRPM = 0;
        int propLastShiftPoint = 0;
        double propRevLim = 0;
        int propIdleRPM = 0;
        double propClutchBitePoint = 0;
        double propClutchSpin = 0;
        double propClutchIdealRangeStart = 0;
        double propClutchIdealRangeStop = 0;
        double propClutchGearRelease = 0;
        double propClutchTimeRelease = 0;
        double propClutchGearReleased = 0;
        double propClutchTimeReleased = 0;
        bool propHighPower = false;
        double propLaunchThrottle = 0;
        double pitMaxSpeed = 0;
        double pitCornerSpeed = 0;
        double pitBrakeDistance = 0;
        double pitAcceleration = 0;
        double pitFuelFillRate = 0;
        bool carHasAnimatedCrew = false;
        double pitAniBaseTime = 0;
        double pitAniSlowAdd = 0;
        double pitBaseTime = 0;
        double pitSlowAdd = 0;
        CrewType pitCrewType = CrewType.SingleTyre;
        bool pitMultitask = false;
        bool pitHasWindscreen = false;
        AnimationType propAnimationType = AnimationType.Analog;
        double revSpeed = 1;

        int ERSlapCounter = 0;
        int ERSreturnMode = 0;
        bool ERSstartingLap = false;
        int ERSChangeCount = 0;
        int W12ERSRef = 0;


        double pitStopDuration = 0;
        bool propLFTog = false;
        bool propRFTog = false;
        bool propLRTog = false;
        bool propRRTog = false;
        bool propfuelTog = false;
        bool propWSTog = false;
        bool propRepairTog = false;

        bool sessionScreen = false;
        bool scenicActive = false;
        bool camToolActive = false;
        bool UIHidden = false;
        bool useAutoShotSelection = false;
        bool useTemporaryEdits = false;
        bool useKeyAcceleration = false;
        bool useKey10xAcceleration = false;
        bool useMouseAimMode = false;

        bool savePitTimerLock = false;
        TimeSpan savePitTimerSnap = new TimeSpan(0);
        TimeSpan slowestLapTimeSpanCopy = new TimeSpan(0);
        double minFuelPush = 0;
        double maxFuelPush = 0;
        double propFuelPerLapOffset = 0;
        bool onlyThrough = true;

        bool fuelTargetCheck = false;
        double oldFuelValue = 0;
        double commandMinFuel = 0;
        double commandMaxFuel = 500;

        double minimumCornerSpeed = 0;
        double straightLineSpeed = 0;
        double highestThrottle = 0;
        bool throttleLift = false;

        string propSmoothGear = "";
        int neutralCounter = 0;

        //Buttons
        int pitMenuRotary = 12; //Starting on strat page
        int inCarRotary = 0;

        bool TCactive = false;
        bool propTCactive = false;
        bool propTCtoggle = false;
        double TCOffTimer = 0;
        TimeSpan propTCOffTimer = new TimeSpan(0);
        bool TCLimiter = false;
        TimeSpan TCtimer = new TimeSpan(0);


        bool propP2pActive = false;
        int propP2pCounter = -1;
        int myTireCompound = -1;
        int myDRSCount = -1;

        bool propRadio = false;
        string propRadioName = "";
        int propRadioPosition;
        bool propRadioIsSpectator;

        bool NBpressed = false;
        bool NBactive = false;
        bool NBspeedLim = false;
        bool propNBvalue = false;

        bool plusButtonCheck = false;
        bool minusButtonCheck = false;
        bool OKButtonCheck = false;
        bool upshift = false;
        bool downshift = false;
        bool launchPressed = false;
        bool launchReleased = false;
        bool propLaunchActive = false;
        bool propPaceCheck = false;
        bool pacePressed = false;
        bool paceReleased = false;
        bool pitPressed = false;
        bool pitReleased = false;
        bool propPitScreenEnable = false;
        bool bitePointPressed = false;
        bool bitePointReleased = false;
        bool propBitePointAdjust = false;
        bool propLEDwarningActive = false;
        bool propSpotMode = false;

        TimeSpan stopWatch = new TimeSpan(0);
        bool accelerationStart = false;
        int accelerationPremature = 0;
        bool oneHundered = false;
        bool twoHundered = false;
        TimeSpan reactionTime = new TimeSpan(0);
        string reactionGear = "";
        double propReactionPush = 0;

        TimeSpan offTrackTimer = new TimeSpan(0);
        bool propOffTrack = false;

        double TCrpm = 0;
        double TCthrottle = 0;
        bool TCon = false;
        int TCduration = 0;
        string TCgear = "";
        int TCgearCD = 0;
        int propTCreleaseCD = 0;
        int TCdropCD = 0;
        double TCPushTimer = 0;
        int tcBumpCounter = 0;
        bool tcBump = false;
        int[] roadTextures = { 1, 2, 9, 11, 12 };

        int brakeClock = 0;
        int brakeClockBase = 0;
        List<double> brakeCurve = new List<double> { };
        bool brakeTrigger = false;
        bool brakeTriggerCheck = false;
        double propBrakeMax = 0;
        double propBrakeCurveAUC = 0;
        string propBrakeCurveValues = String.Empty;
        double propThrottleAgro = 0;
        string propThrottleCurveValues = String.Empty;


        int throttleClock = 0;
        int throttleClockBase = 0;
        List<double> throttleCurve = new List<double> { };
        bool throttleTrigger = false;
        bool throttleTriggerCheck = false;

        double propSlipLF = 0;
        double propSlipRF = 0;
        double propSlipLR = 0;
        double propSlipRR = 0;


        bool watchOn = false;
        bool watchReset = false;
        bool watchStopper = false;
        bool watchSplit = false;
        TimeSpan watchSplitTime = new TimeSpan(0);
        TimeSpan watchTimer = new TimeSpan(0);
        double watchResult = 0;
        double watchSnap = 0;

        double RPMtracker = 0;
        bool RPMgearShift = false;
        double propRPMlastGear = 0;
        string propRPMgear = "";

        List<string> classColors = new List<string> { "0xffda59", "0x33ceff", "0xff5888", "0xae6bff", "0x53ff77" };
        //1: light yellow
        //2: vivid cyan
        //3: light pink
        //4: very light violet
        //5: light lime green


        TrackInfo trackInfoClass = new TrackInfo();
        List<Tracks> trackInfo;

        CarInfo carInfoClass = new CarInfo();
        List<Cars> carInfo;

        DataSampleEx irData;
        #endregion

        public Data(DahlDesign dahlDesign)
        {
            Base = dahlDesign;

            p = new iRacing.Properties(Base);

            //Find the lap records file
            LapRecords.findCSV(ref csvAdress);

            carInfo = carInfoClass.carInfo;
            trackInfo = trackInfoClass.trackInfo;


            #region lists


            for (int u = 0; u < trackSections; u++)
            {
                List<bool> locks = new List<bool> { };
                List<bool> checks = new List<bool> { };
                List<TimeSpan> points = new List<TimeSpan> { };

                for (int i = 0; i < 64; i++)
                {
                    locks.Add(false);
                    checks.Add(false);
                    points.Add(TimeSpan.FromSeconds(0));
                }

                realGapLocks.Add(locks);
                realGapChecks.Add(checks);
                realGapPoints.Add(points);
            }

            for (int i = 0; i < 64; i++)
            {
                realGapOpponentDelta.Add(0);
                realGapOpponentRelative.Add(0);
                sessionCarsLapsSincePit.Add(-1);
                sessionCarsLap.Add(-1);
            }

            for (int i = 0; i < lapDeltaSections + 1; i++)
            {
                lapDeltaCurrent.Add(-1);
                lapDeltaSessionBest.Add(-1);
                lapDeltaLast.Add(-1);
                lapDeltaRecord.Add(-1);
                lapDeltaLastChange.Add(0);
                lapDeltaSessionBestChange.Add(0);
                lapDeltaLapRecordChange.Add(0);
            }

            for (int i = 0; i < deltaChangeChunks; i++)
            {
                lastChunks.Add(0);
                SBChunks.Add(0);
                LRChunks.Add(0);
            }
            #endregion
            #region SimHub Properties

            Base.AttachDelegate("TestProperty", () => propTCreleaseCD != 0);
            Base.AttachDelegate("Position", () => propRealPosition);
            Base.AttachDelegate("HotLapPosition", () => propHotLapPosition);
            Base.AttachDelegate("RaceFinished", () => propRaceFinished);
            Base.AttachDelegate("SoF", () => propSoF);
            Base.AttachDelegate("IRchange", () => propIRchange);
            Base.AttachDelegate("MyClassColor", () => propMyClassColor);
            Base.AttachDelegate("CenterDashType", () => propDashType);
            Base.AttachDelegate("MenuType", () => propRotaryType);
            Base.AttachDelegate("OptimalShiftGear1", () => propShiftPoint1);
            Base.AttachDelegate("OptimalShiftGear2", () => propShiftPoint2);
            Base.AttachDelegate("OptimalShiftGear3", () => propShiftPoint3);
            Base.AttachDelegate("OptimalShiftGear4", () => propShiftPoint4);
            Base.AttachDelegate("OptimalShiftGear5", () => propShiftPoint5);
            Base.AttachDelegate("OptimalShiftGear6", () => propShiftPoint6);
            Base.AttachDelegate("OptimalShiftGear7", () => propShiftPoint7);
            Base.AttachDelegate("OptimalShiftCurrentGear", () => propCurrentShiftPoint);
            Base.AttachDelegate("OptimalShiftLastGear", () => propLastShiftPoint);
            Base.AttachDelegate("TrueRevLimiter", () => propRevLim);
            Base.AttachDelegate("IdleRPM", () => propIdleRPM);

            Base.AttachDelegate("Lap01Time", () => propLapTimeList[0]);
            Base.AttachDelegate("Lap02Time", () => propLapTimeList[1]);
            Base.AttachDelegate("Lap03Time", () => propLapTimeList[2]);
            Base.AttachDelegate("Lap04Time", () => propLapTimeList[3]);
            Base.AttachDelegate("Lap05Time", () => propLapTimeList[4]);
            Base.AttachDelegate("Lap06Time", () => propLapTimeList[5]);
            Base.AttachDelegate("Lap07Time", () => propLapTimeList[6]);
            Base.AttachDelegate("Lap08Time", () => propLapTimeList[7]);
            Base.AttachDelegate("Lap01Status", () => propLapStatusList[0]);
            Base.AttachDelegate("Lap02Status", () => propLapStatusList[1]);
            Base.AttachDelegate("Lap03Status", () => propLapStatusList[2]);
            Base.AttachDelegate("Lap04Status", () => propLapStatusList[3]);
            Base.AttachDelegate("Lap05Status", () => propLapStatusList[4]);
            Base.AttachDelegate("Lap06Status", () => propLapStatusList[5]);
            Base.AttachDelegate("Lap07Status", () => propLapStatusList[6]);
            Base.AttachDelegate("Lap08Status", () => propLapStatusList[7]);
            Base.AddProp("Lap01Delta", 0);
            Base.AddProp("Lap02Delta", 0);
            Base.AddProp("Lap03Delta", 0);
            Base.AddProp("Lap04Delta", 0);
            Base.AddProp("Lap05Delta", 0);
            Base.AddProp("Lap06Delta", 0);
            Base.AddProp("Lap07Delta", 0);
            Base.AddProp("Lap08Delta", 0);

            Base.AttachDelegate("SmallFuelIncrement", () => Base.Settings.SmallFuelIncrement);
            Base.AttachDelegate("LargeFuelIncrement", () => Base.Settings.LargeFuelIncrement);
            Base.AttachDelegate("CoupleInCarToPit", () => Base.Settings.CoupleInCarToPit);
            Base.AttachDelegate("Idle", () => propIRIdle);
            Base.AttachDelegate("SmoothGear", () => propSmoothGear);
            Base.AttachDelegate("TrackEntry", () => propOffTrack);
            Base.AttachDelegate("LastGearMaxRPM", () => propRPMlastGear);
            Base.AttachDelegate("LastGear", () => propRPMgear);
            Base.AttachDelegate("OvertakeMode", () => propOvertakeMode);
            Base.AttachDelegate("StopWatch", () => watchReset);
            Base.AttachDelegate("StopWatchSplit", () => watchSplitTime);
            Base.AttachDelegate("AccelerationTo100KPH", () => propAccelerationTo100KPH);
            Base.AttachDelegate("AccelerationTo200KPH", () => propAccelerationTo200KPH);
            Base.AttachDelegate("ERSTarget", () => propERSTarget);
            Base.AttachDelegate("ERSCharges", () => propERSCharges);
            Base.AttachDelegate("HasTC", () => hasTCtimer || hasTCtog || hasTC);
            Base.AttachDelegate("HasABS", () => propHasABS);
            Base.AttachDelegate("HasDRS", () => propHasDRS);
            Base.AttachDelegate("DRSState", () => propDRSpush);
            Base.AttachDelegate("HasAntiStall", () => propHasAntiStall);
            Base.AttachDelegate("HasOvertake", () => propHasOvertake);
            Base.AttachDelegate("MapHigh", () => propMapHigh);
            Base.AttachDelegate("MapLow", () => propMapLow);
            Base.AttachDelegate("P2PCount", () => propP2pCounter);
            Base.AttachDelegate("P2PStatus", () => propP2pActive);
            Base.AttachDelegate("AnimationType", () => propAnimationType);
            Base.AttachDelegate("ShiftLightRPM", () => propShiftLightRPM);
            Base.AttachDelegate("ReactionTime", () => Math.Round(propReactionPush));
            Base.AttachDelegate("LEDWarnings", () => propLEDwarningActive);
            Base.AttachDelegate("LaunchBitePoint", () => propClutchBitePoint);
            Base.AttachDelegate("LaunchSpin", () => propClutchSpin);
            Base.AttachDelegate("LaunchIdealRangeStart", () => propClutchIdealRangeStart);
            Base.AttachDelegate("LaunchIdealRangeStop", () => propClutchIdealRangeStop);
            Base.AttachDelegate("LaunchGearRelease", () => propClutchGearRelease);
            Base.AttachDelegate("LaunchGearReleased", () => propClutchGearReleased);
            Base.AttachDelegate("LaunchTimeRelease", () => propClutchTimeRelease);
            Base.AttachDelegate("LaunchTimeReleased", () => propClutchTimeReleased);
            Base.AttachDelegate("HighPower", () => propHighPower);
            Base.AttachDelegate("LaunchThrottle", () => propLaunchThrottle);

            Base.AttachDelegate("TCActive", () => propTCactive);
            Base.AttachDelegate("TCToggle", () => propTCtoggle);
            Base.AttachDelegate("ABSToggle", () => propABStoggle);
            Base.AddProp("DRSCount", -1);

            Base.AttachDelegate("BrakeCurveValues", () => propBrakeCurveValues);
            Base.AttachDelegate("BrakeCurvePeak", () => propBrakeMax);
            Base.AttachDelegate("BrakeCurveAUC", () => propBrakeCurveAUC);
            Base.AttachDelegate("ThrottleCurveValues", () => propThrottleCurveValues);
            Base.AttachDelegate("ThrottleAgro", () => propThrottleAgro);

            Base.AttachDelegate("SlipLF", () => propSlipLF);
            Base.AttachDelegate("SlipRF", () => propSlipRF);
            Base.AttachDelegate("SlipLR", () => propSlipLR);
            Base.AttachDelegate("SlipRR", () => propSlipRR);

            Base.AddProp("ApproximateCalculations", false);
            Base.AddProp("LapsRemaining", 0);
            Base.AddProp("LapBalance", 0);

            Base.AttachDelegate("LapStatus", () => propLapStatus);

            Base.AddProp("StintTimer", new TimeSpan(0));
            Base.AddProp("StintTotalTime", new TimeSpan(0));
            Base.AddProp("StintTotalHotlaps", 0);
            Base.AddProp("StintCurrentHotlap", 0);

            Base.AttachDelegate("StintValidLaps", () => propValidStintLaps);
            Base.AttachDelegate("StintInvalidLaps", () => propInvalidStintLaps);

            Base.AddProp("Pace", new TimeSpan(0));

            Base.AttachDelegate("PitBoxPosition", () => propPitBox);
            Base.AttachDelegate("PitBoxApproach", () => propBoxApproach);
            Base.AttachDelegate("PitEntry", () => propPitEntry);
            Base.AttachDelegate("PitSpeeding", () => propPitSpeeding);

            Base.AttachDelegate("SessionBestLap", () => propLapRecord);
            Base.AttachDelegate("HotlapLivePosition", () => propHotLapLivePosition);
            Base.AttachDelegate("QualyWarmUpLap", () => propWarmup);
            Base.AttachDelegate("QualyLap1Status", () => propQLap1Status);
            Base.AttachDelegate("QualyLap2Status", () => propQLap2Status);
            Base.AddProp("QualyLap1Time", new TimeSpan(0));
            Base.AddProp("QualyLap2Time", new TimeSpan(0));

            Base.AddProp("CurrentSector", 0);
            Base.AddProp("CurrentSector1Time", new TimeSpan(0));
            Base.AddProp("CurrentSector2Time", new TimeSpan(0));
            Base.AddProp("CurrentSector3Time", new TimeSpan(0));
            Base.AddProp("CurrentSector1Delta", 0);
            Base.AddProp("CurrentSector2Delta", 0);
            Base.AddProp("CurrentSector3Delta", 0);
            Base.AddProp("CurrentSector1Status", 0);
            Base.AddProp("CurrentSector2Status", 0);
            Base.AttachDelegate("CurrentSector3Status", () => propCurrentSector3Status);
            Base.AttachDelegate("SessionBestSector1", () => TimeSpan.FromSeconds(propSessionBestSector1));
            Base.AttachDelegate("SessionBestSector2", () => TimeSpan.FromSeconds(propSessionBestSector2));
            Base.AttachDelegate("SessionBestSector3", () => TimeSpan.FromSeconds(propSessionBestSector3));
            Base.AddProp("Sector1Pace", new TimeSpan(0));
            Base.AddProp("Sector2Pace", new TimeSpan(0));
            Base.AddProp("Sector3Pace", new TimeSpan(0));
            Base.AddProp("Sector1Score", 0);
            Base.AddProp("Sector2Score", 0);
            Base.AddProp("Sector3Score", 0);

            Base.AttachDelegate("OptimalLapTime", () => optimalLapTime);

            for (int i = 0; i < 7; i++)
            {
                string propIndex = $"{i + 1:00}";

                Base.AttachDelegate($"Lap{propIndex}Sector1Time", () => TimeSpan.FromSeconds(propSector1TimeList[i]));
                Base.AttachDelegate($"Lap{propIndex}Sector2Time", () => TimeSpan.FromSeconds(propSector2TimeList[i]));
                Base.AttachDelegate($"Lap{propIndex}Sector3Time", () => TimeSpan.FromSeconds(propSector3TimeList[i]));
                Base.AttachDelegate($"Lap{propIndex}Sector1Delta", () => propLapSectorDelta[i, 1]);
                Base.AttachDelegate($"Lap{propIndex}Sector2Delta", () => propLapSectorDelta[i, 2]);
                Base.AttachDelegate($"Lap{propIndex}Sector3Delta", () => propLapSectorDelta[i, 3]);
                Base.AttachDelegate($"Lap{propIndex}Sector1Status", () => propSector1StatusList[i]);
                Base.AttachDelegate($"Lap{propIndex}Sector2Status", () => propSector2StatusList[i]);
                Base.AttachDelegate($"Lap{propIndex}Sector3Status", () => propSector3StatusList[i]);
                Base.AttachDelegate($"Lap{propIndex}FuelTargetDelta", () => propFuelTargetDeltas[i]);
            }

            Base.AttachDelegate("LapRecord", () => propLapRecord);
            Base.AddProp("DeltaLastLap", 0);
            Base.AddProp("DeltaSessionBest", 0);
            Base.AddProp("DeltaLapRecord", 0);
            Base.AddProp("DeltaLastLapChange", "");
            Base.AddProp("DeltaSessionBestChange", "");
            Base.AddProp("DeltaLapRecordChange", "");

            Base.AddProp("P1Gap", 0);
            Base.AddProp("P1Name", "");
            Base.AddProp("P1Pace", new TimeSpan(0));
            Base.AddProp("P1Finished", false);
            Base.AddProp("P1LapBalance", 0);

            Base.AddProp("ClassP1Gap", 0);
            Base.AddProp("ClassP1Name", "");
            Base.AddProp("ClassP1Pace", new TimeSpan(0));
            Base.AddProp("ClassP1RealGap", 0);

            Base.AddProp("LuckyDogGap", 0);
            Base.AddProp("LuckyDogRealGap", 0);
            Base.AddProp("LuckyDogName", "");
            Base.AddProp("LuckyDogPositionsAhead", 0);

            Base.AddProp("AheadName", "");
            Base.AddProp("AheadGap", 0);
            Base.AddProp("AheadPace", new TimeSpan(0));
            Base.AddProp("AheadBestLap", new TimeSpan(0));
            Base.AddProp("AheadIsConnected", false);
            Base.AddProp("AheadIsInPit", false);
            Base.AddProp("AheadSlowLap", false);
            Base.AddProp("AheadPrognosis", 0);
            Base.AddProp("AheadLapsToOvertake", 0);
            Base.AddProp("AheadLapsSincePit", -1);
            Base.AddProp("AheadP2PStatus", false);
            Base.AddProp("AheadP2PCount", -1);
            Base.AddProp("AheadRealGap", 0);

            Base.AddProp("BehindName", "");
            Base.AddProp("BehindGap", 0);
            Base.AddProp("BehindPace", new TimeSpan(0));
            Base.AddProp("BehindBestLap", new TimeSpan(0));
            Base.AddProp("BehindIsConnected", false);
            Base.AddProp("BehindIsInPit", false);
            Base.AddProp("BehindSlowLap", false);
            Base.AddProp("BehindPrognosis", 0);
            Base.AddProp("BehindLapsToOvertake", 0);
            Base.AddProp("BehindLapsSincePit", -1);
            Base.AddProp("BehindP2PStatus", false);
            Base.AddProp("BehindP2PCount", -1);
            Base.AddProp("BehindRealGap", 0);

            Base.AttachDelegate("LeftCarGap", () => iRacingSpotter.carPositionLeft);
            Base.AttachDelegate("LeftCarName", () => iRacingSpotter.carNameLeft);
            Base.AttachDelegate("RightCarGap", () => iRacingSpotter.carPositionRight);
            Base.AttachDelegate("RightCarName", () => iRacingSpotter.carNameRight);

            for (int i = 0; i < 6; i++)
            {
                string propIndex = $"{i + 1:00}";

                Base.AddProp($"CarAhead{propIndex}Gap", 0);
                Base.AddProp($"CarAhead{propIndex}RaceGap", 0);
                Base.AddProp($"CarAhead{propIndex}BestLap", new TimeSpan(0));
                Base.AddProp($"CarAhead{propIndex}Name", "");
                Base.AddProp($"CarAhead{propIndex}Position", 0);
                Base.AddProp($"CarAhead{propIndex}IRating", 0);
                Base.AddProp($"CarAhead{propIndex}Licence", "");
                Base.AddProp($"CarAhead{propIndex}IsAhead", false);
                Base.AddProp($"CarAhead{propIndex}IsClassLeader", false);
                Base.AddProp($"CarAhead{propIndex}IsInPit", false);
                Base.AddProp($"CarAhead{propIndex}ClassColor", "");
                Base.AddProp($"CarAhead{propIndex}ClassDifference", 0);
                Base.AddProp($"CarAhead{propIndex}JokerLaps", 0);
                Base.AddProp($"CarAhead{propIndex}LapsSincePit", -1);
                Base.AddProp($"CarAhead{propIndex}P2PCount", -1);
                Base.AddProp($"CarAhead{propIndex}P2PStatus", false);
                Base.AddProp($"CarAhead{propIndex}RealGap", 0);
                Base.AddProp($"CarAhead{propIndex}RealRelative", 0);
            }

            for (int i = 0; i < 6; i++)
            {
                string propIndex = $"{i + 1:00}";

                Base.AddProp($"CarBehind{propIndex}Gap", 0);
                Base.AddProp($"CarBehind{propIndex}RaceGap", 0);
                Base.AddProp($"CarBehind{propIndex}BestLap", new TimeSpan(0));
                Base.AddProp($"CarBehind{propIndex}Name", "");
                Base.AddProp($"CarBehind{propIndex}Position", 0);
                Base.AddProp($"CarBehind{propIndex}IRating", 0);
                Base.AddProp($"CarBehind{propIndex}Licence", "");
                Base.AddProp($"CarBehind{propIndex}IsAhead", false);
                Base.AddProp($"CarBehind{propIndex}IsClassLeader", false);
                Base.AddProp($"CarBehind{propIndex}IsInPit", false);
                Base.AddProp($"CarBehind{propIndex}ClassColor", "");
                Base.AddProp($"CarBehind{propIndex}ClassDifference", 0);
                Base.AddProp($"CarBehind{propIndex}JokerLaps", 0);
                Base.AddProp($"CarBehind{propIndex}LapsSincePit", -1);
                Base.AddProp($"CarBehind{propIndex}P2PCount", -1);
                Base.AddProp($"CarBehind{propIndex}P2PStatus", false);
                Base.AddProp($"CarBehind{propIndex}RealGap", 0);
                Base.AddProp($"CarBehind{propIndex}RealRelative", 0);
            }


            Base.AddProp("FuelDelta", 0);
            Base.AddProp("FuelPitWindowFirst", 0);
            Base.AddProp("FuelPitWindowLast", 0);
            Base.AddProp("FuelMinimumFuelFill", 0);
            Base.AddProp("FuelMaximumFuelFill", 0);
            Base.AddProp("FuelPitStops", 0);
            Base.AddProp("FuelConserveToSaveAStop", 0);
            Base.AddProp("FuelAlert", false);

            Base.AddProp("FuelDeltaLL", 0);
            Base.AddProp("FuelPitWindowFirstLL", 0);
            Base.AddProp("FuelPitWindowLastLL", 0);
            Base.AddProp("FuelMinimumFuelFillLL", 0);
            Base.AddProp("FuelMaximumFuelFillLL", 0);
            Base.AddProp("FuelPitStopsLL", 0);
            Base.AddProp("FuelConserveToSaveAStopLL", 0);

            Base.AddProp("FuelSlowestFuelSavePace", new TimeSpan(0));
            Base.AddProp("FuelSaveDeltaValue", 0);
            Base.AttachDelegate("FuelPerLapOffset", () => Math.Round(propFuelPerLapOffset, 2));
            Base.AddProp("FuelPerLapTarget", 0);
            Base.AddProp("FuelPerLapTargetLastLapDelta", 0);
            Base.AddProp("FuelTargetDeltaCumulative", 0);

            Base.AttachDelegate("TrackType", () => propTrackType);
            Base.AttachDelegate("JokerThisLap", () => propJokerThisLap);
            Base.AttachDelegate("JokerCount", () => propJokerLapCount);

            Base.AddProp("MinimumCornerSpeed", 0);
            Base.AddProp("StraightLineSpeed", 0);

            Base.AttachDelegate("PitToggleLF", () => propLFTog);
            Base.AttachDelegate("PitToggleRF", () => propRFTog);
            Base.AttachDelegate("PitToggleLR", () => propLRTog);
            Base.AttachDelegate("PitToggleRR", () => propRRTog);
            Base.AttachDelegate("PitToggleFuel", () => propfuelTog);
            Base.AttachDelegate("PitToggleWindscreen", () => propWSTog);
            Base.AttachDelegate("PitToggleRepair", () => propRepairTog);

            Base.AddProp("PitServiceFuelTarget", 0);
            Base.AddProp("PitServiceLFPSet", 0);
            Base.AddProp("PitServiceRFPSet", 0);
            Base.AddProp("PitServiceLRPSet", 0);
            Base.AddProp("PitServiceRRPSet", 0);

            Base.AttachDelegate("CurrentFrontWing", () => propCurrentFrontWing);
            Base.AttachDelegate("CurrentRearWing", () => propCurrentRearWing);
            Base.AttachDelegate("CurrentPowersteer", () => currentPWS);
            Base.AttachDelegate("CurrentTape", () => propCurrentTape);

            Base.AddProp("PitCrewType", 0);
            Base.AddProp("PitTimeTires", 0);
            Base.AddProp("PitTimeFuel", 0);
            Base.AddProp("PitTimeWindscreen", 0);
            Base.AddProp("PitTimeAdjustment", 0);
            Base.AddProp("PitTimeDriveThrough", 0);
            Base.AddProp("PitTimeService", 0);
            Base.AddProp("PitTimeTotal", 0);
            Base.AddProp("PitExitPosition", 0);

            for (int i = 0; i < 15; i++)
            {
                string propIndex = $"{i + 1:0}";

                Base.AddProp($"PitExitCar{propIndex}Name", "");
                Base.AddProp($"PitExitCar{propIndex}Gap", 0);
                Base.AddProp($"PitExitCar{propIndex}Position", 0);
                Base.AddProp($"PitExitCar{propIndex}ClassDifference", 0);
                Base.AddProp($"PitExitCar{propIndex}IsAhead", false);
                Base.AddProp($"PitExitCar{propIndex}IsFaster", false);
            }

            /*
             * Hardware buttons
             */
            Base.AttachDelegate("BitePointAdjust", () => propBitePointAdjust);
            Base.AddAction("BitePointPressed", (a, b) => bitePointPressed = true);
            Base.AddAction("BitePointReleased", (a, b) => bitePointReleased = true);
            Base.AddAction("PlusPressed", (a, b) => plusButtonCheck = true);
            Base.AddAction("MinusPressed", (a, b) => minusButtonCheck = true);
            Base.AddAction("OKPressed", (a, b) => OKButtonCheck = true);
            Base.AddAction("Upshift", (a, b) => upshift = true);
            Base.AddAction("Downshift", (a, b) => downshift = true);
            Base.AttachDelegate("LaunchScreen", () => propLaunchActive);
            Base.AddAction("LaunchPressed", (a, b) => launchPressed = true);
            Base.AddAction("LaunchReleased", (a, b) => launchReleased = true);
            Base.AttachDelegate("NoBoost", () => propNBvalue);
            Base.AddAction("NBPressed", (a, b) => NBpressed = true);
            Base.AttachDelegate("SpotterMode", () => propSpotMode);
            Base.AttachDelegate("Radio", () => propRadio);
            Base.AttachDelegate("RadioName", () => propRadioName);
            Base.AttachDelegate("RadioPosition", () => propRadioPosition);
            Base.AttachDelegate("RadioIsSpectator", () => propRadioIsSpectator);
            Base.AddAction("RadioPressed", (a, b) => propRadio = true);
            Base.AddAction("RadioReleased", (a, b) => propRadio = false);
            Base.AttachDelegate("PaceCheck", () => propPaceCheck);
            Base.AddAction("PacePressed", (a, b) => pacePressed = true);
            Base.AddAction("PaceReleased", (a, b) => paceReleased = true);
            Base.AttachDelegate("PitScreen", () => propPitScreenEnable);
            Base.AddAction("PitPressed", (a, b) => pitPressed = true);
            Base.AddAction("PitReleased", (a, b) => pitReleased = true);
            Base.AttachDelegate("TCOffTimer", () => propTCOffTimer);
            Base.AddAction("TCPressed", (a, b) => TCactive = true);
            Base.AddAction("TCReleased", (a, b) => TCactive = false);

            Base.AddProp("PitMenu", 1);
            for (int i = 1; i < 13; i++)
            {
                AddRotaryPitMenu(i);
            }

            Base.AddAction("LInc", (a, b) =>
            {
                pitMenuRotary++;
                if (pitMenuRotary > 12)
                {
                    pitMenuRotary = 1;
                }
                Base.SetProp("PitMenu", pitMenuRotary);
            });
            Base.AddAction("LDec", (a, b) =>
            {
                pitMenuRotary--;
                if (pitMenuRotary < 1)
                {
                    pitMenuRotary = 12;
                }
                Base.SetProp("PitMenu", pitMenuRotary);
            });

            Base.AttachDelegate("PitSavePaceLock", () => savePitTimerLock);

            Base.AddProp("InCarMenu", 0);

            for (int i = 1; i < 13; i++)
            {
                AddRotaryInCar(i);
            }


            Base.AddAction("RInc", (a, b) =>
            {
                inCarRotary++;
                if (inCarRotary > 12)
                {
                    inCarRotary = 1;
                }
                Base.SetProp("InCarMenu", inCarRotary);
            });
            Base.AddAction("RDec", (a, b) =>
            {
                inCarRotary--;
                if (inCarRotary < 1)
                {
                    inCarRotary = 12;
                }
                Base.SetProp("InCarMenu", inCarRotary);
            });
            #endregion
        }



        public void DataUpdateIdle()
        {
            if (Base.gameRunning) //Stuf that happens when out of game
                return;


            propFuelPerLapOffset = 0;
            savePitTimerLock = false;
            savePitTimerSnap = new TimeSpan(0);
            slowestLapTimeSpanCopy = new TimeSpan(0);

            propPitBox = 0.5;
            hasPitted = false;
            propValidStintLaps = 0;
            propInvalidStintLaps = 0;
            fuelTargetDeltaCumulative = 0;
            propRaceFinished = false;
            propJokerThisLap = false;
            jokerLapChecker = false;
            finishedCars = new List<string> { };
            fuelTargetCheck = false;
            oldFuelValue = 0;
            NBactive = false;
            propNBvalue = false;
            NBspeedLim = false;
            ERSlapCounter = 0;
            ERSstartingLap = true;
            TCon = false;
            TCduration = 0;
            propOffTrack = false;
            propIRchange = 0;

            //Props that need refresh
            propTCactive = false;

            //Refreshing some lists
            if (Base.counter == 59)
            {
                realGapLocks.Clear();
                realGapChecks.Clear();
                realGapPoints.Clear();
                realGapOpponentDelta.Clear();
                realGapOpponentRelative.Clear();
                sessionCarsLapsSincePit.Clear();
                sessionCarsLap.Clear();

                lapDeltaCurrent.Clear();
                lapDeltaSessionBest.Clear();
                lapDeltaLast.Clear();
                lapDeltaRecord.Clear();
                lapDeltaLastChange.Clear();
                lapDeltaSessionBestChange.Clear();
                lapDeltaLapRecordChange.Clear();
                lastChunks.Clear();
                SBChunks.Clear();
                LRChunks.Clear();

                for (int u = 0; u < trackSections; u++)
                {
                    List<bool> locks = new List<bool> { };
                    List<bool> checks = new List<bool> { };
                    List<TimeSpan> points = new List<TimeSpan> { };

                    for (int i = 0; i < 64; i++)
                    {
                        locks.Add(false);
                        checks.Add(false);
                        points.Add(TimeSpan.FromSeconds(0));
                    }

                    realGapLocks.Add(locks);
                    realGapChecks.Add(checks);
                    realGapPoints.Add(points);
                }

                for (int i = 0; i < 64; i++)
                {
                    realGapOpponentDelta.Add(0);
                    realGapOpponentRelative.Add(0);
                    sessionCarsLapsSincePit.Add(-1);
                    sessionCarsLap.Add(-1);
                }

                for (int i = 0; i < lapDeltaSections + 1; i++)
                {
                    lapDeltaCurrent.Add(-1);
                    lapDeltaSessionBest.Add(-1);
                    lapDeltaLast.Add(-1);
                    lapDeltaRecord.Add(-1);
                    lapDeltaLastChange.Add(0);
                    lapDeltaSessionBestChange.Add(0);
                    lapDeltaLapRecordChange.Add(0);
                }
                for (int i = 0; i < deltaChangeChunks; i++)
                {
                    lastChunks.Add(0);
                    SBChunks.Add(0);
                    LRChunks.Add(0);
                }
            }
        }

        public void DataUpdate()
        {
            if (Base.gameName != "IRacing" || !Base.gameRunning)
                return;

            #region GameData
            //Gaining access to raw data
            if (Base.gameData?.NewData?.GetRawDataObject() is DataSampleEx) { irData = Base.gameData.NewData.GetRawDataObject() as DataSampleEx; }

            //Updating relevant data
            globalClock = TimeSpan.FromTicks(DateTime.Now.Ticks);

            irData.Telemetry.TryGetValue("PlayerCarTeamIncidentCount", out object rawIncidents);
            incidents = Convert.ToInt32(rawIncidents);                                          //Incidents

            irData.Telemetry.TryGetValue("PlayerCarInPitStall", out object rawStall);
            pitStall = Convert.ToInt32(rawStall);                                               //Pit Stall

            irData.Telemetry.TryGetValue("ManualBoost", out object rawBoost);
            boost = Convert.ToBoolean(rawBoost);                                               //Boost

            irData.Telemetry.TryGetValue("PowerMGU_K", out object rawMGU);
            MGU = Convert.ToInt32(rawMGU);                                                      //MGU-K current

            irData.Telemetry.TryGetValue("EnergyERSBatteryPct", out object rawBattery);
            battery = Convert.ToDouble(rawBattery);                                          //Battery

            irData.Telemetry.TryGetValue("DRS_Status", out object rawDRS);
            DRSState = Convert.ToInt32(rawDRS);                                                 //DRS state

            slipLF = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.FrontLeft"));  //Wheel slip
            slipRF = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.FrontRight"));  //Wheel slip
            slipLR = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.RearLeft"));  //Wheel slip
            slipRR = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.RearRight"));  //Wheel slip

            trackPosition = irData.Telemetry.LapDistPct;                                     //Lap distance
            completedLaps = Base.gameData.NewData.CompletedLaps;                                         //Completed laps
            currentLap = Base.gameData.NewData.CurrentLap;                                               //Current lap
            totalLaps = Base.gameData.NewData.TotalLaps;                                                 //Total laps
            currentLapTime = Base.gameData.NewData.CurrentLapTime;                                  //Current lap time
            pit = Base.gameData.NewData.IsInPit;                                                         //Pit
            pitLimiter = Base.gameData.NewData.PitLimiterOn;                                             //Pit limiter on/off
            gear = Base.gameData.NewData.Gear;                                                        //Gear
            fuelAvgLap = Convert.ToDouble(Base.GetProp("DataCorePlugin.Computed.Fuel_LitersPerLap")); //Fuel avg lap
            black = Base.gameData.NewData.Flag_Black;                                                    //Black flag
            white = Base.gameData.NewData.Flag_White;                                                    //White flag
            checkered = Base.gameData.NewData.Flag_Checkered;                                            //Checkered flag
            lastLapTime = Base.gameData.NewData.LastLapTime;                                        //Last Lap Time 
            carModel = Base.gameData.NewData.CarModel;                                                //Car model
            track = Base.gameData.NewData.TrackName;                                                  //Track name
            session = Base.gameData.NewData.SessionTypeName;                                          //Session type
            timeLeft = Base.gameData.NewData.SessionTimeLeft;                                       //Session time left
            pitLocation = irData.SessionData.DriverInfo.DriverPitTrkPct;                     //Pit location
            trackLength = Base.gameData.NewData.TrackLength;                                          //Track length
            defaultRevLim = Base.gameData.NewData.CarSettings_MaxRPM;                                 //Default rev limiter
            pitSpeedLimit = 0;                                                                  //Pit speed limit
            if (irData.SessionData.WeekendInfo.TrackPitSpeedLimit != null)
            {
                if (Convert.ToInt32(irData.SessionData.WeekendInfo.TrackPitSpeedLimit.Substring(0, 1)) != 0)
                {
                    pitSpeedLimit = Convert.ToInt32(irData.SessionData.WeekendInfo.TrackPitSpeedLimit.Substring(0, 2));
                }
            }

            ERSlimit = 0;
            if (pitSpeedLimit > 70)
            {
                ERSlimit = 76;
            }
            else
            {
                ERSlimit = 52;
            }

            sessionNumber = irData.Telemetry.SessionNum;                                        //Session number, to find correct session
            trackConfig = irData.SessionData.WeekendInfo.TrackType;                          //Track type name
            greenFlag = Base.gameData.NewData.Flag_Green;                                                //Green flag

            irData.Telemetry.TryGetValue("dcTractionControlToggle", out object rawTCswitch);        //In-game TC toggle
            TCswitch = Convert.ToBoolean(rawTCswitch);

            irData.Telemetry.TryGetValue("dcABSToggle", out object rawABSswitch);                   //In-game ABS toggle
            ABSswitch = Convert.ToBoolean(rawABSswitch);

            irData.Telemetry.TryGetValue("dcABS", out object rawABS);                               //In-game ABS switch position
            ABS = Convert.ToInt32(rawABS);

            irData.Telemetry.TryGetValue("dcTractionControl", out object rawTC);                    //In-game TC switch position
            TC = Convert.ToInt32(rawTC);

            irData.Telemetry.TryGetValue("PlayerTrackSurfaceMaterial", out object rawSurface);      //Track surface type
            surface = Convert.ToInt32(rawSurface);

            stintLength = Base.gameData.NewData.StintOdo;                                             //Stint length
            opponents = Base.gameData.NewData.Opponents.Count;                                           //All opponents
            classOpponents = Base.gameData.NewData.PlayerClassOpponentsCount;                            //Class opponents
            fuel = Base.gameData.NewData.Fuel;                                                        //Fuel on tank

            irData.Telemetry.TryGetValue("SessionState", out object rawSessionState);
            sessionState = Convert.ToInt32(rawSessionState);                                    //Session State

            irData.Telemetry.TryGetValue("PlayerTrackSurface", out object rawtrackLocation);
            trackLocation = Convert.ToInt32(rawtrackLocation);                                  //TrkLoc

            irData.Telemetry.TryGetValue("dpWingFront", out object rawWingFront);                   //Front wing setting
            wingFront = Math.Round(Convert.ToDouble(rawWingFront), 2);

            irData.Telemetry.TryGetValue("dpWingRear", out object rawWingRear);                     //Rear wing setting
            wingRear = Math.Round(Convert.ToDouble(rawWingRear), 1);

            irData.Telemetry.TryGetValue("dpQTape", out object rawtape);                            //Tape
            tape = Convert.ToInt16(rawtape);

            irData.Telemetry.TryGetValue("dpPowerSteering", out object rawPWS);                     //Powersteering
            PWS = Convert.ToInt16(rawPWS);

            gearRatio = Convert.ToDouble(Base.GetProp("GameRawData.SessionData.CarSetup.Chassis.Rear.DropGearARatio")); //Gear ratio

            irData.Telemetry.TryGetValue("SessionOnJokerLap", out object rawisOnJoker);             //Joker lap
            onJokerLap = Convert.ToBoolean(rawisOnJoker);

            irData.Telemetry.TryGetValue("PlayerCarIdx", out object rawPlayerIdx);                  //My CarIdx
            myCarIdx = Convert.ToInt32(rawPlayerIdx);

            irData.Telemetry.TryGetValue("CarIdxP2P_Count", out object p2pCount);                   //P2P Counts
            irData.Telemetry.TryGetValue("CarIdxP2P_Status", out object p2pStatus);                 //P2P Statuses
            irData.Telemetry.TryGetValue("CarIdxBestLapTime", out object BestLapTimes);             //BestLapTimes
            //BestLapTimes = (float[])_BestLapTimes;
            irData.Telemetry.TryGetValue("CarIdxTireCompound", out object tireCompounds);           //Tire compounds

            furled = Convert.ToBoolean(Base.GetProp("GameRawData.Telemetry.SessionFlagsDetails.IsFurled"));  //Furled flag

            irData.Telemetry.TryGetValue("LRshockVel", out object rawLRShockVel);                   //Left rear shock
            LRShockVel = Convert.ToDouble(rawLRShockVel);

            irData.Telemetry.TryGetValue("LRshockVel", out object rawRRShockVel);                   //Right rear shock
            RRShockVel = Convert.ToDouble(rawRRShockVel);

            irData.Telemetry.TryGetValue("DRS_Count", out object rawDRSCount);                      //DRS Count
            if (rawDRSCount != null)
            {
                myDRSCount = Convert.ToInt32(rawDRSCount);
            }
            else
            {
                myDRSCount = 0;
            }

            estimatedLapTime = (TimeSpan)(Base.GetProp("PersistantTrackerPlugin.EstimatedLapTime")); //EstimatedLapTime

            if (Base.gameData.NewData.OpponentsAheadOnTrack.Count > 0)
            {
                aheadGap = Base.gameData.NewData.OpponentsAheadOnTrack[0].GaptoPlayer;                       //Ahead GAP
                aheadClass = Base.gameData.NewData.OpponentsAheadOnTrack[0].CarClass;                        //Ahead Class
                aheadClassPosition = Base.gameData.NewData.OpponentsAheadOnTrack[0].PositionInClass;         //Ahead Position (class)
            }
            myClass = Base.gameData.NewData.CarClass;                                                 //My Class
            myPosition = irData.Telemetry.PlayerCarClassPosition;                               //My Position (class)
            throttle = Base.gameData.NewData.Throttle;                                                //Throttle application
            brake = Base.gameData.NewData.Brake;                                                      //Brake application
            clutch = Base.gameData.NewData.Clutch;                                                    //Clutch application
            speed = Base.gameData.NewData.SpeedLocal;                                                 //Speed
            rpm = Base.gameData.NewData.Rpms;                                                         //RPM value

            plannedFuel = Convert.ToDouble(irData.Telemetry.PitSvFuel);                      //Planned fuel
            maxFuel = Base.gameData.NewData.MaxFuel;
            plannedLFPressure = irData.Telemetry.PitSvLFP;                                    //Planned LF pressure
            plannedRFPressure = irData.Telemetry.PitSvRFP;                                    //Planned RF pressure
            plannedLRPressure = irData.Telemetry.PitSvLRP;                                    //Planned LR pressure
            plannedRRPressure = irData.Telemetry.PitSvRRP;                                    //Planned RR pressure

            cam = irData.Telemetry.CamCameraState;                                              //Cam state
            sessionScreen = Convert.ToBoolean(cam & 1);
            scenicActive = Convert.ToBoolean(cam & 2);
            camToolActive = Convert.ToBoolean(cam & 4);
            UIHidden = Convert.ToBoolean(cam & 8);
            useAutoShotSelection = Convert.ToBoolean(cam & 16);
            useTemporaryEdits = Convert.ToBoolean(cam & 32);
            useKeyAcceleration = Convert.ToBoolean(cam & 64);
            useKey10xAcceleration = Convert.ToBoolean(cam & 128);
            useMouseAimMode = Convert.ToBoolean(cam & 256);

            pitInfo = irData.Telemetry.PitSvFlags;                                              //Pit stop toggles
            propLFTog = Convert.ToBoolean(pitInfo & 1);
            propRFTog = Convert.ToBoolean(pitInfo & 2);
            propLRTog = Convert.ToBoolean(pitInfo & 4);
            propRRTog = Convert.ToBoolean(pitInfo & 8);
            propfuelTog = Convert.ToBoolean(pitInfo & 16);
            propWSTog = Convert.ToBoolean(pitInfo & 32);
            propRepairTog = Convert.ToBoolean(pitInfo & 64);
            #endregion


            SmoothGear();

            if (Base.counter == 8)
            {
                SofAndIrating();
            }

            OffTrack();

            if (Base.counter == 1)
            {
                TrackAttributes();
            }

            //-----------------------------------------------------------------------------
            //----------------------CAR ATTRIBUTES UPDATE----------------------------------
            //-----------------------------------------------------------------------------

            //p2pCount, object p2pStatus, object tireCompounds ==> local variables

            if (Base.counter == 14)
            {

                //Resetting values to default
                carId = "";
                propHasAntiStall = false;
                propHasDRS = false;
                hasTCtog = false;
                hasTCtimer = false;
                TCoffPosition = -1;
                hasABStog = false;
                propHasABS = false;
                hasTC = false;
                ABSoffPosition = -1;
                propMapHigh = -1;
                propMapLow = -1;
                hasNoBoost = false;
                propHasOvertake = false;
                propRotaryType = "Single";
                propDashType = "Default";
                propShiftPoint1 = 0;
                propShiftPoint2 = 0;
                propShiftPoint3 = 0;
                propShiftPoint4 = 0;
                propShiftPoint5 = 0;
                propShiftPoint6 = 0;
                propShiftPoint7 = 0;
                propRevLim = defaultRevLim;
                propIdleRPM = 0;
                propClutchBitePoint = 40;
                propClutchSpin = 0;
                propClutchIdealRangeStart = 0;
                propClutchIdealRangeStop = 0;
                propClutchGearRelease = 1;
                propClutchTimeRelease = 0;
                propClutchGearReleased = 1;
                propClutchTimeReleased = 100;
                propHighPower = false;
                propLaunchThrottle = 0;
                pitMaxSpeed = 1;
                pitCornerSpeed = 1;
                pitBrakeDistance = 1;
                pitAcceleration = 1;
                pitFuelFillRate = 2.7;
                carHasAnimatedCrew = false;
                pitAniBaseTime = 0;
                pitAniSlowAdd = 0;
                pitBaseTime = 0;
                pitSlowAdd = 0;
                pitCrewType = CrewType.SingleTyre;
                pitMultitask = true;
                pitHasWindscreen = true;
                propAnimationType = AnimationType.Analog;
                revSpeed = 1;


                Cars _carInfo = carInfo.FirstOrDefault(x => x.Id == carModel);
                if (_carInfo != null)
                {
                    carId = _carInfo.Id;
                    propHasAntiStall = _carInfo.HasAntiStall;
                    propHasDRS = _carInfo.HasDRS;
                    hasTCtog = _carInfo.HasTCtog;
                    hasTCtimer = _carInfo.HasTCtimer;
                    TCoffPosition = _carInfo.TCOffPosition;
                    hasABStog = _carInfo.HasABStog;
                    propHasABS = _carInfo.HasABS;
                    hasTC = _carInfo.HasTC;
                    ABSoffPosition = _carInfo.ABSOffPosition;
                    propMapHigh = _carInfo.MapHigh;
                    propMapLow = _carInfo.MapLow;
                    hasNoBoost = _carInfo.HasNoBoost;
                    propHasOvertake = _carInfo.HasOvertake;
                    propRotaryType = _carInfo.RotaryType;
                    propDashType = _carInfo.DashType;
                    propShiftPoint1 = _carInfo.ShiftPoint1;
                    propShiftPoint2 = _carInfo.ShiftPoint2;
                    propShiftPoint3 = _carInfo.ShiftPoint3;
                    propShiftPoint4 = _carInfo.ShiftPoint4;
                    propShiftPoint5 = _carInfo.ShiftPoint5;
                    propShiftPoint6 = _carInfo.ShiftPoint6;
                    propShiftPoint7 = _carInfo.ShiftPoint7;
                    propRevLim = _carInfo.RevLim;
                    propIdleRPM = _carInfo.IdleRPM;
                    propClutchBitePoint = _carInfo.ClutchBitePoint;
                    propClutchSpin = _carInfo.ClutchSpin;
                    propClutchIdealRangeStart = _carInfo.ClutchIdealRangeStart;
                    propClutchIdealRangeStop = _carInfo.ClutchIdealRangeStop;
                    propClutchGearRelease = _carInfo.ClutchGearRelease;
                    propClutchTimeRelease = _carInfo.ClutchTimeRelease;
                    propClutchGearReleased = _carInfo.ClutchGearReleased;
                    propClutchTimeReleased = _carInfo.ClutchTimeReleased;
                    propHighPower = _carInfo.HighPower;
                    propLaunchThrottle = _carInfo.LaunchThrottle;
                    pitMaxSpeed = _carInfo.PitMaxSpeed;
                    pitCornerSpeed = _carInfo.PitCornerSpeed;
                    pitBrakeDistance = _carInfo.PitBrakeDistance;
                    pitAcceleration = _carInfo.PitAcceleration;
                    pitFuelFillRate = _carInfo.PitFuelFillRate;
                    carHasAnimatedCrew = _carInfo.PitHasAnimatedCrew;
                    pitAniBaseTime = _carInfo.PitAniBaseTime;
                    pitAniSlowAdd = _carInfo.PitAniSlowAdd;
                    pitBaseTime = _carInfo.PitBaseTime;
                    pitSlowAdd = _carInfo.PitSlowAdd;
                    pitCrewType = _carInfo.CrewType;
                    pitMultitask = _carInfo.PitMultitask;
                    pitHasWindscreen = _carInfo.PitHasWindscreen;
                    propAnimationType = _carInfo.AnimationType;
                    revSpeed = _carInfo.RevSpeed;

                }

                if (Base.Settings.DashType != "Automatic Selection")
                {
                    propDashType = Base.Settings.DashType;
                }

                if (p2pCount != null)
                {
                    propP2pCounter = ((int[])p2pCount)[myCarIdx];
                }
                else
                {
                    propP2pCounter = -1;
                }

                if (p2pStatus != null)
                {
                    propP2pActive = ((bool[])p2pStatus)[myCarIdx];
                }
                else
                {
                    propP2pActive = false;
                }

                if (tireCompounds != null)
                {
                    myTireCompound = ((int[])tireCompounds)[myCarIdx];
                }
                else
                {
                    myTireCompound = -1;
                }

                //No pit stop tracks
                if (propTrackType > 0 && propTrackType < 5)
                {
                    propRotaryType = "Default";
                }

                //Supercar gear ratio bite point setting
                if (propDashType == "Supercar")
                {
                    switch (gearRatio)
                    {
                        case 0.85:
                            propClutchBitePoint = 28;
                            propClutchSpin = 0;
                            propClutchIdealRangeStart = 28;
                            propClutchIdealRangeStop = 31;
                            propLaunchThrottle = 100;

                            break;
                        case 0.931:
                            propClutchBitePoint = 30.0;
                            propClutchSpin = 29.0;
                            propClutchIdealRangeStart = 29.5;
                            propClutchIdealRangeStop = 33;
                            propLaunchThrottle = 85;
                            break;
                        case 0.96:
                            propClutchBitePoint = 30.0;
                            propClutchSpin = 29.5;
                            propClutchIdealRangeStart = 31.0;
                            propClutchIdealRangeStop = 34;
                            propLaunchThrottle = 85;
                            break;
                        case 1:
                            propClutchBitePoint = 32.0;
                            propClutchSpin = 31.5;
                            propClutchIdealRangeStart = 32.0;
                            propClutchIdealRangeStop = 35;
                            propLaunchThrottle = 80;
                            break;
                        case 1.042:
                            propClutchBitePoint = 34.0;
                            propClutchSpin = 33.0;
                            propClutchIdealRangeStart = 34.0;
                            propClutchIdealRangeStop = 36;
                            propLaunchThrottle = 75;
                            break;
                        case 1.074:
                            propClutchBitePoint = 34.0;
                            propClutchSpin = 33.0;
                            propClutchIdealRangeStart = 35.0;
                            propClutchIdealRangeStop = 37;
                            propLaunchThrottle = 70;
                            break;
                        case 1.13:
                            propClutchBitePoint = 36.0;
                            propClutchSpin = 35.0;
                            propClutchIdealRangeStart = 35.5;
                            propClutchIdealRangeStop = 38;
                            propLaunchThrottle = 67;
                            break;
                    }
                }
            }


            //----------------------------------------------------
            //--------CHECK FOR BEST LAP--------------------------
            //----------------------------------------------------

            LapRecords.lapFetch(ref findLapRecord, csvAdress, ref csvIndex, track, carModel, ref propLapRecord, ref lapDeltaRecord, lapDeltaSections);

            DRSCount();
            DRS();
            ShiftLight();
            ERSTarget();

            //-------------------------------------
            //-------RX JOKER DETECTION------------
            //-------------------------------------

            if (onJokerLap)
            {
                propJokerThisLap = true;
            }

            Acceleration();

            //----------------------------------------------------
            //------------Spotter calculations--------------------
            //----------------------------------------------------

            iRacingSpotter.Spotter(Base.gameData, trackLength);

            StopWatch();
            WheelSlip();
            OvertakeMode();

            //Idle property
            propIRIdle = sessionScreen && !propSpotMode;

            //Identifying my class color and iRating
            if (Base.counter == 2)
            {
                for (int i = 0; i < irData.SessionData.DriverInfo.CompetingDrivers.Length; i++)
                {
                    if (Base.gameData.NewData.PlayerName == irData.SessionData.DriverInfo.CompetingDrivers[i].UserName)
                    {
                        propMyClassColor = irData.SessionData.DriverInfo.CompetingDrivers[i].CarClassColor;
                        myClassColorIndex = classColors.IndexOf(propMyClassColor);
                        myIR = Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[i].IRating);
                        break;
                    }
                }
            }

            //Looking for exempt sector
            if (hasExempt && ((trackPosition > exemptOne && trackPosition < (exemptOne + exemptOneMargin)) || (trackPosition > exemptTwo && trackPosition < (exemptTwo + exemptTwoMargin))))
            {
                sectorExempt = true;
            }
            else
            {
                sectorExempt = false;
            }

            //----------------------------------------------------
            //--------------BUTTONS-------------------------------
            //----------------------------------------------------

            PitCommands();

            FullScreen(ref launchPressed, ref propLaunchActive, ref launchReleased);
            FullScreen(ref pitPressed, ref propPitScreenEnable, ref pitReleased);
            FullScreen(ref pacePressed, ref propPaceCheck, ref paceReleased);
            FullScreen(ref bitePointPressed, ref propBitePointAdjust, ref bitePointReleased);

            Radio();

            NoBoost();

            TCoff();

            TCEmulation();

            TCtoggle();

            ABStoggle();

            RPMTracker();


            //-----------------------------------------
            //----------Lap calculations---------------
            //-----------------------------------------
            stintLapsCheck = false;

            if ((currentLapTime.TotalSeconds > 6 && trackPosition > 0.15 && trackPosition < twoThirds) || pit == 1)
            {
                currentLapTimeStarted = true;
            }
            if (trackPosition > twoThirds)
            {
                currentLapTimeStarted = false;
            }

            if (stintLength > 0) //Starting new stint
            {
                hasPitted = true;
            }

            propLapStatus = 1; //Lap status calculation: 1 = Valid lap, 2 = Invalid lap, 3 = Out lap, 4 = Penalty, 5 = Pit lane

            if (outLap)
            {
                propLapStatus = 3;
                stintLapsCheck = true;
            }
            if ((incidents > roadOff || furled) && !outLap)
            {
                propLapStatus = 2;
            }

            if (trackPosition > (1 - cutoff)) //Approaching start/finish line
            {
                sector1StatusHolder = currentSector1Status;
                sector1TimeHolder = currentSector1Time;
                statusReadyToFetch = true;
                jokerLapChecker = false;
                lastLapChecker = lastLapTime;
            }

            if (trackPosition < cutoff) //Crossing start/finish line
            {
                roadOff = incidents;
                outLap = false;
                lineCross = true;
                if (propJokerThisLap)
                {
                    jokerLapChecker = true;
                    propJokerThisLap = false;
                }

            }
            if (Base.counter == 11)
            {
                if (currentLapTime.TotalSeconds > 6 && trackPosition > 0.1 && trackPosition < 0.3333) //Stuf that happens a bit into lap
                {
                    if (lastLapChecker.TotalSeconds == lastLapTime.TotalSeconds)
                    {
                        Base.SetProp("CurrentSector3Time", new TimeSpan(0));
                        Base.SetProp("CurrentSector3Delta", 0);
                    }
                }
            }

            if (trackPosition > 0.5) //Getting halfways
            {
                lineCross = false;
            }

            if (pit == 1 || propIRIdle) //If in pit or idle
            {
                outLap = true;
                roadOff = incidents;
                propLapStatus = 5;
            }
            if (black == 1) //Black flag
            {
                propLapStatus = 4;
            }
            if (propJokerThisLap || jokerLapChecker)
            {
                propLapStatus = 6;
            }

            //Sector calculations
            if (trackPosition > twoThirds)
            {
                if (!(sectorExempt) && !(currentSector == 1 && propLapStatus != 5)) //Not update sector if jump to exempt area of track or in driving backwards.
                {
                    currentSector = 3;
                    sector1to2 = false;
                }
            }
            else if (trackPosition > oneThird && trackPosition < twoThirds)
            {
                if (!(sectorExempt) && !(currentSector == 3 && propLapStatus != 5))
                {
                    currentSector = 2;
                    sector2to3 = false;
                }
            }
            else
            {
                if (!(sectorExempt) && !(currentSector == 2 && propLapStatus != 5))
                {
                    currentSector = 1;
                    sector1to2 = false;
                    sector2to3 = false;
                }
            }

            if (currentSector == 3) //Updating lap time and status
            {
                currentSector3Time = currentLapTime.TotalSeconds - currentSector2Time - currentSector1Time;
                if (currentSector3Time < 0 || currentSector1Time == 0 || currentSector2Time == 0)
                {
                    currentSector3Time = 0;
                }

                if (!sector2to3)
                {
                    lastSectorStatusHolder = propLapStatus;
                    propCurrentSector3Status = 1;
                    sector2to3 = true;
                    sector3Incidents = incidents;
                }
                if (sector2to3 && sector3Incidents != incidents)
                {
                    if (propLapStatus == 3)
                    {
                        propCurrentSector3Status = 2;
                        lastSectorStatusHolder = 2;
                    }
                    else
                    {
                        propCurrentSector3Status = propLapStatus;
                        lastSectorStatusHolder = propLapStatus;
                    }

                    sector3Incidents = incidents;

                }
                if (sector2to3 && lastSectorStatusHolder != propLapStatus && propLapStatus != 3)
                {
                    propCurrentSector3Status = propLapStatus;
                    lastSectorStatusHolder = propLapStatus;
                }

                Base.SetProp("CurrentSector3Time", TimeSpan.FromSeconds(currentSector3Time));
                Base.SetProp("CurrentSector3Delta", 0);

                if (currentSector2Time > 0 && propSessionBestSector2 > 0)
                {
                    double delta = currentSector2Time - propSessionBestSector2;
                    Base.SetProp("CurrentSector2Delta", Math.Round(delta, 3));
                }
                else
                {
                    Base.SetProp("CurrentSector2Delta", 0);
                }
            }

            else if (currentSector == 2)
            {
                currentSector2Time = currentLapTime.TotalSeconds - currentSector1Time;
                if (currentSector2Time < 0 || currentSector1Time == 0)
                {
                    currentSector2Time = 0;
                }
                if (!sector1to2)
                {
                    lastSectorStatusHolder = propLapStatus;
                    currentSector2Status = 1;
                    sector1to2 = true;
                    sector2Incidents = incidents;
                }
                if (sector1to2 && sector2Incidents != incidents)
                {
                    if (propLapStatus == 3)
                    {
                        currentSector2Status = 2;
                        lastSectorStatusHolder = 2;
                    }
                    else
                    {
                        currentSector2Status = propLapStatus;
                        lastSectorStatusHolder = propLapStatus;
                    }

                    sector2Incidents = incidents;

                }
                if (sector1to2 && lastSectorStatusHolder != propLapStatus && propLapStatus != 3)
                {
                    currentSector2Status = propLapStatus;
                    lastSectorStatusHolder = propLapStatus;
                }

                Base.SetProp("CurrentSector2Time", TimeSpan.FromSeconds(currentSector2Time));
                Base.SetProp("CurrentSector2Status", currentSector2Status);
                Base.SetProp("CurrentSector2Delta", 0);

                if (currentSector1Time > 0 && propSessionBestSector1 > 0)
                {
                    double delta = currentSector1Time - propSessionBestSector1;
                    Base.SetProp("CurrentSector1Delta", Math.Round(delta, 3));
                }
                else
                {
                    Base.SetProp("CurrentSector1Delta", 0);
                }
            }
            else if (currentLapTimeStarted) //sector 1
            {
                currentSector1Time = currentLapTime.TotalSeconds;
                currentSector1Status = propLapStatus;

                Base.SetProp("CurrentSector1Time", TimeSpan.FromSeconds(currentSector1Time));
                Base.SetProp("CurrentSector1Status", currentSector1Status);
                Base.SetProp("CurrentSector1Delta", 0);
            }

            Base.SetProp("CurrentSector", currentSector);

            if (propPitBox > 0 && !hasApproached) //If jumped to pit box, not taking a proper inlap
            {
                if (trackPosition > 0.5)
                {
                    currentSector = 3;
                }
                else
                {
                    currentSector = 1;
                }

                Base.SetProp("CurrentSector", currentSector);

                currentSector1Time = 0;
                currentSector2Time = 0;
                currentSector3Time = 0;
                currentSector1Status = 0;
                currentSector2Status = 0;
                propCurrentSector3Status = 0;

                Base.SetProp("CurrentSector3Time", TimeSpan.FromSeconds(currentSector3Time));
                Base.SetProp("CurrentSector3Delta", 0);
                Base.SetProp("CurrentSector2Time", TimeSpan.FromSeconds(currentSector2Time));
                Base.SetProp("CurrentSector2Status", currentSector2Status);
                Base.SetProp("CurrentSector2Delta", 0);
                Base.SetProp("CurrentSector1Time", TimeSpan.FromSeconds(currentSector1Time));
                Base.SetProp("CurrentSector1Status", currentSector1Status);
                Base.SetProp("CurrentSector1Delta", 0);


            }


            //Sector calculations finished

            if (lineCross && statusReadyToFetch)     //Updating values at finish line crossing
            {
                lastStatusHolder = propLapStatus;
                lastSectorStatusHolder = propCurrentSector3Status;
                statusReadyToFetch = false;
                if (pit != 1)
                {
                    outLap = false;
                }

            }

            if (lastLapHolder != lastLapTime && (lastLapTime != new TimeSpan(0)))  //New lap time arrives, update certain lists and values
            {
                ERSChangeCount = 4;
                propLapStatusList.Insert(0, lastStatusHolder);

                if (lastStatusHolder == 1)
                {
                    propValidStintLaps++;
                }
                if (lastStatusHolder == 2)
                {
                    propInvalidStintLaps++;
                }
                if (lastStatusHolder == 6)
                {
                    propJokerLapCount++;
                    jokerLapChecker = false;
                }

                propLapStatusList.RemoveAt(8); //Making sure list doesnt grow untill infility
                if (propLapStatusList[0] != 0)
                {
                    propLapTimeList.Insert(0, lastLapTime);

                    //Checking for session best lap
                    if ((propLapTimeList[0].TotalSeconds < sessionBestLap.TotalSeconds || sessionBestLap.TotalSeconds == 0) && propLapStatusList[0] == 1)
                    {
                        sessionBestLap = propLapTimeList[0];
                        for (int i = 0; i < lapDeltaSections + 1; i++) //Keep hold of the timings on that lap
                        {
                            lapDeltaSessionBest[i] = lapDeltaLast[i];
                        }
                    }

                    //Checking for lap record
                    if (propLapRecord.TotalSeconds == 0 && propLapStatusList[0] == 1)
                    {
                        LapRecords.addLapRecord(track, carModel, propLapTimeList[0].TotalMilliseconds, lapDeltaLast, csvAdress, ref csvIndex);
                        for (int i = 0; i < lapDeltaSections + 1; i++) //Keep hold of the timings on that lap
                        {
                            lapDeltaRecord[i] = lapDeltaLast[i];
                        }
                        findLapRecord = true;
                    }
                    else if (propLapTimeList[0].TotalSeconds < propLapRecord.TotalSeconds && propLapStatusList[0] == 1)
                    {
                        LapRecords.replaceLapRecord(track, carModel, propLapTimeList[0].TotalMilliseconds, lapDeltaLast, csvAdress, csvIndex);
                        findLapRecord = true;
                    }

                    propLapTimeList.RemoveAt(8); //Making sure list doesnt grow untill infinity
                }
                lastLapHolder = lastLapTime;

                //Sectors
                propSector1StatusList.Insert(0, sector1StatusHolder);
                propSector1StatusList.RemoveAt(8);
                propSector1TimeList.Insert(0, sector1TimeHolder);
                if ((propSector1TimeList[0] < propSessionBestSector1 || propSessionBestSector1 == 0) && propSector1StatusList[0] == 1)
                {
                    propSessionBestSector1 = propSector1TimeList[0];
                }
                propSector1TimeList.RemoveAt(8);

                propSector2StatusList.Insert(0, currentSector2Status);
                propSector2StatusList.RemoveAt(8);
                propSector2TimeList.Insert(0, currentSector2Time);
                if ((propSector2TimeList[0] < propSessionBestSector2 || propSessionBestSector2 == 0) && propSector2StatusList[0] == 1)
                {
                    propSessionBestSector2 = propSector2TimeList[0];
                }
                propSector2TimeList.RemoveAt(8);

                propSector3StatusList.Insert(0, lastSectorStatusHolder);
                propSector3StatusList.RemoveAt(8);
                propSector3TimeList.Insert(0, propLapTimeList[0].TotalSeconds - sector1TimeHolder - currentSector2Time);
                currentSector3Time = propSector3TimeList[0];
                Base.SetProp("CurrentSector3Time", TimeSpan.FromSeconds(currentSector3Time));
                if (currentSector3Time > 0 && propSessionBestSector3 > 0)
                {
                    double delta = currentSector3Time - propSessionBestSector3;
                    Base.SetProp("CurrentSector3Delta", Math.Round(delta, 3));
                }
                else
                {
                    Base.SetProp("CurrentSector3Delta", 0);
                }
                if ((propSector3TimeList[0] < propSessionBestSector3 || propSessionBestSector3 == 0) && propSector3StatusList[0] == 1)
                {
                    propSessionBestSector3 = propSector3TimeList[0];
                }
                propSector3TimeList.RemoveAt(8);

                currentSector1Time = 0;
                currentSector2Time = 0;
                currentSector3Time = 0;

                if (lastStatusHolder != 3)
                {
                    propFuelTargetDeltas.Insert(0, fuelTargetDelta);
                    propFuelTargetDeltas.RemoveAt(8);

                    fuelTargetDeltaCumulative = fuelTargetDeltaCumulative + fuelTargetDelta;
                }
            }


            if (Base.counter == 17)
            {
                Hotlap();
            }

            //----------------------------------------------------
            //---------Pit box location calculations--------------
            //----------------------------------------------------

            PitBox();

            //---------------------------------------------------------------
            //-------------Pace calculation, once pr. second-----------------
            //---------------------------------------------------------------


            if (Base.counter == 30) //Race pace pr lap
            {
                List<double> lapListSeconds = new List<double> { };
                double fastLap = 0;
                for (int i = 0; i < propLapTimeList.Count; i++)
                {
                    lapListSeconds.Add(propLapTimeList[i].TotalSeconds);
                    if (fastLap == 0 || lapListSeconds[i] != 0 && lapListSeconds[i] < fastLap)
                    {
                        fastLap = lapListSeconds[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                for (int i = 0; i < propLapTimeList.Count; i++)
                {
                    if ((propLapStatusList[i] < 3 && propLapStatusList[i] != 0) && !(lapListSeconds[i] > (fastLap + 8) && lapListSeconds[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
                    {
                        if (lapListSeconds[i] < thresholdLap)
                        {
                            fastList.Add(lapListSeconds[i]);
                        }
                        else
                        {
                            slowList.Add(lapListSeconds[i]);
                        }
                    }
                }

                pace = fastList.Count > 0 ? fastList.Average() : 0.0;

                if (lapListSeconds.Count > 1)
                {
                    if (lapListSeconds[0] > thresholdLap && lapListSeconds[1] > thresholdLap && propLapStatusList[0] < 3 && propLapStatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (lapListSeconds[0] < fastLap * 1.005 && lapListSeconds[1] < fastLap * 1.005 && propLapStatusList[0] == 1 && propLapStatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
                    {
                        pace = (fastList[0] + fastList[1]) / 2;
                    }
                }
                TimeSpan paceTime = TimeSpan.FromSeconds(pace);

                Base.SetProp("Pace", paceTime);

                if (sessionBestLap.TotalSeconds > 0)
                {
                    for (int i = 0; i < lapListSeconds.Count; i++)
                    {
                        double delta = Math.Round(lapListSeconds[i] - sessionBestLap.TotalSeconds, 3);
                        if (lapListSeconds[i] > 0)
                        {
                            Base.SetProp("Lap0" + (i + 1) + "Delta", delta);
                        }
                    }
                }


            }

            if (Base.counter == 33) //Sector 1 pace
            {
                double fastLap = 0;
                for (int i = 0; i < propSector1TimeList.Count; i++)
                {
                    if (fastLap == 0 || propSector1TimeList[i] != 0 && propSector1TimeList[i] < fastLap)
                    {
                        fastLap = propSector1TimeList[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                double sectorAverage = 0;
                int sectorAverageCounter = 0;
                for (int i = 0; i < propSector1TimeList.Count; i++)
                {
                    if (propSector1StatusList[i] < 3 && propSector1StatusList[i] != 0)
                    {
                        sectorAverage = sectorAverage + propSector1TimeList[i];
                        sectorAverageCounter++;
                    }
                    if ((propSector1StatusList[i] < 3 && propSector1StatusList[i] != 0) && !(propSector1TimeList[i] > (fastLap + 8) && propSector1TimeList[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
                    {
                        if (propSector1TimeList[i] < thresholdLap)
                        {
                            fastList.Add(propSector1TimeList[i]);
                        }
                        else
                        {
                            slowList.Add(propSector1TimeList[i]);
                        }
                    }
                }

                sector1Pace = fastList.Count > 0 ? fastList.Average() : 0.0;

                sectorAverage = sectorAverage / sectorAverageCounter;

                double sum = 0;
                int invalids = 0;
                int valids = 0;
                double sectorVariance = 0;
                double sectorScore = 0;
                for (int i = 0; i < propSector1TimeList.Count; i++)
                {
                    if (propSector1StatusList[i] < 3 && propSector1StatusList[i] != 0)
                    {
                        if (propSector1StatusList[i] == 1)
                        {
                            valids++;
                        }
                        if (propSector1StatusList[i] == 2)
                        {
                            invalids++;
                        }
                        sum = sum + ((propSector1TimeList[i] - sectorAverage) * (propSector1TimeList[i] - sectorAverage));
                    }
                }

                if (sectorAverageCounter > 2)
                {
                    sectorVariance = Math.Sqrt(sum / sectorAverageCounter);
                    sectorScore = 10 / ((1 + sectorVariance) * (1 + (invalids / (valids + invalids))));
                    sectorScore = Math.Round(sectorScore - ((8 - valids - invalids) * 0.4), 1);
                    if (sectorScore < 0)
                    {
                        sectorScore = 0.1;
                    }
                }

                if (propSector1TimeList.Count > 1)
                {
                    if (propSector1TimeList[0] > thresholdLap && propSector1TimeList[1] > thresholdLap && propSector1StatusList[0] < 3 && propSector1StatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        sector1Pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (propSector1TimeList[0] < fastLap * 1.005 && propSector1TimeList[1] < fastLap * 1.005 && propSector1StatusList[0] == 1 && propSector1StatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
                    {
                        sector1Pace = (fastList[0] + fastList[1]) / 2;
                    }
                }

                Base.SetProp("Sector1Pace", TimeSpan.FromSeconds(sector1Pace));
                Base.SetProp("Sector1Score", sectorScore);

            }

            if (Base.counter == 43) //Sector 2 pace
            {
                double fastLap = 0;
                for (int i = 0; i < propSector2TimeList.Count; i++)
                {
                    if (fastLap == 0 || propSector2TimeList[i] != 0 && propSector2TimeList[i] < fastLap)
                    {
                        fastLap = propSector2TimeList[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                double sectorAverage = 0;
                int sectorAverageCounter = 0;
                for (int i = 0; i < propSector2TimeList.Count; i++)
                {
                    if (propSector2StatusList[i] < 3 && propSector2StatusList[i] != 0)
                    {
                        sectorAverage = sectorAverage + propSector2TimeList[i];
                        sectorAverageCounter++;
                    }
                    if ((propSector2StatusList[i] < 3 && propSector2StatusList[i] != 0) && !(propSector2TimeList[i] > (fastLap + 8) && propSector2TimeList[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
                    {
                        if (propSector2TimeList[i] < thresholdLap)
                        {
                            fastList.Add(propSector2TimeList[i]);
                        }
                        else
                        {
                            slowList.Add(propSector2TimeList[i]);
                        }
                    }
                }

                sector2Pace = fastList.Count > 0 ? fastList.Average() : 0.0;

                sectorAverage = sectorAverage / sectorAverageCounter;

                double sum = 0;
                int invalids = 0;
                int valids = 0;
                double sectorVariance = 0;
                double sectorScore = 0;

                for (int i = 0; i < propSector2TimeList.Count; i++)
                {
                    if (propSector2StatusList[i] < 3 && propSector2StatusList[i] != 0)
                    {
                        if (propSector2StatusList[i] == 1)
                        {
                            valids++;
                        }
                        if (propSector2StatusList[i] == 2)
                        {
                            invalids++;
                        }
                        sum = sum + ((propSector2TimeList[i] - sectorAverage) * (propSector2TimeList[i] - sectorAverage));
                    }
                }

                if (sectorAverageCounter > 2)
                {
                    sectorVariance = Math.Sqrt(sum / sectorAverageCounter);
                    sectorScore = 10 / ((1 + sectorVariance) * (1 + (invalids / (valids + invalids))));
                    sectorScore = Math.Round(sectorScore - ((8 - valids - invalids) * 0.4), 1);
                    if (sectorScore < 0)
                    {
                        sectorScore = 0.1;
                    }
                }

                if (propSector2TimeList.Count > 1)
                {
                    if (propSector2TimeList[0] > thresholdLap && propSector2TimeList[1] > thresholdLap && propSector2StatusList[0] < 3 && propSector2StatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        sector2Pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (propSector2TimeList[0] < fastLap * 1.005 && propSector2TimeList[1] < fastLap * 1.005 && propSector2StatusList[0] == 1 && propSector2StatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
                    {
                        sector2Pace = (fastList[0] + fastList[1]) / 2;
                    }
                }

                Base.SetProp("Sector2Pace", TimeSpan.FromSeconds(sector2Pace));
                Base.SetProp("Sector2Score", sectorScore);

            }

            if (Base.counter == 53) //Sector 3 pace
            {
                double fastLap = 0;
                for (int i = 0; i < propSector3TimeList.Count; i++)
                {
                    if (fastLap == 0 || propSector3TimeList[i] != 0 && propSector3TimeList[i] < fastLap)
                    {
                        fastLap = propSector3TimeList[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                double sectorAverage = 0;
                int sectorAverageCounter = 0;
                for (int i = 0; i < propSector3TimeList.Count; i++)
                {
                    if (propSector3StatusList[i] < 3 && propSector3StatusList[i] != 0)
                    {
                        sectorAverage = sectorAverage + propSector3TimeList[i];
                        sectorAverageCounter++;
                    }
                    if ((propSector3StatusList[i] < 3 && propSector3StatusList[i] != 0) && !(propSector3TimeList[i] > (fastLap + 8) && propSector3TimeList[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
                    {
                        if (propSector3TimeList[i] < thresholdLap)
                        {
                            fastList.Add(propSector3TimeList[i]);
                        }
                        else
                        {
                            slowList.Add(propSector3TimeList[i]);
                        }
                    }
                }

                sector3Pace = fastList.Count > 0 ? fastList.Average() : 0.0;

                sectorAverage = sectorAverage / sectorAverageCounter;

                double sum = 0;
                int invalids = 0;
                int valids = 0;
                double sectorVariance = 0;
                double sectorScore = 0;

                for (int i = 0; i < propSector3TimeList.Count; i++)
                {
                    if (propSector3StatusList[i] < 3 && propSector3StatusList[i] != 0)
                    {
                        if (propSector3StatusList[i] == 1)
                        {
                            valids++;
                        }
                        if (propSector3StatusList[i] == 2)
                        {
                            invalids++;
                        }
                        sum = sum + ((propSector3TimeList[i] - sectorAverage) * (propSector3TimeList[i] - sectorAverage));
                    }
                }

                if (sectorAverageCounter > 2)
                {
                    sectorVariance = Math.Sqrt(sum / sectorAverageCounter);
                    sectorScore = 10 / ((1 + sectorVariance) * (1 + (invalids / (valids + invalids))));
                    sectorScore = Math.Round(sectorScore - ((8 - valids - invalids) * 0.4), 1);
                    if (sectorScore < 0)
                    {
                        sectorScore = 0.1;
                    }
                }

                if (propSector3TimeList.Count > 1)
                {
                    if (propSector3TimeList[0] > thresholdLap && propSector3TimeList[1] > thresholdLap && propSector3StatusList[0] < 3 && propSector3StatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        sector3Pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (propSector3TimeList[0] < fastLap * 1.005 && propSector3TimeList[1] < fastLap * 1.005 && propSector3StatusList[0] == 1 && propSector3StatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
                    {
                        sector3Pace = (fastList[0] + fastList[1]) / 2;
                    }
                }

                Base.SetProp("Sector3Pace", TimeSpan.FromSeconds(sector3Pace));
                Base.SetProp("Sector3Score", sectorScore);
            }

            //----------------------------------------------------------------
            //------------Updating delta values, once pr. second--------------
            //----------------------------------------------------------------

            SectorDelta(1, propSessionBestSector1, propSector1TimeList);
            SectorDelta(2, propSessionBestSector2, propSector2TimeList);
            SectorDelta(3, propSessionBestSector3, propSector3TimeList);

            //---------------------------------------------------------------
            //------Real position calculations, twice pr. second-------------
            //---------------------------------------------------------------

            if (Base.counter == 15 || Base.counter == 45)
            {
                isRaceLeader = false;
                propRealPosition = 1;

                if (session == "Lone Qualify" || session == "Open Qualify")
                {
                    qualyPosition = myPosition;
                    propRealPosition = myPosition;
                    propHotLapPosition = myPosition;
                }

                else if (session == "Race" && opponents > 1)
                {
                    isRaceLeader = true;

                    for (int i = 0; i < opponents; i++)
                    {
                        if (Base.gameData.NewData.Opponents[i].GaptoPlayer < 0)
                        {
                            isRaceLeader = false;
                            if (Base.gameData.NewData.Opponents[i].CarClass == myClass)
                            {
                                propRealPosition++;
                            }
                        }
                        propHotLapPosition = 1;
                        if (Base.gameData.NewData.Opponents[i].BestLapTime.TotalSeconds < sessionBestLap.TotalSeconds && Base.gameData.NewData.Opponents[i].BestLapTime.TotalSeconds > 0)
                        {
                            propHotLapPosition++;
                        }
                        if (sessionBestLap.TotalSeconds == 0)
                        {
                            propHotLapPosition = opponents;
                        }
                    }

                    if (Base.gameData.NewData.Opponents[0].GaptoPlayer == null && Base.gameData.NewData.Opponents[1].GaptoPlayer == null)
                    {
                        if (aheadClass == myClass && aheadGap != 0)
                        {
                            propRealPosition = aheadClassPosition + 1;
                        }
                        if (aheadClass != myClass || aheadGap == 0)
                        {
                            propRealPosition = myPosition;
                        }
                    }
                    if (currentLapTime.TotalSeconds == 0 && qualyPosition > 0)
                    {
                        propRealPosition = qualyPosition;
                    }
                    if (currentLapTime.TotalSeconds == 0 && qualyPosition == 0)
                    {
                        propRealPosition = myPosition;
                    }
                    if (currentLapTime.TotalSeconds > 0)
                    {
                        qualyPosition = 0;
                    }

                    if (checkered == 1 && ((trackPosition > 0.1 && trackPosition < 0.15) || (currentLapTime.TotalSeconds > 5 && currentLapTime.TotalSeconds < 10)))
                    {
                        propRaceFinished = true;
                    }
                    if ((lapRaceFinished || timeRaceFinished)) //Identify all cars with one lap more finished - keep in list, cannot decrement if players DC. 
                    {
                        int position = 1;

                        for (int i = 0; i < opponents; i++)
                        {
                            if (finishedCars.IndexOf(Base.gameData.NewData.Opponents[i].CarNumber) < 0 && Base.gameData.NewData.Opponents[i].CurrentLap > currentLap && myClass == Base.gameData.NewData.Opponents[i].CarClass)
                            {
                                finishedCars.Add(Base.gameData.NewData.Opponents[i].CarNumber);
                            }

                            if (Base.gameData.NewData.Opponents[i].CurrentLap == currentLap && Base.gameData.NewData.Opponents[i].GaptoPlayer < 0 && myClass == Base.gameData.NewData.Opponents[i].CarClass)
                            {
                                position++;
                            }
                        }

                        propRealPosition = position + finishedCars.Count;
                    }
                    if ((lapRaceFinished || timeRaceFinished) && trackPosition < 0.1 && checkered == 1)
                    {
                        propRealPosition = 1 + finishedCars.Count;
                    }

                    if (propRaceFinished)
                    {
                        propRealPosition = myPosition;
                    }

                }
                else
                {
                    propRealPosition = myPosition;
                    propHotLapPosition = myPosition;

                }

            }

            //-------------------------------------------------
            //----Opponents calculations and remaining laps----
            //-------------------------------------------------

            if (Base.counter == 5 || Base.counter == 20 || Base.counter == 35 || Base.counter == 50)
            {
                //Declaring and resetting

                double? leaderGap = 0;
                string leaderName = "";
                int? leaderCurrentLap = 0;
                TimeSpan leaderLastLap = new TimeSpan(0);
                TimeSpan leaderBestLap = new TimeSpan(0);
                double? leaderTrackPosition = 0;

                double? classLeaderGap = 0;
                classLeaderName = "";
                TimeSpan classLeaderLastLap = new TimeSpan(0);
                TimeSpan classLeaderBestLap = new TimeSpan(0);

                double? aheadGap = 0;
                string aheadName = "";
                aheadGlobal = aheadName;
                TimeSpan aheadLastLap = new TimeSpan(0);
                TimeSpan aheadBestLap = new TimeSpan(0);
                bool aheadIsConnected = false;
                bool aheadIsInPit = false;
                bool aheadSlowLap = false;
                int aheadOvertakePrediction = 0;
                int aheadLapsSincePit = -1;
                int aheadP2PCount = -1;
                bool aheadP2PActive = false;
                double? aheadRealGap = 0;

                double? behindGap = 0;
                string behindName = "";
                behindGlobal = behindName;
                TimeSpan behindLastLap = new TimeSpan(0);
                TimeSpan behindBestLap = new TimeSpan(0);
                bool behindIsConnected = false;
                bool behindIsInPit = false;
                bool behindSlowLap = false;
                int behindOvertakePrediction = 0;
                int behindLapsSincePit = -1;
                int behindP2PCount = -1;
                bool behindP2PActive = false;
                double? behindRealGap = 0;

                double? luckyDogRealGap = 0;
                double? luckyDogGap = 0;
                string luckyDogName = "";
                int luckyDogPositionsAhead = 0;

                remainingLaps = 0;

                int gridSubtract = 0;

                double totalSessionTime = irData.SessionData.SessionInfo.Sessions[sessionNumber]._SessionTime;                          //Total session time of the session
                long completedRaceLaps = irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsLapsComplete;                    //To use for identifying lap race finish

                double timeLeftSeconds = timeLeft.TotalSeconds;

                if (Base.Settings.CorrectByPitstop && !onlyThrough)
                {
                    timeLeftSeconds = timeLeftSeconds - pitStopDuration;
                }

                propQLap1Status = 0;
                propQLap2Status = 0;
                Base.SetProp("QualyLap1Time", new TimeSpan(0));
                Base.SetProp("QualyLap2Time", new TimeSpan(0));
                propWarmup = false;


                for (int i = 0; i < opponents; i++)
                {
                    if (Base.gameData.NewData.Opponents[i].GaptoPlayer < classLeaderGap && Base.gameData.NewData.Opponents[i].CarClass == myClass)
                    {
                        classLeaderGap = Base.gameData.NewData.Opponents[i].GaptoPlayer;
                        classLeaderName = Base.gameData.NewData.Opponents[i].Name;
                        classLeaderLastLap = Base.gameData.NewData.Opponents[i].LastLapTime;
                        classLeaderBestLap = Base.gameData.NewData.Opponents[i].BestLapTime;
                    }
                    if (Base.gameData.NewData.Opponents[i].GaptoPlayer < leaderGap)
                    {
                        leaderGap = Base.gameData.NewData.Opponents[i].GaptoPlayer;
                        leaderName = Base.gameData.NewData.Opponents[i].Name;
                        leaderCurrentLap = Base.gameData.NewData.Opponents[i].CurrentLap;
                        leaderLastLap = Base.gameData.NewData.Opponents[i].LastLapTime;
                        leaderBestLap = Base.gameData.NewData.Opponents[i].BestLapTime;
                        leaderTrackPosition = Base.gameData.NewData.Opponents[i].TrackPositionPercent;
                    }
                    if (Base.gameData.NewData.Opponents[i].GaptoPlayer < 0 && (aheadGap == 0 || Base.gameData.NewData.Opponents[i].GaptoPlayer > aheadGap))
                    {
                        aheadGap = Base.gameData.NewData.Opponents[i].GaptoPlayer;
                        aheadName = Base.gameData.NewData.Opponents[i].Name;
                        aheadLastLap = Base.gameData.NewData.Opponents[i].LastLapTime;
                        aheadBestLap = Base.gameData.NewData.Opponents[i].BestLapTime;
                        aheadIsConnected = Base.gameData.NewData.Opponents[i].IsConnected;
                        aheadIsInPit = Base.gameData.NewData.Opponents[i].IsCarInPit;
                    }
                    else if (Base.gameData.NewData.Opponents[i].GaptoPlayer > 0 && (behindGap == 0 || Base.gameData.NewData.Opponents[i].GaptoPlayer < behindGap))
                    {
                        behindGap = Base.gameData.NewData.Opponents[i].GaptoPlayer;
                        behindName = Base.gameData.NewData.Opponents[i].Name;
                        behindLastLap = Base.gameData.NewData.Opponents[i].LastLapTime;
                        behindBestLap = Base.gameData.NewData.Opponents[i].BestLapTime;
                        behindIsConnected = Base.gameData.NewData.Opponents[i].IsConnected;
                        behindIsInPit = Base.gameData.NewData.Opponents[i].IsCarInPit;
                    }
                    if ((leaderCurrentLap + leaderTrackPosition) - (Base.gameData.NewData.Opponents[i].TrackPositionPercent + Base.gameData.NewData.Opponents[i].CurrentLap) > 1 && Base.gameData.NewData.Opponents[i].CarClass == myClass && (luckyDogGap == 0 || Base.gameData.NewData.Opponents[i].GaptoLeader < luckyDogGap))
                    {
                        luckyDogGap = Base.gameData.NewData.Opponents[i].GaptoPlayer;
                        luckyDogName = Base.gameData.NewData.Opponents[i].Name;
                        if (Base.gameData.NewData.Opponents[i].GaptoPlayer < 0)
                        {
                            luckyDogPositionsAhead++;
                        }
                    }
                    else if ((leaderCurrentLap + leaderTrackPosition) - (Base.gameData.NewData.Opponents[i].TrackPositionPercent + Base.gameData.NewData.Opponents[i].CurrentLap) > 1 && Base.gameData.NewData.Opponents[i].CarClass == myClass && Base.gameData.NewData.Opponents[i].GaptoPlayer < 0)
                    {
                        luckyDogPositionsAhead++;
                    }
                    if ((leaderCurrentLap + leaderTrackPosition) - (currentLap + trackPosition) > 1 && luckyDogGap > 0)
                    {
                        luckyDogGap = 0;
                        luckyDogName = Base.gameData.NewData.PlayerName;
                        luckyDogPositionsAhead = 0;
                    }

                }

                bool inaccurateCalculations = false;

                myExpectedLapTime = pace;

                if (propLapRecord.TotalSeconds == 0 || (pace > 0 && pace > propLapRecord.TotalSeconds * 1.05))
                {
                    inaccurateCalculations = true;
                }

                if (myExpectedLapTime == 0)
                {
                    myExpectedLapTime = propLapRecord.TotalSeconds * 1.05;
                    inaccurateCalculations = true;
                }
                if (myExpectedLapTime == 0)
                {
                    myExpectedLapTime = trackLength / 40;
                    inaccurateCalculations = true;
                }

                lapLapsRemaining = totalLaps - currentLap;
                timeLapsRemaining = timeLeftSeconds / myExpectedLapTime + trackPosition - 1;

                Base.SetProp("ApproximateCalculations", inaccurateCalculations);

                Base.SetProp("P1Gap", leaderGap);
                Base.SetProp("P1Name", leaderName);
                Base.SetProp("ClassP1Gap", classLeaderGap);
                Base.SetProp("ClassP1Name", classLeaderName);
                if (propTrackType > 4)
                {
                    Base.SetProp("LuckyDogGap", luckyDogGap);
                    Base.SetProp("LuckyDogName", luckyDogName);
                    Base.SetProp("LuckyDogPositionsAhead", luckyDogPositionsAhead);
                }

                //Leader lap times
                double leaderExpectedLapTime = (leaderLastLap.TotalSeconds * 2 + leaderBestLap.TotalSeconds) / 3;
                if (leaderLastLap.TotalSeconds == 0)
                {
                    leaderExpectedLapTime = leaderBestLap.TotalSeconds * 1.01;
                }
                if (leaderBestLap.TotalSeconds == 0)
                {
                    leaderExpectedLapTime = leaderLastLap.TotalSeconds;
                }

                double classLeaderExpectedLapTime = (classLeaderLastLap.TotalSeconds * 2 + classLeaderBestLap.TotalSeconds) / 3;
                if (classLeaderLastLap.TotalSeconds == 0)
                {
                    classLeaderExpectedLapTime = classLeaderBestLap.TotalSeconds * 1.01;
                }
                if (classLeaderBestLap.TotalSeconds == 0)
                {
                    classLeaderExpectedLapTime = classLeaderLastLap.TotalSeconds;
                }
                TimeSpan classLeaderPace = TimeSpan.FromSeconds(classLeaderExpectedLapTime);
                TimeSpan leaderPace = TimeSpan.FromSeconds(leaderExpectedLapTime);

                Base.SetProp("P1Pace", leaderPace);
                Base.SetProp("ClassP1Pace", classLeaderPace);

                if (session == "Race") //Race sessions exemptions
                {
                    leaderDecimal = 0;

                    if (sessionState < 4)
                    {
                        propOffTrack = false;
                        offTrackTimer = globalClock;
                        timeLeftSeconds = totalSessionTime;
                        if (trackPosition > 0.5 || trackPosition == 0)
                        {
                            gridSubtract = 1;
                        }
                    }

                    if (timeLeft.TotalSeconds == 0 && completedLaps > 0)
                    {
                        timedOut = true;
                    }
                    if (timedOut || timeLeftSeconds < 0)
                    {
                        timeLeftSeconds = 0;
                    }

                    //Leader finishing race in lap based race
                    if (completedRaceLaps == totalLaps)
                    {
                        lapRaceFinished = true;
                    }
                    //Leader finishing race in a time based race
                    if (!timedOut)
                    {
                        timeBasedChecker = true;
                        timeLapCounter = leaderCurrentLap;
                    }
                    if (leaderCurrentLap > timeLapCounter && timeBasedChecker)
                    {
                        timeBasedChecker = false;
                        timeRaceFinished = true;
                    }

                    if (leaderExpectedLapTime == 0)
                    {
                        timeLapsRemaining = (timeLeftSeconds / myExpectedLapTime) + trackPosition - 1; //No grid subtract
                        lapLapsRemaining = lapLapsRemaining + gridSubtract;
                    }

                    //Continuing calculations if we have leader pace and my pace --- and I'm not the leader. 
                    if (leaderExpectedLapTime > 0 && !isRaceLeader)
                    {
                        //Lap limited session calculations

                        double? leaderRaceTime = leaderExpectedLapTime * (totalLaps - leaderCurrentLap + 1 - leaderTrackPosition);
                        double? lapsWhileLeaderRace = leaderRaceTime / myExpectedLapTime;
                        lapLapsRemaining = lapsWhileLeaderRace + trackPosition;

                        //Time limited session calculations
                        double? leaderTimeOut = (timeLeftSeconds / leaderExpectedLapTime) + leaderTrackPosition;
                        leaderDecimal = leaderTimeOut - ((int)(leaderTimeOut * 100)) / 100;
                        double? timeUntillLeaderCheckered = leaderExpectedLapTime * (leaderTimeOut + (1 - leaderDecimal) - leaderTrackPosition);
                        timeLapsRemaining = (timeUntillLeaderCheckered / myExpectedLapTime) + trackPosition;
                        if (isTimeLimited)
                        {
                            Base.SetProp("P1LapBalance", leaderDecimal);
                        }
                    }
                    else
                    {
                        Base.SetProp("P1LapBalance", 0);
                    }

                    remainingLaps = lapLapsRemaining;
                    isLapLimited = irData.SessionData.SessionInfo.Sessions[sessionNumber].IsLimitedSessionLaps;
                    isTimeLimited = irData.SessionData.SessionInfo.Sessions[sessionNumber].IsLimitedTime;

                    if (isLapLimited && isTimeLimited) //Session is both lap and time limited
                    {
                        if (timeLapsRemaining < lapLapsRemaining + 1)
                        {
                            remainingLaps = timeLapsRemaining;
                        }
                    }
                    else if (isTimeLimited) //Session is strictly time limited
                    {
                        remainingLaps = timeLapsRemaining;
                    }
                    else //Session is strictly lap limited
                    {
                        leaderDecimal = 0;
                        Base.SetProp("P1LapBalance", 0);
                    }
                    if (lapRaceFinished || timeRaceFinished)
                    {
                        remainingLaps = 0;
                        Base.SetProp("P1Finished", true);
                        Base.SetProp("P1LapBalance", 0);
                    }
                    else
                    {
                        Base.SetProp("P1Finished", false);
                    }
                }

                else if (session == "Lone Qualify") //Qlap status: 1 - Waiting, 2 - Valid lap, not completed. 3 - Ruined lap, completed or not. 4 - Finished valid lap
                {

                    if (((timeLeftSeconds / myExpectedLapTime) + trackPosition - 1) > lapLapsRemaining + 1)
                    {
                        remainingLaps = lapLapsRemaining + 0.99;
                    }
                    else
                    {
                        remainingLaps = (timeLeftSeconds / myExpectedLapTime) + trackPosition - 1;
                    }

                }

                else if (session == "Offline Testing")
                {
                    remainingLaps = 0;
                }
                else
                {
                    remainingLaps = timeLapsRemaining;
                    if (isLapLimited)
                    {
                        remainingLaps = lapLapsRemaining;
                    }
                }

                int truncRemainingLaps = ((int)(remainingLaps * 100)) / 100;
                double? lapBalance = remainingLaps - truncRemainingLaps;


                Base.SetProp("LapsRemaining", truncRemainingLaps);
                Base.SetProp("LapBalance", lapBalance);

                Base.SetProp("AheadPace", new TimeSpan(0));
                Base.SetProp("AheadSlowLap", false);
                Base.SetProp("AheadPrognosis", 0);
                Base.SetProp("AheadLapsToOvertake", -1);
                Base.SetProp("AheadLapsSincePit", -1);
                Base.SetProp("AheadP2PStatus", false);
                Base.SetProp("AheadP2PCount", -1);

                Base.SetProp("BehindPace", new TimeSpan(0));
                Base.SetProp("BehindSlowLap", false);
                Base.SetProp("BehindPrognosis", 0);
                Base.SetProp("BehindLapsToOvertake", -1);
                Base.SetProp("BehindLapsSincePit", -1);
                Base.SetProp("BehindP2PStatus", false);
                Base.SetProp("BehindP2PCount", -1);

                Base.SetProp("AheadName", "");
                Base.SetProp("AheadGap", 0);
                Base.SetProp("AheadBestLap", new TimeSpan(0));
                Base.SetProp("AheadIsConnected", false);
                Base.SetProp("AheadIsInPit", true);
                Base.SetProp("AheadRealGap", 0);

                Base.SetProp("BehindName", "");
                Base.SetProp("BehindGap", 0);
                Base.SetProp("BehindBestLap", new TimeSpan(0));
                Base.SetProp("BehindIsConnected", false);
                Base.SetProp("BehindIsInPit", true);
                Base.SetProp("BehindRealGap", 0);

                Base.SetProp("ClassP1RealGap", 0);

                if (session == "Race")
                {
                    Base.SetProp("AheadName", aheadName);
                    Base.SetProp("AheadGap", aheadGap);
                    Base.SetProp("AheadBestLap", aheadBestLap);
                    Base.SetProp("AheadIsConnected", aheadIsConnected);
                    Base.SetProp("AheadIsInPit", aheadIsInPit);

                    Base.SetProp("BehindName", behindName);
                    Base.SetProp("BehindGap", behindGap);
                    Base.SetProp("BehindBestLap", behindBestLap);
                    Base.SetProp("BehindIsConnected", behindIsConnected);
                    Base.SetProp("BehindIsInPit", behindIsInPit);

                    //Calculations of ahead and behind drivers + lucky dog

                    for (int e = 0; e < irData.SessionData.DriverInfo.CompetingDrivers.Length; e++)
                    {
                        if (aheadName == irData.SessionData.DriverInfo.CompetingDrivers[e].UserName)
                        {
                            int carID = Convert.ToInt16(irData.SessionData.DriverInfo.CompetingDrivers[e].CarIdx);

                            aheadRealGap = realGapOpponentDelta[carID];

                            if ((aheadRealGap > aheadGap * 1.25 && aheadRealGap - aheadGap > 10) || (aheadRealGap < aheadGap * 0.75 && aheadRealGap - aheadGap < -10) || aheadRealGap >= 0)
                            {
                                aheadRealGap = aheadGap;
                            }
                            aheadLapsSincePit = sessionCarsLapsSincePit[carID];
                            if (p2pCount != null)
                            {
                                aheadP2PCount = ((int[])p2pCount)[carID];
                            }
                            else
                            {
                                aheadP2PCount = -1;
                            }
                            if (p2pStatus != null)
                            {
                                aheadP2PActive = ((bool[])p2pStatus)[carID];
                            }
                            else
                            {
                                aheadP2PActive = false;
                            }

                            break;
                        }
                    }

                    for (int i = 0; i < irData.SessionData.DriverInfo.CompetingDrivers.Length; i++)
                    {
                        if (behindName == irData.SessionData.DriverInfo.CompetingDrivers[i].UserName)
                        {
                            int carID = Convert.ToInt16(irData.SessionData.DriverInfo.CompetingDrivers[i].CarIdx);
                            behindRealGap = realGapOpponentDelta[carID];

                            if ((behindRealGap > behindGap * 1.25 && behindRealGap - behindGap > 10) || (behindRealGap < behindGap * 0.75 && behindRealGap - behindGap < -10) || behindRealGap <= 0)
                            {
                                behindRealGap = behindGap;
                            }

                            behindLapsSincePit = sessionCarsLapsSincePit[carID];
                            if (p2pCount != null)
                            {
                                behindP2PCount = ((int[])p2pCount)[carID];
                            }
                            else
                            {
                                behindP2PCount = -1;
                            }
                            if (p2pStatus != null)
                            {
                                behindP2PActive = ((bool[])p2pStatus)[carID];
                            }
                            else
                            {
                                behindP2PActive = false;
                            }

                            break;

                        }
                    }

                    for (int i = 0; i < irData.SessionData.DriverInfo.CompetingDrivers.Length; i++)
                    {
                        if (luckyDogName == irData.SessionData.DriverInfo.CompetingDrivers[i].UserName)
                        {
                            int carID = Convert.ToInt16(irData.SessionData.DriverInfo.CompetingDrivers[i].CarIdx);
                            luckyDogRealGap = realGapOpponentDelta[carID];

                            if ((luckyDogRealGap > luckyDogGap * 1.25 && luckyDogRealGap - luckyDogGap > 10) || (luckyDogRealGap < luckyDogGap * 0.75 && luckyDogRealGap - luckyDogGap < -10) || luckyDogRealGap <= 0)
                            {
                                luckyDogRealGap = luckyDogGap;
                            }

                            break;

                        }
                    }
                    if ((leaderCurrentLap + leaderTrackPosition) - (currentLap + trackPosition) > 1 && luckyDogGap > 0)
                    {
                        luckyDogRealGap = 0;
                    }

                    //Calculate class P1 real gap

                    for (int e = 0; e < irData.SessionData.DriverInfo.CompetingDrivers.Length; e++)
                    {
                        if (classLeaderName == irData.SessionData.DriverInfo.CompetingDrivers[e].UserName)
                        {
                            int carID = Convert.ToInt16(irData.SessionData.DriverInfo.CompetingDrivers[e].CarIdx);

                            if (carID == myCarIdx)
                            {
                                classLeaderRealGap = 0;
                                break;
                            }

                            classLeaderRealGap = realGapOpponentDelta[carID];

                            if ((classLeaderRealGap > classLeaderGap * 1.25 && classLeaderRealGap - classLeaderGap > 10) || (classLeaderRealGap < classLeaderGap * 0.75 && classLeaderRealGap - classLeaderGap < -10) || classLeaderRealGap >= 0)
                            {
                                classLeaderRealGap = classLeaderGap;
                            }

                            break;
                        }
                    }
                    if (propTrackType > 4)
                    {
                        Base.SetProp("LuckyDogRealGap", luckyDogRealGap);
                    }
                    Base.SetProp("ClassP1RealGap", classLeaderRealGap);

                    double overtakeThreshold = -0.5;

                    double aheadBestLapSeconds = aheadBestLap.TotalSeconds;
                    double aheadLastLapSeconds = aheadLastLap.TotalSeconds;
                    double behindBestLapSeconds = behindBestLap.TotalSeconds;
                    double behindLastLapSeconds = behindLastLap.TotalSeconds;


                    if ((aheadBestLapSeconds != 0 || aheadLastLapSeconds != 0) && pace != 0)
                    {
                        double? overtakeGap = aheadRealGap - overtakeThreshold;
                        double aheadPace = (aheadBestLapSeconds + aheadLastLapSeconds * 2) / 3;
                        if (aheadBestLapSeconds == 0)
                        {
                            aheadPace = aheadLastLapSeconds;
                        }

                        if (aheadBestLapSeconds * 1.02 < aheadLastLapSeconds && aheadBestLapSeconds != 0)
                        {
                            aheadPace = aheadLastLapSeconds;
                            aheadSlowLap = true;
                        }

                        double distanceLeft = truncRemainingLaps + (1 - trackPosition);
                        double paceDifference = aheadPace - pace;
                        double? gapOnFinish = overtakeGap + (paceDifference * distanceLeft);
                        double? marginPerLap = gapOnFinish / distanceLeft;

                        if (marginPerLap > 0.7)
                        {
                            aheadOvertakePrediction = 1;
                        }
                        else if (marginPerLap > 0.2)
                        {
                            aheadOvertakePrediction = 2;
                        }
                        else if (marginPerLap > -0.2)
                        {
                            aheadOvertakePrediction = 3;
                        }
                        else if (marginPerLap > -0.7)
                        {
                            aheadOvertakePrediction = 4;
                        }
                        else
                        {
                            aheadOvertakePrediction = 5;
                        }

                        int aheadLapsToOvertake = ((int)(((-overtakeGap / paceDifference) + trackPosition) * 100)) / 100;

                        if (paceDifference < 0 || overtakeGap > -0.5)
                        {
                            aheadLapsToOvertake = -1;
                        }

                        TimeSpan aheadPaceTime = TimeSpan.FromSeconds(aheadPace);

                        Base.SetProp("AheadName", aheadName);
                        Base.SetProp("AheadPace", aheadPaceTime);
                        Base.SetProp("AheadSlowLap", aheadSlowLap);
                        Base.SetProp("AheadPrognosis", aheadOvertakePrediction);
                        Base.SetProp("AheadLapsToOvertake", aheadLapsToOvertake);
                        Base.SetProp("AheadLapsSincePit", aheadLapsSincePit);
                        Base.SetProp("AheadP2PStatus", aheadP2PActive);
                        Base.SetProp("AheadP2PCount", aheadP2PCount);
                        Base.SetProp("AheadRealGap", aheadRealGap);

                        aheadGlobal = aheadName;

                    }

                    if ((behindBestLapSeconds != 0 || behindLastLapSeconds != 0) && pace != 0)
                    {
                        double? overtakeGap = behindRealGap + overtakeThreshold;
                        double behindPace = (behindBestLapSeconds + behindLastLapSeconds * 2) / 3;
                        if (behindBestLapSeconds == 0)
                        {
                            behindPace = behindLastLapSeconds;
                        }

                        if (behindBestLapSeconds * 1.02 < behindLastLapSeconds && behindBestLapSeconds != 0)
                        {
                            behindPace = behindLastLapSeconds;
                            behindSlowLap = true;
                        }

                        double distanceLeft = truncRemainingLaps + (1 - trackPosition);
                        double paceDifference = behindPace - pace;
                        double? gapOnFinish = overtakeGap + (paceDifference * distanceLeft);
                        double? marginPerLap = gapOnFinish / distanceLeft;

                        if (marginPerLap > 0.7)
                        {
                            behindOvertakePrediction = 1;
                        }
                        else if (marginPerLap > 0.2)
                        {
                            behindOvertakePrediction = 2;
                        }
                        else if (marginPerLap > -0.2)
                        {
                            behindOvertakePrediction = 3;
                        }
                        else if (marginPerLap > -0.7)
                        {
                            behindOvertakePrediction = 4;
                        }
                        else
                        {
                            behindOvertakePrediction = 5;
                        }

                        int behindLapsToOvertake = ((int)(((-overtakeGap / paceDifference) + trackPosition) * 100)) / 100;
                        if (paceDifference > 0 || overtakeGap < 0.5)
                        {
                            behindLapsToOvertake = -1;
                        }

                        TimeSpan behindPaceTime = TimeSpan.FromSeconds(behindPace);

                        Base.SetProp("BehindName", behindName);
                        Base.SetProp("BehindPace", behindPaceTime);
                        Base.SetProp("BehindSlowLap", behindSlowLap);
                        Base.SetProp("BehindPrognosis", behindOvertakePrediction);
                        Base.SetProp("BehindLapsSincePit", behindLapsSincePit);
                        Base.SetProp("BehindP2PStatus", behindP2PActive);
                        Base.SetProp("BehindP2PCount", behindP2PCount);
                        Base.SetProp("BehindRealGap", behindRealGap);

                        behindGlobal = behindName;
                    }
                }
            }

            //---------------------------------------------
            //------------LONE QUALY-----------------------
            //---------------------------------------------

            if (session == "Lone Qualify")
            {
                if (currentLapTime.TotalSeconds == 0) //Warmup lap
                {
                    propWarmup = true;
                    lapLapsRemaining = 2;
                    if (pit == 1)
                    {
                        lapLapsRemaining = 3;
                    }
                    propQLap1Status = 1;
                    propQLap2Status = 1;
                }
                else if (completedLaps == 0) //1st Q lap
                {
                    lapLapsRemaining = 1;
                    propQLap1Status = 2;
                    qLap1Time = currentLapTime;
                    if (propLapStatus > 1)
                    {
                        propQLap1Status = 3;
                        qLap1Time = TimeSpan.FromSeconds(0);
                    }
                    qLapStarted2 = false;
                }
                else if (completedLaps == 1) //2nd Q lap
                {
                    if (propLapTimeList.Count > 0)
                    {
                        qLap1Time = propLapTimeList[0];
                    }
                    if (propQLap1Status == 2)
                    {
                        propQLap1Status = 4;
                    }
                    if (currentLapTime.TotalSeconds < 5 || (trackPosition > 0.1 && trackPosition < 0.11))
                    {
                        qLapStarted2 = true;
                    }
                    if (qLapStarted2)
                    {
                        qLap2Time = currentLapTime;
                    }
                    lapLapsRemaining = 0;
                    propQLap2Status = 2;
                    if (propLapStatus > 1)
                    {
                        propQLap2Status = 3;
                        qLap2Time = TimeSpan.FromSeconds(0);
                    }
                }
                else if (completedLaps == 2) //Completed qualy
                {
                    lapLapsRemaining = 0;
                    if (propLapTimeList.Count > 0 && qLap1Time != propLapTimeList[0])
                    {
                        qLap2Time = propLapTimeList[0];
                    }
                    if (propQLap2Status == 2)
                    {
                        propQLap2Status = 4;
                    }
                }

                Base.SetProp("QualyLap1Time", qLap1Time);
                Base.SetProp("QualyLap2Time", qLap2Time);

            }


            //---------------------------------------------
            //-------------AHEAD/BEHIND CARS---------------
            //---------------------------------------------
            if (Base.counter == 9 || Base.counter == 24 || Base.counter == 39 || Base.counter == 54)
            {
                carAheadGap.Clear();
                carAheadRaceGap.Clear();
                carAheadName.Clear();
                carAheadIsInPit.Clear();
                carAheadIsClassLeader.Clear();
                carAheadClassColor.Clear();
                carAheadClassDifference.Clear();
                carAheadIsAhead.Clear();
                carAheadLicence.Clear();
                carAheadiRating.Clear();
                carAheadBestLap.Clear();
                carAheadJokerLaps.Clear();
                carAheadLapsSincePit.Clear();
                carAheadPosition.Clear();
                carAheadP2PCount.Clear();
                carAheadP2PStatus.Clear();
                carAheadRealGap.Clear();
                carAheadRealRelative.Clear();

                carBehindGap.Clear();
                carBehindRaceGap.Clear();
                carBehindName.Clear();
                carBehindIsInPit.Clear();
                carBehindIsClassLeader.Clear();
                carBehindClassColor.Clear();
                carBehindClassDifference.Clear();
                carBehindIsAhead.Clear();
                carBehindLicence.Clear();
                carBehindiRating.Clear();
                carBehindBestLap.Clear();
                carBehindJokerLaps.Clear();
                carBehindLapsSincePit.Clear();
                carBehindPosition.Clear();
                carBehindP2PCount.Clear();
                carBehindP2PStatus.Clear();
                carBehindRealGap.Clear();
                carBehindRealRelative.Clear();

                //Session car lists

                //Checking the list regularly

                for (int i = 0; i < 64; i++)
                {
                    int trackLoc = Convert.ToInt16(irData.Telemetry.CarIdxTrackSurface[i]);

                    if (trackLoc >= 0)
                    {
                        if (trackLoc == 1 || trackLoc == 2)
                        {
                            sessionCarsLap[i] = irData.Telemetry.CarIdxLap[i];
                            sessionCarsLapsSincePit[i] = 0;
                        }
                        else if (sessionCarsLapsSincePit[i] != -1 || (sessionCarsLapsSincePit[i] == -1 && irData.Telemetry.CarIdxLap[i] - sessionCarsLap[i] > 0))
                        {
                            sessionCarsLapsSincePit[i] = irData.Telemetry.CarIdxLap[i] - sessionCarsLap[i];
                        }
                        else if (sessionCarsLapsSincePit[i] < -1)
                        {
                            sessionCarsLap[i] = irData.Telemetry.CarIdxLap[i];
                            sessionCarsLapsSincePit[i] = -1;
                        }
                    }
                    else
                    {
                        sessionCarsLap[i] = irData.Telemetry.CarIdxLap[i];
                        sessionCarsLapsSincePit[i] = -1;

                    }
                }

                //Cars ahead/behind on track calculations

                for (int i = 0; i < Base.gameData.NewData.OpponentsAheadOnTrack.Count && i < 5; i++)
                {
                    carAheadGap.Add(Base.gameData.NewData.OpponentsAheadOnTrack[i].RelativeGapToPlayer);
                    carAheadRaceGap.Add(Base.gameData.NewData.OpponentsAheadOnTrack[i].GaptoPlayer);
                    carAheadName.Add(Base.gameData.NewData.OpponentsAheadOnTrack[i].Name);
                    carAheadIsInPit.Add(Base.gameData.NewData.OpponentsAheadOnTrack[i].IsCarInPit);
                    carAheadBestLap.Add(Base.gameData.NewData.OpponentsAheadOnTrack[i].BestLapTime);
                    carAheadPosition.Add(Base.gameData.NewData.OpponentsAheadOnTrack[i].Position);

                    for (int u = 0; u < irData.SessionData.DriverInfo.CompetingDrivers.Length; u++)
                    {
                        if (irData.SessionData.DriverInfo.CompetingDrivers[u].UserName == Base.gameData.NewData.OpponentsAheadOnTrack[i].Name)
                        {
                            carAheadLicence.Add(irData.SessionData.DriverInfo.CompetingDrivers[u].LicString);
                            carAheadiRating.Add(irData.SessionData.DriverInfo.CompetingDrivers[u].IRating);
                            carAheadClassColor.Add(irData.SessionData.DriverInfo.CompetingDrivers[u].CarClassColor);
                            carAheadClassDifference.Add((classColors.IndexOf(irData.SessionData.DriverInfo.CompetingDrivers[u].CarClassColor)) - myClassColorIndex);
                            carAheadLapsSincePit.Add(sessionCarsLapsSincePit[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)]);

                            double? gap = Base.gameData.NewData.OpponentsAheadOnTrack[i].GaptoPlayer;
                            double? realgap = realGapOpponentDelta[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)];
                            double? relative = Base.gameData.NewData.OpponentsAheadOnTrack[i].RelativeGapToPlayer;
                            double? realrelative = realGapOpponentRelative[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)];

                            if ((gap > realgap * 1.25 && gap - realgap > 10) || (gap < realgap * 0.75 && gap - realgap < -10) || realgap == 0)
                            {
                                realgap = gap;
                                if (realgap == null)
                                {
                                    realgap = 0;
                                }
                            }
                            if (relative - realrelative > 10 || relative - realrelative < -10 || realrelative >= 0)
                            {
                                realrelative = relative;
                            }

                            carAheadRealGap.Add(realgap);
                            carAheadRealRelative.Add(realrelative);

                            if (p2pCount != null)
                            {
                                carAheadP2PCount.Add(((int[])p2pCount)[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)]);
                            }
                            if (p2pStatus != null)
                            {
                                carAheadP2PStatus.Add(((bool[])p2pStatus)[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)]);
                            }

                            if (irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions != null)
                            {
                                for (int e = 0; e < irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions.Length; e++)
                                {
                                    if (irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx == irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions[e].CarIdx)
                                    {
                                        carAheadJokerLaps.Add(irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions[e].JokerLapsComplete);
                                        break;
                                    }
                                }
                            }

                            if (carAheadJokerLaps.Count < carAheadName.Count)
                            {
                                carAheadJokerLaps.Add(0);
                            }

                            break;
                        }
                    }
                    if (Base.gameData.NewData.OpponentsAheadOnTrack[i].GaptoPlayer < 0 || (Base.gameData.NewData.OpponentsAheadOnTrack[i].RelativeGapToPlayer != null && Base.gameData.NewData.OpponentsAheadOnTrack[i].GaptoPlayer == null))
                    {
                        carAheadIsAhead.Add(true);
                    }
                    else
                    {
                        carAheadIsAhead.Add(false);
                    }
                    if (Base.gameData.NewData.OpponentsAheadOnTrack[i].Name == classLeaderName)
                    {
                        carAheadIsClassLeader.Add(true);
                    }
                    else
                    {
                        carAheadIsClassLeader.Add(false);
                    }

                    Base.SetProp("CarAhead0" + (i + 1) + "Gap", carAheadGap[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "RaceGap", carAheadRaceGap[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "BestLap", carAheadBestLap[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "Name", carAheadName[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "IRating", carAheadiRating[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "Licence", carAheadLicence[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "IsAhead", carAheadIsAhead[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "IsClassLeader", carAheadIsClassLeader[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "IsInPit", carAheadIsInPit[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "ClassColor", carAheadClassColor[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "ClassDifference", carAheadClassDifference[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "Position", carAheadPosition[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "JokerLaps", carAheadJokerLaps[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "LapsSincePit", carAheadLapsSincePit[i]);

                    if (carAheadP2PCount.Count > 0)
                    {
                        Base.SetProp("CarAhead0" + (i + 1) + "P2PCount", carAheadP2PCount[i]);
                        Base.SetProp("CarAhead0" + (i + 1) + "P2PStatus", carAheadP2PStatus[i]);
                    }

                    Base.SetProp("CarAhead0" + (i + 1) + "RealGap", carAheadRealGap[i]);
                    Base.SetProp("CarAhead0" + (i + 1) + "RealRelative", carAheadRealRelative[i]);

                }

                for (int i = Base.gameData.NewData.OpponentsAheadOnTrack.Count; i < 5; i++) //Clearing the empty ones
                {
                    Base.SetProp("CarAhead0" + (i + 1) + "Gap", 0);
                    Base.SetProp("CarAhead0" + (i + 1) + "RaceGap", 0);
                    Base.SetProp("CarAhead0" + (i + 1) + "BestLap", new TimeSpan(0));
                    Base.SetProp("CarAhead0" + (i + 1) + "Name", "");
                    Base.SetProp("CarAhead0" + (i + 1) + "IRating", 0);
                    Base.SetProp("CarAhead0" + (i + 1) + "Licence", "");
                    Base.SetProp("CarAhead0" + (i + 1) + "IsAhead", false);
                    Base.SetProp("CarAhead0" + (i + 1) + "IsClassLeader", false);
                    Base.SetProp("CarAhead0" + (i + 1) + "IsInPit", false);
                    Base.SetProp("CarAhead0" + (i + 1) + "ClassColor", "");
                    Base.SetProp("CarAhead0" + (i + 1) + "ClassDifference", 0);
                    Base.SetProp("CarAhead0" + (i + 1) + "Position", 0);
                    Base.SetProp("CarAhead0" + (i + 1) + "JokerLaps", 0);
                    Base.SetProp("CarAhead0" + (i + 1) + "LapsSincePit", -1);
                    Base.SetProp("CarAhead0" + (i + 1) + "P2PCount", -1);
                    Base.SetProp("CarAhead0" + (i + 1) + "P2PStatus", false);
                    Base.SetProp("CarAhead0" + (i + 1) + "RealGap", 0);
                    Base.SetProp("CarAhead0" + (i + 1) + "RealRelative", 0);
                }

                for (int i = 0; i < Base.gameData.NewData.OpponentsBehindOnTrack.Count && i < 5; i++)
                {
                    carBehindGap.Add(Base.gameData.NewData.OpponentsBehindOnTrack[i].RelativeGapToPlayer);
                    carBehindRaceGap.Add(Base.gameData.NewData.OpponentsBehindOnTrack[i].GaptoPlayer);
                    carBehindName.Add(Base.gameData.NewData.OpponentsBehindOnTrack[i].Name);
                    carBehindIsInPit.Add(Base.gameData.NewData.OpponentsBehindOnTrack[i].IsCarInPit);
                    carBehindBestLap.Add(Base.gameData.NewData.OpponentsBehindOnTrack[i].BestLapTime);
                    carBehindPosition.Add(Base.gameData.NewData.OpponentsBehindOnTrack[i].Position);

                    for (int u = 0; u < irData.SessionData.DriverInfo.CompetingDrivers.Length; u++)
                    {
                        if (irData.SessionData.DriverInfo.CompetingDrivers[u].UserName == Base.gameData.NewData.OpponentsBehindOnTrack[i].Name)
                        {
                            carBehindLicence.Add(irData.SessionData.DriverInfo.CompetingDrivers[u].LicString);
                            carBehindiRating.Add(irData.SessionData.DriverInfo.CompetingDrivers[u].IRating);
                            carBehindClassColor.Add(irData.SessionData.DriverInfo.CompetingDrivers[u].CarClassColor);
                            carBehindClassDifference.Add((classColors.IndexOf(irData.SessionData.DriverInfo.CompetingDrivers[u].CarClassColor)) - myClassColorIndex);
                            carBehindLapsSincePit.Add(sessionCarsLapsSincePit[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)]);

                            double? relative = Base.gameData.NewData.OpponentsBehindOnTrack[i].RelativeGapToPlayer;
                            double? gap = Base.gameData.NewData.OpponentsBehindOnTrack[i].GaptoPlayer;
                            double? realgap = realGapOpponentDelta[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)];
                            double? realrelative = realGapOpponentRelative[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)];

                            if ((gap > realgap * 1.25 && gap - realgap > 10) || (gap < realgap * 0.75 && gap - realgap < -10) || realgap == 0)
                            {
                                realgap = gap;
                                if (realgap == null)
                                {
                                    realgap = 0;
                                }
                            }
                            if (relative - realrelative > 10 || relative - realrelative < -10 || realrelative <= 0)
                            {
                                realrelative = relative;
                            }

                            carBehindRealGap.Add(realgap);
                            carBehindRealRelative.Add(realrelative);


                            if (p2pCount != null)
                            {
                                carBehindP2PCount.Add(((int[])p2pCount)[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)]);
                            }
                            if (p2pStatus != null)
                            {
                                carBehindP2PStatus.Add(((bool[])p2pStatus)[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)]);
                            }


                            if (irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions != null)
                            {
                                for (int e = 0; e < irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions.Length; e++)
                                {
                                    if (irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx == irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions[e].CarIdx)
                                    {
                                        carBehindJokerLaps.Add(irData.SessionData.SessionInfo.Sessions[sessionNumber].ResultsPositions[e].JokerLapsComplete);
                                        break;
                                    }
                                }
                            }

                            if (carBehindJokerLaps.Count < carBehindName.Count)
                            {
                                carBehindJokerLaps.Add(0);
                            }

                            break;

                        }
                    }
                    if (Base.gameData.NewData.OpponentsBehindOnTrack[i].GaptoPlayer < 0)
                    {
                        carBehindIsAhead.Add(true);
                    }
                    else
                    {
                        carBehindIsAhead.Add(false);
                    }
                    if (Base.gameData.NewData.OpponentsBehindOnTrack[i].Name == classLeaderName)
                    {
                        carBehindIsClassLeader.Add(true);
                    }
                    else
                    {
                        carBehindIsClassLeader.Add(false);
                    }
                    Base.SetProp("CarBehind0" + (i + 1) + "Gap", carBehindGap[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "RaceGap", carBehindRaceGap[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "BestLap", carBehindBestLap[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "Name", carBehindName[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "IRating", carBehindiRating[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "Licence", carBehindLicence[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "IsAhead", carBehindIsAhead[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "IsClassLeader", carBehindIsClassLeader[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "IsInPit", carBehindIsInPit[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "ClassColor", carBehindClassColor[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "ClassDifference", carBehindClassDifference[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "Position", carBehindPosition[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "JokerLaps", carBehindJokerLaps[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "LapsSincePit", carBehindLapsSincePit[i]);

                    if (carBehindP2PCount.Count > 0)
                    {
                        Base.SetProp("CarBehind0" + (i + 1) + "P2PCount", carBehindP2PCount[i]);
                        Base.SetProp("CarBehind0" + (i + 1) + "P2PStatus", carBehindP2PStatus[i]);
                    }

                    Base.SetProp("CarBehind0" + (i + 1) + "RealGap", carBehindRealGap[i]);
                    Base.SetProp("CarBehind0" + (i + 1) + "RealRelative", carBehindRealRelative[i]);
                }

                for (int i = Base.gameData.NewData.OpponentsBehindOnTrack.Count; i < 5; i++)
                {
                    Base.SetProp("CarBehind0" + (i + 1) + "Gap", 0);
                    Base.SetProp("CarBehind0" + (i + 1) + "RaceGap", 0);
                    Base.SetProp("CarBehind0" + (i + 1) + "BestLap", new TimeSpan(0));
                    Base.SetProp("CarBehind0" + (i + 1) + "Name", "");
                    Base.SetProp("CarBehind0" + (i + 1) + "IRating", 0);
                    Base.SetProp("CarBehind0" + (i + 1) + "Licence", "");
                    Base.SetProp("CarBehind0" + (i + 1) + "IsAhead", false);
                    Base.SetProp("CarBehind0" + (i + 1) + "IsClassLeader", false);
                    Base.SetProp("CarBehind0" + (i + 1) + "IsInPit", false);
                    Base.SetProp("CarBehind0" + (i + 1) + "ClassColor", "");
                    Base.SetProp("CarBehind0" + (i + 1) + "ClassDifference", 0);
                    Base.SetProp("CarBehind0" + (i + 1) + "Position", 0);
                    Base.SetProp("CarBehind0" + (i + 1) + "JokerLaps", 0);
                    Base.SetProp("CarBehind0" + (i + 1) + "LapsSincePit", -1);
                    Base.SetProp("CarBehind0" + (i + 1) + "P2PCount", -1);
                    Base.SetProp("CarBehind0" + (i + 1) + "P2PStatus", false);
                    Base.SetProp("CarBehind0" + (i + 1) + "RealGap", 0);
                    Base.SetProp("CarBehind0" + (i + 1) + "RealRelative", 0);
                }
            }



            //---------------------------------------------
            //--------------FUEL CALCULATION + STINT-------
            //---------------------------------------------

            if (Base.counter == 3 || Base.counter == 4 || pit == 1)
            {
                Base.SetProp("FuelPerLapTarget", Base.Settings.fuelPerLapTarget);

                double fuelLastLap = Convert.ToDouble(Base.GetProp("DataCorePlugin.Computed.Fuel_LastLapConsumption"));
                double fuelPerLap = 0;

                int truncRemainingLaps = ((int)(remainingLaps * 100)) / 100;

                if (sessionState < 4 && trackPosition == 0 && isLapLimited && !isTimeLimited) //When standing on grid and track position is not updated yet. 
                {
                    truncRemainingLaps--;
                }

                if (Base.counter != 4)
                {
                    fuelPerLap = fuelAvgLap + Math.Round(propFuelPerLapOffset, 2);
                }
                else
                {
                    fuelPerLap = fuelLastLap;
                }

                if (Base.counter != 4)
                {
                    Base.SetProp("FuelDelta", 0);
                    Base.SetProp("FuelPitWindowFirst", 0);
                    Base.SetProp("FuelPitWindowLast", 0);
                    Base.SetProp("FuelMinimumFuelFill", 0);
                    Base.SetProp("FuelMaximumFuelFill", 0);
                    Base.SetProp("FuelPitStops", 0);
                    Base.SetProp("FuelConserveToSaveAStop", 0);
                    Base.SetProp("FuelSlowestFuelSavePace", new TimeSpan(0));
                    Base.SetProp("FuelAlert", false);

                }
                else
                {
                    Base.SetProp("FuelDeltaLL", 0);
                    Base.SetProp("FuelPitWindowFirstLL", 0);
                    Base.SetProp("FuelPitWindowLastLL", 0);
                    Base.SetProp("FuelMinimumFuelFillLL", 0);
                    Base.SetProp("FuelMaximumFuelFillLL", 0);
                    Base.SetProp("FuelPitStopsLL", 0);
                    Base.SetProp("FuelConserveToSaveAStopLL", 0);
                    Base.SetProp("FuelSaveDeltaValue", 0);
                }


                if (fuelPerLap > 0)
                {
                    double distanceLeft = truncRemainingLaps + 1 - trackPosition;
                    double fuelDelta = fuel - (fuelPerLap * distanceLeft) - Base.Settings.FuelCalculationMargin;

                    //Calculating pit window

                    //Room for fuel
                    double roomForFuel = maxFuel - fuel;
                    double roomAfterDelta = roomForFuel + fuelDelta;

                    //Where will I get to with current fuel load
                    double dryPosition = (fuel / fuelPerLap) + currentLap + trackPosition;
                    //Latest possible pit stop on lap:
                    int latestPitLap = ((int)((dryPosition - 1.1) * 100)) / 100;
                    if (fuelDelta > 0 && session != "Offline Testing")
                    {
                        latestPitLap = 0;
                    }

                    //Fuel alert
                    bool fuelAlert = false;
                    if (latestPitLap != 0 && latestPitLap <= currentLap)
                    {
                        fuelAlert = true;
                    }

                    //How much is left on tank on latest possible stop
                    double latestPitFuelLoad = (dryPosition - (latestPitLap + 1)) * fuelPerLap;
                    //The most I can fuel
                    double maxFillOnStop = maxFuel - latestPitFuelLoad;
                    //How far can I get on that tank?
                    double maxDist = maxFuel / fuelPerLap;
                    double maxLaps = ((int)((maxDist - 1.1) * 100)) / 100;
                    //Least amount of fuel to give maximum amount of laps
                    double secondFuelingMinimum = fuelPerLap * maxLaps;

                    //Maximumfueling
                    //How much is left on tank at the end of this lap
                    double thisLapFuelLoad = (fuel - ((1 - myPosition) * fuelPerLap));
                    //Compare that to secondFuelingMinumum           
                    maxFuelPush = secondFuelingMinimum - thisLapFuelLoad;

                    double pitStops = 0;
                    if (remainingLaps != 0)
                    {
                        if (fuelDelta > 0)
                        {
                            pitStops = 1 - (fuelDelta / maxFuel);
                        }
                        if (fuelDelta < 0)
                        {
                            pitStops = 1 - (fuelDelta / maxFillOnStop);
                        }
                        if (fuelDelta < -maxFillOnStop)
                        {
                            pitStops = 2 - ((fuelDelta + maxFillOnStop) / secondFuelingMinimum);
                        }
                    }


                    int truncPitStops = ((int)(pitStops * 100)) / 100;
                    double minimumFueling = (pitStops - truncPitStops) * maxFuel;

                    if (minimumFueling > maxFillOnStop)
                    {
                        minimumFueling = maxFillOnStop - 0.01;
                    }

                    double roomAfterMinFueling = roomForFuel - minimumFueling;

                    minFuelPush = 0;
                    if (fuelDelta < 0)
                    {
                        minFuelPush = -fuelDelta;
                    }
                    if (pitStops > 2)
                    {
                        minFuelPush = minimumFueling;
                    }

                    if (Base.counter != 4)
                    {
                        commandMinFuel = Math.Ceiling(minFuelPush + Base.Settings.FuelCommandMargin);
                        if (minFuelPush == 0)
                        {
                            commandMinFuel = 0;
                        }
                        commandMaxFuel = Math.Ceiling(maxFuelPush + Base.Settings.FuelCommandMargin);
                        if (maxFuelPush == 0)
                        {
                            commandMaxFuel = 500;
                        }

                    }

                    int earliestLap = ((int)((currentLap + trackPosition - (roomAfterDelta / fuelPerLap)) * 100)) / 100;
                    if (pitStops > 2)
                    {
                        earliestLap = ((int)((currentLap + trackPosition - (roomAfterMinFueling / fuelPerLap)) * 100)) / 100;
                    }
                    if (earliestLap <= currentLap || pitStops > 2 && roomAfterMinFueling > 0)
                    {
                        earliestLap = currentLap;
                    }
                    if (fuelDelta > 0)
                    {
                        earliestLap = 0;
                    }

                    double conserveToNotPit = (minFuelPush / distanceLeft) / fuelPerLap;
                    double slowestLapTime = (pitStopDuration / distanceLeft) + myExpectedLapTime;

                    double saveDelta = 0;
                    if (pitStops - truncPitStops > 0.5)
                    {
                        slowestLapTime = 0;
                        if (minFuelPush == 0)
                        {
                            saveDelta = -fuelDelta;
                        }
                        else
                        {
                            saveDelta = minFuelPush - maxFillOnStop;
                        }

                    }
                    else
                    {
                        saveDelta = minFuelPush;
                        if (minFuelPush == 0)
                        {
                            slowestLapTime = 0;
                        }
                    }

                    if (session == "Offline Testing")
                    {
                        slowestLapTime = 0;
                        fuelDelta = 0;
                        pitStops = 0;
                        if (roomForFuel > fuelPerLap)
                        {
                            earliestLap = currentLap;
                        }
                        else
                        {
                            earliestLap = 0;
                        }
                        saveDelta = 0;

                    }

                    TimeSpan slowestLapTimeSpan = TimeSpan.FromSeconds(slowestLapTime);

                    if (propRaceFinished)
                    {
                        fuelDelta = 0;
                    }

                    if (Base.counter != 4)
                    {

                        slowestLapTimeSpanCopy = slowestLapTimeSpan;

                        Base.SetProp("FuelDelta", fuelDelta);
                        Base.SetProp("FuelPitWindowFirst", earliestLap);
                        Base.SetProp("FuelPitWindowLast", latestPitLap);
                        Base.SetProp("FuelMinimumFuelFill", minFuelPush);
                        Base.SetProp("FuelMaximumFuelFill", maxFuelPush);
                        Base.SetProp("FuelPitStops", pitStops);
                        Base.SetProp("FuelConserveToSaveAStop", conserveToNotPit);
                        Base.SetProp("FuelAlert", fuelAlert);


                        if (!savePitTimerLock)
                        {
                            Base.SetProp("FuelSlowestFuelSavePace", slowestLapTimeSpan);
                        }
                        else
                        {
                            Base.SetProp("FuelSlowestFuelSavePace", savePitTimerSnap);
                        }


                        //Stint calculations

                        if ((propLapTimeList[0].TotalSeconds == 0 && pit == 0) || propPitBox > 0 || (session == "Race" && sessionState == 2) || (session == "Lone Qualify" && pit == 1)) //Update values only when in box, on grid or at end of pit lane for qualy laps. 
                        {
                            stintLapsTotal = latestPitLap - currentLap - 1; //Laps remaining of the stint
                            if ((session == "Race" && sessionState == 2) || (session == "Lone Qualify" && pit == 1) || (propLapTimeList[0].TotalSeconds == 0 && pit == 0))
                            {
                                stintLapsTotal++;
                            }
                            if (fuelDelta > 0) //In case there is no need to fuel to end the sessions
                            {
                                stintLapsTotal = truncRemainingLaps;
                            }

                            if (pitLocation > 0.8 && !(session == "Race" && sessionState == 2) && !(session == "Lone Qualify" && pit == 1))
                            {
                                stintLapsTotal--;
                            }
                            stintTimeTotal = TimeSpan.FromSeconds((stintLapsTotal + 2) * myExpectedLapTime);
                            if ((session == "Race" && sessionState == 2) || (session == "Lone Qualify" && pit == 1))
                            {
                                stintTimeTotal = TimeSpan.FromSeconds(stintLapsTotal * myExpectedLapTime);
                            }
                            if (fuelDelta > 0) //In case there is no need to fuel to end the sessions
                            {
                                if (isLapLimited)
                                {
                                    stintTimeTotal = TimeSpan.FromSeconds(truncRemainingLaps * myExpectedLapTime);
                                }
                                else
                                {
                                    double posWhenZero = timeLeft.TotalSeconds / myExpectedLapTime + trackPosition;
                                    int truncPos = ((int)(posWhenZero * 100)) / 100;

                                    stintTimeTotal = TimeSpan.FromSeconds(timeLeft.TotalSeconds + (1 - (posWhenZero - truncPos)) * myExpectedLapTime);
                                }
                            }
                            if (propLapTimeList[0].TotalSeconds == 0 && pit == 0)
                            {
                                stintTimeTotal = TimeSpan.FromSeconds(stintTimeTotal.TotalSeconds);
                            }
                            if (sessionState > 4) //If session is ending
                            {
                                stintTimeTotal = new TimeSpan(0);
                                stintLapsTotal = 0;
                            }
                            Base.SetProp("StintTotalTime", stintTimeTotal);
                            Base.SetProp("StintTotalHotlaps", stintLapsTotal);
                        }

                    }
                    else
                    {
                        Base.SetProp("FuelDeltaLL", fuelDelta);
                        Base.SetProp("FuelPitWindowFirstLL", earliestLap);
                        Base.SetProp("FuelPitWindowLastLL", latestPitLap);
                        Base.SetProp("FuelMinimumFuelFillLL", minFuelPush);
                        Base.SetProp("FuelMaximumFuelFillLL", maxFuelPush);
                        Base.SetProp("FuelPitStopsLL", pitStops);
                        Base.SetProp("FuelConserveToSaveAStopLL", conserveToNotPit);
                        Base.SetProp("FuelSaveDeltaValue", saveDelta);


                        //Fuel target calculations

                        fuelTargetDelta = fuelPerLap - Base.Settings.fuelPerLapTarget;
                        if (fuelPerLap == 0)
                        {
                            fuelTargetDelta = 0;
                        }
                        Base.SetProp("FuelPerLapTargetLastLapDelta", fuelTargetDelta);
                        Base.SetProp("FuelTargetDeltaCumulative", fuelTargetDeltaCumulative);
                    }
                }

            }

            //----------------------------------------
            //---------Stint timer/lap Base.counter--------
            //----------------------------------------

            if (Base.counter == 7 || Base.counter == 22 || Base.counter == 37 || Base.counter == 52)
            {
                //Several conditions where stint timer will reset
                if (propIRIdle || propPitBox > 0 || (session == "Race" && sessionState < 4) || (session == "Offline Testing" && pit == 1) || pushTimer.TotalHours > 10)
                {
                    stintTimer = globalClock;
                }

                pushTimer = TimeSpan.FromMilliseconds(globalClock.TotalMilliseconds - stintTimer.TotalMilliseconds);

                Base.SetProp("StintTimer", pushTimer);

                int stintLaps = propValidStintLaps + propInvalidStintLaps + 1;

                if (stintLapsCheck)
                {
                    stintLaps = stintLaps - 1;
                }
                Base.SetProp("StintCurrentHotlap", stintLaps);
            }

            //--------------------------------------------------
            //----Minimum Corner Speed and Straight Line Speed--
            //--------------------------------------------------
            if (pit == 1)
            {
                Base.SetProp("StraightLineSpeed", 0);
                Base.SetProp("MinimumCornerSpeed", minimumCornerSpeed);
            }
            else
            {
                if (throttle > highestThrottle && !throttleLift) //recording highest throttle value
                {
                    highestThrottle = throttle;
                }

                if (!throttleLift && highestThrottle > 0.995) //Updating straight line speed when throttle is on
                {
                    if (straightLineSpeed < speed)
                    {
                        straightLineSpeed = speed;
                    }
                }

                if (throttle < (0.98 * highestThrottle) && !throttleLift) //detecting throttle lift
                {
                    throttleLift = true;
                    minimumCornerSpeed = speed;
                }
                if (throttleLift && throttle < 30 && straightLineSpeed > 50) //posting straight line speed
                {
                    Base.SetProp("StraightLineSpeed", straightLineSpeed);
                }

                if (throttleLift) //Throttle has been lifted, start recording throttle again, if speed is lower than recorded MCS, pick it up.
                {
                    highestThrottle = throttle;
                    if (minimumCornerSpeed == 0 || minimumCornerSpeed > speed)
                    {
                        minimumCornerSpeed = speed;
                    }
                }

                if (throttleLift && speed > (1.1 * minimumCornerSpeed)) //Detecting increase in speed, resetting straight line value. 
                {
                    throttleLift = false;
                    straightLineSpeed = 0;
                }

                Base.SetProp("MinimumCornerSpeed", minimumCornerSpeed);
            }

            //--------------------------------------------------
            //--------------------BRAKE CURVE-------------------
            //--------------------------------------------------


            BrakeCurve();

            //--------------------------------------------------
            //--------------------THROTTLE CURVE-------------------
            //--------------------------------------------------

            ThrottleCurve();



            //--------------------------------------------------
            //-------PIT STOP EXIT POSITION CALCULATIONS--------
            //--------------------------------------------------

            if (sessionBestLap.TotalSeconds > 0 && Base.counter == 27 && session == "Race" && pitLimiter != 1)
            {

                pitStopOpponents.Clear();
                finalList.Clear();

                for (int i = 0; i < opponents; i++) //Add all opponents as objects with gap to player and name
                {
                    if (!Base.gameData.NewData.Opponents[i].IsPlayer)
                    {

                        double? gap = Base.gameData.NewData.Opponents[i].GaptoPlayer;
                        double? realgap = 0;
                        bool usingRealGap = true;
                        for (int u = 0; u < irData.SessionData.DriverInfo.CompetingDrivers.Length; u++)
                        {
                            if (irData.SessionData.DriverInfo.CompetingDrivers[u].UserName == Base.gameData.NewData.Opponents[i].Name)
                            {
                                realgap = realGapOpponentDelta[Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[u].CarIdx)];
                                break;
                            }
                        }

                        if ((gap > realgap * 1.25 && gap - realgap > 10) || (gap < realgap * 0.75 && gap - realgap < -10) || realgap == 0)
                        {
                            realgap = gap;
                            usingRealGap = false;
                            if (realgap == null)
                            {
                                realgap = 0;
                            }
                        }


                        pitStopOpponents.Add(new pitOpponents(realgap, Base.gameData.NewData.Opponents[i].Name, Base.gameData.NewData.Opponents[i].TrackPositionPercent, Base.gameData.NewData.Opponents[i].CarClass == myClass, 0, 0, Base.gameData.NewData.Opponents[i].BestLapTime, false, false, usingRealGap));
                    }
                }

                pitStopOpponents = pitStopOpponents.OrderBy(entry => entry.Gap).ToList(); //Sort by gap to find position
                pitStopOpponents.Sort((x, y) => y.IsSameClass.CompareTo(x.IsSameClass));

                for (int i = 0; i < pitStopOpponents.Count; i++)
                {
                    double bestLap = pitStopOpponents[i].BestLap.TotalSeconds; //Calculations for gap using player best lap (or my best lap if none)
                    if (pitStopOpponents[i].BestLap.TotalSeconds < sessionBestLap.TotalSeconds)
                    {
                        pitStopOpponents[i].IsFaster = true;
                    }
                    if (bestLap == 0)
                    {
                        bestLap = sessionBestLap.TotalSeconds;
                        pitStopOpponents[i].IsFaster = false;
                    }

                    double correctingFactor = 1;
                    if (!pitStopOpponents[i].UsedRealGap)
                    {
                        correctingFactor = bestLap / sessionBestLap.TotalSeconds;
                    }

                    if ((pitStopOpponents[i].Gap * correctingFactor) - pitStopDuration < 0) //Will this car actually be ahead in race after pit stop?
                    {
                        pitStopOpponents[i].IsAhead = true;
                    }

                    if (pitStopOpponents[i].Gap - pitStopDuration < 10 && pitStopOpponents[i].Gap - pitStopDuration > -10) //If no calculations are needed to adjust for extra laps, just use the gap, as it is likely to be a real meassured gap, and therefore quite accurate
                    {
                        pitStopOpponents[i].Gap = pitStopOpponents[i].Gap - pitStopDuration;
                    }

                    else
                    {
                        double? posOnExit = pitStopOpponents[i].TrackPosition + (pitStopDuration / bestLap); //Updating the gap to show relative gap on exit
                        posOnExit = posOnExit % 1;
                        pitStopOpponents[i].Gap = -1 * ((posOnExit - trackPosition) % 1) * sessionBestLap.TotalSeconds;
                    }

                    if (pitStopOpponents[i].IsSameClass) //Give position to same class cars
                    {
                        pitStopOpponents[i].Position = i + 1;
                    }

                    if (pitStopOpponents[i].IsSameClass && !pitStopOpponents[i].IsAhead)
                    {
                        pitStopOpponents[i].Position++;
                    }
                }

                //Futher include only cars in the +/1 10 seconds range

                int posAfterPit = 1;

                for (int i = 0; i < pitStopOpponents.Count; i++)
                {
                    if (pitStopOpponents[i].Gap > -10 && pitStopOpponents[i].Gap < 10)
                    {
                        finalList.Add(pitStopOpponents[i]);
                    }

                    if (pitStopOpponents[i].IsAhead && pitStopOpponents[i].IsSameClass) //Find my position when exiting the pits
                    {
                        posAfterPit++;
                    }
                }

                Base.SetProp("PitExitPosition", posAfterPit);

                for (int i = 0; i < finalList.Count && i < 14; i++) //Edit name and find class difference of relevant cars
                {

                    for (int u = 0; u < irData.SessionData.DriverInfo.CompetingDrivers.Length; u++)
                    {
                        if (irData.SessionData.DriverInfo.CompetingDrivers[u].UserName == finalList[i].Name)
                        {
                            finalList[i].ClassDifference = classColors.IndexOf(irData.SessionData.DriverInfo.CompetingDrivers[u].CarClassColor) - myClassColorIndex;
                            break;
                        }
                    }

                    int letterCount = finalList[i].Name.Split(' ').Last().Length;
                    if (letterCount > 3)
                    {
                        letterCount = 3;
                    }

                    finalList[i].Name = finalList[i].Name.Split(' ').Last().Substring(0, letterCount).ToUpper();

                    Base.SetProp("PitExitCar" + (i + 1) + "Name", finalList[i].Name);
                    Base.SetProp("PitExitCar" + (i + 1) + "Gap", finalList[i].Gap);
                    Base.SetProp("PitExitCar" + (i + 1) + "Position", finalList[i].Position);
                    Base.SetProp("PitExitCar" + (i + 1) + "ClassDifference", finalList[i].ClassDifference);
                    Base.SetProp("PitExitCar" + (i + 1) + "IsAhead", finalList[i].IsAhead);
                    Base.SetProp("PitExitCar" + (i + 1) + "IsFaster", finalList[i].IsFaster);

                }
                for (int i = finalList.Count; i < 14; i++)
                {
                    Base.SetProp("PitExitCar" + (i + 1) + "Name", "");
                    Base.SetProp("PitExitCar" + (i + 1) + "Gap", 0);
                    Base.SetProp("PitExitCar" + (i + 1) + "Position", 0);
                    Base.SetProp("PitExitCar" + (i + 1) + "ClassDifference", 0);
                    Base.SetProp("PitExitCar" + (i + 1) + "IsAhead", false);
                    Base.SetProp("PitExitCar" + (i + 1) + "IsFaster", false);
                }

            }

            //-----------------------------------------------------------------------------
            //----------------------PIT STOP DURATION--------------------------------------
            //-----------------------------------------------------------------------------

            if (Base.counter == 10 || Base.counter == 25 || Base.counter == 40 || Base.counter == 55)
            {

                double throughTime = pitStopBase + pitStopBase * ((pitMaxSpeed - 1) * pitStopMaxSpeed + (pitCornerSpeed - 1) * pitStopCornerSpeed - (pitAcceleration - 1) * pitStopAcceleration + (pitBrakeDistance - 1) * pitStopBrakeDistance);

                double tireTime = 0;

                //establish toggle bools, front/rear/left/right/all

                bool pitToggleFront = propLFTog && propRFTog;
                bool pitToggleRear = propLRTog && propRRTog;
                bool pitToggleLeft = propLFTog && propLRTog;
                bool pitToggleRight = propRFTog && propRRTog;

                int totalTireNumber = Convert.ToInt16(propLFTog) + Convert.ToInt16(propRFTog) + Convert.ToInt16(propLRTog) + Convert.ToInt16(propRRTog);

                if (carHasAnimatedCrew && trackHasAnimatedCrew)
                {
                    pitBaseTime = pitAniBaseTime;
                    pitSlowAdd = pitAniSlowAdd;
                }

                tireTime = 0;
                if (totalTireNumber > 0)
                {

                    if (pitCrewType == CrewType.SingleTyre)
                    {
                        if (totalTireNumber == 4)
                        {
                            tireTime = pitBaseTime * 4 + pitSlowAdd * 2;
                        }
                        else if (totalTireNumber == 3)
                        {
                            tireTime = pitBaseTime * 3 + pitSlowAdd;
                        }
                        else if (totalTireNumber == 2 && ((pitFastSide == "Left" && (propRFTog || propRRTog)) || (pitFastSide == "Right" && (propLFTog || propLRTog))))
                        {
                            tireTime = pitBaseTime * 2 + (2 * pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 2)
                        {
                            tireTime = pitBaseTime * 2 - (pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 1 && ((pitFastSide == "Left" && (propRFTog || propRRTog)) || (pitFastSide == "Right" && (propLFTog || propLRTog))))
                        {
                            tireTime = pitBaseTime + pitSlowAdd;
                        }
                        else
                        {
                            tireTime = pitBaseTime;
                        }
                    }

                    else if (pitCrewType == CrewType.FrontRear)
                    {
                        if (totalTireNumber == 4 || (totalTireNumber == 3 && ((pitFastSide == "Left" && ((pitToggleFront && propLRTog) || (pitToggleRear && propLFTog))) || (pitFastSide == "Right" && ((pitToggleFront && propRRTog) || (pitToggleRear && propRFTog)))))
                           || (totalTireNumber == 2 && ((pitFastSide == "Left" && pitToggleRight) || (pitFastSide == "Right" && pitToggleLeft))))
                        {
                            tireTime = pitBaseTime * 2 + (2 * pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 3 || totalTireNumber == 2 && (pitToggleRight || pitToggleLeft))
                        {
                            tireTime = pitBaseTime * 2 - (pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 2 || totalTireNumber == 1 && ((pitFastSide == "Left" && (propRFTog || propRRTog)) || (pitFastSide == "Right" && (propLFTog || propLRTog))))
                        {
                            tireTime = pitBaseTime + pitSlowAdd;
                        }
                        else
                        {
                            tireTime = pitBaseTime;
                        }
                    }

                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        if (totalTireNumber == 4 || totalTireNumber == 3 || (totalTireNumber == 2 && !pitToggleLeft && !pitToggleRight))
                        {
                            tireTime = pitBaseTime * 2 + (2 * pitSlowAdd / 3);
                        }
                        else if ((pitFastSide == "Left" && (pitToggleRight || propRFTog || propRRTog)) || (pitFastSide == "Right" && (pitToggleLeft || propLFTog || propLRTog)))
                        {
                            tireTime = pitBaseTime + pitSlowAdd;
                        }
                        else if (totalTireNumber == 2 || totalTireNumber == 1 && ((pitFastSide == "Left" && (propRFTog || propRRTog)) || (pitFastSide == "Right" && (propLFTog || propLRTog))))
                        {
                            tireTime = pitBaseTime + pitSlowAdd;
                        }
                        else
                        {
                            tireTime = pitBaseTime;
                        }
                    }
                    else
                    {
                        tireTime = pitBaseTime;
                    }

                }

                if (plannedFuel + fuel > maxFuel)
                {
                    plannedFuel = maxFuel - fuel;
                }

                double fuelTime = 1 + (plannedFuel / pitFuelFillRate) + 0.2;

                if (!propfuelTog)
                {
                    fuelTime = 0;
                }

                if (!fuelTargetCheck)
                {
                    fuelTargetCheck = true;
                    oldFuelValue = fuel;
                }

                if (oldFuelValue >= fuel || !propfuelTog || oldFuelValue == 0)
                {
                    oldFuelValue = fuel;
                }

                double fuelTarget = oldFuelValue;
                if (propfuelTog)
                {
                    fuelTarget = fuelTarget + plannedFuel;
                }

                double WStimer = 0;
                if (pitHasWindscreen && propWSTog)
                {
                    WStimer = 2.5;
                }

                double frontWingTime = 0;
                double rearWingTime = 0;
                double tapeTime = 0;
                double powersteerTime = 0;

                //Front wing
                double currentFrontWingC = Math.Abs(propCurrentFrontWing - wingFront);
                if (carId == "Dallara IR18")
                {
                    currentFrontWingC = currentFrontWingC * 10;
                }

                if (currentFrontWingC > 0)
                {
                    frontWingTime = 2.6 + (currentFrontWingC - 1) * 0.2;
                }

                //Rear wing
                double currentRearWingC = Math.Abs(propCurrentRearWing - wingRear);
                if (carId == "Dallara IR18")
                {
                    currentRearWingC = currentRearWingC * 10;
                }

                if (currentRearWingC > 0)
                {
                    rearWingTime = 2.6 + (currentRearWingC - 1) * 0.2;
                }

                //PWS
                int currentPWSC = Math.Abs(currentPWS - PWS);

                if (currentPWSC > 0)
                {
                    powersteerTime = 4 + (currentPWSC - 1) * 2;
                }

                //Tape
                int currentTapeC = Math.Abs(propCurrentTape - tape);

                if (currentTapeC > 0)
                {
                    tapeTime = 1.2 + (currentTapeC - 1) * 0.2;
                }

                double adjustmentTime = Math.Max(Math.Max(Math.Max(frontWingTime, rearWingTime), powersteerTime), tapeTime);

                double pitTime = Math.Max(Math.Max(Math.Max(tireTime, fuelTime), WStimer), adjustmentTime);
                if (!pitMultitask)
                {
                    pitTime = fuelTime + tireTime;
                    if (WStimer > fuelTime + tireTime)
                    {
                        pitTime = WStimer;
                    }
                    if ((adjustmentTime > fuelTime + tireTime) && adjustmentTime > WStimer)
                    {
                        pitTime = adjustmentTime;
                    }

                    if (propfuelTog && totalTireNumber > 0)
                    {
                        pitTime = pitTime - pitSlowAdd;
                    }
                }

                pitStopDuration = pitTime + throughTime;

                if (pitStopDuration == throughTime)
                {
                    onlyThrough = true;
                }
                else
                {
                    onlyThrough = false;
                }

                if (pitStall != 1)
                {
                    Base.SetProp("PitServiceFuelTarget", fuelTarget);
                }

                Base.SetProp("PitTimeTires", tireTime);
                Base.SetProp("PitTimeFuel", fuelTime);
                Base.SetProp("PitTimeWindscreen", WStimer);
                Base.SetProp("PitTimeAdjustment", adjustmentTime);
                Base.SetProp("PitTimeDriveThrough", throughTime);
                Base.SetProp("PitTimeService", pitTime);
                Base.SetProp("PitTimeTotal", pitStopDuration);

                Base.SetProp("PitCrewType", (int)pitCrewType);

            }

            //-----------------------------------------------------------------------------
            //----------------------LAP DELTA TIMING---------------------------------------
            //-----------------------------------------------------------------------------


            int myDeltaIndex = ((int)((trackPosition * lapDeltaSections) * 100)) / 100;

            if (myDeltaIndex >= lapDeltaSections)
            {
                myDeltaIndex = trackSections - 1;
            }
            if (myDeltaIndex < 0)
            {
                myDeltaIndex = 0;
                myDeltaIndexOld = 0;
            }

            double deltaLastLap = 0;
            double deltaSessionBest = 0;
            double deltaLapRecord = 0;


            if (myDeltaIndex != myDeltaIndexOld)
            {
                myDeltaIndexOld = myDeltaIndex;

                lapDeltaCurrent[myDeltaIndex + 1] = currentLapTime.TotalMilliseconds;

                if (currentLapTime.TotalSeconds < 2 && lapDeltaCurrent[0] != 1)
                {
                    lapDeltaCurrent[0] = 1; //This lap recording checked for full-length
                }

                bool passCheck = (pit == 0 && (myDeltaIndex > 5 || (myDeltaIndex > 3 && lapDeltaLast[myDeltaIndex + 1] < 10000 && lapDeltaCurrent[myDeltaIndex + 1] < 10000)));

                //Setting last lap delta
                if (passCheck && lapDeltaLast[myDeltaIndex + 1] > 0 && lapDeltaCurrent[myDeltaIndex + 1] > 0)
                {
                    deltaLastLap = (lapDeltaCurrent[myDeltaIndex + 1] - lapDeltaLast[myDeltaIndex + 1]) / 1000;
                    lapDeltaLastChange[myDeltaIndex] = deltaLastLap;
                    Base.SetProp("DeltaLastLap", deltaLastLap);
                }

                if (lapDeltaLast[myDeltaIndex + 1] == -1)
                {
                    Base.SetProp("DeltaLastLap", 0);
                }

                if (myDeltaIndex > 5 && lapDeltaSessionBest[myDeltaIndex + 1] < 10000)
                {
                    passCheck = false;
                }

                //Setting session best lap delta
                if (passCheck && lapDeltaSessionBest[myDeltaIndex + 1] > 0 && lapDeltaCurrent[myDeltaIndex + 1] > 0)
                {
                    deltaSessionBest = (lapDeltaCurrent[myDeltaIndex + 1] - lapDeltaSessionBest[myDeltaIndex + 1]) / 1000;
                    lapDeltaSessionBestChange[myDeltaIndex] = deltaSessionBest;
                    Base.SetProp("DeltaSessionBest", deltaSessionBest);
                }
                if (lapDeltaSessionBest[myDeltaIndex + 1] == -1)
                {
                    Base.SetProp("DeltaSessionBest", 0);
                }


                //Setting lap record delta
                bool recordCheck = (pit == 0 && (myDeltaIndex > 5 || (myDeltaIndex > 3 && lapDeltaRecord[myDeltaIndex + 1] < 10000 && lapDeltaCurrent[myDeltaIndex + 1] < 10000)));
                if (recordCheck && lapDeltaRecord[myDeltaIndex + 1] > 0 && lapDeltaCurrent[myDeltaIndex + 1] > 0)
                {
                    deltaLapRecord = (lapDeltaCurrent[myDeltaIndex + 1] - lapDeltaRecord[myDeltaIndex + 1]) / 1000;
                    lapDeltaLapRecordChange[myDeltaIndex] = deltaLapRecord;
                    Base.SetProp("DeltaLapRecord", deltaLapRecord);
                }
                if (lapDeltaRecord[myDeltaIndex + 1] == -1)
                {
                    Base.SetProp("DeltaLapRecord", 0);
                }


                if (myDeltaIndex == 0) //last section, copy to last lap. Further copy to session/ATB on lap changes. (from last lap)
                {
                    for (int i = 0; i < lapDeltaSections + 1; i++)
                    {
                        lapDeltaLast[i] = lapDeltaCurrent[i];
                        lapDeltaCurrent[i] = -1;
                    }
                }
            }

            int chunkSize = lapDeltaSections / deltaChangeChunks;
            int currentChunk = myDeltaIndex / chunkSize;
            bool changeStarted = false;
            double changeSum = 0;
            double firstOfChunk = 0;
            double lastOfChunk = 0;

            if (lapDeltaLast[myDeltaIndex + 1] > 0)
            {
                for (int i = currentChunk * chunkSize; i < myDeltaIndex + 1; i++)
                {
                    if (!changeStarted)
                    {
                        firstOfChunk = lapDeltaLastChange[i];
                    }
                    changeStarted = true;

                    if (i == myDeltaIndex)
                    {
                        lastOfChunk = lapDeltaLastChange[i];
                    }
                }
            }

            if (changeStarted)
            {
                changeSum = lastOfChunk - firstOfChunk;
            }

            lastChunks[currentChunk] = changeSum;

            string lastResult = string.Join(",", lastChunks); //push result as string

            changeStarted = false;
            changeSum = 0;
            firstOfChunk = 0;
            lastOfChunk = 0;

            for (int i = currentChunk * chunkSize; i < myDeltaIndex + 1; i++)
            {
                if (!changeStarted)
                {
                    firstOfChunk = lapDeltaSessionBestChange[i];
                }
                changeStarted = true;

                if (i == myDeltaIndex)
                {
                    lastOfChunk = lapDeltaSessionBestChange[i];
                }
            }

            if (changeStarted)
            {
                changeSum = lastOfChunk - firstOfChunk;
            }

            SBChunks[currentChunk] = changeSum;

            string SBResult = string.Join(",", SBChunks); //push result as string

            changeStarted = false;
            changeSum = 0;
            firstOfChunk = 0;
            lastOfChunk = 0;

            for (int i = currentChunk * chunkSize; i < myDeltaIndex + 1; i++)
            {
                if (!changeStarted)
                {
                    firstOfChunk = lapDeltaLapRecordChange[i];
                }
                changeStarted = true;

                if (i == myDeltaIndex)
                {
                    lastOfChunk = lapDeltaLapRecordChange[i];
                }
            }

            if (changeStarted)
            {
                changeSum = lastOfChunk - firstOfChunk;
            }

            LRChunks[currentChunk] = changeSum;

            string LRResult = string.Join(",", LRChunks); //push result as string



            Base.SetProp("DeltaLastLapChange", lastResult);
            Base.SetProp("DeltaSessionBestChange", SBResult);
            Base.SetProp("DeltaLapRecordChange", LRResult);

            //-----------------------------------------------------------------------------
            //----------------------REAL GAPS----------------------------------------------
            //-----------------------------------------------------------------------------

            int myLap = irData.Telemetry.CarIdxLap[myCarIdx]; //My lap count
            double myLoc = irData.Telemetry.CarIdxLapDistPct[myCarIdx]; //My current track position
            int myDistIndex = ((int)((myLoc * trackSections) * 100)) / 100; //Distance index, dividing track position into sections
            if (myDistIndex >= trackSections)
            {
                myDistIndex = trackSections - 1;
            }
            int myPrevIndex = myDistIndex - 1;
            if (myPrevIndex == -1)
            {
                myPrevIndex = trackSections - 1;
            }
            if (myDistIndex < 0)
            {
                myDistIndex = 0;
                myPrevIndex = 0;
            }

            if (sessionState == 4 && BestLapTimes != null)
            {
                for (int i = 0; i < 64; i++)
                {
                    if ((int)irData.Telemetry.CarIdxTrackSurface[i] != -1 && irData.Telemetry.CarIdxLap[i] > 0) //Checking if this CarID is in world
                    {
                        int distIndex = ((int)((irData.Telemetry.CarIdxLapDistPct[i] * trackSections) * 100)) / 100;
                        if (distIndex >= trackSections)
                        {
                            distIndex = trackSections - 1;
                        }
                        int distPrevIndex = distIndex - 1;
                        if (distPrevIndex == -1)
                        {
                            distPrevIndex = trackSections - 1;
                        }

                        if (distIndex < 0)
                        {
                            distIndex = 0;
                            distPrevIndex = 0;
                        }

                        int lap = irData.Telemetry.CarIdxLap[i];

                        float bestLapRaw = ((float[])BestLapTimes)[i];
                        double bestLap = Convert.ToDouble(bestLapRaw);
                        if (bestLap < 1)
                        {
                            bestLap = myExpectedLapTime;
                        }
                        double posdiff = myLoc - irData.Telemetry.CarIdxLapDistPct[i];
                        double lapdiff = myLap - lap + posdiff;
                        int truncdiff = ((int)((lapdiff) * 100)) / 100;

                        //Checking if car is in front. 
                        if ((posdiff < 0 && posdiff > -0.5) || posdiff > 0.5)
                        {
                            if (!realGapLocks[distIndex][i] && !realGapChecks[distIndex][i])  //Car arriving at unchecked, closed gate. Opening, snapshotting global clock, setting check. Unchecking previous gate. 
                            {
                                realGapPoints[distIndex][i] = globalClock;
                                realGapLocks[distIndex][i] = true;
                                realGapChecks[distIndex][i] = true;
                                realGapChecks[distPrevIndex][i] = false;
                            }

                            if (realGapLocks[myDistIndex][i]) //If I just arrived at an open gate , close it and post delta.
                            {
                                double delta = realGapPoints[myDistIndex][i].TotalSeconds - globalClock.TotalSeconds;

                                realGapOpponentRelative[i] = delta;

                                if (lapdiff < -1)
                                {
                                    delta = delta - truncdiff * myExpectedLapTime;
                                }
                                else if (lapdiff > 0)
                                {
                                    delta = bestLap + delta + truncdiff * bestLap;
                                }

                                realGapOpponentDelta[i] = delta;
                                realGapLocks[myDistIndex][i] = false;
                            }

                        }

                        else//Assume the car is behind
                        {
                            if (!realGapLocks[myDistIndex][i] && !realGapChecks[myDistIndex][i]) //If I just arrived at a unchecked, closed gate, open and snapshot global clock, checking. Unchecking previous gate.
                            {
                                realGapPoints[myDistIndex][i] = globalClock;
                                realGapLocks[myDistIndex][i] = true;
                                realGapChecks[myDistIndex][i] = true;
                                realGapChecks[myPrevIndex][i] = false;
                            }

                            //Calculating the total race distance to this car


                            if (realGapLocks[distIndex][i]) //If car just arrived at an open gate, close it and post delta. 
                            {
                                double delta = globalClock.TotalSeconds - realGapPoints[distIndex][i].TotalSeconds;

                                realGapOpponentRelative[i] = delta;

                                if (lapdiff < 0)
                                {
                                    delta = delta - myExpectedLapTime - truncdiff * myExpectedLapTime;
                                }
                                else if (lapdiff > 1)
                                {
                                    delta = delta + truncdiff * bestLap;
                                }

                                realGapOpponentDelta[i] = delta;
                                realGapLocks[distIndex][i] = false;


                            }

                        }
                    }
                }
            }




            //-----------------------------------------------------------------------------
            //----------------------IDLE AND RESETS----------------------------------------
            //-----------------------------------------------------------------------------

            //Stuf that happens when idle
            if (propIRIdle)
            {
                findLapRecord = true;
                csvIndex = 0;
                propCurrentFrontWing = 0;
                propCurrentRearWing = 0;
                currentPWS = 0;
                propCurrentTape = 0;
                propPitBox = 0.5;
                hasPitted = false;
                propValidStintLaps = 0;
                propInvalidStintLaps = 0;
                fuelTargetDeltaCumulative = 0;
                propRaceFinished = false;
                propJokerThisLap = false;
                jokerLapChecker = false;
                finishedCars = new List<string> { };
                fuelTargetCheck = false;
                oldFuelValue = 0;
                NBactive = false;
                propNBvalue = false;
                NBspeedLim = false;
                ERSlapCounter = currentLap;
                ERSstartingLap = true;
                TCon = false;
                TCduration = 0;
                propOffTrack = false;
                commandMinFuel = 0;
                commandMaxFuel = 500;
                propLEDwarningActive = false;
                tcBump = false;
                tcBumpCounter = 0;

                //Props that need refresh
                propTCactive = false;

                //Session or car or track change
                if (carModelHolder != carModel || trackHolder != track || sessionHolder != session)
                {
                    findLapRecord = true;
                    csvIndex = 0;
                    propIRchange = 0;
                    ERSChangeCount = 4;
                    savePitTimerLock = false;
                    savePitTimerSnap = new TimeSpan(0);
                    slowestLapTimeSpanCopy = new TimeSpan(0);
                    propLapTimeList = new List<TimeSpan> { listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller }; //Reset lap and status lists
                    propLapStatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propSector1TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propSector2TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propSector3TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propSector1StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propSector2StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propSector3StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propFuelTargetDeltas = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    propSessionBestSector1 = 0;
                    propSessionBestSector2 = 0;
                    propSessionBestSector3 = 0;
                    sessionBestLap = new TimeSpan(0);
                    propQLap1Status = 0;
                    propQLap2Status = 0;
                    qLap1Time = new TimeSpan(0);
                    qLap2Time = new TimeSpan(0);
                    lapRaceFinished = false;
                    timeRaceFinished = false;
                    timedOut = false;
                    leaderDecimal = 0;
                    isRaceLeader = false;
                    isLapLimited = false;
                    isTimeLimited = false;
                    propJokerLapCount = 0;
                    Base.SetProp("P1Finished", false);
                    minFuelPush = 0;
                    maxFuelPush = 0;
                    qLapStarted2 = false;

                    //Props that need refresh
                    propTCactive = false;

                    //Resetting relGap list
                    if (Base.counter == 59)
                    {
                        realGapLocks.Clear();
                        realGapChecks.Clear();
                        realGapPoints.Clear();
                        realGapOpponentDelta.Clear();
                        realGapOpponentRelative.Clear();
                        sessionCarsLapsSincePit.Clear();
                        sessionCarsLap.Clear();

                        lapDeltaCurrent.Clear();
                        lapDeltaSessionBest.Clear();
                        lapDeltaLast.Clear();
                        lapDeltaRecord.Clear();
                        lapDeltaLastChange.Clear();
                        lapDeltaSessionBestChange.Clear();
                        lapDeltaLapRecordChange.Clear();
                        lastChunks.Clear();
                        SBChunks.Clear();
                        LRChunks.Clear();

                        for (int u = 0; u < trackSections; u++)
                        {
                            List<bool> locks = new List<bool> { };
                            List<bool> checks = new List<bool> { };
                            List<TimeSpan> points = new List<TimeSpan> { };

                            for (int i = 0; i < 64; i++)
                            {
                                locks.Add(false);
                                checks.Add(false);
                                points.Add(TimeSpan.FromSeconds(0));
                            }

                            realGapLocks.Add(locks);
                            realGapChecks.Add(checks);
                            realGapPoints.Add(points);
                        }

                        for (int i = 0; i < 64; i++)
                        {
                            realGapOpponentDelta.Add(0);
                            realGapOpponentRelative.Add(0);
                            sessionCarsLapsSincePit.Add(-1);
                            sessionCarsLap.Add(-1);
                        }

                        for (int i = 0; i < lapDeltaSections + 1; i++)
                        {
                            lapDeltaCurrent.Add(-1);
                            lapDeltaSessionBest.Add(-1);
                            lapDeltaLast.Add(-1);
                            lapDeltaRecord.Add(-1);
                            lapDeltaLastChange.Add(0);
                            lapDeltaSessionBestChange.Add(0);
                            lapDeltaLapRecordChange.Add(0);
                        }
                        for (int i = 0; i < deltaChangeChunks; i++)
                        {
                            lastChunks.Add(0);
                            SBChunks.Add(0);
                            LRChunks.Add(0);
                        }
                    }

                }
            }

            //Stuf that happens when not idle

            if (!propIRIdle)
            {
                carModelHolder = carModel; //Updating choice of car, track and session
                trackHolder = track;
                sessionHolder = session;
            }

            //-----------------------------------------------------------------------------
            //----------------------SETTING GLOBAL PROPERTY VALUES-------------------------
            //-----------------------------------------------------------------------------

            if (propSessionBestSector1 > 0 && propSessionBestSector2 > 0 && propSessionBestSector3 > 0)
            {
                optimalLapTime = TimeSpan.FromSeconds(propSessionBestSector1 + propSessionBestSector2 + propSessionBestSector3);
            }
            else
            {
                optimalLapTime = new TimeSpan(0);
            }
        }

        /// <summary>
        /// THROTTLE CURVE
        /// </summary>
        private void ThrottleCurve()
        {
            if (throttle > 0 && throttle < 10 && !throttleTrigger && throttleClock == 0)
            {
                throttleTriggerCheck = true;
            }

            if (throttleTrigger)
            {
                throttleClock++;
            }

            if (throttleTriggerCheck)
            {
                throttleTrigger = true;
                throttleTriggerCheck = false;
                throttleCurve.Add(Math.Round(throttle, 1));
                throttleClock++;
            }

            if (throttleTrigger && throttleClock > (throttleClockBase + 3) && throttleCurve.Count < 41)
            {
                throttleCurve.Add(Math.Round(throttle, 1));
                throttleClockBase = throttleClock;
            }

            if (throttleCurve.Count == 40 && throttleTrigger)
            {
                throttleTrigger = false;
                string result = string.Join(",", throttleCurve); //push result as string
                propThrottleCurveValues = result;

                double agro = 0;
                for (int i = 0; i < 40; i++)
                {
                    if (throttleCurve[i] != 100)
                    {
                        agro++;
                    }
                    else if (throttleCurve[i] == 100)
                    {
                        break;
                    }
                }
                if (agro == 40)
                {
                    agro = 0;
                }
                propThrottleAgro = Math.Round((0.06666666667 * agro), 2);
            }
            if (throttleCurve.Count == 40 && throttle == 0)
            {
                throttleCurve.Clear();
                throttleClock = 0;
                throttleClockBase = 0;
            }
        }

        /// <summary>
        /// BRAKE CURVE
        /// </summary>
        private void BrakeCurve()
        {
            if (brake > 0 && !brakeTrigger && brakeClock == 0)
            {
                brakeTriggerCheck = true;
            }

            if (brakeTrigger)
            {
                brakeClock++;
                if (propBrakeMax < brake)
                {
                    propBrakeMax = brake;
                }
            }

            if (brakeTriggerCheck)
            {
                brakeTrigger = true;
                brakeTriggerCheck = false;
                brakeCurve.Add(Math.Round(brake, 1));
                brakeClock++;
            }

            if (brakeTrigger && brakeClock > (brakeClockBase + 5) && brakeCurve.Count < 41)
            {
                brakeCurve.Add(Math.Round(brake, 1));
                brakeClockBase = brakeClock;
            }

            if (brakeCurve.Count == 40 && brakeTrigger)
            {
                brakeTrigger = false;
                string result = string.Join(",", brakeCurve); //push result as string
                propBrakeCurveValues = result;

                double auc = 0;
                for (int i = 0; i < 40; i++)
                {
                    auc = auc + (0.1 * brakeCurve[i]);
                }
                propBrakeCurveAUC = Math.Round(auc, 1);
            }
            if (brakeCurve.Count == 40 && brake == 0)
            {
                brakeCurve.Clear();
                brakeClock = 0;
                brakeClockBase = 0;
                propBrakeMax = 0;
            }
        }

        /// <summary>
        /// Pit box location calculations
        /// </summary>
        private void PitBox()
        {
            propBoxApproach = false;

            propPitBox = (pitLocation - trackPosition) * trackLength;
            if (pitLocation < 0.2 && trackPosition > 0.8)
            {
                propPitBox = (pitLocation + (1 - trackPosition)) * trackLength;
            }
            else if (pitLocation > 0.8 && trackPosition < 0.2)
            {
                propPitBox = -((1 - pitLocation) + trackPosition) * trackLength;
            }

            awayFromPits = -propPitBox;

            if (propPitBox > -8 && propPitBox < 33 && pit == 1 && pitStall != 1 && hasPitted == true) //Car is approaching the pit box, and can pass by 8 meters. 
            {
                propBoxApproach = true;
                hasApproached = true;
            }

            if (Math.Abs(propPitBox) < 2 && pit == 1)   //Car is in the pit box
            {
                propPitBox = 1 - ((propPitBox + 2) / 4);
                propValidStintLaps = 0;
                propInvalidStintLaps = 0;
                stintLapsCheck = true;
                fuelTargetDeltaCumulative = 0;
            }
            else propPitBox = 0;

            if (pitStall == 1) //Car has spawned or recieved pit stop
            {
                hasPitted = false;
                propCurrentFrontWing = wingFront;
                propCurrentRearWing = wingRear;
                currentPWS = PWS;
                propCurrentTape = tape;
                propOffTrack = false;
                offTrackTimer = globalClock;
            }
            if (pit == 0)
            {
                hasApproached = false;
            }


            bool pitEntry = false;

            if (pitLimiter == 1 && pit == 0 && stintLength > 1000)
            {
                pitEntry = true;
            }

            bool pitSpeeding = false;

            if (pit == 1 && (Math.Round(speed, 0) - 2.5) > pitSpeedLimit)
            {
                pitSpeeding = true;
            }

            propPitEntry = pitEntry;
            propPitSpeeding = pitSpeeding;
        }

        /// <summary>
        /// Hotlap live position
        /// </summary>
        private void Hotlap()
        {
            int position = 0;
            for (int i = 0; i < opponents; i++)
            {
                if (estimatedLapTime.TotalSeconds > 0 && Base.gameData.NewData.Opponents[i].BestLapTime.TotalSeconds > 0 && estimatedLapTime.TotalSeconds > Base.gameData.NewData.Opponents[i].BestLapTime.TotalSeconds && Base.gameData.NewData.Opponents[i].CarClass == myClass && !Base.gameData.NewData.Opponents[i].IsPlayer)
                {
                    position++;
                }

            }
            if (opponents > 1 && !(session == "Race" && currentLap == 1))
            {
                position++;
            }

            if (estimatedLapTime.TotalSeconds == 0)
            {
                position = 0;
            }

            propHotLapLivePosition = position;
        }

        /// <summary>
        /// TC toggle
        /// </summary>
        private void TCtoggle()
        {
            if (!hasTC || TCPushTimer > 0 || (TC == TCoffPosition && TCoffPosition != -1) || (hasTCtog && !TCswitch))
            {
                propTCtoggle = false;
            }
            else
            {
                propTCtoggle = true;
            }
        }

        /// <summary>
        /// ABS toggle
        /// </summary>
        private void ABStoggle()
        {
            if (hasABStog || ABSoffPosition > -1)
            {
                if ((!ABSswitch && hasABStog) || ABSoffPosition == ABS)
                {
                    propABStoggle = false;
                }
                else
                {
                    propABStoggle = true;
                }
            }
            else
            {
                propABStoggle = false;
            }
        }

        /// <summary>
        /// RPM Tracker
        /// </summary>
        private void RPMTracker()
        {
            if (rpm > 300 && rpm > RPMtracker && !upshift && clutch == 0)
            {
                RPMtracker = rpm;
            }

            if (propRPMgear != gear && gear != "N")
            {
                propRPMlastGear = RPMtracker;
                RPMgearShift = true;

                switch (propRPMgear)
                {
                    case "1":
                        propLastShiftPoint = propShiftPoint1;
                        break;

                    case "2":
                        propLastShiftPoint = propShiftPoint2;
                        break;

                    case "3":
                        propLastShiftPoint = propShiftPoint3;
                        break;

                    case "4":
                        propLastShiftPoint = propShiftPoint4;
                        break;

                    case "5":
                        propLastShiftPoint = propShiftPoint5;
                        break;

                    case "6":
                        propLastShiftPoint = propShiftPoint6;
                        break;

                    case "7":
                        propLastShiftPoint = propShiftPoint7;
                        break;
                }

                propRPMgear = gear;
                RPMtracker = 0;
                upshift = false;
                downshift = false;
            }

            if (brake == 0)
            {
                RPMgearShift = false;
            }

            if (RPMgearShift && brake > 0 || pit == 1) //slowing down
            {
                RPMtracker = 0;
            }
        }

        /// <summary>
        /// TC EMULATION
        /// Materials on road: 2
        /// </summary>
        private void TCEmulation()
        {
            if (Base.Settings.WheelSlipLEDs || ((hasTCtog && TCswitch) || (hasTCtimer && TCPushTimer == 0)) && !(pitLimiter == 1 && speed > 0.9 * pitSpeedLimit) && TC != TCoffPosition)
            {

                if (TCrpm * 0.998 > rpm || TCdropCD > 0)  //Main filter
                {
                    TCdropCD++;
                    if (TCdropCD > 3 && gear == TCgear)
                    {
                        TCdropCD = 0;
                    }
                }

                int TCgearLimit = 25;

                if (carId == "Porsche 911 GT3.R") //Rediculous wobbly RPM on gear shift on this car
                {
                    TCgearLimit = 40;
                }

                if (upshift || TCgearCD > 0 || downshift) //Stop registering TC after gear shift
                {
                    TCgearCD++;
                }
                if (TCgearCD > TCgearLimit)
                {
                    TCgearCD = 0;
                    TCgear = gear;
                    TCthrottle = throttle;
                    TCrpm = rpm;
                }


                if (roadTextures.Contains(surface) && (Math.Abs(LRShockVel) > 0.13 || Math.Abs(RRShockVel) > 0.13))  //Filter on bumps
                {
                    tcBumpCounter = 1;
                }
                if (tcBumpCounter > 0)
                {
                    tcBump = true;
                    tcBumpCounter++;
                }
                if (tcBumpCounter > 20)
                {
                    tcBumpCounter = 0;
                    tcBump = false;
                }

                if ((TCthrottle == 0 && throttle > 0) || propTCreleaseCD > 0)  //Filter on heavy throttle application
                {
                    propTCreleaseCD++;
                    if (propTCreleaseCD > 25)
                    {
                        propTCreleaseCD = 0;
                    }
                }


                if (!tcBump && propTCreleaseCD == 0 && gear == TCgear && TCdropCD == 0 && (TCthrottle < throttle || TCthrottle == 100 && throttle == 100) && (throttle > 30 || trackLocation == 0) && TCrpm * 0.995 > rpm && rpm < 0.98 * propRevLim && speed < 200 && rpm > propIdleRPM * 1.3)
                {
                    TCon = true;
                    TCthrottle = throttle;
                    TCrpm = rpm;
                    TCduration = 0;
                }
                else if (TCdropCD == 0)
                {
                    TCthrottle = throttle;
                    TCrpm = rpm;
                }
                if (TCon)
                {
                    TCduration++;
                }
                if (TCduration > 20)
                {
                    TCon = false;
                    TCduration = 0;
                }

                //Running wheel slip through the filter
                if (!tcBump && propTCreleaseCD == 0 && gear == TCgear && TCdropCD == 0 && (((TCthrottle < throttle || TCthrottle == 100 && throttle == 100) && (throttle > 30 || trackLocation == 0)) || (slipLF == 100 || slipRF == 100)))
                {
                    propSlipLF = slipLF;
                    propSlipRF = slipRF;
                    propSlipLR = slipLR;
                    propSlipRR = slipRR;
                }

                if ((hasTCtog && TCswitch) || (hasTCtimer && TCPushTimer == 0)) //Push active TC, check again that calculations has been done because of TC, and not because of wheel slip calc
                {
                    propTCactive = TCon;
                }

            }
        }

        /// <summary>
        /// TC off toggle
        /// </summary>
        private void TCoff()
        {
            if (hasTCtimer)
            {

                if (!TCLimiter) //Idle state
                {
                    TCtimer = globalClock;
                }

                TCOffTimer = globalClock.TotalSeconds - TCtimer.TotalSeconds; //ticks/seconds, something = 0 in idle state

                if (TCactive) //Activated, sets timer to 5, keeps tractionTimer updated as long as button is held, starts the 5 second count-up when released
                {
                    TCOffTimer = 5;
                    TCtimer = globalClock;
                    TCLimiter = true;
                }

                if (globalClock.TotalSeconds - TCtimer.TotalSeconds > 5) //Ends the 5 second count-up 
                {
                    TCLimiter = false;
                }

                TCPushTimer = 5 - TCOffTimer; //Refining the result
                if (TCOffTimer > 5)
                {
                    TCPushTimer = 0;
                }

                if (TCOffTimer == 5)
                {
                    TCPushTimer = 5;
                }
                if (TCOffTimer == 0)
                {
                    TCPushTimer = 0;
                }

                propTCOffTimer = TimeSpan.FromSeconds(TCPushTimer);

            }
            else
            {
                propTCOffTimer = new TimeSpan(0);
            }
        }

        /// <summary>
        /// No Boost
        /// </summary>
        private void NoBoost()
        {
            if (hasNoBoost)
            {
                if (speed > 80)
                {
                    NBspeedLim = true;
                }

                if (NBpressed)
                {
                    NBactive = !NBactive;
                    NBpressed = false;
                }

                if (NBactive)
                {
                    propNBvalue = true;
                }

                if (speed < 80 && NBspeedLim || boost || !NBactive || MGU > 0 || battery == 1)
                {
                    propNBvalue = false;
                    NBspeedLim = false;
                    NBactive = false;
                }
            }
        }

        /// <summary>
        /// Radio toggle/name
        /// </summary>
        private void Radio()
        {
            if (irData.Telemetry.RadioTransmitCarIdx != -1)
            {
                propRadioName = irData.SessionData.DriverInfo.Drivers[irData.Telemetry.RadioTransmitCarIdx].UserName;
                propRadioIsSpectator = Convert.ToBoolean(irData.SessionData.DriverInfo.Drivers[irData.Telemetry.RadioTransmitCarIdx].IsSpectator);

                if (propRadioName == aheadGlobal)
                {
                    propRadioPosition = propRealPosition - 1;
                }
                else if (propRadioName == behindGlobal)
                {
                    propRadioPosition = propRealPosition + 1;
                }
                else
                {
                    propRadioPosition = irData.Telemetry.CarIdxClassPosition[irData.Telemetry.RadioTransmitCarIdx];
                }
            }
            else
            {
                propRadioName = "";
                propRadioIsSpectator = false;
            }

            propRadioName = propRadioName.ToUpper();

            if (irData.Telemetry.RadioTransmitCarIdx != -1)
            {
                propRadio = false;
            }
        }

        /// <summary>
        /// Full screen actions
        /// </summary>
        private void FullScreen(ref bool pressed, ref bool enable, ref bool released)
        {
            if (pressed)
            {
                enable = !enable;
                pressed = false;
            }

            if (released)
            {
                enable = false;
                pressed = false;
                released = false;
            }
        }

        private void PitCommands()
        {
            //Pit commands
            if (!Base.Settings.CoupleInCarToPit) // Ignore all of this if we explicitly state that coupling the InCar to Pit is off in settings)
            {
                pitMenuRequirementMet = true;
            }
            else if (
                inCarRotary == 0 && pitMenuRotary != 0 ||
                propRotaryType == "Single" ||
                (propRotaryType != "Single" && propRotaryType != "Default" && inCarRotary == 12))
            {
                pitMenuRequirementMet = true;
            }
            else
            {
                pitMenuRequirementMet = false;
            }

            bool aheadPlayerReady = false;
            bool behindPlayerReady = false;

            if (Base.gameData.NewData.OpponentsAheadOnTrack.Count > 0)
            {
                aheadPlayerReady = true;
            }
            if (Base.gameData.NewData.OpponentsBehindOnTrack.Count > 0)
            {
                behindPlayerReady = true;
            }

            if (propRotaryType == "Single" && pitMenuRotary == 0)
            {
                pitMenuRotary = inCarRotary;
            }

            if (plusButtonCheck)
            {
                if (pitMenuRotary == 1 && pitMenuRequirementMet)
                {
                    string pushPit = "";

                    if (commandMaxFuel == 0)
                    {
                        pushPit = "#clear ws$";
                    }
                    else
                    {
                        pushPit = "#clear fuel " + Convert.ToString(commandMaxFuel) + "l ws$";
                    }

                    iRacing.PitCommands.iRacingChat(pushPit);
                }
                else if (pitMenuRotary == 2 && pitMenuRequirementMet)
                {
                    propLaunchActive = !propLaunchActive;
                }
                else if (pitMenuRotary == 3 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#lf +3kpa rf +3kpa lr +3kpa rr +3kpa$");
                }
                else if (pitMenuRotary == 4 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        iRacing.PitCommands.iRacingChat("#lf +3kpa rf +3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#lf +3kpa lr +3kpa$");
                    }
                }
                else if (pitMenuRotary == 5 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        iRacing.PitCommands.iRacingChat("#lr +3kpa rr +3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#rf +3kpa rr +3kpa$");
                    }
                }
                else if (pitMenuRotary == 6 && pitMenuRequirementMet && aheadPlayerReady)
                {
                    iRacing.PitCommands.iRacingChat("/" + Base.gameData.NewData.OpponentsAheadOnTrack[0].CarNumber + " " + Base.Settings.AheadPlayerText);
                }
                else if (pitMenuRotary == 7 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#fuel +" + Base.Settings.SmallFuelIncrement + "l$");
                }
                else if (pitMenuRotary == 8 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#fuel +" + Base.Settings.LargeFuelIncrement + "l$");
                }
                else if (pitMenuRotary == 9 && pitMenuRequirementMet)
                {
                    watchSplit = true;
                }

                else if (pitMenuRotary == 10 && pitMenuRequirementMet)
                {
                    Base.Settings.ShowMapEnabled = !Base.Settings.ShowMapEnabled;
                }

                else if (pitMenuRotary == 11 && pitMenuRequirementMet)
                {
                    savePitTimerLock = true;
                    savePitTimerSnap = slowestLapTimeSpanCopy;
                }

                else if (pitMenuRotary == 12 && pitMenuRequirementMet)
                {
                    //pluginManager.TriggerAction("ShakeITBSV3Plugin.MainFeedbackLevelIncrement");
                    propFuelPerLapOffset = propFuelPerLapOffset + Base.Settings.fuelOffsetIncrement;
                }


                plusButtonCheck = false;
            }

            if (minusButtonCheck)
            {
                if (pitMenuRotary == 1 && pitMenuRequirementMet)
                {
                    string pushPit = "";
                    if (commandMinFuel == 0)
                    {
                        pushPit = "#clear ws$";
                    }
                    else
                    {
                        pushPit = "#clear fuel " + Convert.ToString(commandMinFuel) + "l ws$";
                    }
                    iRacing.PitCommands.iRacingChat(pushPit);
                }
                else if (pitMenuRotary == 2 && pitMenuRequirementMet)
                {
                    propPaceCheck = !propPaceCheck;
                }
                else if (pitMenuRotary == 3 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#lf -3kpa rf -3kpa lr -3kpa rr -3kpa$");
                }
                else if (pitMenuRotary == 4 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        iRacing.PitCommands.iRacingChat("#rf -3kpa lf -3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#lf -3kpa lr -3kpa$");
                    }
                }
                else if (pitMenuRotary == 5 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        iRacing.PitCommands.iRacingChat("#lr -3kpa rr -3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#rf -3kpa rr -3kpa$");
                    }
                }
                else if (pitMenuRotary == 6 && pitMenuRequirementMet && behindPlayerReady)
                {
                    string driverText = "/#" + Base.gameData.NewData.OpponentsBehindOnTrack[0].CarNumber + " " + Base.Settings.BehindPlayerText;
                    iRacing.PitCommands.iRacingChat(driverText);
                }
                else if (pitMenuRotary == 7 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#fuel -" + Base.Settings.SmallFuelIncrement + "l$");
                }
                else if (pitMenuRotary == 8 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#fuel -" + Base.Settings.LargeFuelIncrement + "l$");
                }

                else if (pitMenuRotary == 9 && pitMenuRequirementMet)
                {
                    watchTimer = globalClock;
                    watchSnap = 0;
                    watchReset = true;
                    watchResult = 0;
                    watchSplit = false;
                }

                else if (pitMenuRotary == 10 && pitMenuRequirementMet)
                {
                    propPitScreenEnable = !propPitScreenEnable;

                }

                else if (pitMenuRotary == 11 && pitMenuRequirementMet)
                {
                    savePitTimerLock = false;
                }

                else if (pitMenuRotary == 12 && pitMenuRequirementMet)
                {
                    //pluginManager.TriggerAction("ShakeITBSV3Plugin.MainFeedbackLevelDecrement");
                    if ((fuelAvgLap + propFuelPerLapOffset - Base.Settings.fuelOffsetIncrement) > 0)
                    {
                        propFuelPerLapOffset = propFuelPerLapOffset - Base.Settings.fuelOffsetIncrement;
                    }
                    else
                    {
                        propFuelPerLapOffset = -fuelAvgLap;
                    }
                }

                minusButtonCheck = false;
            }

            if (OKButtonCheck)
            {
                if (pitMenuRotary == 1 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#clear$");
                    propFuelPerLapOffset = 0;
                }
                else if (pitMenuRotary == 2 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#!fr$");
                }
                else if (pitMenuRotary == 3 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#!cleartires$");
                }
                else if (pitMenuRotary == 4 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#!lf !rf$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#!lf !lr$");
                    }
                    else
                    {
                        iRacing.PitCommands.iRacingChat("#!cleartires$");
                    }
                }
                else if (pitMenuRotary == 5 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#!lr !rr$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        iRacing.PitCommands.iRacingChat("#!rf !rr$");
                    }
                    else
                    {
                        iRacing.PitCommands.iRacingChat("#!cleartires$");
                    }
                }
                else if (pitMenuRotary == 6 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#!ws$");
                }
                else if (pitMenuRotary == 7 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#!fuel$");
                }
                else if (pitMenuRotary == 8 && pitMenuRequirementMet)
                {
                    iRacing.PitCommands.iRacingChat("#!fuel$");
                }
                else if (pitMenuRotary == 9 && pitMenuRequirementMet)
                {
                    watchOn = !watchOn;
                }
                else if (pitMenuRotary == 10 && pitMenuRequirementMet)
                {
                    propSpotMode = !propSpotMode;
                }
                else if (pitMenuRotary == 11 && pitMenuRequirementMet)
                {
                    Base.Dashboard.DeltaScreen.Next();
                }
                else if (pitMenuRotary == 12 && pitMenuRequirementMet)
                {
                    Base.Settings.fuelPerLapTarget = fuelAvgLap + propFuelPerLapOffset;
                }

                OKButtonCheck = false;
            }
        }

        /// <summary>
        /// OvertakeMode
        /// </summary>
        private void OvertakeMode()
        {
            propOvertakeMode = false;

            if (throttle == 100 && rpm > 300 && speed > 10)
            {
                propOvertakeMode = true;
            }
        }

        /// <summary>
        /// Wheel slip
        /// </summary>
        private void WheelSlip()
        {
            if (!Base.Settings.WheelSlipLEDs || slipLF < 25 || slipRF < 25)
            {
                slipLF = 0;
                slipLR = 0;
                slipRF = 0;
                slipRR = 0;
            }

            if (slipLF < 40 && slipLF > slipRF)
            {
                slipRF = 0;
                slipRR = 0;
            }
            else if (slipRF < 40 && slipRF > slipLF)
            {
                slipLF = 0;
                slipLR = 0;
            }

            if (slipLF == 0 && slipLR == 0)
            {
                propSlipLF = 0;
                propSlipRF = 0;
                propSlipLR = 0;
                propSlipRR = 0;
            }
        }

        /// <summary>
        /// TRIGGERED STOPWATCH
        /// </summary>
        private void StopWatch()
        {
            // -- Idle clock
            if (!watchOn && watchReset)
            {
                watchTimer = globalClock;
                watchResult = 0;
            }

            // -- Clock is started
            if (watchOn)
            {
                watchReset = false;
                watchResult = globalClock.TotalSeconds - watchTimer.TotalSeconds + watchSnap;
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
                watchTimer = globalClock;
                if (watchStopper)
                {
                    watchSnap = watchResult;
                    watchStopper = false;
                }
            }
        }

        /// <summary>
        /// ACCELERATION STOPWATCH
        /// </summary>
        private void Acceleration()
        {
            if (gear != "N" && speed < 0.5 && rpm > 300)
            {
                accelerationStart = true;
            }
            else if (accelerationPremature == 1)
            {
                propAccelerationTo200KPH = 0;
            }
            else if (accelerationPremature == 2)
            {
                propAccelerationTo100KPH = 0;
                propAccelerationTo200KPH = 0;
            }

            if (!accelerationStart && speed > 0.5)
            {
                if (!oneHundered && !twoHundered)
                {
                    accelerationPremature = 2;
                }
                else if (!twoHundered)
                {
                    accelerationPremature = 1;
                }
            }

            if (accelerationStart)
            {
                stopWatch = globalClock;
                oneHundered = false;
                twoHundered = false;
                propAccelerationTo100KPH = 0;
                propAccelerationTo200KPH = 0;
                accelerationStart = false;
            }

            if (!accelerationStart && speed > 0.5)
            {
                if (!oneHundered)
                {
                    propAccelerationTo100KPH = globalClock.TotalSeconds - stopWatch.TotalSeconds;
                }
                if (!twoHundered)
                {
                    propAccelerationTo200KPH = globalClock.TotalSeconds - stopWatch.TotalSeconds;
                }

            }

            if (speed > 100 && !oneHundered)
            {
                oneHundered = true;
                accelerationPremature = 1;
            }

            if (speed > 200 && !twoHundered)
            {
                twoHundered = true;
                accelerationPremature = 0;
            }
        }

        /// <summary>
        /// F3.5 DRS COUNT
        /// </summary>
        private void DRSCount()
        {
            DRSleft = 8 - myDRSCount;

            if (DRSleft < 0 || session != "Race")
            {
                DRSleft = 0;
            }

            //Special considerations

            //Indycar P2P

            if (carId == "Dallara IR18")
            {
                if (propP2pActive)
                {
                    propRevLim = 12300;
                    propShiftPoint1 = 12250;
                    propShiftPoint2 = 12270;
                    propShiftPoint3 = 12280;
                    propShiftPoint4 = 12280;
                    propShiftPoint5 = 12280;
                }

            }
        }

        /// <summary>
        /// MCLAREN MP4-30 ERS TARGET
        /// </summary>
        private void ERSTarget()
        {
            if (carId == "Mclaren MP4-30" || carId == "Mercedes W12")
            {
                irData.Telemetry.TryGetValue("dcMGUKDeployMode", out object rawERSMode);
                int ERSselectedMode = Convert.ToInt32(rawERSMode);
                int W12ERS = ERSselectedMode;
                int ERSstartMode = 0;
                if (Base.GetProp("GameRawData.SessionData.CarSetup.DriveBrake.PowerUnitConfig.TargetBatterySoc") != null)
                {
                    ERSstartMode = Convert.ToInt32(Convert.ToString(Base.GetProp("GameRawData.SessionData.CarSetup.DriveBrake.PowerUnitConfig.TargetBatterySoc")).Substring(0, 2));
                }

                if (W12ERS != W12ERSRef)
                {
                    if (speed > ERSlimit)
                    {
                        ERSChangeCount--;
                    }
                    W12ERSRef = W12ERS;
                    if (ERSChangeCount < 0)
                    {
                        ERSChangeCount = 0;
                    }
                }

                if (ERSstartingLap)
                {
                    ERSreturnMode = ERSstartMode;
                }

                if (currentLap != ERSlapCounter)
                {
                    ERSlapCounter = currentLap;
                    ERSreturnMode = ERSselectedMode;
                    ERSstartingLap = false;
                }

                propERSCharges = ERSChangeCount;
                propERSTarget = ERSreturnMode;
            }
            else
            {
                propERSCharges = 0;
                propERSTarget = 0;
            }
        }

        /// <summary>
        /// SHIFT LIGHT/SHIFT POINT PER GEAR
        /// </summary>
        private void ShiftLight()
        {
            switch (gear)
            {
                case "1":
                    propCurrentShiftPoint = propShiftPoint1;
                    shiftPointAdjustment = 4;
                    break;

                case "2":
                    propCurrentShiftPoint = propShiftPoint2;
                    shiftPointAdjustment = 2;
                    break;

                case "3":
                    propCurrentShiftPoint = propShiftPoint3;
                    shiftPointAdjustment = 1.5;
                    break;

                case "4":
                    propCurrentShiftPoint = propShiftPoint4;
                    shiftPointAdjustment = 1;
                    break;

                case "5":
                    propCurrentShiftPoint = propShiftPoint5;
                    shiftPointAdjustment = 0.8;
                    break;

                case "6":
                    propCurrentShiftPoint = propShiftPoint6;
                    shiftPointAdjustment = 0.7;
                    break;

                case "7":
                    propCurrentShiftPoint = propShiftPoint7;
                    shiftPointAdjustment = 0.4;
                    break;
                case "8":
                    propCurrentShiftPoint = Convert.ToInt32(propRevLim);
                    shiftPointAdjustment = 0;
                    break;
            }
            double amplifier = 1;

            if (gear == "N" && propSmoothGear == "N")
            {
                propCurrentShiftPoint = propShiftPoint1;
                shiftPointAdjustment = 0;
            }

            if (boost || MGU > 200000)
            {
                amplifier = amplifier + 0.3;
            }

            if (propHasDRS && propDRSpush == "Open")
            {
                amplifier = amplifier + 0.15;
            }

            double revSpeedCopy = revSpeed * amplifier;

            propShiftLightRPM = propCurrentShiftPoint - (Base.Settings.ReactionTime * shiftPointAdjustment * revSpeedCopy);
            double throttleFraction = throttle - 30;
            if (throttleFraction < 0)
            {
                throttleFraction = 0;
            }
            propShiftLightRPM = propShiftLightRPM + ((propCurrentShiftPoint - propShiftLightRPM) * (1 - throttleFraction / 70));
            if (propCurrentShiftPoint == 0)
            {
                propShiftLightRPM = propRevLim;
            }


            if (rpm < propShiftLightRPM)
            {
                reactionTime = globalClock;
                reactionGear = gear;
            }

            if (gear != reactionGear && gear == "N")
            {
                propReactionPush = globalClock.TotalMilliseconds - reactionTime.TotalMilliseconds - 40;
                reactionGear = gear;
            }
        }

        /// <summary>
        /// DRS
        /// </summary>
        private void DRS()
        {
            propDRSpush = "";
            switch (DRSState)
            {
                case 0:
                    propDRSpush = "None";
                    break;
                case 1:
                    propDRSpush = "Acquired";
                    if (carId == "Formula Renault 3.5")
                    {
                        propDRSpush = "None";
                    }
                    break;
                case 2:
                    propDRSpush = "Ready";
                    if (carId == "Formula Renault 3.5")
                    {
                        propDRSpush = "Open";
                    }
                    break;
                case 3:
                    propDRSpush = "Open";
                    break;
            }
        }

        /// <summary>
        /// TRACK ATTRIBUTES UPDATE
        /// </summary>
        private void TrackAttributes()
        {
            //Resetting values to default
            propTrackType = 0;
            hasExempt = false;
            exemptOne = 0;
            exemptOneMargin = 0;
            exemptTwo = 0;
            exemptTwoMargin = 0;
            hasCutOff = false;
            cutoffValue = 0;
            pitStopBase = 25;
            pitStopMaxSpeed = 0;
            pitStopCornerSpeed = 0;
            pitStopBrakeDistance = 0;
            pitStopAcceleration = 0;
            trackHasAnimatedCrew = false;
            pitFastSide = "Right";

            //Extracting info from track list

            Tracks _trackInfo = trackInfo.FirstOrDefault(x => x.Id == track);
            if (_trackInfo != null)
            {
                propTrackType = _trackInfo.TrackType;
                hasExempt = _trackInfo.HasExempt;
                exemptOne = _trackInfo.ExemptOne;
                exemptOneMargin = _trackInfo.ExemptOneMargin;
                exemptTwo = _trackInfo.ExemptTwo;
                exemptTwoMargin = _trackInfo.ExemptTwoMargin;
                hasCutOff = _trackInfo.HasCutOff;
                cutoffValue = _trackInfo.CutOff;
                pitStopBase = _trackInfo.PitStopBase;
                pitStopMaxSpeed = _trackInfo.PitStopMaxSpeed;
                pitStopCornerSpeed = _trackInfo.PitStopCornerSpeed;
                pitStopBrakeDistance = _trackInfo.PitStopBrakeDistance;
                pitStopAcceleration = _trackInfo.PitStopAcceleration;
                trackHasAnimatedCrew = _trackInfo.HasAnimatedCrew;
                pitFastSide = _trackInfo.PitFastSide;
            }


            if (hasCutOff)
            {
                cutoff = cutoffValue;
            }
            else
            {
                cutoff = 0.02;
            }

            if (propTrackType == 0)
            {
                if (trackConfig == "short oval")
                {
                    propTrackType = 6;
                }
                else if (trackConfig == "medium oval")
                {
                    propTrackType = 7;
                }
                else if (trackConfig == "super speedway")
                {
                    propTrackType = 8;
                }
                else if (trackConfig == "dirt oval")
                {
                    propTrackType = 5;
                }
                else if (trackConfig == "dirt road course")
                {
                    propTrackType = 4;
                }
            }
        }

        /// <summary>
        /// Off track registration
        /// </summary>
        private void OffTrack()
        {
            if ((session == "Race" || session == "Practice" || session == "Open Qualify") && sessionState > 3)
            {
                if ((trackLocation != 0 && !(pit != 1 && speed < 10) && !(awayFromPits > 2 && stintLength < 400 && stintLength > 20)) || ((currentLap == 1 || currentLap == 0) && stintLength < 400 && session == "Race"))
                {
                    offTrackTimer = globalClock;
                }
                if (globalClock.TotalSeconds - offTrackTimer.TotalSeconds > 1 && speed < 150)
                {
                    propOffTrack = true;
                }
                if (propOffTrack && globalClock.TotalSeconds - offTrackTimer.TotalSeconds < 1 && speed > 50)
                {
                    propOffTrack = false;
                }
            }
        }

        /// <summary>
        /// SoF AND IR LOSS/GAIN
        /// </summary>
        private void SofAndIrating()
        {
            List<double?> iratings = new List<double?> { };
            double weight = 1600 / Math.Log(2);
            double posCorr = (classOpponents / 2 - propRealPosition) / 100;

            for (int i = 0; i < opponents; i++)
            {
                if (Base.gameData.NewData.Opponents[i].CarClass == myClass)
                {
                    iratings.Add(Base.gameData.NewData.Opponents[i].IRacing_IRating);
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

            if (filtered.Count >= classOpponents)
            {
                for (int e = 0; e < classOpponents; e++)
                {
                    sum += Math.Pow(2, -filtered[e] / 1600);
                    IRscore += (1 - Math.Exp(-myIR / weight)) * Math.Exp(-filtered[e] / weight) / ((1 - Math.Exp(-filtered[e] / weight)) * Math.Exp(-myIR / weight) + (1 - Math.Exp(-myIR / weight)) * Math.Exp(-filtered[e] / weight));
                }
            }

            if (IRscore != 0)
            {
                IRscore = IRscore - 0.5;
            }

            propSoF = 0;

            if (sum != 0)
            {
                propSoF = Math.Round(weight * Math.Log(classOpponents / sum));
                if (session == "Race" && !propRaceFinished && sessionState > 3)
                {
                    propIRchange = Math.Round((classOpponents - propRealPosition - IRscore - posCorr) * 200 / classOpponents);
                }

            }
        }

        /// <summary>
        /// Smooth Gear
        /// </summary>
        private void SmoothGear()
        {
            if (gear != "N")
            {
                propSmoothGear = gear;
                neutralCounter = 0;
            }

            if (gear == "N")
            {
                neutralCounter++;
            }

            if (neutralCounter > 6)
            {
                propSmoothGear = "N";
                neutralCounter = 0;
            }
            if (Base.DDC.button8Mode == 1)
            {
                propSmoothGear = "N";
            }
        }

        /// <summary>
        /// Calculate sector deltas
        /// </summary>
        private void SectorDelta(int sectorNumber, double bestSector, List<double> timeList)
        {
            if (bestSector > 0)
            {
                for (int i = 0; i < timeList.Count; i++)
                {
                    if (timeList[i] > 0)
                    {
                        //Base.SetProp("Lap0" + (i + 1) + "Sector"+sectorNumber.ToString()+"Delta", Math.Round(delta, 3));
                        propLapSectorDelta[i, sectorNumber] = Math.Round(timeList[i] - bestSector, 3);
                    }
                }
            }
        }

        /// <summary>
        /// Add rotary action and bindings for Pit Menu
        /// </summary>
        private void AddRotaryPitMenu(int position)
        {
            Base.AddAction($"L{position:0}", (a, b) =>
            {
                pitMenuRotary = position;
                Base.SetProp("PitMenu", pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu", inCarRotary);
                }
            });
        }

        /// <summary>
        /// Add rotary action and bindings for inCar Menu
        /// </summary>
        private void AddRotaryInCar(int position)
        {
            Base.AddAction($"R{position:0}", (a, b) =>
           {
               inCarRotary = position;
               Base.SetProp("InCarMenu", inCarRotary);
               if (Base.Settings.DDSEnabled)
               {
                   if (propRotaryType == "Single")
                   {
                       pitMenuRotary = inCarRotary;
                       Base.SetProp("PitMenu", inCarRotary);
                   }
                   else
                   {
                       Base.SetProp("PitMenu", 0);
                   }
               }
           });
        }
    }
}