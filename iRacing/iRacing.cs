﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRacingReader;

namespace User.PluginSdkDemo.Categories
{
    public class iRacing
    {
        private readonly DahlDesign Base;

        #region Variables
        //CSV file adress
        string csvAdress = "";
        int csvIndex = 0;

        //Declaring global variables

        string myClassColor = "";
        int myClassColorIndex = 0;

        List<pitOpponents> pitStopOpponents = new List<pitOpponents> { };
        List<pitOpponents> finalList = new List<pitOpponents> { };

        int trackSections = 60;
        List<double> realGapOpponentDelta = new List<double> { };
        List<double> realGapOpponentRelative = new List<double> { };

        List<List<TimeSpan>> realGapPoints = new List<List<TimeSpan>> { };
        List<List<bool>> realGapLocks = new List<List<bool>> { };
        List<List<bool>> realGapChecks = new List<List<bool>> { };

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

        int roadOff = 0;
        bool outLap = false;
        double cutoff = 0.02;
        bool iRIdle = true;
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
        int currentSector3Status = 0;
        int lastSectorStatusHolder = 0;
        int sector1StatusHolder = 0;
        double sector1TimeHolder = 0;
        int sector2Incidents = 0;
        int sector3Incidents = 0;
        bool currentLapTimeStarted = false;

        double oneThird = 1d / 3d;
        double twoThirds = 2d / 3d;

        TimeSpan lapRecord = new TimeSpan(0);
        TimeSpan sessionBestLap = new TimeSpan(0);
        double sessionBestSector1 = 0;
        double sessionBestSector2 = 0;
        double sessionBestSector3 = 0;
        double sector1Pace = 0;
        double sector2Pace = 0;
        double sector3Pace = 0;

        int currentTape = 0;
        int currentPWS = 0;
        double currentFrontWing = 0;
        double currentRearWing = 0;

        TimeSpan lastLapHolder;
        TimeSpan lastLapChecker;
        static TimeSpan listFiller = new TimeSpan(0);
        List<TimeSpan> lapTimeList = new List<TimeSpan> { listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller };
        List<double> sector1TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> sector2TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<double> sector3TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };

        int lastStatusHolder = 0;
        List<int> lapStatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> sector1StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> sector2StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> sector3StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };

        List<double> fuelTargetDeltas = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
        double fuelTargetDeltaCumulative = 0;
        double fuelTargetDelta = 0;

        string classLeaderName = "";
        double? classLeaderRealGap = 0;

        string carModelHolder = "";
        string trackHolder = "";
        string sessionHolder = "";

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

        double pitBox = 0;
        double awayFromPits = 0;
        bool hasPitted = false;
        bool hasApproached = false;

        int validStintLaps = 0;
        int invalidStintLaps = 0;
        TimeSpan stintTimer = new TimeSpan(0);
        TimeSpan pushTimer = new TimeSpan(0);
        TimeSpan stintTimeTotal = new TimeSpan(0);
        int stintLapsTotal = 0;
        bool stintLapsCheck = false;

        int qualyPosition = 0;
        bool raceFinished = false;

        double? aheadGap = 0;
        string aheadClass = "";
        int aheadClassPosition = 0;

        int realPosition = 0;
        int hotLapPosition = 0;
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
        bool warmup = false;
        int qLap1Status = 0;
        int qLap2Status = 0;
        TimeSpan qLap1Time = new TimeSpan(0);
        TimeSpan qLap2Time = new TimeSpan(0);
        bool qLapStarted2 = false;

        bool isLapLimited = false;
        bool isTimeLimited = false;

        double pace = 0;
        double? remainingLaps = 0;

        int myIR = 0;
        double IRchange = 0;

        bool jokerThisLap = false;
        int jokerLapCount = 0;
        bool jokerLapChecker = false;

        //Track parameters
        int trackType = 0; //Track type: 0 = Road, 1-3 = RX, 4 = Dirt road w/o joker, 5 = Dirt Oval, 6 = Short oval, 7 = oval, 8 = super speedway
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
        bool hasAntiStall = false;
        bool hasDRS = false;
        bool hasTCtog = false;
        bool hasTCtimer = false;
        int TCoffPosition = -1;
        bool hasABS = false;
        bool hasTC = false;
        bool hasABStog = false;
        int ABSoffPosition = -1;
        int mapHigh = -1;
        int mapLow = -1;
        bool hasNoBoost = false;
        bool hasOvertake = false;
        string rotaryType = "Single";
        string dashType = "Default";
        int shiftPoint1 = 0;
        int shiftPoint2 = 0;
        int shiftPoint3 = 0;
        int shiftPoint4 = 0;
        int shiftPoint5 = 0;
        int shiftPoint6 = 0;
        int shiftPoint7 = 0;
        int currentShiftPoint = 0;
        double shiftPointAdjustment = 0;
        double shiftLightRPM = 0;
        int lastShiftPoint = 0;
        double revLim = 0;
        int idleRPM = 0;
        double clutchBitePoint = 0;
        double clutchSpin = 0;
        double clutchIdealRangeStart = 0;
        double clutchIdealRangeStop = 0;
        double clutchGearRelease = 0;
        double clutchTimeRelease = 0;
        double clutchGearReleased = 0;
        double clutchTimeReleased = 0;
        bool highPower = false;
        double launchThrottle = 0;
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
        AnimationType animaionType = AnimationType.Analog;
        double revSpeed = 1;

        int ERSlapCounter = 0;
        int ERSreturnMode = 0;
        bool ERSstartingLap = false;
        int ERSChangeCount = 0;
        int W12ERSRef = 0;


        double pitStopDuration = 0;
        bool LFTog = false;
        bool RFTog = false;
        bool LRTog = false;
        bool RRTog = false;
        bool fuelTog = false;
        bool WSTog = false;
        bool repairTog = false;

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
        double fuelPerLapOffset = 0;
        bool onlyThrough = true;

        bool fuelTargetCheck = false;
        double oldFuelValue = 0;
        double commandMinFuel = 0;
        double commandMaxFuel = 500;

        float LFCold = 0;
        float RFCold = 0;
        float LRCold = 0;
        float RRCold = 0;

        double minimumCornerSpeed = 0;
        double straightLineSpeed = 0;
        double highestThrottle = 0;
        bool throttleLift = false;

        string smoothGear = "";
        int neutralCounter = 0;

        //Buttons
        int pitMenuRotary = 12; //Starting on strat page
        int inCarRotary = 0;

        bool TCactive = false;
        double TCOffTimer = 0;
        bool TCLimiter = false;
        TimeSpan TCtimer = new TimeSpan(0);

        bool p2pActive = false;
        int p2pCounter = -1;
        int myTireCompound = -1;
        int myDRSCount = -1;

        bool radio = false;
        string radioName = "";
        int radioPosition;
        bool radioIsSpectator;

        bool NBpressed = false;
        bool NBactive = false;
        bool NBspeedLim = false;
        bool NBvalue = false;

        int fuelSaveDelta = 0;
        bool plusButtonCheck = false;
        bool minusButtonCheck = false;
        bool OKButtonCheck = false;
        bool upshift = false;
        bool downshift = false;
        bool launchPressed = false;
        bool launchReleased = false;
        bool launchActive = false;
        bool paceCheck = false;
        bool pacePressed = false;
        bool paceReleased = false;
        bool pitPressed = false;
        bool pitReleased = false;
        bool pitScreenEnable = false;
        bool bitePointPressed = false;
        bool bitePointReleased = false;
        bool bitePointAdjust = false;
        bool LEDwarningActive = false;
        bool spotMode = false;

        TimeSpan stopWatch = new TimeSpan(0);
        bool accelerationStart = false;
        int accelerationPremature = 0;
        bool oneHundered = false;
        bool twoHundered = false;
        TimeSpan reactionTime = new TimeSpan(0);
        string reactionGear = "";
        double reactionPush = 0;

        TimeSpan offTrackTimer = new TimeSpan(0);
        bool offTrack = false;

        double TCrpm = 0;
        double TCthrottle = 0;
        bool TCon = false;
        int TCduration = 0;
        string TCgear = "";
        int TCgearCD = 0;
        int TCreleaseCD = 0;
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
        double brakeMax = 0;

        int throttleClock = 0;
        int throttleClockBase = 0;
        List<double> throttleCurve = new List<double> { };
        bool throttleTrigger = false;
        bool throttleTriggerCheck = false;

        bool watchOn = false;
        bool watchReset = false;
        bool watchStopper = false;
        bool watchSplit = false;
        TimeSpan watchSplitTime = new TimeSpan(0);
        TimeSpan watchTimer = new TimeSpan(0);
        double watchResult = 0;
        double watchSnap = 0;

        string carNameLeft = "";
        string carNameRight = "";
        double? carPositionLeft = 0;
        double? carPositionRight = 0;
        bool leftTaken = false;
        bool rightTaken = false;

        double RPMtracker = 0;
        bool RPMgearShift = false;
        double RPMlastGear = 0;
        string RPMgear = "";

        List<string> classColors = new List<string> { "0xffda59", "0x33ceff", "0xff5888", "0xae6bff", "0x53ff77" };
        //1: light yellow
        //2: vivid cyan
        //3: light pink
        //4: very light violet
        //5: light lime green

        List<Tracks> trackInfo = new List<Tracks> { };
        List<Cars> carInfo = new List<Cars> { };

        DataSampleEx irData;
        #endregion

        public iRacing(DahlDesign dahlDesign)
        {
            Base = dahlDesign;

            //Find the lap records file
            LapRecords.findCSV(ref csvAdress);

            #region Tracks
            //Dirt road
            trackInfo.Add(new Tracks("atlanta rallycross long", 2, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("atlanta rallycross short", 2, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("brandshatch rallycross", 1, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("charlotte 2018 2019 rallycrosslong", 3, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("daytona rallycross long", 2, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("daytona rallycross short", 2, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("iowa rallycross", 2, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("lankebanen hellrx", 1, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("lankebanen rallyshort", 1, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("irp rallycross", 1, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("phoenix rallycross", 1, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("sonoma rallycross", 1, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("wildhorse", 4, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));
            trackInfo.Add(new Tracks("wildwest full", 4, false, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, "None"));

            //Road

            trackInfo.Add(new Tracks("daytona 2011 road", 0, false, 0, 0, 0, 0, false, 0, 19.5, 0.2, 0.3, 0.3, 0.1, true, "Left"));

            trackInfo.Add(new Tracks("silverstone 2019 gp", 0, false, 0, 0, 0, 0, false, 0, 13.5, 0.4, 0.3, 0.1, 0.2, false, "Right"));
            trackInfo.Add(new Tracks("silverstone 2019 international", 0, false, 0, 0, 0, 0, false, 0, 13.5, 0.4, 0.3, 0.1, 0.2, false, "Right"));
            trackInfo.Add(new Tracks("silverstone 2019 national", 0, false, 0, 0, 0, 0, false, 0, 17.5, 0.6, 0.2, 0, 0.2, false, "Right"));

            trackInfo.Add(new Tracks("limerock 2019 gp", 0, false, 0, 0, 0, 0, false, 0, 18.5, 0.6, 0, 0.2, 0.3, false, "Right"));
            trackInfo.Add(new Tracks("limerock 2019 classic", 0, false, 0, 0, 0, 0, false, 0, 18.5, 0.6, 0, 0.2, 0.3, false, "Right"));
            trackInfo.Add(new Tracks("limerock 2019 chicanes", 0, false, 0, 0, 0, 0, false, 0, 18.5, 0.55, 0, 0.2, 0.3, false, "Right"));
            trackInfo.Add(new Tracks("limerock 2019 chicanewestb", 0, false, 0, 0, 0, 0, false, 0, 18.5, 0.55, 0, 0.2, 0.3, false, "Right"));

            trackInfo.Add(new Tracks("longbeach", 0, true, 0.2, 0.05, 0.4, 0.05, false, 0, 20, 0, 0, 0, 0, false, "Right")); //PIT CREW INDY || base || other
            trackInfo.Add(new Tracks("okayama full", 0, false, 0, 0, 0, 0, true, 0.0035, 19, 0.2, 0.2, 0.2, 0.3, false, "Right")); //base || other
            trackInfo.Add(new Tracks("bathurst", 0, false, 0, 0, 0, 0, false, 0, 19.5, 0.7, 0.2, 0.0, 0.2, false, "Left"));
            trackInfo.Add(new Tracks("snetterton 300", 0, false, 0, 0, 0, 0, true, 0.005, 20, 0, 0, 0, 0, false, "Right")); //base || other
            trackInfo.Add(new Tracks("virginia east", 0, false, 0, 0, 0, 0, true, 0.005, 20, 0, 0, 0, 0, false, "Right")); //base || other
            #endregion            
            #region Cars
            carInfo.Add(new Cars("Dallara F312 F3", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "BiasOnly", 7200, 7100, 7050, 7000, 6950, 0, 0, 7340, 1932, 25.9, 25.5, 20.0, 32.0, 1, 90, 1, 90, false, 0, 1, 1, 1, 1, 7.0, false, 0, 0, 6, 1.5, CrewType.All, true, false, AnimationType.FormulaRenault, 0.35));
            carInfo.Add(new Cars("Dallara P217 LMP2", true, false, false, true, -1, false, true, false, -1, -1, -1, false, false, "Dallara LMP2", "Dallara LMP2", 8400, 8500, 8600, 8640, 8640, 0, 0, 8690, 2400, 41.3, 41.1, 41.3, 65, 1, 100, 1, 100, false, 0, 1.2, 1.05, 1.1, 1.1, 2.38, false, 0, 0, 10.9, 1.2, CrewType.FrontRear, false, true, AnimationType.LMP2, 0.3));
            carInfo.Add(new Cars("Porsche 919 2016", true, false, false, true, -1, false, true, false, -1, 1, 12, true, false, "Porsche 919", "Porsche 919", 8500, 8500, 8600, 8700, 8700, 8700, 0, 9003, 3000, 42.8, 42.7, 42.8, 53.2, 1, 100, 1, 100, false, 0, 1.2, 1.1, 1.1, 1.4, 3, false, 0, 0, 7.4, 1.4, CrewType.FrontRear, false, true, AnimationType.Porsche, 0.5));
            carInfo.Add(new Cars("Mclaren MP4-30", true, true, false, false, -1, false, false, false, -1, -1, -1, false, false, "Mclaren F1", "Mclaren F1", 12400, 12400, 12160, 11850, 11450, 11200, 11300, 12850, 3050, 60.0, 0, 0, 0, 1, 40, 1, 80, true, 70, 1.25, 1.1, 1.2, 1.3, 0, false, 0, 0, 3.2, 0, CrewType.All, true, false, AnimationType.MclarenF1, 1.1));
            carInfo.Add(new Cars("Mercedes W12", true, true, false, false, -1, false, false, false, -1, -1, -1, false, false, "Mercedes W12", "Mercedes W12", 11800, 11600, 11700, 11800, 11800, 11800, 11900, 12960, 4000, 54.5, 54.1, 0, 0, 1, 5, 1, 40, true, 50, 1.25, 1.1, 1.2, 1.3, 0, false, 0, 0, 3.2, 0, CrewType.All, true, false, AnimationType.MclarenF1, 1.05));
            carInfo.Add(new Cars("Mercedes AMG GT3", false, false, true, false, -1, true, true, true, 12, 3, 1, false, false, "Mercedes AMG GT3", "GT3", 7350, 7130, 6780, 6570, 6530, 0, 0, 7470, 1284, 37.5, 36.7, 36.8, 48.0, 1, 20, 1, 70, false, 50, 1, 0.9, 1.1, 0.7, 2.7, false, 0, 0, 6.5, 1.5, CrewType.SingleTyre, false, true, AnimationType.AMGGT3, 0.25));
            carInfo.Add(new Cars("Ferrari 488 GT3 Evo 2020", false, false, false, true, 1, true, true, false, 1, 1, 12, false, false, "Ferrari 488 GT3", "GT3", 7300, 7450, 7200, 7200, 7150, 0, 0, 7650, 1962, 33.2, 32.9, 32.9, 36.5, 1, 50, 1, 100, false, 0, 1, 0.9, 1.1, 0.7, 2.7, false, 0, 0, 6.5, 1.5, CrewType.SingleTyre, false, true, AnimationType.Ferrari488, 0.25));
            carInfo.Add(new Cars("Volkswagen Beetle GRC Lite", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Default", "Rally", 7500, 7500, 7500, 7500, 7500, 0, 0, 8190, 1918, 50, 50, 50, 50, 50, 50, 50, 50, false, 0, 0, 0, 0, 0, 0, false, 0, 0, 0, 0, CrewType.SingleTyre, true, true, AnimationType.Analog, 1)); //not finished 
            carInfo.Add(new Cars("Porsche 911 GT3 Cup (992)", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "BiasOnly", 8560, 8560, 8560, 8560, 8560, 0, 0, 8740, 1570, 40.5, 40.0, 40.5, 47.0, 1, 10, 1, 15, false, 0, 0.9, 0.8, 1.2, 0.9, 3, false, 0, 0, 6.5, 1.5, CrewType.SingleTyre, false, true, AnimationType.Porsche, 0.3));
            carInfo.Add(new Cars("Dallara IR18", true, false, false, false, -1, false, false, false, -1, 1, 8, false, true, "Indycar", "Indycar", 11900, 11900, 11930, 11960, 11960, 0, 0, 11995, 2999, 51.5, 0, 0, 0, 1, 70, 1, 80, true, 80, 0, 0, 0, 0, 9.2, true, 7.1, 0, 6.2, 0, CrewType.All, true, false, AnimationType.Indycar, 0.7));
            carInfo.Add(new Cars("Formula Renault 3.5", false, true, false, false, -1, false, false, false, -1, -1, -1, false, false, "FR3.5", "FR3.5", 8940, 8940, 8940, 8940, 8940, 0, 0, 8950, 2499, 44.5, 0, 0, 0, 1, 30, 1, 90, true, 63, 1.1, 1.1, 1, 1.1, 8.1, false, 0, 0, 6.2, 0, CrewType.All, true, false, AnimationType.FormulaRenault, 0.4));
            carInfo.Add(new Cars("Mazda MX-5 Cup", false, false, false, false, -1, true, false, false, -1, -1, -1, false, false, "Single", "Default", 7200, 7380, 7420, 7420, 0, 0, 0, 7350, 885, 45.5, 0, 40, 48, 1, 40, 1, 40, false, 0, 0.8, 0.8, 1, 0.5, 0.6, false, 0, 0, 10.3, 0, CrewType.LeftRight, true, true, AnimationType.MX5, 0.15));
            carInfo.Add(new Cars("Formula Vee", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "BiasOnly", 6500, 6500, 6500, 0, 0, 0, 0, 7330, 1171, 58.0, 57.5, 20, 65, 1, 90, 1, 90, false, 0, 0.65, 0.8, 1, 0.5, 0.56, false, 0, 0, 15, 0, CrewType.FrontRear, true, true, AnimationType.Vee, 0.1));
            carInfo.Add(new Cars("Skip Barber Formula 2000", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "Default", 6190, 6140, 6240, 6270, 0, 0, 0, 6350, 800, 28.5, 0, 27.0, 31.0, 1, 80, 1, 80, false, 0, 0.85, 0.85, 1, 0.7, 0.58, false, 0, 0, 9.0, 1.4, CrewType.FrontRear, true, false, AnimationType.Analog, 0.1));
            carInfo.Add(new Cars("Audi R8 LMS", false, false, false, true, 12, true, true, false, 12, -1, -1, false, false, "Audi R8 GT3", "GT3", 7950, 8080, 8120, 8050, 8000, 0, 0, 8480, 1090, 39.8, 39.5, 39.8, 45.0, 1, 100, 1, 100, false, 0, 1, 0.9, 1.1, 0.7, 2.7, false, 0, 0, 6.5, 1.5, CrewType.SingleTyre, false, true, AnimationType.AudiR8, 0.25));
            carInfo.Add(new Cars("Lamborghini Huracan GT3 EVO", false, false, false, true, 12, true, true, false, 12, 1, 12, false, false, "Lamborghini Huracan GT3", "GT3", 8250, 8200, 8220, 8220, 8240, 0, 0, 8480, 1090, 41.8, 41.5, 41.6, 45, 1, 60, 1, 70, false, 0, 1, 0.9, 1.1, 0.7, 2.7, false, 0, 0, 6.5, 1.5, CrewType.SingleTyre, false, true, AnimationType.LamboGT3, 0.25));
            carInfo.Add(new Cars("Porsche 911 GT3.R", true, false, false, true, 0, true, true, false, 0, 4, 0, false, false, "Porsche GT3R", "Porsche GT3R", 9250, 9250, 9250, 9250, 9250, 0, 0, 9435, 1846, 65.0, 64.5, 64.5, 65.5, 1, 90, 1, 90, false, 0, 1, 0.9, 1.1, 0.7, 2.7, false, 0, 0, 6.5, 1.5, CrewType.SingleTyre, false, true, AnimationType.PorscheGT3R, 0.25));
            carInfo.Add(new Cars("Audi 90 Quattro GTO", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "Default", 7650, 7650, 7650, 7650, 0, 0, 0, 7670, 1300, 0, 0, 0, 0, 0, 0, 0, 0, false, 0, 0, 0, 0, 0, 0, false, 0, 0, 10, 1, CrewType.SingleTyre, true, true, AnimationType.Porsche, 0.15));
            carInfo.Add(new Cars("Supercars Ford Mustang GT", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "Supercar", 7470, 7470, 7470, 7480, 7480, 0, 0, 7490, 1205, 29.5, 29.0, 29.6, 33.0, 1, 50, 1, 100, true, 0, 1.15, 0.7, 0.7, 0.9, 2.36, false, 0, 0, 6.7, 0.9, CrewType.All, true, true, AnimationType.Supercar, 0.35));
            carInfo.Add(new Cars("Supercars Holden ZB Commodore", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "Supercar", 7470, 7470, 7470, 7480, 7480, 0, 0, 7490, 1205, 29.5, 29.0, 29.6, 33.0, 1, 50, 1, 100, true, 0, 1.15, 0.7, 0.7, 0.9, 2.36, false, 0, 0, 6.7, 0.9, CrewType.All, true, true, AnimationType.Supercar, 0.35));
            carInfo.Add(new Cars("iRacing Formula IR-04", false, false, false, false, -1, false, false, false, -1, -1, -1, false, false, "Single", "BiasOnly", 7150, 7100, 7090, 7090, 7090, 0, 0, 7270, 1200, 33.8, 24.5, 25, 37, 1, 100, 1, 100, false, 0, 0.9, 1, 1, 0.9, 6.25, false, 0, 0, 6.11, 0, CrewType.All, true, false, AnimationType.F4, 0.35));
            #endregion
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

            Base.AddProp("TestProperty", 0);
            Base.AddProp("Position",  0);
            Base.AddProp("HotLapPosition",  0);
            Base.AddProp("RaceFinished",  false);
            Base.AddProp("SoF",  0);
            Base.AddProp("IRchange",  0);
            Base.AddProp("MyClassColor",  "");


            Base.AddProp("OptimalShiftGear1",  0);
            Base.AddProp("OptimalShiftGear2",  0);
            Base.AddProp("OptimalShiftGear3",  0);
            Base.AddProp("OptimalShiftGear4",  0);
            Base.AddProp("OptimalShiftGear5",  0);
            Base.AddProp("OptimalShiftGear6",  0);
            Base.AddProp("OptimalShiftGear7",  0);
            Base.AddProp("OptimalShiftCurrentGear",  0);
            Base.AddProp("OptimalShiftLastGear",  0);

            Base.AddProp("TrueRevLimiter",  0);
            Base.AddProp("IdleRPM",  0);

            Base.AddProp("Lap01Time",  new TimeSpan(0));
            Base.AddProp("Lap02Time",  new TimeSpan(0));
            Base.AddProp("Lap03Time",  new TimeSpan(0));
            Base.AddProp("Lap04Time",  new TimeSpan(0));
            Base.AddProp("Lap05Time",  new TimeSpan(0));
            Base.AddProp("Lap06Time",  new TimeSpan(0));
            Base.AddProp("Lap07Time",  new TimeSpan(0));
            Base.AddProp("Lap08Time",  new TimeSpan(0));

            Base.AddProp("Lap01Status",  0);
            Base.AddProp("Lap02Status",  0);
            Base.AddProp("Lap03Status",  0);
            Base.AddProp("Lap04Status",  0);
            Base.AddProp("Lap05Status",  0);
            Base.AddProp("Lap06Status",  0);
            Base.AddProp("Lap07Status",  0);
            Base.AddProp("Lap08Status",  0);

            Base.AddProp("Lap01Delta",  0);
            Base.AddProp("Lap02Delta",  0);
            Base.AddProp("Lap03Delta",  0);
            Base.AddProp("Lap04Delta",  0);
            Base.AddProp("Lap05Delta",  0);
            Base.AddProp("Lap06Delta",  0);
            Base.AddProp("Lap07Delta",  0);
            Base.AddProp("Lap08Delta",  0);

            Base.AddProp("SmallFuelIncrement",  Base.Settings.SmallFuelIncrement);
            Base.AddProp("LargeFuelIncrement",  Base.Settings.LargeFuelIncrement);
            Base.AddProp("CoupleInCarToPit",  Base.Settings.CoupleInCarToPit);

            Base.AddProp("Idle",  true);
            Base.AddProp("SmoothGear",  "");
            Base.AddProp("TrackEntry",  false);
            Base.AddProp("LastGearMaxRPM",  0);
            Base.AddProp("LastGear",  0);
            Base.AddProp("OvertakeMode",  false);

            Base.AddProp("StopWatch",  TimeSpan.FromSeconds(0));
            Base.AddProp("StopWatchSplit",  TimeSpan.FromSeconds(0));

            Base.AddProp("AccelerationTo100KPH",  0);
            Base.AddProp("AccelerationTo200KPH",  0);
            Base.AddProp("BrakeCurveValues",  "");
            Base.AddProp("BrakeCurvePeak",  0);
            Base.AddProp("BrakeCurveAUC",  0);
            Base.AddProp("ThrottleCurveValues",  "");
            Base.AddProp("ThrottleAgro",  0);

            Base.AddProp("ERSTarget",  0);
            Base.AddProp("ERSCharges",  0);
            Base.AddProp("TCActive",  false);
            Base.AddProp("TCToggle",  false);
            Base.AddProp("ABSToggle",  false);
            Base.AddProp("HasTC",  false);
            Base.AddProp("HasABS",  false);
            Base.AddProp("HasDRS",  false);
            Base.AddProp("DRSState",  "");
            Base.AddProp("HasAntiStall",  false);
            Base.AddProp("HasOvertake",  false);
            Base.AddProp("MapHigh",  mapHigh);
            Base.AddProp("MapLow",  mapLow);
            Base.AddProp("P2PCount",  -1);
            Base.AddProp("P2PStatus",  false);
            Base.AddProp("DRSCount",  -1);

            Base.AddProp("SlipLF",  0);
            Base.AddProp("SlipRF",  0);
            Base.AddProp("SlipLR",  0);
            Base.AddProp("SlipRR",  0);


            Base.AddProp("AnimationType",  1);
            Base.AddProp("ShiftLightRPM",  0);
            Base.AddProp("ReactionTime",  0);
            Base.AddProp("LEDWarnings", false);

            Base.AddProp("LaunchBitePoint",  0);
            Base.AddProp("LaunchSpin",  0);
            Base.AddProp("LaunchIdealRangeStart",  0);
            Base.AddProp("LaunchIdealRangeStop",  0);
            Base.AddProp("LaunchGearRelease",  0);
            Base.AddProp("LaunchGearReleased",  0);
            Base.AddProp("LaunchTimeRelease",  0);
            Base.AddProp("LaunchTimeReleased",  0);
            Base.AddProp("HighPower",  false);
            Base.AddProp("LaunchThrottle",  0);


            Base.AddProp("ApproximateCalculations",  false);
            Base.AddProp("LapsRemaining",  0);
            Base.AddProp("LapBalance",  0);

            Base.AddProp("LapStatus",  0);

            Base.AddProp("StintTimer",  new TimeSpan(0));
            Base.AddProp("StintTotalTime",  new TimeSpan(0));
            Base.AddProp("StintTotalHotlaps",  0);
            Base.AddProp("StintCurrentHotlap",  0);
            Base.AddProp("StintValidLaps",  0);
            Base.AddProp("StintInvalidLaps",  0);

            Base.AddProp("Pace",  new TimeSpan(0));

            Base.AddProp("PitBoxPosition",  1);
            Base.AddProp("PitBoxApproach",  false);
            Base.AddProp("PitEntry",  false);
            Base.AddProp("PitSpeeding",  false);

            Base.AddProp("SessionBestLap",  new TimeSpan(0));

            Base.AddProp("HotlapLivePosition",  0);

            Base.AddProp("QualyWarmUpLap",  false);
            Base.AddProp("QualyLap1Status",  0);
            Base.AddProp("QualyLap2Status",  0);
            Base.AddProp("QualyLap1Time",  new TimeSpan(0));
            Base.AddProp("QualyLap2Time",  new TimeSpan(0));



            Base.AddProp("CurrentSector",  0);
            Base.AddProp("CurrentSector1Time",  new TimeSpan(0));
            Base.AddProp("CurrentSector2Time",  new TimeSpan(0));
            Base.AddProp("CurrentSector3Time",  new TimeSpan(0));
            Base.AddProp("CurrentSector1Delta",  0);
            Base.AddProp("CurrentSector2Delta",  0);
            Base.AddProp("CurrentSector3Delta",  0);
            Base.AddProp("CurrentSector1Status",  0);
            Base.AddProp("CurrentSector2Status",  0);
            Base.AddProp("CurrentSector3Status",  0);
            Base.AddProp("SessionBestSector1",  new TimeSpan(0));
            Base.AddProp("SessionBestSector2",  new TimeSpan(0));
            Base.AddProp("SessionBestSector3",  new TimeSpan(0));
            Base.AddProp("Sector1Pace",  new TimeSpan(0));
            Base.AddProp("Sector2Pace",  new TimeSpan(0));
            Base.AddProp("Sector3Pace",  new TimeSpan(0));
            Base.AddProp("Sector1Score",  0);
            Base.AddProp("Sector2Score",  0);
            Base.AddProp("Sector3Score",  0);

            Base.AddProp("OptimalLapTime",  new TimeSpan(0));

            Base.AddProp("Lap01Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap01Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap01Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap01Sector1Delta",  0);
            Base.AddProp("Lap01Sector2Delta",  0);
            Base.AddProp("Lap01Sector3Delta",  0);
            Base.AddProp("Lap01Sector1Status",  0);
            Base.AddProp("Lap01Sector2Status",  0);
            Base.AddProp("Lap01Sector3Status",  0);
            Base.AddProp("Lap01FuelTargetDelta",  0);

            Base.AddProp("Lap02Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap02Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap02Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap02Sector1Delta",  0);
            Base.AddProp("Lap02Sector2Delta",  0);
            Base.AddProp("Lap02Sector3Delta",  0);
            Base.AddProp("Lap02Sector1Status",  0);
            Base.AddProp("Lap02Sector2Status",  0);
            Base.AddProp("Lap02Sector3Status",  0);
            Base.AddProp("Lap02FuelTargetDelta",  0);

            Base.AddProp("Lap03Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap03Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap03Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap03Sector1Delta",  0);
            Base.AddProp("Lap03Sector2Delta",  0);
            Base.AddProp("Lap03Sector3Delta",  0);
            Base.AddProp("Lap03Sector1Status",  0);
            Base.AddProp("Lap03Sector2Status",  0);
            Base.AddProp("Lap03Sector3Status",  0);
            Base.AddProp("Lap03FuelTargetDelta",  0);

            Base.AddProp("Lap04Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap04Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap04Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap04Sector1Delta",  0);
            Base.AddProp("Lap04Sector2Delta",  0);
            Base.AddProp("Lap04Sector3Delta",  0);
            Base.AddProp("Lap04Sector1Status",  0);
            Base.AddProp("Lap04Sector2Status",  0);
            Base.AddProp("Lap04Sector3Status",  0);
            Base.AddProp("Lap04FuelTargetDelta",  0);

            Base.AddProp("Lap05Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap05Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap05Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap05Sector1Delta",  0);
            Base.AddProp("Lap05Sector2Delta",  0);
            Base.AddProp("Lap05Sector3Delta",  0);
            Base.AddProp("Lap05Sector1Status",  0);
            Base.AddProp("Lap05Sector2Status",  0);
            Base.AddProp("Lap05Sector3Status",  0);
            Base.AddProp("Lap05FuelTargetDelta",  0);

            Base.AddProp("Lap06Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap06Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap06Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap06Sector1Delta",  0);
            Base.AddProp("Lap06Sector2Delta",  0);
            Base.AddProp("Lap06Sector3Delta",  0);
            Base.AddProp("Lap06Sector1Status",  0);
            Base.AddProp("Lap06Sector2Status",  0);
            Base.AddProp("Lap06Sector3Status",  0);
            Base.AddProp("Lap06FuelTargetDelta",  0);

            Base.AddProp("Lap07Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap07Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap07Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap07Sector1Delta",  0);
            Base.AddProp("Lap07Sector2Delta",  0);
            Base.AddProp("Lap07Sector3Delta",  0);
            Base.AddProp("Lap07Sector1Status",  0);
            Base.AddProp("Lap07Sector2Status",  0);
            Base.AddProp("Lap07Sector3Status",  0);
            Base.AddProp("Lap07FuelTargetDelta",  0);

            Base.AddProp("Lap08Sector1Time",  new TimeSpan(0));
            Base.AddProp("Lap08Sector2Time",  new TimeSpan(0));
            Base.AddProp("Lap08Sector3Time",  new TimeSpan(0));
            Base.AddProp("Lap08Sector1Delta",  0);
            Base.AddProp("Lap08Sector2Delta",  0);
            Base.AddProp("Lap08Sector3Delta",  0);
            Base.AddProp("Lap08Sector1Status",  0);
            Base.AddProp("Lap08Sector2Status",  0);
            Base.AddProp("Lap08Sector3Status",  0);
            Base.AddProp("Lap08FuelTargetDelta",  0);

            Base.AddProp("LapRecord",  new TimeSpan(0));
            Base.AddProp("DeltaLastLap",  0);
            Base.AddProp("DeltaSessionBest",  0);
            Base.AddProp("DeltaLapRecord",  0);
            Base.AddProp("DeltaLastLapChange",  "");
            Base.AddProp("DeltaSessionBestChange",  "");
            Base.AddProp("DeltaLapRecordChange",  "");

            Base.AddProp("P1Gap",  0);
            Base.AddProp("P1Name",  "");
            Base.AddProp("P1Pace",  new TimeSpan(0));
            Base.AddProp("P1Finished",  false);
            Base.AddProp("P1LapBalance",  0);

            Base.AddProp("ClassP1Gap",  0);
            Base.AddProp("ClassP1Name",  "");
            Base.AddProp("ClassP1Pace",  new TimeSpan(0));
            Base.AddProp("ClassP1RealGap",  0);

            Base.AddProp("LuckyDogGap",  0);
            Base.AddProp("LuckyDogRealGap",  0);
            Base.AddProp("LuckyDogName",  "");
            Base.AddProp("LuckyDogPositionsAhead",  0);

            Base.AddProp("AheadName",  "");
            Base.AddProp("AheadGap",  0);
            Base.AddProp("AheadPace",  new TimeSpan(0));
            Base.AddProp("AheadBestLap",  new TimeSpan(0));
            Base.AddProp("AheadIsConnected",  false);
            Base.AddProp("AheadIsInPit",  false);
            Base.AddProp("AheadSlowLap",  false);
            Base.AddProp("AheadPrognosis",  0);
            Base.AddProp("AheadLapsToOvertake",  0);
            Base.AddProp("AheadLapsSincePit",  -1);
            Base.AddProp("AheadP2PStatus",  false);
            Base.AddProp("AheadP2PCount",  -1);
            Base.AddProp("AheadRealGap",  0);

            Base.AddProp("BehindName",  "");
            Base.AddProp("BehindGap",  0);
            Base.AddProp("BehindPace",  new TimeSpan(0));
            Base.AddProp("BehindBestLap",  new TimeSpan(0));
            Base.AddProp("BehindIsConnected",  false);
            Base.AddProp("BehindIsInPit",  false);
            Base.AddProp("BehindSlowLap",  false);
            Base.AddProp("BehindPrognosis",  0);
            Base.AddProp("BehindLapsToOvertake",  0);
            Base.AddProp("BehindLapsSincePit",  -1);
            Base.AddProp("BehindP2PStatus",  false);
            Base.AddProp("BehindP2PCount",  -1);
            Base.AddProp("BehindRealGap",  0);

            Base.AddProp("LeftCarGap",  0);
            Base.AddProp("LeftCarName",  "");
            Base.AddProp("RightCarGap",  0);
            Base.AddProp("RightCarName",  "");

            Base.AddProp("CarAhead01Gap",  0);
            Base.AddProp("CarAhead01RaceGap",  0);
            Base.AddProp("CarAhead01BestLap",  new TimeSpan(0));
            Base.AddProp("CarAhead01Name",  "");
            Base.AddProp("CarAhead01Position",  0);
            Base.AddProp("CarAhead01IRating",  0);
            Base.AddProp("CarAhead01Licence",  "");
            Base.AddProp("CarAhead01IsAhead",  false);
            Base.AddProp("CarAhead01IsClassLeader",  false);
            Base.AddProp("CarAhead01IsInPit",  false);
            Base.AddProp("CarAhead01ClassColor",  "");
            Base.AddProp("CarAhead01ClassDifference",  0);
            Base.AddProp("CarAhead01JokerLaps",  0);
            Base.AddProp("CarAhead01LapsSincePit",  -1);
            Base.AddProp("CarAhead01P2PCount",  -1);
            Base.AddProp("CarAhead01P2PStatus",  false);
            Base.AddProp("CarAhead01RealGap",  0);
            Base.AddProp("CarAhead01RealRelative",  0);

            Base.AddProp("CarAhead02Gap",  0);
            Base.AddProp("CarAhead02RaceGap",  0);
            Base.AddProp("CarAhead02BestLap",  new TimeSpan(0));
            Base.AddProp("CarAhead02Name",  "");
            Base.AddProp("CarAhead02Position",  0);
            Base.AddProp("CarAhead02IRating",  0);
            Base.AddProp("CarAhead02Licence",  "");
            Base.AddProp("CarAhead02IsAhead",  false);
            Base.AddProp("CarAhead02IsClassLeader",  false);
            Base.AddProp("CarAhead02IsInPit",  false);
            Base.AddProp("CarAhead02ClassColor",  "");
            Base.AddProp("CarAhead02ClassDifference",  0);
            Base.AddProp("CarAhead02JokerLaps",  0);
            Base.AddProp("CarAhead02LapsSincePit",  -1);
            Base.AddProp("CarAhead02P2PCount",  -1);
            Base.AddProp("CarAhead02P2PStatus",  false);
            Base.AddProp("CarAhead02RealGap",  0);
            Base.AddProp("CarAhead02RealRelative",  0);

            Base.AddProp("CarAhead03Gap",  0);
            Base.AddProp("CarAhead03RaceGap",  0);
            Base.AddProp("CarAhead03BestLap",  new TimeSpan(0));
            Base.AddProp("CarAhead03Name",  "");
            Base.AddProp("CarAhead03Position",  0);
            Base.AddProp("CarAhead03IRating",  0);
            Base.AddProp("CarAhead03Licence",  "");
            Base.AddProp("CarAhead03IsAhead",  false);
            Base.AddProp("CarAhead03IsClassLeader",  false);
            Base.AddProp("CarAhead03IsInPit",  false);
            Base.AddProp("CarAhead03ClassColor",  "");
            Base.AddProp("CarAhead03ClassDifference",  0);
            Base.AddProp("CarAhead03JokerLaps",  0);
            Base.AddProp("CarAhead03LapsSincePit",  -1);
            Base.AddProp("CarAhead03P2PCount",  -1);
            Base.AddProp("CarAhead03P2PStatus",  false);
            Base.AddProp("CarAhead03RealGap",  0);
            Base.AddProp("CarAhead03RealRelative",  0);

            Base.AddProp("CarAhead04Gap",  0);
            Base.AddProp("CarAhead04RaceGap",  0);
            Base.AddProp("CarAhead04BestLap",  new TimeSpan(0));
            Base.AddProp("CarAhead04Name",  "");
            Base.AddProp("CarAhead04Position",  0);
            Base.AddProp("CarAhead04IRating",  0);
            Base.AddProp("CarAhead04Licence",  "");
            Base.AddProp("CarAhead04IsAhead",  false);
            Base.AddProp("CarAhead04IsClassLeader",  false);
            Base.AddProp("CarAhead04IsInPit",  false);
            Base.AddProp("CarAhead04ClassColor",  "");
            Base.AddProp("CarAhead04ClassDifference",  0);
            Base.AddProp("CarAhead04JokerLaps",  0);
            Base.AddProp("CarAhead04LapsSincePit",  -1);
            Base.AddProp("CarAhead04P2PCount",  -1);
            Base.AddProp("CarAhead04P2PStatus",  false);
            Base.AddProp("CarAhead04RealGap",  0);
            Base.AddProp("CarAhead04RealRelative",  0);

            Base.AddProp("CarAhead05Gap",  0);
            Base.AddProp("CarAhead05RaceGap",  0);
            Base.AddProp("CarAhead05BestLap",  new TimeSpan(0));
            Base.AddProp("CarAhead05Name",  "");
            Base.AddProp("CarAhead05Position",  0);
            Base.AddProp("CarAhead05IRating",  0);
            Base.AddProp("CarAhead05Licence",  "");
            Base.AddProp("CarAhead05IsAhead",  false);
            Base.AddProp("CarAhead05IsClassLeader",  false);
            Base.AddProp("CarAhead05IsInPit",  false);
            Base.AddProp("CarAhead05ClassColor",  "");
            Base.AddProp("CarAhead05ClassDifference",  0);
            Base.AddProp("CarAhead05JokerLaps",  0);
            Base.AddProp("CarAhead05LapsSincePit",  -1);
            Base.AddProp("CarAhead05P2PCount",  -1);
            Base.AddProp("CarAhead05P2PStatus",  false);
            Base.AddProp("CarAhead05RealGap",  0);
            Base.AddProp("CarAhead05RealRelative",  0);

            Base.AddProp("CarBehind01Gap",  0);
            Base.AddProp("CarBehind01RaceGap",  0);
            Base.AddProp("CarBehind01BestLap",  new TimeSpan(0));
            Base.AddProp("CarBehind01Name",  "");
            Base.AddProp("CarBehind01Position",  0);
            Base.AddProp("CarBehind01IRating",  0);
            Base.AddProp("CarBehind01Licence",  "");
            Base.AddProp("CarBehind01IsAhead",  false);
            Base.AddProp("CarBehind01IsClassLeader",  false);
            Base.AddProp("CarBehind01IsInPit",  false);
            Base.AddProp("CarBehind01ClassColor",  "");
            Base.AddProp("CarBehind01ClassDifference",  0);
            Base.AddProp("CarBehind01JokerLaps",  0);
            Base.AddProp("CarBehind01LapsSincePit",  -1);
            Base.AddProp("CarBehind01P2PCount",  -1);
            Base.AddProp("CarBehind01P2PStatus",  false);
            Base.AddProp("CarBehind01RealGap",  0);
            Base.AddProp("CarBehind01RealRelative",  0);

            Base.AddProp("CarBehind02Gap",  0);
            Base.AddProp("CarBehind02RaceGap",  0);
            Base.AddProp("CarBehind02BestLap",  new TimeSpan(0));
            Base.AddProp("CarBehind02Name",  "");
            Base.AddProp("CarBehind02Position",  0);
            Base.AddProp("CarBehind02IRating",  0);
            Base.AddProp("CarBehind02Licence",  "");
            Base.AddProp("CarBehind02IsAhead",  false);
            Base.AddProp("CarBehind02IsClassLeader",  false);
            Base.AddProp("CarBehind02IsInPit",  false);
            Base.AddProp("CarBehind02ClassColor",  "");
            Base.AddProp("CarBehind02ClassDifference",  0);
            Base.AddProp("CarBehind02JokerLaps",  0);
            Base.AddProp("CarBehind02LapsSincePit",  -1);
            Base.AddProp("CarBehind02P2PCount",  -1);
            Base.AddProp("CarBehind02P2PStatus",  false);
            Base.AddProp("CarBehind02RealGap",  0);
            Base.AddProp("CarBehind02RealRelative",  0);

            Base.AddProp("CarBehind03Gap",  0);
            Base.AddProp("CarBehind03RaceGap",  0);
            Base.AddProp("CarBehind03BestLap",  new TimeSpan(0));
            Base.AddProp("CarBehind03Name",  "");
            Base.AddProp("CarBehind03Position",  0);
            Base.AddProp("CarBehind03IRating",  0);
            Base.AddProp("CarBehind03Licence",  "");
            Base.AddProp("CarBehind03IsAhead",  false);
            Base.AddProp("CarBehind03IsClassLeader",  false);
            Base.AddProp("CarBehind03IsInPit",  false);
            Base.AddProp("CarBehind03ClassColor",  "");
            Base.AddProp("CarBehind03ClassDifference",  0);
            Base.AddProp("CarBehind03JokerLaps",  0);
            Base.AddProp("CarBehind03LapsSincePit",  -1);
            Base.AddProp("CarBehind03P2PCount",  -1);
            Base.AddProp("CarBehind03P2PStatus",  false);
            Base.AddProp("CarBehind03RealGap",  0);
            Base.AddProp("CarBehind03RealRelative",  0);

            Base.AddProp("CarBehind04Gap",  0);
            Base.AddProp("CarBehind04RaceGap",  0);
            Base.AddProp("CarBehind04BestLap",  new TimeSpan(0));
            Base.AddProp("CarBehind04Name",  "");
            Base.AddProp("CarBehind04Position",  0);
            Base.AddProp("CarBehind04IRating",  0);
            Base.AddProp("CarBehind04Licence",  "");
            Base.AddProp("CarBehind04IsAhead",  false);
            Base.AddProp("CarBehind04IsClassLeader",  false);
            Base.AddProp("CarBehind04IsInPit",  false);
            Base.AddProp("CarBehind04ClassColor",  "");
            Base.AddProp("CarBehind04ClassDifference",  0);
            Base.AddProp("CarBehind04JokerLaps",  0);
            Base.AddProp("CarBehind04LapsSincePit",  -1);
            Base.AddProp("CarBehind04P2PCount",  -1);
            Base.AddProp("CarBehind04P2PStatus",  false);
            Base.AddProp("CarBehind04RealGap",  0);
            Base.AddProp("CarBehind04RealRelative",  0);

            Base.AddProp("CarBehind05Gap",  0);
            Base.AddProp("CarBehind05RaceGap",  0);
            Base.AddProp("CarBehind05BestLap",  new TimeSpan(0));
            Base.AddProp("CarBehind05Name",  "");
            Base.AddProp("CarBehind05Position",  0);
            Base.AddProp("CarBehind05IRating",  0);
            Base.AddProp("CarBehind05Licence",  "");
            Base.AddProp("CarBehind05IsAhead",  false);
            Base.AddProp("CarBehind05IsClassLeader",  false);
            Base.AddProp("CarBehind05IsInPit",  false);
            Base.AddProp("CarBehind05ClassColor",  "");
            Base.AddProp("CarBehind05ClassDifference",  0);
            Base.AddProp("CarBehind05JokerLaps",  0);
            Base.AddProp("CarBehind05LapsSincePit",  -1);
            Base.AddProp("CarBehind05P2PCount",  -1);
            Base.AddProp("CarBehind05P2PStatus",  false);
            Base.AddProp("CarBehind05RealGap",  0);
            Base.AddProp("CarBehind05RealRelative",  0);

            Base.AddProp("FuelDelta",  0);
            Base.AddProp("FuelPitWindowFirst",  0);
            Base.AddProp("FuelPitWindowLast",  0);
            Base.AddProp("FuelMinimumFuelFill",  0);
            Base.AddProp("FuelMaximumFuelFill",  0);
            Base.AddProp("FuelPitStops",  0);
            Base.AddProp("FuelConserveToSaveAStop",  0);
            Base.AddProp("FuelAlert",  false);

            Base.AddProp("FuelDeltaLL",  0);
            Base.AddProp("FuelPitWindowFirstLL",  0);
            Base.AddProp("FuelPitWindowLastLL",  0);
            Base.AddProp("FuelMinimumFuelFillLL",  0);
            Base.AddProp("FuelMaximumFuelFillLL",  0);
            Base.AddProp("FuelPitStopsLL",  0);
            Base.AddProp("FuelConserveToSaveAStopLL",  0);

            Base.AddProp("FuelSlowestFuelSavePace",  new TimeSpan(0));
            Base.AddProp("FuelSaveDeltaValue",  0);
            Base.AddProp("FuelPerLapOffset",  0);
            Base.AddProp("FuelPerLapTarget",  0);
            Base.AddProp("FuelPerLapTargetLastLapDelta",  0);
            Base.AddProp("FuelTargetDeltaCumulative",  0);

            Base.AddProp("TrackType",  0);
            Base.AddProp("JokerThisLap",  false);
            Base.AddProp("JokerCount",  0);

            Base.AddProp("MinimumCornerSpeed",  0);
            Base.AddProp("StraightLineSpeed",  0);

            Base.AddProp("PitToggleLF",  false);
            Base.AddProp("PitToggleRF",  false);
            Base.AddProp("PitToggleLR",  false);
            Base.AddProp("PitToggleRR",  false);
            Base.AddProp("PitToggleFuel",  false);
            Base.AddProp("PitToggleWindscreen",  false);
            Base.AddProp("PitToggleRepair",  false);

            Base.AddProp("PitServiceFuelTarget",  0);
            Base.AddProp("PitServiceLFPSet",  0);
            Base.AddProp("PitServiceRFPSet",  0);
            Base.AddProp("PitServiceLRPSet",  0);
            Base.AddProp("PitServiceRRPSet",  0);
            Base.AddProp("PitServiceLFPCold",  0);
            Base.AddProp("PitServiceRFPCold",  0);
            Base.AddProp("PitServiceLRPCold",  0);
            Base.AddProp("PitServiceRRPCold",  0);

            Base.AddProp("CurrentFrontWing",  0);
            Base.AddProp("CurrentRearWing",  0);
            Base.AddProp("CurrentPowersteer",  0);
            Base.AddProp("CurrentTape",  0);

            Base.AddProp("PitCrewType",  0);
            Base.AddProp("PitTimeTires",  0);
            Base.AddProp("PitTimeFuel",  0);
            Base.AddProp("PitTimeWindscreen",  0);
            Base.AddProp("PitTimeAdjustment",  0);
            Base.AddProp("PitTimeDriveThrough",  0);
            Base.AddProp("PitTimeService",  0);
            Base.AddProp("PitTimeTotal",  0);


            Base.AddProp("PitExitPosition",  0);

            Base.AddProp("PitExitCar1Name",  "");
            Base.AddProp("PitExitCar1Gap",  0);
            Base.AddProp("PitExitCar1Position",  0);
            Base.AddProp("PitExitCar1ClassDifference",  0);
            Base.AddProp("PitExitCar1IsAhead",  false);
            Base.AddProp("PitExitCar1IsFaster",  false);

            Base.AddProp("PitExitCar2Name",  "");
            Base.AddProp("PitExitCar2Gap",  0);
            Base.AddProp("PitExitCar2Position",  0);
            Base.AddProp("PitExitCar2ClassDifference",  0);
            Base.AddProp("PitExitCar2IsAhead",  false);
            Base.AddProp("PitExitCar2IsFaster",  false);

            Base.AddProp("PitExitCar3Name",  "");
            Base.AddProp("PitExitCar3Gap",  0);
            Base.AddProp("PitExitCar3Position",  0);
            Base.AddProp("PitExitCar3ClassDifference",  0);
            Base.AddProp("PitExitCar3IsAhead",  false);
            Base.AddProp("PitExitCar3IsFaster",  false);

            Base.AddProp("PitExitCar4Name",  "");
            Base.AddProp("PitExitCar4Gap",  0);
            Base.AddProp("PitExitCar4Position",  0);
            Base.AddProp("PitExitCar4ClassDifference",  0);
            Base.AddProp("PitExitCar4IsAhead",  false);
            Base.AddProp("PitExitCar4IsFaster",  false);

            Base.AddProp("PitExitCar5Name",  "");
            Base.AddProp("PitExitCar5Gap",  0);
            Base.AddProp("PitExitCar5Position",  0);
            Base.AddProp("PitExitCar5ClassDifference",  0);
            Base.AddProp("PitExitCar5IsAhead",  false);
            Base.AddProp("PitExitCar5IsFaster",  false);

            Base.AddProp("PitExitCar6Name",  "");
            Base.AddProp("PitExitCar6Gap",  0);
            Base.AddProp("PitExitCar6Position",  0);
            Base.AddProp("PitExitCar6ClassDifference",  0);
            Base.AddProp("PitExitCar6IsAhead",  false);
            Base.AddProp("PitExitCar6IsFaster",  false);

            Base.AddProp("PitExitCar7Name",  "");
            Base.AddProp("PitExitCar7Gap",  0);
            Base.AddProp("PitExitCar7Position",  0);
            Base.AddProp("PitExitCar7ClassDifference",  0);
            Base.AddProp("PitExitCar7IsAhead",  false);
            Base.AddProp("PitExitCar7IsFaster",  false);

            Base.AddProp("PitExitCar8Name",  "");
            Base.AddProp("PitExitCar8Gap",  0);
            Base.AddProp("PitExitCar8Position",  0);
            Base.AddProp("PitExitCar8ClassDifference",  0);
            Base.AddProp("PitExitCar8IsAhead",  false);
            Base.AddProp("PitExitCar8IsFaster",  false);

            Base.AddProp("PitExitCar9Name",  "");
            Base.AddProp("PitExitCar9Gap",  0);
            Base.AddProp("PitExitCar9Position",  0);
            Base.AddProp("PitExitCar9ClassDifference",  0);
            Base.AddProp("PitExitCar9IsAhead",  false);
            Base.AddProp("PitExitCar9IsFaster",  false);

            Base.AddProp("PitExitCar10Name",  "");
            Base.AddProp("PitExitCar10Gap",  0);
            Base.AddProp("PitExitCar10Position",  0);
            Base.AddProp("PitExitCar10ClassDifference",  0);
            Base.AddProp("PitExitCar10IsAhead",  false);
            Base.AddProp("PitExitCar10IsFaster",  false);

            Base.AddProp("PitExitCar11Name",  "");
            Base.AddProp("PitExitCar11Gap",  0);
            Base.AddProp("PitExitCar11Position",  0);
            Base.AddProp("PitExitCar11ClassDifference",  0);
            Base.AddProp("PitExitCar11IsAhead",  false);
            Base.AddProp("PitExitCar11IsFaster",  false);

            Base.AddProp("PitExitCar12Name",  "");
            Base.AddProp("PitExitCar12Gap",  0);
            Base.AddProp("PitExitCar12Position",  0);
            Base.AddProp("PitExitCar12ClassDifference",  0);
            Base.AddProp("PitExitCar12IsAhead",  false);
            Base.AddProp("PitExitCar12IsFaster",  false);

            Base.AddProp("PitExitCar13Name",  "");
            Base.AddProp("PitExitCar13Gap",  0);
            Base.AddProp("PitExitCar13Position",  0);
            Base.AddProp("PitExitCar13ClassDifference",  0);
            Base.AddProp("PitExitCar13IsAhead",  false);
            Base.AddProp("PitExitCar13IsFaster",  false);

            Base.AddProp("PitExitCar14Name",  "");
            Base.AddProp("PitExitCar14Gap",  0);
            Base.AddProp("PitExitCar14Position",  0);
            Base.AddProp("PitExitCar14ClassDifference",  0);
            Base.AddProp("PitExitCar14IsAhead",  false);
            Base.AddProp("PitExitCar14IsFaster",  false);

            /*
             * Hardware buttons
             */
            Base.AddProp("FuelSaveDelta",  0);

            Base.AddProp("BitePointAdjust",  false);
            Base.AddAction("BitePointPressed",  (a, b) =>
            {
                bitePointPressed = true;
            });
            Base.AddAction("BitePointReleased",  (a, b) =>
            {
                bitePointReleased = true;
            });
            Base.AddAction("PlusPressed",  (a, b) =>
            {
                plusButtonCheck = true;
            });

            Base.AddAction("MinusPressed",  (a, b) =>
            {
                minusButtonCheck = true;
            });

            Base.AddAction("OKPressed",  (a, b) =>
            {
                OKButtonCheck = true;
            });

            Base.AddAction("Upshift",  (a, b) =>
            {
                upshift = true;
            });

            Base.AddAction("Downshift",  (a, b) =>
            {
                downshift = true;
            });

            Base.AddProp("LaunchScreen",  false);
            Base.AddAction("LaunchPressed",  (a, b) =>
            {
                launchPressed = true;
            });
            Base.AddAction("LaunchReleased",  (a, b) =>
            {
                launchReleased = true;
            });

            Base.AddProp("NoBoost",  false);
            Base.AddAction("NBPressed",  (a, b) =>
            {
                NBpressed = true;
            });
            Base.AddProp("SpotterMode",  false);



            Base.AddProp("Radio",  false);
            Base.AddProp("RadioName",  "");
            Base.AddProp("RadioPosition",  0);
            Base.AddProp("RadioIsSpectator",  false);

            Base.AddAction("RadioPressed",  (a, b) =>
            {
                radio = true;
            });
            Base.AddAction("RadioReleased",  (a, b) =>
            {
                radio = false;
            });

            Base.AddProp("PaceCheck",  false);
            Base.AddAction("PacePressed",  (a, b) =>
            {
                pacePressed = true;
            });
            Base.AddAction("PaceReleased",  (a, b) =>
            {
                paceReleased = true;
            });

            Base.AddProp("PitScreen",  false);
            Base.AddAction("PitPressed",  (a, b) =>
            {
                pitPressed = true;
            });
            Base.AddAction("PitReleased",  (a, b) =>
            {
                pitReleased = true;
            });

            Base.AddProp("TCOffTimer",  new TimeSpan(0));
            Base.AddAction("TCPressed",  (a, b) =>
            {
                TCactive = true;
            });
            Base.AddAction("TCReleased",  (a, b) =>
            {
                TCactive = false;
            });

            Base.AddProp("PitMenu",  1);
            Base.AddAction("L1",  (a, b) =>
            {
                pitMenuRotary = 1;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L2",  (a, b) =>
            {
                pitMenuRotary = 2;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L3",  (a, b) =>
            {
                pitMenuRotary = 3;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L4",  (a, b) =>
            {
                pitMenuRotary = 4;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L5",  (a, b) =>
            {
                pitMenuRotary = 5;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L6",  (a, b) =>
            {
                pitMenuRotary = 6;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L7",  (a, b) =>
            {
                pitMenuRotary = 7;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L8",  (a, b) =>
            {
                pitMenuRotary = 8;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L9",  (a, b) =>
            {
                pitMenuRotary = 9;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L10",  (a, b) =>
            {
                pitMenuRotary = 10;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L11",  (a, b) =>
            {
                pitMenuRotary = 11;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("L12",  (a, b) =>
            {
                pitMenuRotary = 12;
                Base.SetProp("PitMenu",  pitMenuRotary);
                if (Base.Settings.DDSEnabled)
                {
                    inCarRotary = 0;
                    Base.SetProp("InCarMenu",  inCarRotary);
                }
            });
            Base.AddAction("LInc",  (a, b) =>
            {
                pitMenuRotary++;
                if (pitMenuRotary > 12)
                {
                    pitMenuRotary = 1;
                }
                Base.SetProp("PitMenu",  pitMenuRotary);
            });
            Base.AddAction("LDec",  (a, b) =>
            {
                pitMenuRotary--;
                if (pitMenuRotary < 1)
                {
                    pitMenuRotary = 12;
                }
                Base.SetProp("PitMenu",  pitMenuRotary);
            });

            Base.AddAction("DeltaInc",  (a, b) =>
            {
                fuelSaveDelta++;
                if (fuelSaveDelta > 4)
                {
                    fuelSaveDelta = 0;
                }
                Base.SetProp("FuelSaveDelta",  fuelSaveDelta);
            });

            Base.AddAction("DeltaDec",  (a, b) =>
            {
                fuelSaveDelta--;
                if (fuelSaveDelta < 0)
                {
                    fuelSaveDelta = 4;
                }
                Base.SetProp("FuelSaveDelta",  fuelSaveDelta);
            });

            Base.AddProp("PitSavePaceLock",  false);

            Base.AddProp("InCarMenu",  0);
            Base.AddAction("R1",  (a, b) =>
            {
                inCarRotary = 1;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R2",  (a, b) =>
            {
                inCarRotary = 2;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R3",  (a, b) =>
            {
                inCarRotary = 3;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R4",  (a, b) =>
            {
                inCarRotary = 4;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R5",  (a, b) =>
            {
                inCarRotary = 5;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R6",  (a, b) =>
            {
                inCarRotary = 6;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R7",  (a, b) =>
            {
                inCarRotary = 7;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R8",  (a, b) =>
            {
                inCarRotary = 8;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R9",  (a, b) =>
            {
                inCarRotary = 9;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R10",  (a, b) =>
            {
                inCarRotary = 10;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R11",  (a, b) =>
            {
                inCarRotary = 11;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("R12",  (a, b) =>
            {
                inCarRotary = 12;
                Base.SetProp("InCarMenu",  inCarRotary);
                if (Base.Settings.DDSEnabled)
                {
                    if (rotaryType == "Single")
                    {
                        pitMenuRotary = inCarRotary;
                        Base.SetProp("PitMenu",  inCarRotary);
                    }
                    else
                    {
                        Base.SetProp("PitMenu",  0);
                    }
                }
            });
            Base.AddAction("RInc",  (a, b) =>
            {
                inCarRotary++;
                if (inCarRotary > 12)
                {
                    inCarRotary = 1;
                }
                Base.SetProp("InCarMenu",  inCarRotary);
            });
            Base.AddAction("RDec",  (a, b) =>
            {
                inCarRotary--;
                if (inCarRotary < 1)
                {
                    inCarRotary = 12;
                }
                Base.SetProp("InCarMenu",  inCarRotary);
            });
            #endregion

        }

        public void DataUpdateIdle()
        {
            if (Base.gameRunning) //Stuf that happens when out of game
                return;


            fuelPerLapOffset = 0;
            savePitTimerLock = false;
            savePitTimerSnap = new TimeSpan(0);
            slowestLapTimeSpanCopy = new TimeSpan(0);

            pitBox = 0.5;
            hasPitted = false;
            validStintLaps = 0;
            invalidStintLaps = 0;
            fuelTargetDeltaCumulative = 0;
            raceFinished = false;
            jokerThisLap = false;
            jokerLapChecker = false;
            finishedCars = new List<string> { };
            fuelTargetCheck = false;
            oldFuelValue = 0;
            NBactive = false;
            NBvalue = false;
            NBspeedLim = false;
            ERSlapCounter = 0;
            ERSstartingLap = true;
            TCon = false;
            TCduration = 0;
            offTrack = false;
            IRchange = 0;

            //Props that need refresh
            Base.SetProp("TCActive",  false);

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

            //Gaining access to raw data
            if (Base.gameData?.NewData?.GetRawDataObject() is DataSampleEx) { irData = Base.gameData.NewData.GetRawDataObject() as DataSampleEx; }

            //Updating relevant data
            TimeSpan globalClock = TimeSpan.FromTicks(DateTime.Now.Ticks);

            irData.Telemetry.TryGetValue("PlayerCarTeamIncidentCount", out object rawIncidents);
            int incidents = Convert.ToInt32(rawIncidents);                                          //Incidents

            irData.Telemetry.TryGetValue("PlayerCarInPitStall", out object rawStall);
            int pitStall = Convert.ToInt32(rawStall);                                               //Pit Stall

            irData.Telemetry.TryGetValue("ManualBoost", out object rawBoost);
            bool boost = Convert.ToBoolean(rawBoost);                                               //Boost

            irData.Telemetry.TryGetValue("PowerMGU_K", out object rawMGU);
            int MGU = Convert.ToInt32(rawMGU);                                                      //MGU-K current

            irData.Telemetry.TryGetValue("EnergyERSBatteryPct", out object rawBattery);
            double battery = Convert.ToDouble(rawBattery);                                          //Battery

            irData.Telemetry.TryGetValue("DRS_Status", out object rawDRS);
            int DRSState = Convert.ToInt32(rawDRS);                                                 //DRS state

            double slipLF = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.FrontLeft"));  //Wheel slip
            double slipRF = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.FrontRight"));  //Wheel slip
            double slipLR = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.RearLeft"));  //Wheel slip
            double slipRR = Convert.ToDouble(Base.GetProp("ShakeITMotorsV3Plugin.Export.WheelSlip.RearRight"));  //Wheel slip

            double trackPosition = irData.Telemetry.LapDistPct;                                     //Lap distance
            bool spotLeft = Convert.ToBoolean(Base.gameData.NewData.SpotterCarLeft);                         //Spotter call left
            bool spotRight = Convert.ToBoolean(Base.gameData.NewData.SpotterCarRight);                       //Spotter call left
            int completedLaps = Base.gameData.NewData.CompletedLaps;                                         //Completed laps
            int currentLap = Base.gameData.NewData.CurrentLap;                                               //Current lap
            int totalLaps = Base.gameData.NewData.TotalLaps;                                                 //Total laps
            TimeSpan currentLapTime = Base.gameData.NewData.CurrentLapTime;                                  //Current lap time
            int pit = Base.gameData.NewData.IsInPit;                                                         //Pit
            int pitLimiter = Base.gameData.NewData.PitLimiterOn;                                             //Pit limiter on/off
            string gear = Base.gameData.NewData.Gear;                                                        //Gear
            double fuelAvgLap = Convert.ToDouble(Base.GetProp("DataCorePlugin.Computed.Fuel_LitersPerLap")); //Fuel avg lap
            int black = Base.gameData.NewData.Flag_Black;                                                    //Black flag
            int white = Base.gameData.NewData.Flag_White;                                                    //White flag
            int checkered = Base.gameData.NewData.Flag_Checkered;                                            //Checkered flag
            TimeSpan lastLapTime = Base.gameData.NewData.LastLapTime;                                        //Last Lap Time 
            string carModel = Base.gameData.NewData.CarModel;                                                //Car model
            string track = Base.gameData.NewData.TrackName;                                                  //Track name
            string session = Base.gameData.NewData.SessionTypeName;                                          //Session type
            TimeSpan timeLeft = Base.gameData.NewData.SessionTimeLeft;                                       //Session time left
            double pitLocation = irData.SessionData.DriverInfo.DriverPitTrkPct;                     //Pit location
            double trackLength = Base.gameData.NewData.TrackLength;                                          //Track length
            double defaultRevLim = Base.gameData.NewData.CarSettings_MaxRPM;                                 //Default rev limiter
            int pitSpeedLimit = 0;                                                                  //Pit speed limit
            if (irData.SessionData.WeekendInfo.TrackPitSpeedLimit != null)
            {
                if (Convert.ToInt32(irData.SessionData.WeekendInfo.TrackPitSpeedLimit.Substring(0, 1)) != 0)
                {
                    pitSpeedLimit = Convert.ToInt32(irData.SessionData.WeekendInfo.TrackPitSpeedLimit.Substring(0, 2));
                }
            }

            int ERSlimit = 0;
            if (pitSpeedLimit > 70)
            {
                ERSlimit = 76;
            }
            else
            {
                ERSlimit = 52;
            }
            int sessionNumber = irData.Telemetry.SessionNum;                                        //Session number, to find correct session
            string trackConfig = irData.SessionData.WeekendInfo.TrackType;                          //Track type name
            int greenFlag = Base.gameData.NewData.Flag_Green;                                                //Green flag

            irData.Telemetry.TryGetValue("dcTractionControlToggle", out object rawTCswitch);        //In-game TC toggle
            bool TCswitch = Convert.ToBoolean(rawTCswitch);

            irData.Telemetry.TryGetValue("dcABSToggle", out object rawABSswitch);                   //In-game ABS toggle
            bool ABSswitch = Convert.ToBoolean(rawABSswitch);

            irData.Telemetry.TryGetValue("dcABS", out object rawABS);                               //In-game ABS switch position
            int ABS = Convert.ToInt32(rawABS);

            irData.Telemetry.TryGetValue("dcTractionControl", out object rawTC);                    //In-game TC switch position
            int TC = Convert.ToInt32(rawTC);

            irData.Telemetry.TryGetValue("PlayerTrackSurfaceMaterial", out object rawSurface);      //Track surface type
            int surface = Convert.ToInt32(rawSurface);

            double stintLength = Base.gameData.NewData.StintOdo;                                             //Stint length
            int opponents = Base.gameData.NewData.Opponents.Count;                                           //All opponents
            int classOpponents = Base.gameData.NewData.PlayerClassOpponentsCount;                            //Class opponents
            double fuel = Base.gameData.NewData.Fuel;                                                        //Fuel on tank

            irData.Telemetry.TryGetValue("SessionState", out object rawSessionState);
            int sessionState = Convert.ToInt32(rawSessionState);                                    //Session State

            irData.Telemetry.TryGetValue("PlayerTrackSurface", out object rawtrackLocation);
            int trackLocation = Convert.ToInt32(rawtrackLocation);                                  //TrkLoc

            irData.Telemetry.TryGetValue("dpWingFront", out object rawWingFront);                   //Front wing setting
            double wingFront = Math.Round(Convert.ToDouble(rawWingFront), 2);

            irData.Telemetry.TryGetValue("dpWingRear", out object rawWingRear);                     //Rear wing setting
            double wingRear = Math.Round(Convert.ToDouble(rawWingRear), 1);

            irData.Telemetry.TryGetValue("dpQTape", out object rawtape);                            //Tape
            int tape = Convert.ToInt16(rawtape);

            irData.Telemetry.TryGetValue("dpPowerSteering", out object rawPWS);                     //Powersteering
            int PWS = Convert.ToInt16(rawPWS);

            double gearRatio = Convert.ToDouble(Base.GetProp("GameRawData.SessionData.CarSetup.Chassis.Rear.DropGearARatio")); //Gear ratio

            irData.Telemetry.TryGetValue("SessionOnJokerLap", out object rawisOnJoker);             //Joker lap
            bool onJokerLap = Convert.ToBoolean(rawisOnJoker);

            irData.Telemetry.TryGetValue("PlayerCarIdx", out object rawPlayerIdx);                  //My CarIdx
            int myCarIdx = Convert.ToInt32(rawPlayerIdx);

            irData.Telemetry.TryGetValue("CarIdxP2P_Count", out object p2pCount);                   //P2P Counts
            irData.Telemetry.TryGetValue("CarIdxP2P_Status", out object p2pStatus);                 //P2P Statuses
            irData.Telemetry.TryGetValue("CarIdxBestLapTime", out object BestLapTimes);             //BestLapTimes
            irData.Telemetry.TryGetValue("CarIdxTireCompound", out object tireCompounds);           //Tire compounds

            bool furled = Convert.ToBoolean(Base.GetProp("GameRawData.Telemetry.SessionFlagsDetails.IsFurled"));  //Furled flag

            irData.Telemetry.TryGetValue("LRshockVel", out object rawLRShockVel);                   //Left rear shock
            double LRShockVel = Convert.ToDouble(rawLRShockVel);

            irData.Telemetry.TryGetValue("LRshockVel", out object rawRRShockVel);                   //Right rear shock
            double RRShockVel = Convert.ToDouble(rawRRShockVel);

            irData.Telemetry.TryGetValue("DRS_Count", out object rawDRSCount);                      //DRS Count
            if (rawDRSCount != null)
            {
                myDRSCount = Convert.ToInt32(rawDRSCount);
            }
            else
            {
                myDRSCount = 0;
            }

            var estimatedLapTime = (TimeSpan)(Base.GetProp("PersistantTrackerPlugin.EstimatedLapTime")); //EstimatedLapTime

            if (Base.gameData.NewData.OpponentsAheadOnTrack.Count > 0)
            {
                aheadGap = Base.gameData.NewData.OpponentsAheadOnTrack[0].GaptoPlayer;                       //Ahead GAP
                aheadClass = Base.gameData.NewData.OpponentsAheadOnTrack[0].CarClass;                        //Ahead Class
                aheadClassPosition = Base.gameData.NewData.OpponentsAheadOnTrack[0].PositionInClass;         //Ahead Position (class)
            }
            string myClass = Base.gameData.NewData.CarClass;                                                 //My Class
            int myPosition = irData.Telemetry.PlayerCarClassPosition;                               //My Position (class)
            double throttle = Base.gameData.NewData.Throttle;                                                //Throttle application
            double brake = Base.gameData.NewData.Brake;                                                      //Brake application
            double clutch = Base.gameData.NewData.Clutch;                                                    //Clutch application
            double speed = Base.gameData.NewData.SpeedLocal;                                                 //Speed
            double rpm = Base.gameData.NewData.Rpms;                                                         //RPM value

            double plannedFuel = Convert.ToDouble(irData.Telemetry.PitSvFuel);                      //Planned fuel
            double maxFuel = Base.gameData.NewData.MaxFuel;
            float plannedLFPressure = irData.Telemetry.PitSvLFP;                                    //Planned LF pressure
            float plannedRFPressure = irData.Telemetry.PitSvRFP;                                    //Planned RF pressure
            float plannedLRPressure = irData.Telemetry.PitSvLRP;                                    //Planned LR pressure
            float plannedRRPressure = irData.Telemetry.PitSvRRP;                                    //Planned RR pressure

            int cam = irData.Telemetry.CamCameraState;                                              //Cam state
            sessionScreen = Convert.ToBoolean(cam & 1);
            scenicActive = Convert.ToBoolean(cam & 2);
            camToolActive = Convert.ToBoolean(cam & 4);
            UIHidden = Convert.ToBoolean(cam & 8);
            useAutoShotSelection = Convert.ToBoolean(cam & 16);
            useTemporaryEdits = Convert.ToBoolean(cam & 32);
            useKeyAcceleration = Convert.ToBoolean(cam & 64);
            useKey10xAcceleration = Convert.ToBoolean(cam & 128);
            useMouseAimMode = Convert.ToBoolean(cam & 256);

            int pitInfo = irData.Telemetry.PitSvFlags;                                              //Pit stop toggles
            LFTog = Convert.ToBoolean(pitInfo & 1);
            RFTog = Convert.ToBoolean(pitInfo & 2);
            LRTog = Convert.ToBoolean(pitInfo & 4);
            RRTog = Convert.ToBoolean(pitInfo & 8);
            fuelTog = Convert.ToBoolean(pitInfo & 16);
            WSTog = Convert.ToBoolean(pitInfo & 32);
            repairTog = Convert.ToBoolean(pitInfo & 64);




            //-----------------------------------------------
            //--------TIRE ATTRIBUTES------------------------
            //-----------------------------------------------

            if (Base.counter == 47)
            {
                LFCold = irData.Telemetry.LFcoldPressure;
                RFCold = irData.Telemetry.RFcoldPressure;
                LRCold = irData.Telemetry.LRcoldPressure;
                RRCold = irData.Telemetry.RRcoldPressure;

                Base.SetProp("PitServiceLFPCold", LFCold);
                Base.SetProp("PitServiceRFPCold", RFCold);
                Base.SetProp("PitServiceLRPCold", LRCold);
                Base.SetProp("PitServiceRRPCold", RRCold);
            }

            //----------------------------------------------
            //--------SMOOTH GEAR---------------------------
            //----------------------------------------------

            if (gear != "N")
            {
                smoothGear = gear;
                neutralCounter = 0;
            }

            if (gear == "N")
            {
                neutralCounter++;
            }

            if (neutralCounter > 6)
            {
                smoothGear = "N";
                neutralCounter = 0;
            }
            if (Base.DDC.button8Mode == 1)
            {
                smoothGear = "N";
            }

            //----------------------------------------------
            //--------SoF AND IR LOSS/GAIN------------------
            //----------------------------------------------

            if (Base.counter == 8)
            {
                List<double?> iratings = new List<double?> { };
                double weight = 1600 / Math.Log(2);
                double posCorr = (classOpponents / 2 - realPosition) / 100;

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

                double SoF = 0;

                if (sum != 0)
                {
                    SoF = Math.Round(weight * Math.Log(classOpponents / sum));
                    if (session == "Race" && !raceFinished && sessionState > 3)
                    {
                        IRchange = Math.Round((classOpponents - realPosition - IRscore - posCorr) * 200 / classOpponents);
                    }

                }

                Base.SetProp("SoF", SoF);
                Base.SetProp("IRchange", IRchange);

            }

            //----------------------------------------------
            //--------OFF TRACK REGISTRATION----------------
            //----------------------------------------------
            if ((session == "Race" || session == "Practice" || session == "Open Qualify") && sessionState > 3)
            {
                if ((trackLocation != 0 && !(pit != 1 && speed < 10) && !(awayFromPits > 2 && stintLength < 400 && stintLength > 20)) || ((currentLap == 1 || currentLap == 0) && stintLength < 400 && session == "Race"))
                {
                    offTrackTimer = globalClock;
                }
                if (globalClock.TotalSeconds - offTrackTimer.TotalSeconds > 1 && speed < 150)
                {
                    offTrack = true;
                }
                if (offTrack && globalClock.TotalSeconds - offTrackTimer.TotalSeconds < 1 && speed > 50)
                {
                    offTrack = false;
                }
            }


            //-----------------------------------------------
            //--------TRACK ATTRIBUTES UPDATE----------------
            //-----------------------------------------------

            if (Base.counter == 1)
            {
                //Resetting values to default

                trackType = 0;
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

                for (int i = 0; i < trackInfo.Count; i++)
                {
                    if (track == trackInfo[i].Id)
                    {
                        trackType = trackInfo[i].TrackType;
                        hasExempt = trackInfo[i].HasExempt;
                        exemptOne = trackInfo[i].ExemptOne;
                        exemptOneMargin = trackInfo[i].ExemptOneMargin;
                        exemptTwo = trackInfo[i].ExemptTwo;
                        exemptTwoMargin = trackInfo[i].ExemptTwoMargin;
                        hasCutOff = trackInfo[i].HasCutOff;
                        cutoffValue = trackInfo[i].CutOff;
                        pitStopBase = trackInfo[i].PitStopBase;
                        pitStopMaxSpeed = trackInfo[i].PitStopMaxSpeed;
                        pitStopCornerSpeed = trackInfo[i].PitStopCornerSpeed;
                        pitStopBrakeDistance = trackInfo[i].PitStopBrakeDistance;
                        pitStopAcceleration = trackInfo[i].PitStopAcceleration;
                        trackHasAnimatedCrew = trackInfo[i].HasAnimatedCrew;
                        pitFastSide = trackInfo[i].PitFastSide;

                        break;
                    }
                }

                if (hasCutOff)
                {
                    cutoff = cutoffValue;
                }
                else
                {
                    cutoff = 0.02;
                }

                if (trackType == 0)
                {
                    if (trackConfig == "short oval")
                    {
                        trackType = 6;
                    }
                    else if (trackConfig == "medium oval")
                    {
                        trackType = 7;
                    }
                    else if (trackConfig == "super speedway")
                    {
                        trackType = 8;
                    }
                    else if (trackConfig == "dirt oval")
                    {
                        trackType = 5;
                    }
                    else if (trackConfig == "dirt road course")
                    {
                        trackType = 4;
                    }
                }

            }

            //-----------------------------------------------------------------------------
            //----------------------CAR ATTRIBUTES UPDATE----------------------------------
            //-----------------------------------------------------------------------------


            if (Base.counter == 14)
            {

                //Resetting values to default
                carId = "";
                hasAntiStall = false;
                hasDRS = false;
                hasTCtog = false;
                hasTCtimer = false;
                TCoffPosition = -1;
                hasABStog = false;
                hasABS = false;
                hasTC = false;
                ABSoffPosition = -1;
                mapHigh = -1;
                mapLow = -1;
                hasNoBoost = false;
                hasOvertake = false;
                rotaryType = "Single";
                dashType = "Default";
                shiftPoint1 = 0;
                shiftPoint2 = 0;
                shiftPoint3 = 0;
                shiftPoint4 = 0;
                shiftPoint5 = 0;
                shiftPoint6 = 0;
                shiftPoint7 = 0;
                revLim = defaultRevLim;
                idleRPM = 0;
                clutchBitePoint = 40;
                clutchSpin = 0;
                clutchIdealRangeStart = 0;
                clutchIdealRangeStop = 0;
                clutchGearRelease = 1;
                clutchTimeRelease = 0;
                clutchGearReleased = 1;
                clutchTimeReleased = 100;
                highPower = false;
                launchThrottle = 0;
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
                animaionType = AnimationType.Analog;
                revSpeed = 1;



                for (int i = 0; i < carInfo.Count; i++)
                {
                    if (carModel == carInfo[i].Id)
                    {
                        carId = carInfo[i].Id;
                        hasAntiStall = carInfo[i].HasAntiStall;
                        hasDRS = carInfo[i].HasDRS;
                        hasTCtog = carInfo[i].HasTCtog;
                        hasTCtimer = carInfo[i].HasTCtimer;
                        TCoffPosition = carInfo[i].TCOffPosition;
                        hasABStog = carInfo[i].HasABStog;
                        hasABS = carInfo[i].HasABS;
                        hasTC = carInfo[i].HasTC;
                        ABSoffPosition = carInfo[i].ABSOffPosition;
                        mapHigh = carInfo[i].MapHigh;
                        mapLow = carInfo[i].MapLow;
                        hasNoBoost = carInfo[i].HasNoBoost;
                        hasOvertake = carInfo[i].HasOvertake;
                        rotaryType = carInfo[i].RotaryType;
                        dashType = carInfo[i].DashType;
                        shiftPoint1 = carInfo[i].ShiftPoint1;
                        shiftPoint2 = carInfo[i].ShiftPoint2;
                        shiftPoint3 = carInfo[i].ShiftPoint3;
                        shiftPoint4 = carInfo[i].ShiftPoint4;
                        shiftPoint5 = carInfo[i].ShiftPoint5;
                        shiftPoint6 = carInfo[i].ShiftPoint6;
                        shiftPoint7 = carInfo[i].ShiftPoint7;
                        revLim = carInfo[i].RevLim;
                        idleRPM = carInfo[i].IdleRPM;
                        clutchBitePoint = carInfo[i].ClutchBitePoint;
                        clutchSpin = carInfo[i].ClutchSpin;
                        clutchIdealRangeStart = carInfo[i].ClutchIdealRangeStart;
                        clutchIdealRangeStop = carInfo[i].ClutchIdealRangeStop;
                        clutchGearRelease = carInfo[i].ClutchGearRelease;
                        clutchTimeRelease = carInfo[i].ClutchTimeRelease;
                        clutchGearReleased = carInfo[i].ClutchGearReleased;
                        clutchTimeReleased = carInfo[i].ClutchTimeReleased;
                        highPower = carInfo[i].HighPower;
                        launchThrottle = carInfo[i].LaunchThrottle;
                        pitMaxSpeed = carInfo[i].PitMaxSpeed;
                        pitCornerSpeed = carInfo[i].PitCornerSpeed;
                        pitBrakeDistance = carInfo[i].PitBrakeDistance;
                        pitAcceleration = carInfo[i].PitAcceleration;
                        pitFuelFillRate = carInfo[i].PitFuelFillRate;
                        carHasAnimatedCrew = carInfo[i].PitHasAnimatedCrew;
                        pitAniBaseTime = carInfo[i].PitAniBaseTime;
                        pitAniSlowAdd = carInfo[i].PitAniSlowAdd;
                        pitBaseTime = carInfo[i].PitBaseTime;
                        pitSlowAdd = carInfo[i].PitSlowAdd;
                        pitCrewType = carInfo[i].CrewType;
                        pitMultitask = carInfo[i].PitMultitask;
                        pitHasWindscreen = carInfo[i].PitHasWindscreen;
                        animaionType = carInfo[i].AnimationType;
                        revSpeed = carInfo[i].RevSpeed;
                        break;
                    }
                }

                if (Base.Settings.DashType != "Automatic Selection")
                {
                    dashType = Base.Settings.DashType;
                }

                if (p2pCount != null)
                {
                    p2pCounter = ((int[])p2pCount)[myCarIdx];
                }
                else
                {
                    p2pCounter = -1;
                }

                if (p2pStatus != null)
                {
                    p2pActive = ((bool[])p2pStatus)[myCarIdx];
                }
                else
                {
                    p2pActive = false;
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
                if (trackType > 0 && trackType < 5)
                {
                    rotaryType = "Default";
                }

                //Supercar gear ratio bite point setting
                if (dashType == "Supercar")
                {
                    switch (gearRatio)
                    {
                        case 0.85:
                            clutchBitePoint = 28;
                            clutchSpin = 0;
                            clutchIdealRangeStart = 28;
                            clutchIdealRangeStop = 31;
                            launchThrottle = 100;

                            break;
                        case 0.931:
                            clutchBitePoint = 30.0;
                            clutchSpin = 29.0;
                            clutchIdealRangeStart = 29.5;
                            clutchIdealRangeStop = 33;
                            launchThrottle = 85;
                            break;
                        case 0.96:
                            clutchBitePoint = 30.0;
                            clutchSpin = 29.5;
                            clutchIdealRangeStart = 31.0;
                            clutchIdealRangeStop = 34;
                            launchThrottle = 85;
                            break;
                        case 1:
                            clutchBitePoint = 32.0;
                            clutchSpin = 31.5;
                            clutchIdealRangeStart = 32.0;
                            clutchIdealRangeStop = 35;
                            launchThrottle = 80;
                            break;
                        case 1.042:
                            clutchBitePoint = 34.0;
                            clutchSpin = 33.0;
                            clutchIdealRangeStart = 34.0;
                            clutchIdealRangeStop = 36;
                            launchThrottle = 75;
                            break;
                        case 1.074:
                            clutchBitePoint = 34.0;
                            clutchSpin = 33.0;
                            clutchIdealRangeStart = 35.0;
                            clutchIdealRangeStop = 37;
                            launchThrottle = 70;
                            break;
                        case 1.13:
                            clutchBitePoint = 36.0;
                            clutchSpin = 35.0;
                            clutchIdealRangeStart = 35.5;
                            clutchIdealRangeStop = 38;
                            launchThrottle = 67;
                            break;
                    }
                }



                Base.SetProp("LaunchBitePoint", clutchBitePoint);
                Base.SetProp("LaunchSpin", clutchSpin);
                Base.SetProp("LaunchIdealRangeStart", clutchIdealRangeStart);
                Base.SetProp("LaunchIdealRangeStop", clutchIdealRangeStop);
                Base.SetProp("LaunchGearRelease", clutchGearRelease);
                Base.SetProp("LaunchGearReleased", clutchGearReleased);
                Base.SetProp("LaunchTimeRelease", clutchTimeRelease);
                Base.SetProp("LaunchTimeReleased", clutchTimeReleased);
                Base.SetProp("HighPower", highPower);
                Base.SetProp("LaunchThrottle", launchThrottle);

                Base.SetProp("OptimalShiftGear1", shiftPoint1);
                Base.SetProp("OptimalShiftGear2", shiftPoint2);
                Base.SetProp("OptimalShiftGear3", shiftPoint3);
                Base.SetProp("OptimalShiftGear4", shiftPoint4);
                Base.SetProp("OptimalShiftGear5", shiftPoint5);
                Base.SetProp("OptimalShiftGear6", shiftPoint6);
                Base.SetProp("OptimalShiftGear7", shiftPoint7);

                Base.SetProp("HasTC", hasTCtimer || hasTCtog || hasTC);
                Base.SetProp("HasABS", hasABS);
                Base.SetProp("HasDRS", hasDRS);
                Base.SetProp("HasAntiStall", hasAntiStall);
                Base.SetProp("HasOvertake", hasOvertake);
                Base.SetProp("MapHigh", mapHigh);
                Base.SetProp("MapLow", mapLow);

                Base.SetProp("AnimationType", (int)animaionType);

                Base.SetProp("TrueRevLimiter", revLim);
                Base.SetProp("IdleRPM", idleRPM);

                Base.SetProp("CenterDashType", dashType);
                Base.SetProp("MenuType", rotaryType);

            }


            //----------------------------------------------------
            //--------CHECK FOR BEST LAP--------------------------
            //----------------------------------------------------

            LapRecords.lapFetch(ref findLapRecord, csvAdress, ref csvIndex, track, carModel, ref lapRecord, ref lapDeltaRecord, lapDeltaSections);

            //----------------------------------------------------
            //--------F3.5 DRS COUNT------------------------------
            //----------------------------------------------------

            int DRSleft = 8 - myDRSCount;

            if (DRSleft < 0 || session != "Race")
            {
                DRSleft = 0;
            }

            Base.SetProp("P2PCount", p2pCounter);
            Base.SetProp("P2PStatus", p2pActive);
            Base.SetProp("DRSCount", DRSleft);

            //Special considerations

            //Indycar P2P

            if (carId == "Dallara IR18")
            {
                if (p2pActive)
                {
                    revLim = 12300;
                    shiftPoint1 = 12250;
                    shiftPoint2 = 12270;
                    shiftPoint3 = 12280;
                    shiftPoint4 = 12280;
                    shiftPoint5 = 12280;
                }

                Base.SetProp("OptimalShiftGear1", shiftPoint1);
                Base.SetProp("OptimalShiftGear2", shiftPoint2);
                Base.SetProp("OptimalShiftGear3", shiftPoint3);
                Base.SetProp("OptimalShiftGear4", shiftPoint4);
                Base.SetProp("OptimalShiftGear5", shiftPoint5);
                Base.SetProp("OptimalShiftGear6", shiftPoint6);
                Base.SetProp("OptimalShiftGear7", shiftPoint7);
                Base.SetProp("TrueRevLimiter", revLim);
            }



            //-----------------------------------------------
            //--------------DRS------------------------------
            //-----------------------------------------------
            string DRSpush = "";
            switch (DRSState)
            {
                case 0:
                    DRSpush = "None";
                    break;
                case 1:
                    DRSpush = "Acquired";
                    if (carId == "Formula Renault 3.5")
                    {
                        DRSpush = "None";
                    }
                    break;
                case 2:
                    DRSpush = "Ready";
                    if (carId == "Formula Renault 3.5")
                    {
                        DRSpush = "Open";
                    }
                    break;
                case 3:
                    DRSpush = "Open";
                    break;
            }

            Base.SetProp("DRSState", DRSpush);

            //----------------------------------------------
            //-------SHIFT LIGHT/SHIFT POINT PER GEAR-------
            //----------------------------------------------



            switch (gear)
            {
                case "1":
                    currentShiftPoint = shiftPoint1;
                    shiftPointAdjustment = 4;
                    break;

                case "2":
                    currentShiftPoint = shiftPoint2;
                    shiftPointAdjustment = 2;
                    break;

                case "3":
                    currentShiftPoint = shiftPoint3;
                    shiftPointAdjustment = 1.5;
                    break;

                case "4":
                    currentShiftPoint = shiftPoint4;
                    shiftPointAdjustment = 1;
                    break;

                case "5":
                    currentShiftPoint = shiftPoint5;
                    shiftPointAdjustment = 0.8;
                    break;

                case "6":
                    currentShiftPoint = shiftPoint6;
                    shiftPointAdjustment = 0.7;
                    break;

                case "7":
                    currentShiftPoint = shiftPoint7;
                    shiftPointAdjustment = 0.4;
                    break;
                case "8":
                    currentShiftPoint = Convert.ToInt32(revLim);
                    shiftPointAdjustment = 0;
                    break;
            }
            double amplifier = 1;

            if (gear == "N" && smoothGear == "N")
            {
                currentShiftPoint = shiftPoint1;
                shiftPointAdjustment = 0;
            }

            if (boost || MGU > 200000)
            {
                amplifier = amplifier + 0.3;
            }

            if (hasDRS && DRSpush == "Open")
            {
                amplifier = amplifier + 0.15;
            }

            double revSpeedCopy = revSpeed * amplifier;

            shiftLightRPM = currentShiftPoint - (Base.Settings.ReactionTime * shiftPointAdjustment * revSpeedCopy);
            double throttleFraction = throttle - 30;
            if (throttleFraction < 0)
            {
                throttleFraction = 0;
            }
            shiftLightRPM = shiftLightRPM + ((currentShiftPoint - shiftLightRPM) * (1 - throttleFraction / 70));
            if (currentShiftPoint == 0)
            {
                shiftLightRPM = revLim;
            }


            if (rpm < shiftLightRPM)
            {
                reactionTime = globalClock;
                reactionGear = gear;
            }

            if (gear != reactionGear && gear == "N")
            {
                reactionPush = globalClock.TotalMilliseconds - reactionTime.TotalMilliseconds - 40;
                reactionGear = gear;
            }

            Base.SetProp("OptimalShiftCurrentGear", currentShiftPoint);
            Base.SetProp("OptimalShiftLastGear", lastShiftPoint);
            Base.SetProp("ShiftLightRPM", shiftLightRPM);
            Base.SetProp("ReactionTime", Math.Round(reactionPush));

            //-------------------------------------
            //-------MCLAREN MP4-30 ERS TARGET-----
            //-------------------------------------



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

                Base.SetProp("ERSCharges", ERSChangeCount);
                Base.SetProp("ERSTarget", ERSreturnMode);
            }
            else
            {
                Base.SetProp("ERSTarget", 0);
                Base.SetProp("ERSCharges", 0);
            }


            //-------------------------------------
            //-------RX JOKER DETECTION------------
            //-------------------------------------

            if (onJokerLap)
            {
                jokerThisLap = true;
            }

            //----------------------------------
            //----ACCELERATION STOPWATCH--------
            //----------------------------------

            if (gear != "N" && speed < 0.5 && rpm > 300)
            {
                accelerationStart = true;
            }
            else if (accelerationPremature == 1)
            {
                Base.SetProp("AccelerationTo200KPH", 0);
            }
            else if (accelerationPremature == 2)
            {
                Base.SetProp("AccelerationTo100KPH", 0);
                Base.SetProp("AccelerationTo200KPH", 0);
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
                Base.SetProp("AccelerationTo100KPH", 0);
                Base.SetProp("AccelerationTo200KPH", 0);
                accelerationStart = false;
            }

            if (!accelerationStart && speed > 0.5)
            {
                if (!oneHundered)
                {
                    Base.SetProp("AccelerationTo100KPH", globalClock.TotalSeconds - stopWatch.TotalSeconds);
                }
                if (!twoHundered)
                {
                    Base.SetProp("AccelerationTo200KPH", globalClock.TotalSeconds - stopWatch.TotalSeconds);
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

            //----------------------------------------------------
            //------------Spotter calculations--------------------
            //----------------------------------------------------

            //LEFT SIDE

            if (spotLeft && !leftTaken) //Catch and lock
            {
                leftTaken = true;
                double? gap = 0;
                for (int i = 0; i < Base.gameData.NewData.OpponentsAheadOnTrack.Count; i++)
                {
                    if (((Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer != 0 && gap == 0) || Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer * trackLength < gap) && Base.gameData.NewData.OpponentsAheadOnTrack[i].Name != carNameRight)
                    {
                        carNameLeft = Base.gameData.NewData.OpponentsAheadOnTrack[i].Name;
                        carPositionLeft = Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        gap = carPositionLeft;
                    }
                }
                for (int i = 0; i < Base.gameData.NewData.OpponentsBehindOnTrack.Count; i++)
                {
                    if (((Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer != 0 && gap == 0) || -1 * Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer * trackLength < gap) && Base.gameData.NewData.OpponentsBehindOnTrack[i].Name != carNameRight)
                    {
                        carNameLeft = Base.gameData.NewData.OpponentsBehindOnTrack[i].Name;
                        carPositionLeft = Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        gap = carPositionLeft;
                    }
                }
            }

            if (leftTaken) //Read
            {
                for (int i = 0; i < Base.gameData.NewData.OpponentsAheadOnTrack.Count; i++)
                {
                    if (Base.gameData.NewData.OpponentsAheadOnTrack[i].Name == carNameLeft)
                    {
                        carPositionLeft = Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        break;
                    }
                }
                for (int i = 0; i < Base.gameData.NewData.OpponentsBehindOnTrack.Count; i++)
                {
                    if (Base.gameData.NewData.OpponentsBehindOnTrack[i].Name == carNameLeft)
                    {
                        carPositionLeft = Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        break;
                    }
                }
            }


            if (!spotLeft) //Release
            {
                leftTaken = false;
                carNameLeft = "";
                carPositionLeft = 0;
            }


            //RIGHT SIDE

            if (spotRight && !rightTaken) //Catch and lock
            {
                rightTaken = true;
                double? gap = 0;
                for (int i = 0; i < Base.gameData.NewData.OpponentsAheadOnTrack.Count; i++)
                {
                    if (((Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer != 0 && gap == 0) || Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer * trackLength < gap) && Base.gameData.NewData.OpponentsAheadOnTrack[i].Name != carNameLeft)
                    {
                        carNameRight = Base.gameData.NewData.OpponentsAheadOnTrack[i].Name;
                        carPositionRight = Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        gap = carPositionRight;
                    }
                }
                for (int i = 0; i < Base.gameData.NewData.OpponentsBehindOnTrack.Count; i++)
                {
                    if (((Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer != 0 && gap == 0) || -1 * Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer * trackLength < gap) && Base.gameData.NewData.OpponentsBehindOnTrack[i].Name != carNameLeft)
                    {
                        carNameRight = Base.gameData.NewData.OpponentsBehindOnTrack[i].Name;
                        carPositionRight = Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        gap = carPositionRight;
                    }
                }
            }

            if (rightTaken) //Read
            {
                for (int i = 0; i < Base.gameData.NewData.OpponentsAheadOnTrack.Count; i++)
                {
                    if (Base.gameData.NewData.OpponentsAheadOnTrack[i].Name == carNameRight)
                    {
                        carPositionRight = Base.gameData.NewData.OpponentsAheadOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        break;
                    }
                }
                for (int i = 0; i < Base.gameData.NewData.OpponentsBehindOnTrack.Count; i++)
                {
                    if (Base.gameData.NewData.OpponentsBehindOnTrack[i].Name == carNameRight)
                    {
                        carPositionRight = Base.gameData.NewData.OpponentsBehindOnTrack[i].TrackPositionPercentToPlayer * trackLength;
                        break;
                    }
                }
            }

            if (!spotRight) //Release
            {
                rightTaken = false;
                carNameRight = "";
                carPositionRight = 0;
            }

            Base.SetProp("LeftCarGap", carPositionLeft);
            Base.SetProp("LeftCarName", carNameLeft);
            Base.SetProp("RightCarGap", carPositionRight);
            Base.SetProp("RightCarName", carNameRight);


            //----------------------------------
            //-------TRIGGERED STOPWATCH--------
            //----------------------------------

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

            Base.SetProp("StopWatchSplit", watchSplitTime);
            Base.SetProp("StopWatch", TimeSpan.FromSeconds(watchResult));

            //----------------------------------
            //----------MISC--------------------
            //----------------------------------

            //Wheel slip
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
                Base.SetProp("SlipLF", 0);
                Base.SetProp("SlipRF", 0);
                Base.SetProp("SlipLR", 0);
                Base.SetProp("SlipRR", 0);
            }


            //OvertakeMode
            bool overtakeMode = false;

            if (throttle == 100 && rpm > 300 && speed > 10)
            {
                overtakeMode = true;
            }


            //Idle property
            if (sessionScreen && !spotMode)
            {
                iRIdle = true;
            }
            else
            {
                iRIdle = false;
            }

            //Identifying my class color and iRating
            if (Base.counter == 2)
            {
                for (int i = 0; i < irData.SessionData.DriverInfo.CompetingDrivers.Length; i++)
                {
                    if (Base.gameData.NewData.PlayerName == irData.SessionData.DriverInfo.CompetingDrivers[i].UserName)
                    {
                        myClassColor = irData.SessionData.DriverInfo.CompetingDrivers[i].CarClassColor;
                        myClassColorIndex = classColors.IndexOf(myClassColor);
                        myIR = Convert.ToInt32(irData.SessionData.DriverInfo.CompetingDrivers[i].IRating);
                        Base.SetProp("MyClassColor", myClassColor);
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

            //Pit commands
            if (!Base.Settings.CoupleInCarToPit) // Ignore all of this if we explicitly state that coupling the InCar to Pit is off in settings)
            {
                pitMenuRequirementMet = true;
            }
            else if (
                inCarRotary == 0 && pitMenuRotary != 0 ||
                rotaryType == "Single" ||
                (rotaryType != "Single" && rotaryType != "Default" && inCarRotary == 12))
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

            if (rotaryType == "Single" && pitMenuRotary == 0)
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

                    PitCommands.iRacingChat(pushPit);
                }
                else if (pitMenuRotary == 2 && pitMenuRequirementMet)
                {
                    launchActive = !launchActive;
                }
                else if (pitMenuRotary == 3 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#lf +3kpa rf +3kpa lr +3kpa rr +3kpa$");
                }
                else if (pitMenuRotary == 4 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        PitCommands.iRacingChat("#lf +3kpa rf +3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#lf +3kpa lr +3kpa$");
                    }
                }
                else if (pitMenuRotary == 5 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        PitCommands.iRacingChat("#lr +3kpa rr +3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#rf +3kpa rr +3kpa$");
                    }
                }
                else if (pitMenuRotary == 6 && pitMenuRequirementMet && aheadPlayerReady)
                {
                    PitCommands.iRacingChat("/" + Base.gameData.NewData.OpponentsAheadOnTrack[0].CarNumber + " " + Base.Settings.AheadPlayerText);
                }
                else if (pitMenuRotary == 7 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#fuel +" + Base.Settings.SmallFuelIncrement + "l$");
                }
                else if (pitMenuRotary == 8 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#fuel +" + Base.Settings.LargeFuelIncrement + "l$");
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
                    fuelPerLapOffset = fuelPerLapOffset + Base.Settings.fuelOffsetIncrement;
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
                    PitCommands.iRacingChat(pushPit);
                }
                else if (pitMenuRotary == 2 && pitMenuRequirementMet)
                {
                    paceCheck = !paceCheck;
                }
                else if (pitMenuRotary == 3 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#lf -3kpa rf -3kpa lr -3kpa rr -3kpa$");
                }
                else if (pitMenuRotary == 4 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        PitCommands.iRacingChat("#rf -3kpa lf -3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#lf -3kpa lr -3kpa$");
                    }
                }
                else if (pitMenuRotary == 5 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight || pitCrewType == CrewType.All)
                    {
                        PitCommands.iRacingChat("#lr -3kpa rr -3kpa$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#rf -3kpa rr -3kpa$");
                    }
                }
                else if (pitMenuRotary == 6 && pitMenuRequirementMet && behindPlayerReady)
                {
                    string driverText = "/#" + Base.gameData.NewData.OpponentsBehindOnTrack[0].CarNumber + " " + Base.Settings.BehindPlayerText;
                    PitCommands.iRacingChat(driverText);
                }
                else if (pitMenuRotary == 7 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#fuel -" + Base.Settings.SmallFuelIncrement + "l$");
                }
                else if (pitMenuRotary == 8 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#fuel -" + Base.Settings.LargeFuelIncrement + "l$");
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
                    pitScreenEnable = !pitScreenEnable;

                }

                else if (pitMenuRotary == 11 && pitMenuRequirementMet)
                {
                    savePitTimerLock = false;
                }

                else if (pitMenuRotary == 12 && pitMenuRequirementMet)
                {
                    //pluginManager.TriggerAction("ShakeITBSV3Plugin.MainFeedbackLevelDecrement");
                    if ((fuelAvgLap + fuelPerLapOffset - Base.Settings.fuelOffsetIncrement) > 0)
                    {
                        fuelPerLapOffset = fuelPerLapOffset - Base.Settings.fuelOffsetIncrement;
                    }
                    else
                    {
                        fuelPerLapOffset = -fuelAvgLap;
                    }
                }

                minusButtonCheck = false;
            }

            if (OKButtonCheck)
            {
                if (pitMenuRotary == 1 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#clear$");
                    fuelPerLapOffset = 0;
                }
                else if (pitMenuRotary == 2 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#!fr$");
                }
                else if (pitMenuRotary == 3 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#!cleartires$");
                }
                else if (pitMenuRotary == 4 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#!lf !rf$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#!lf !lr$");
                    }
                    else
                    {
                        PitCommands.iRacingChat("#!cleartires$");
                    }
                }
                else if (pitMenuRotary == 5 && pitMenuRequirementMet)
                {
                    if (pitCrewType < CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#!lr !rr$");
                    }
                    else if (pitCrewType == CrewType.LeftRight)
                    {
                        PitCommands.iRacingChat("#!rf !rr$");
                    }
                    else
                    {
                        PitCommands.iRacingChat("#!cleartires$");
                    }
                }
                else if (pitMenuRotary == 6 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#!ws$");
                }
                else if (pitMenuRotary == 7 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#!fuel$");
                }
                else if (pitMenuRotary == 8 && pitMenuRequirementMet)
                {
                    PitCommands.iRacingChat("#!fuel$");
                }
                else if (pitMenuRotary == 9 && pitMenuRequirementMet)
                {
                    watchOn = !watchOn;
                }
                else if (pitMenuRotary == 10 && pitMenuRequirementMet)
                {
                    spotMode = !spotMode;
                }
                else if (pitMenuRotary == 11 && pitMenuRequirementMet)
                {
                    fuelSaveDelta++;
                    if (fuelSaveDelta > 4)
                    {
                        fuelSaveDelta = 0;
                    }
                }
                else if (pitMenuRotary == 12 && pitMenuRequirementMet)
                {
                    Base.Settings.fuelPerLapTarget = fuelAvgLap + fuelPerLapOffset;
                }

                OKButtonCheck = false;
            }

            //Launch control
            if (launchPressed)
            {
                launchActive = !launchActive;
                launchPressed = false;
            }

            if (launchReleased)
            {
                launchActive = false;
                launchPressed = false;
                launchReleased = false;
            }
            Base.SetProp("LaunchScreen", launchActive);

            //Pit screen

            if (pitPressed)
            {
                pitScreenEnable = !pitScreenEnable;
                pitPressed = false;
            }

            if (pitReleased)
            {
                pitScreenEnable = false;
                pitPressed = false;
                pitReleased = false;
            }
            Base.SetProp("PitScreen", pitScreenEnable);


            //Pace screen
            if (pacePressed)
            {
                paceCheck = !paceCheck;
                pacePressed = false;
            }

            if (paceReleased)
            {
                paceCheck = false;
                pacePressed = false;
                paceReleased = false;
            }

            Base.SetProp("PaceCheck", paceCheck);

            //Bite adjust
            if (bitePointPressed)
            {
                bitePointAdjust = !bitePointAdjust;
                bitePointPressed = false;
            }

            if (bitePointReleased)
            {
                bitePointAdjust = false;
                bitePointPressed = false;
                bitePointReleased = false;
            }
            Base.SetProp("BitePointAdjust", bitePointAdjust);

            //Radio toggle/name

            if (irData.Telemetry.RadioTransmitCarIdx != -1)
            {
                radioName = irData.SessionData.DriverInfo.Drivers[irData.Telemetry.RadioTransmitCarIdx].UserName;
                radioIsSpectator = Convert.ToBoolean(irData.SessionData.DriverInfo.Drivers[irData.Telemetry.RadioTransmitCarIdx].IsSpectator);

                if (radioName == aheadGlobal)
                {
                    radioPosition = realPosition - 1;
                }
                else if (radioName == behindGlobal)
                {
                    radioPosition = realPosition + 1;
                }
                else
                {
                    radioPosition = irData.Telemetry.CarIdxClassPosition[irData.Telemetry.RadioTransmitCarIdx];
                }
            }
            else
            {
                radioName = "";
                radioIsSpectator = false;
            }

            radioName = radioName.ToUpper();

            if (irData.Telemetry.RadioTransmitCarIdx != -1)
            {
                radio = false;
            }

            Base.SetProp("Radio", radio);
            Base.SetProp("RadioName", radioName);
            Base.SetProp("RadioPosition", radioPosition);
            Base.SetProp("RadioIsSpectator", radioIsSpectator);



            //No boost
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
                    NBvalue = true;
                }

                if (speed < 80 && NBspeedLim || boost || !NBactive || MGU > 0 || battery == 1)
                {
                    NBvalue = false;
                    NBspeedLim = false;
                    NBactive = false;
                }

                Base.SetProp("NoBoost", NBvalue);
            }

            //TC off toggle
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

                Base.SetProp("TCoffTimer", TimeSpan.FromSeconds(TCPushTimer));

            }
            else
            {
                Base.SetProp("TCoffTimer", new TimeSpan(0));
            }

            //-----------------------------------------
            //----------TC EMULATION-------------------
            //-----------------------------------------

            //Materials on road: 2

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

                if ((TCthrottle == 0 && throttle > 0) || TCreleaseCD > 0)  //Filter on heavy throttle application
                {
                    TCreleaseCD++;
                    if (TCreleaseCD > 25)
                    {
                        TCreleaseCD = 0;
                    }
                }


                if (!tcBump && TCreleaseCD == 0 && gear == TCgear && TCdropCD == 0 && (TCthrottle < throttle || TCthrottle == 100 && throttle == 100) && (throttle > 30 || trackLocation == 0) && TCrpm * 0.995 > rpm && rpm < 0.98 * revLim && speed < 200 && rpm > idleRPM * 1.3)
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
                if (!tcBump && TCreleaseCD == 0 && gear == TCgear && TCdropCD == 0 && (((TCthrottle < throttle || TCthrottle == 100 && throttle == 100) && (throttle > 30 || trackLocation == 0)) || (slipLF == 100 || slipRF == 100)))
                {
                    Base.SetProp("SlipLF", slipLF);
                    Base.SetProp("SlipRF", slipRF);
                    Base.SetProp("SlipLR", slipLR);
                    Base.SetProp("SlipRR", slipRR);
                }

                if ((hasTCtog && TCswitch) || (hasTCtimer && TCPushTimer == 0)) //Push active TC, check again that calculations has been done because of TC, and not because of wheel slip calc
                {
                    Base.SetProp("TCActive", TCon);
                }

            }

            if (!hasTC || TCPushTimer > 0 || (TC == TCoffPosition && TCoffPosition != -1) || (hasTCtog && !TCswitch))
            {
                Base.SetProp("TCToggle", false);
            }

            else
            {
                Base.SetProp("TCToggle", true);
            }

            //-----------------------------------------
            //----------ABS TOGGLE---------------------
            //-----------------------------------------

            if (hasABStog || ABSoffPosition > -1)
            {
                if ((!ABSswitch && hasABStog) || ABSoffPosition == ABS)
                {
                    Base.SetProp("ABSToggle", false);
                }
                else
                {
                    Base.SetProp("ABSToggle", true);
                }
            }
            else
            {
                Base.SetProp("ABSToggle", false);
            }

            //-------------------------------------
            //-------RPM TRACKER-------------------
            //-------------------------------------

            if (rpm > 300 && rpm > RPMtracker && !upshift && clutch == 0)
            {
                RPMtracker = rpm;
            }

            if (RPMgear != gear && gear != "N")
            {
                RPMlastGear = RPMtracker;
                RPMgearShift = true;
                Base.SetProp("LastGearMaxRPM", RPMlastGear);
                Base.SetProp("LastGear", RPMgear);

                switch (RPMgear)
                {
                    case "1":
                        lastShiftPoint = shiftPoint1;
                        break;

                    case "2":
                        lastShiftPoint = shiftPoint2;
                        break;

                    case "3":
                        lastShiftPoint = shiftPoint3;
                        break;

                    case "4":
                        lastShiftPoint = shiftPoint4;
                        break;

                    case "5":
                        lastShiftPoint = shiftPoint5;
                        break;

                    case "6":
                        lastShiftPoint = shiftPoint6;
                        break;

                    case "7":
                        lastShiftPoint = shiftPoint7;
                        break;
                }

                RPMgear = gear;
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

            int lapStatus = 1; //Lap status calculation: 1 = Valid lap, 2 = Invalid lap, 3 = Out lap, 4 = Penalty, 5 = Pit lane

            if (outLap)
            {
                lapStatus = 3;
                stintLapsCheck = true;
            }
            if ((incidents > roadOff || furled) && !outLap)
            {
                lapStatus = 2;
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
                if (jokerThisLap)
                {
                    jokerLapChecker = true;
                    jokerThisLap = false;
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

            if (pit == 1 || iRIdle) //If in pit or idle
            {
                outLap = true;
                roadOff = incidents;
                lapStatus = 5;
            }
            if (black == 1) //Black flag
            {
                lapStatus = 4;
            }
            if (jokerThisLap || jokerLapChecker)
            {
                lapStatus = 6;
            }

            //Sector calculations
            if (trackPosition > twoThirds)
            {
                if (!(sectorExempt) && !(currentSector == 1 && lapStatus != 5)) //Not update sector if jump to exempt area of track or in driving backwards.
                {
                    currentSector = 3;
                    sector1to2 = false;
                }
            }
            else if (trackPosition > oneThird && trackPosition < twoThirds)
            {
                if (!(sectorExempt) && !(currentSector == 3 && lapStatus != 5))
                {
                    currentSector = 2;
                    sector2to3 = false;
                }
            }
            else
            {
                if (!(sectorExempt) && !(currentSector == 2 && lapStatus != 5))
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
                    lastSectorStatusHolder = lapStatus;
                    currentSector3Status = 1;
                    sector2to3 = true;
                    sector3Incidents = incidents;
                }
                if (sector2to3 && sector3Incidents != incidents)
                {
                    if (lapStatus == 3)
                    {
                        currentSector3Status = 2;
                        lastSectorStatusHolder = 2;
                    }
                    else
                    {
                        currentSector3Status = lapStatus;
                        lastSectorStatusHolder = lapStatus;
                    }

                    sector3Incidents = incidents;

                }
                if (sector2to3 && lastSectorStatusHolder != lapStatus && lapStatus != 3)
                {
                    currentSector3Status = lapStatus;
                    lastSectorStatusHolder = lapStatus;
                }

                Base.SetProp("CurrentSector3Time", TimeSpan.FromSeconds(currentSector3Time));
                Base.SetProp("CurrentSector3Status", currentSector3Status);
                Base.SetProp("CurrentSector3Delta", 0);

                if (currentSector2Time > 0 && sessionBestSector2 > 0)
                {
                    double delta = currentSector2Time - sessionBestSector2;
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
                    lastSectorStatusHolder = lapStatus;
                    currentSector2Status = 1;
                    sector1to2 = true;
                    sector2Incidents = incidents;
                }
                if (sector1to2 && sector2Incidents != incidents)
                {
                    if (lapStatus == 3)
                    {
                        currentSector2Status = 2;
                        lastSectorStatusHolder = 2;
                    }
                    else
                    {
                        currentSector2Status = lapStatus;
                        lastSectorStatusHolder = lapStatus;
                    }

                    sector2Incidents = incidents;

                }
                if (sector1to2 && lastSectorStatusHolder != lapStatus && lapStatus != 3)
                {
                    currentSector2Status = lapStatus;
                    lastSectorStatusHolder = lapStatus;
                }

                Base.SetProp("CurrentSector2Time", TimeSpan.FromSeconds(currentSector2Time));
                Base.SetProp("CurrentSector2Status", currentSector2Status);
                Base.SetProp("CurrentSector2Delta", 0);

                if (currentSector1Time > 0 && sessionBestSector1 > 0)
                {
                    double delta = currentSector1Time - sessionBestSector1;
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
                currentSector1Status = lapStatus;

                Base.SetProp("CurrentSector1Time", TimeSpan.FromSeconds(currentSector1Time));
                Base.SetProp("CurrentSector1Status", currentSector1Status);
                Base.SetProp("CurrentSector1Delta", 0);
            }

            Base.SetProp("CurrentSector", currentSector);

            if (pitBox > 0 && !hasApproached) //If jumped to pit box, not taking a proper inlap
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
                currentSector3Status = 0;

                Base.SetProp("CurrentSector3Time", TimeSpan.FromSeconds(currentSector3Time));
                Base.SetProp("CurrentSector3Status", currentSector3Status);
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
                lastStatusHolder = lapStatus;
                lastSectorStatusHolder = currentSector3Status;
                statusReadyToFetch = false;
                if (pit != 1)
                {
                    outLap = false;
                }

            }

            if (lastLapHolder != lastLapTime && (lastLapTime != new TimeSpan(0)))  //New lap time arrives, update certain lists and values
            {
                ERSChangeCount = 4;
                lapStatusList.Insert(0, lastStatusHolder);

                if (lastStatusHolder == 1)
                {
                    validStintLaps++;
                }
                if (lastStatusHolder == 2)
                {
                    invalidStintLaps++;
                }
                if (lastStatusHolder == 6)
                {
                    jokerLapCount++;
                    jokerLapChecker = false;
                }

                lapStatusList.RemoveAt(8); //Making sure list doesnt grow untill infility
                if (lapStatusList[0] != 0)
                {
                    lapTimeList.Insert(0, lastLapTime);

                    //Checking for session best lap
                    if ((lapTimeList[0].TotalSeconds < sessionBestLap.TotalSeconds || sessionBestLap.TotalSeconds == 0) && lapStatusList[0] == 1)
                    {
                        sessionBestLap = lapTimeList[0];
                        for (int i = 0; i < lapDeltaSections + 1; i++) //Keep hold of the timings on that lap
                        {
                            lapDeltaSessionBest[i] = lapDeltaLast[i];
                        }
                    }

                    //Checking for lap record
                    if (lapRecord.TotalSeconds == 0 && lapStatusList[0] == 1)
                    {
                        LapRecords.addLapRecord(track, carModel, lapTimeList[0].TotalMilliseconds, lapDeltaLast, csvAdress, ref csvIndex);
                        for (int i = 0; i < lapDeltaSections + 1; i++) //Keep hold of the timings on that lap
                        {
                            lapDeltaRecord[i] = lapDeltaLast[i];
                        }
                        findLapRecord = true;
                    }
                    else if (lapTimeList[0].TotalSeconds < lapRecord.TotalSeconds && lapStatusList[0] == 1)
                    {
                        LapRecords.replaceLapRecord(track, carModel, lapTimeList[0].TotalMilliseconds, lapDeltaLast, csvAdress, csvIndex);
                        findLapRecord = true;
                    }

                    lapTimeList.RemoveAt(8); //Making sure list doesnt grow untill infinity
                }
                lastLapHolder = lastLapTime;

                //Sectors
                sector1StatusList.Insert(0, sector1StatusHolder);
                sector1StatusList.RemoveAt(8);
                sector1TimeList.Insert(0, sector1TimeHolder);
                if ((sector1TimeList[0] < sessionBestSector1 || sessionBestSector1 == 0) && sector1StatusList[0] == 1)
                {
                    sessionBestSector1 = sector1TimeList[0];
                }
                sector1TimeList.RemoveAt(8);

                sector2StatusList.Insert(0, currentSector2Status);
                sector2StatusList.RemoveAt(8);
                sector2TimeList.Insert(0, currentSector2Time);
                if ((sector2TimeList[0] < sessionBestSector2 || sessionBestSector2 == 0) && sector2StatusList[0] == 1)
                {
                    sessionBestSector2 = sector2TimeList[0];
                }
                sector2TimeList.RemoveAt(8);

                sector3StatusList.Insert(0, lastSectorStatusHolder);
                sector3StatusList.RemoveAt(8);
                sector3TimeList.Insert(0, lapTimeList[0].TotalSeconds - sector1TimeHolder - currentSector2Time);
                currentSector3Time = sector3TimeList[0];
                Base.SetProp("CurrentSector3Time", TimeSpan.FromSeconds(currentSector3Time));
                if (currentSector3Time > 0 && sessionBestSector3 > 0)
                {
                    double delta = currentSector3Time - sessionBestSector3;
                    Base.SetProp("CurrentSector3Delta", Math.Round(delta, 3));
                }
                else
                {
                    Base.SetProp("CurrentSector3Delta", 0);
                }
                if ((sector3TimeList[0] < sessionBestSector3 || sessionBestSector3 == 0) && sector3StatusList[0] == 1)
                {
                    sessionBestSector3 = sector3TimeList[0];
                }
                sector3TimeList.RemoveAt(8);

                currentSector1Time = 0;
                currentSector2Time = 0;
                currentSector3Time = 0;

                if (lastStatusHolder != 3)
                {
                    fuelTargetDeltas.Insert(0, fuelTargetDelta);
                    fuelTargetDeltas.RemoveAt(8);

                    fuelTargetDeltaCumulative = fuelTargetDeltaCumulative + fuelTargetDelta;
                }
            }

            //----------------------------------------------------
            //------------Hotlap live position--------------------
            //----------------------------------------------------

            if (Base.counter == 17)
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

                Base.SetProp("HotlapLivePosition", position);

            }

            //----------------------------------------------------
            //---------Pit box location calculations--------------
            //----------------------------------------------------

            bool boxApproach = false;

            pitBox = (pitLocation - trackPosition) * trackLength;
            if (pitLocation < 0.2 && trackPosition > 0.8)
            {
                pitBox = (pitLocation + (1 - trackPosition)) * trackLength;
            }
            else if (pitLocation > 0.8 && trackPosition < 0.2)
            {
                pitBox = -((1 - pitLocation) + trackPosition) * trackLength;
            }

            awayFromPits = -pitBox;

            if (pitBox > -8 && pitBox < 33 && pit == 1 && pitStall != 1 && hasPitted == true) //Car is approaching the pit box, and can pass by 8 meters. 
            {
                boxApproach = true;
                hasApproached = true;
            }

            if (Math.Abs(pitBox) < 2 && pit == 1)   //Car is in the pit box
            {
                pitBox = 1 - ((pitBox + 2) / 4);
                validStintLaps = 0;
                invalidStintLaps = 0;
                stintLapsCheck = true;
                fuelTargetDeltaCumulative = 0;
            }
            else pitBox = 0;

            if (pitStall == 1) //Car has spawned or recieved pit stop
            {
                hasPitted = false;
                currentFrontWing = wingFront;
                currentRearWing = wingRear;
                currentPWS = PWS;
                currentTape = tape;
                offTrack = false;
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

            Base.SetProp("PitEntry", pitEntry);
            Base.SetProp("PitSpeeding", pitSpeeding);

            //---------------------------------------------------------------
            //-------------Pace calculation, once pr. second-----------------
            //---------------------------------------------------------------


            if (Base.counter == 30) //Race pace pr lap
            {
                List<double> lapListSeconds = new List<double> { };
                double fastLap = 0;
                for (int i = 0; i < lapTimeList.Count; i++)
                {
                    lapListSeconds.Add(lapTimeList[i].TotalSeconds);
                    if (fastLap == 0 || lapListSeconds[i] != 0 && lapListSeconds[i] < fastLap)
                    {
                        fastLap = lapListSeconds[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                for (int i = 0; i < lapTimeList.Count; i++)
                {
                    if ((lapStatusList[i] < 3 && lapStatusList[i] != 0) && !(lapListSeconds[i] > (fastLap + 8) && lapListSeconds[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
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
                    if (lapListSeconds[0] > thresholdLap && lapListSeconds[1] > thresholdLap && lapStatusList[0] < 3 && lapStatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (lapListSeconds[0] < fastLap * 1.005 && lapListSeconds[1] < fastLap * 1.005 && lapStatusList[0] == 1 && lapStatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
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
                for (int i = 0; i < sector1TimeList.Count; i++)
                {
                    if (fastLap == 0 || sector1TimeList[i] != 0 && sector1TimeList[i] < fastLap)
                    {
                        fastLap = sector1TimeList[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                double sectorAverage = 0;
                int sectorAverageCounter = 0;
                for (int i = 0; i < sector1TimeList.Count; i++)
                {
                    if (sector1StatusList[i] < 3 && sector1StatusList[i] != 0)
                    {
                        sectorAverage = sectorAverage + sector1TimeList[i];
                        sectorAverageCounter++;
                    }
                    if ((sector1StatusList[i] < 3 && sector1StatusList[i] != 0) && !(sector1TimeList[i] > (fastLap + 8) && sector1TimeList[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
                    {
                        if (sector1TimeList[i] < thresholdLap)
                        {
                            fastList.Add(sector1TimeList[i]);
                        }
                        else
                        {
                            slowList.Add(sector1TimeList[i]);
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
                for (int i = 0; i < sector1TimeList.Count; i++)
                {
                    if (sector1StatusList[i] < 3 && sector1StatusList[i] != 0)
                    {
                        if (sector1StatusList[i] == 1)
                        {
                            valids++;
                        }
                        if (sector1StatusList[i] == 2)
                        {
                            invalids++;
                        }
                        sum = sum + ((sector1TimeList[i] - sectorAverage) * (sector1TimeList[i] - sectorAverage));
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

                if (sector1TimeList.Count > 1)
                {
                    if (sector1TimeList[0] > thresholdLap && sector1TimeList[1] > thresholdLap && sector1StatusList[0] < 3 && sector1StatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        sector1Pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (sector1TimeList[0] < fastLap * 1.005 && sector1TimeList[1] < fastLap * 1.005 && sector1StatusList[0] == 1 && sector1StatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
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
                for (int i = 0; i < sector2TimeList.Count; i++)
                {
                    if (fastLap == 0 || sector2TimeList[i] != 0 && sector2TimeList[i] < fastLap)
                    {
                        fastLap = sector2TimeList[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                double sectorAverage = 0;
                int sectorAverageCounter = 0;
                for (int i = 0; i < sector2TimeList.Count; i++)
                {
                    if (sector2StatusList[i] < 3 && sector2StatusList[i] != 0)
                    {
                        sectorAverage = sectorAverage + sector2TimeList[i];
                        sectorAverageCounter++;
                    }
                    if ((sector2StatusList[i] < 3 && sector2StatusList[i] != 0) && !(sector2TimeList[i] > (fastLap + 8) && sector2TimeList[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
                    {
                        if (sector2TimeList[i] < thresholdLap)
                        {
                            fastList.Add(sector2TimeList[i]);
                        }
                        else
                        {
                            slowList.Add(sector2TimeList[i]);
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

                for (int i = 0; i < sector2TimeList.Count; i++)
                {
                    if (sector2StatusList[i] < 3 && sector2StatusList[i] != 0)
                    {
                        if (sector2StatusList[i] == 1)
                        {
                            valids++;
                        }
                        if (sector2StatusList[i] == 2)
                        {
                            invalids++;
                        }
                        sum = sum + ((sector2TimeList[i] - sectorAverage) * (sector2TimeList[i] - sectorAverage));
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

                if (sector2TimeList.Count > 1)
                {
                    if (sector2TimeList[0] > thresholdLap && sector2TimeList[1] > thresholdLap && sector2StatusList[0] < 3 && sector2StatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        sector2Pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (sector2TimeList[0] < fastLap * 1.005 && sector2TimeList[1] < fastLap * 1.005 && sector2StatusList[0] == 1 && sector2StatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
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
                for (int i = 0; i < sector3TimeList.Count; i++)
                {
                    if (fastLap == 0 || sector3TimeList[i] != 0 && sector3TimeList[i] < fastLap)
                    {
                        fastLap = sector3TimeList[i];
                    }
                }

                List<double> fastList = new List<double> { };
                List<double> slowList = new List<double> { };
                double thresholdLap = fastLap * 1.015;
                double runOffLap = fastLap * 1.05;
                double sectorAverage = 0;
                int sectorAverageCounter = 0;
                for (int i = 0; i < sector3TimeList.Count; i++)
                {
                    if (sector3StatusList[i] < 3 && sector3StatusList[i] != 0)
                    {
                        sectorAverage = sectorAverage + sector3TimeList[i];
                        sectorAverageCounter++;
                    }
                    if ((sector3StatusList[i] < 3 && sector3StatusList[i] != 0) && !(sector3TimeList[i] > (fastLap + 8) && sector3TimeList[i] > runOffLap)) //Excluding inlaps/outlaps/jokerlaps and laps with accidents (8 sec time loss if that corresponds to 5% or more of normal lap time)
                    {
                        if (sector3TimeList[i] < thresholdLap)
                        {
                            fastList.Add(sector3TimeList[i]);
                        }
                        else
                        {
                            slowList.Add(sector3TimeList[i]);
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

                for (int i = 0; i < sector3TimeList.Count; i++)
                {
                    if (sector3StatusList[i] < 3 && sector3StatusList[i] != 0)
                    {
                        if (sector3StatusList[i] == 1)
                        {
                            valids++;
                        }
                        if (sector3StatusList[i] == 2)
                        {
                            invalids++;
                        }
                        sum = sum + ((sector3TimeList[i] - sectorAverage) * (sector3TimeList[i] - sectorAverage));
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

                if (sector3TimeList.Count > 1)
                {
                    if (sector3TimeList[0] > thresholdLap && sector3TimeList[1] > thresholdLap && sector3StatusList[0] < 3 && sector3StatusList[1] < 3 && slowList.Count > 1) //Pace is slowing down for some reason, fast acting
                    {
                        sector3Pace = (slowList[0] + slowList[1]) / 2;
                    }

                    if (sector3TimeList[0] < fastLap * 1.005 && sector3TimeList[1] < fastLap * 1.005 && sector3StatusList[0] == 1 && sector3StatusList[1] == 1) //Pace is increasing, two fast valid Laps fast acting
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

            if (sessionBestSector1 > 0)
            {
                for (int i = 0; i < sector1TimeList.Count; i++)
                {
                    double delta = Math.Round(sector1TimeList[i] - sessionBestSector1, 3);
                    if (sector1TimeList[i] > 0)
                    {
                        Base.SetProp("Lap0" + (i + 1) + "Sector1Delta", Math.Round(delta, 3));
                    }
                }
            }

            if (sessionBestSector2 > 0)
            {
                for (int i = 0; i < sector2TimeList.Count; i++)
                {
                    double delta = Math.Round(sector2TimeList[i] - sessionBestSector2, 3);
                    if (sector2TimeList[i] > 0)
                    {
                        Base.SetProp("Lap0" + (i + 1) + "Sector2Delta", Math.Round(delta, 3));
                    }
                }
            }

            if (sessionBestSector3 > 0)
            {
                for (int i = 0; i < sector3TimeList.Count; i++)
                {
                    double delta = Math.Round(sector3TimeList[i] - sessionBestSector3, 3);
                    if (sector3TimeList[i] > 0)
                    {
                        Base.SetProp("Lap0" + (i + 1) + "Sector3Delta", Math.Round(delta, 3));
                    }
                }
            }


            //---------------------------------------------------------------
            //------Real position calculations, twice pr. second-------------
            //---------------------------------------------------------------

            if (Base.counter == 15 || Base.counter == 45)
            {
                isRaceLeader = false;
                realPosition = 1;

                if (session == "Lone Qualify" || session == "Open Qualify")
                {
                    qualyPosition = myPosition;
                    realPosition = myPosition;
                    hotLapPosition = myPosition;
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
                                realPosition++;
                            }
                        }
                        hotLapPosition = 1;
                        if (Base.gameData.NewData.Opponents[i].BestLapTime.TotalSeconds < sessionBestLap.TotalSeconds && Base.gameData.NewData.Opponents[i].BestLapTime.TotalSeconds > 0)
                        {
                            hotLapPosition++;
                        }
                        if (sessionBestLap.TotalSeconds == 0)
                        {
                            hotLapPosition = opponents;
                        }
                    }

                    if (Base.gameData.NewData.Opponents[0].GaptoPlayer == null && Base.gameData.NewData.Opponents[1].GaptoPlayer == null)
                    {
                        if (aheadClass == myClass && aheadGap != 0)
                        {
                            realPosition = aheadClassPosition + 1;
                        }
                        if (aheadClass != myClass || aheadGap == 0)
                        {
                            realPosition = myPosition;
                        }
                    }
                    if (currentLapTime.TotalSeconds == 0 && qualyPosition > 0)
                    {
                        realPosition = qualyPosition;
                    }
                    if (currentLapTime.TotalSeconds == 0 && qualyPosition == 0)
                    {
                        realPosition = myPosition;
                    }
                    if (currentLapTime.TotalSeconds > 0)
                    {
                        qualyPosition = 0;
                    }

                    if (checkered == 1 && ((trackPosition > 0.1 && trackPosition < 0.15) || (currentLapTime.TotalSeconds > 5 && currentLapTime.TotalSeconds < 10)))
                    {
                        raceFinished = true;
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

                        realPosition = position + finishedCars.Count;
                    }
                    if ((lapRaceFinished || timeRaceFinished) && trackPosition < 0.1 && checkered == 1)
                    {
                        realPosition = 1 + finishedCars.Count;
                    }

                    if (raceFinished)
                    {
                        realPosition = myPosition;
                    }

                }
                else
                {
                    realPosition = myPosition;
                    hotLapPosition = myPosition;

                }

                Base.SetProp("Position", realPosition);
                Base.SetProp("HotLapPosition", hotLapPosition);
                Base.SetProp("RaceFinished", raceFinished);

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

                Base.SetProp("QualyLap1Status", 0);
                Base.SetProp("QualyLap2Status", 0);
                Base.SetProp("QualyLap1Time", new TimeSpan(0));
                Base.SetProp("QualyLap2Time", new TimeSpan(0));
                warmup = false;


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

                if (lapRecord.TotalSeconds == 0 || (pace > 0 && pace > lapRecord.TotalSeconds * 1.05))
                {
                    inaccurateCalculations = true;
                }

                if (myExpectedLapTime == 0)
                {
                    myExpectedLapTime = lapRecord.TotalSeconds * 1.05;
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
                if (trackType > 4)
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
                        offTrack = false;
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
                    if (trackType > 4)
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
                    warmup = true;
                    lapLapsRemaining = 2;
                    if (pit == 1)
                    {
                        lapLapsRemaining = 3;
                    }
                    qLap1Status = 1;
                    qLap2Status = 1;
                }
                else if (completedLaps == 0) //1st Q lap
                {
                    lapLapsRemaining = 1;
                    qLap1Status = 2;
                    qLap1Time = currentLapTime;
                    if (lapStatus > 1)
                    {
                        qLap1Status = 3;
                        qLap1Time = TimeSpan.FromSeconds(0);
                    }
                    qLapStarted2 = false;
                }
                else if (completedLaps == 1) //2nd Q lap
                {
                    if (lapTimeList.Count > 0)
                    {
                        qLap1Time = lapTimeList[0];
                    }
                    if (qLap1Status == 2)
                    {
                        qLap1Status = 4;
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
                    qLap2Status = 2;
                    if (lapStatus > 1)
                    {
                        qLap2Status = 3;
                        qLap2Time = TimeSpan.FromSeconds(0);
                    }
                }
                else if (completedLaps == 2) //Completed qualy
                {
                    lapLapsRemaining = 0;
                    if (lapTimeList.Count > 0 && qLap1Time != lapTimeList[0])
                    {
                        qLap2Time = lapTimeList[0];
                    }
                    if (qLap2Status == 2)
                    {
                        qLap2Status = 4;
                    }
                }

                Base.SetProp("QualyWarmUpLap", warmup);
                Base.SetProp("QualyLap1Status", qLap1Status);
                Base.SetProp("QualyLap2Status", qLap2Status);
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
                    fuelPerLap = fuelAvgLap + Math.Round(fuelPerLapOffset, 2);
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
                    double fuelDelta = fuel - (fuelPerLap * distanceLeft);

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
                        commandMinFuel = Math.Ceiling(minFuelPush + 0.5);
                        if (minFuelPush == 0)
                        {
                            commandMinFuel = 0;
                        }
                        commandMaxFuel = Math.Ceiling(maxFuelPush + 0.5);
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

                    if (raceFinished)
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

                        if ((lapTimeList[0].TotalSeconds == 0 && pit == 0) || pitBox > 0 || (session == "Race" && sessionState == 2) || (session == "Lone Qualify" && pit == 1)) //Update values only when in box, on grid or at end of pit lane for qualy laps. 
                        {
                            stintLapsTotal = latestPitLap - currentLap - 1; //Laps remaining of the stint
                            if ((session == "Race" && sessionState == 2) || (session == "Lone Qualify" && pit == 1) || (lapTimeList[0].TotalSeconds == 0 && pit == 0))
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
                            if (lapTimeList[0].TotalSeconds == 0 && pit == 0)
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
                if (iRIdle || pitBox > 0 || (session == "Race" && sessionState < 4) || (session == "Offline Testing" && pit == 1) || pushTimer.TotalHours > 10)
                {
                    stintTimer = globalClock;
                }

                pushTimer = TimeSpan.FromMilliseconds(globalClock.TotalMilliseconds - stintTimer.TotalMilliseconds);

                Base.SetProp("StintTimer", pushTimer);

                int stintLaps = validStintLaps + invalidStintLaps + 1;

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


            if (brake > 0 && !brakeTrigger && brakeClock == 0)
            {
                brakeTriggerCheck = true;
            }

            if (brakeTrigger)
            {
                brakeClock++;
                if (brakeMax < brake)
                {
                    brakeMax = brake;
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
                Base.SetProp("BrakeCurveValues", result);

                Base.SetProp("BrakeCurvePeak", brakeMax);

                double auc = 0;
                for (int i = 0; i < 40; i++)
                {
                    auc = auc + (0.1 * brakeCurve[i]);
                }
                Base.SetProp("BrakeCurveAUC", Math.Round(auc, 1));
            }
            if (brakeCurve.Count == 40 && brake == 0)
            {
                brakeCurve.Clear();
                brakeClock = 0;
                brakeClockBase = 0;
                brakeMax = 0;
            }

            //--------------------------------------------------
            //--------------------THROTTLE CURVE-------------------
            //--------------------------------------------------

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
                Base.SetProp("ThrottleCurveValues", result);

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
                Base.SetProp("ThrottleAgro", Math.Round((0.06666666667 * agro), 2));
            }
            if (throttleCurve.Count == 40 && throttle == 0)
            {
                throttleCurve.Clear();
                throttleClock = 0;
                throttleClockBase = 0;
            }



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

                bool pitToggleFront = LFTog && RFTog;
                bool pitToggleRear = LRTog && RRTog;
                bool pitToggleLeft = LFTog && LRTog;
                bool pitToggleRight = RFTog && RRTog;

                int totalTireNumber = Convert.ToInt16(LFTog) + Convert.ToInt16(RFTog) + Convert.ToInt16(LRTog) + Convert.ToInt16(RRTog);

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
                        else if (totalTireNumber == 2 && ((pitFastSide == "Left" && (RFTog || RRTog)) || (pitFastSide == "Right" && (LFTog || LRTog))))
                        {
                            tireTime = pitBaseTime * 2 + (2 * pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 2)
                        {
                            tireTime = pitBaseTime * 2 - (pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 1 && ((pitFastSide == "Left" && (RFTog || RRTog)) || (pitFastSide == "Right" && (LFTog || LRTog))))
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
                        if (totalTireNumber == 4 || (totalTireNumber == 3 && ((pitFastSide == "Left" && ((pitToggleFront && LRTog) || (pitToggleRear && LFTog))) || (pitFastSide == "Right" && ((pitToggleFront && RRTog) || (pitToggleRear && RFTog)))))
                           || (totalTireNumber == 2 && ((pitFastSide == "Left" && pitToggleRight) || (pitFastSide == "Right" && pitToggleLeft))))
                        {
                            tireTime = pitBaseTime * 2 + (2 * pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 3 || totalTireNumber == 2 && (pitToggleRight || pitToggleLeft))
                        {
                            tireTime = pitBaseTime * 2 - (pitSlowAdd / 3);
                        }
                        else if (totalTireNumber == 2 || totalTireNumber == 1 && ((pitFastSide == "Left" && (RFTog || RRTog)) || (pitFastSide == "Right" && (LFTog || LRTog))))
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
                        else if ((pitFastSide == "Left" && (pitToggleRight || RFTog || RRTog)) || (pitFastSide == "Right" && (pitToggleLeft || LFTog || LRTog)))
                        {
                            tireTime = pitBaseTime + pitSlowAdd;
                        }
                        else if (totalTireNumber == 2 || totalTireNumber == 1 && ((pitFastSide == "Left" && (RFTog || RRTog)) || (pitFastSide == "Right" && (LFTog || LRTog))))
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

                if (!fuelTog)
                {
                    fuelTime = 0;
                }

                if (!fuelTargetCheck)
                {
                    fuelTargetCheck = true;
                    oldFuelValue = fuel;
                }

                if (oldFuelValue >= fuel || !fuelTog || oldFuelValue == 0)
                {
                    oldFuelValue = fuel;
                }

                double fuelTarget = oldFuelValue;
                if (fuelTog)
                {
                    fuelTarget = fuelTarget + plannedFuel;
                }

                double WStimer = 0;
                if (pitHasWindscreen && WSTog)
                {
                    WStimer = 2.5;
                }

                double frontWingTime = 0;
                double rearWingTime = 0;
                double tapeTime = 0;
                double powersteerTime = 0;

                //Front wing
                double currentFrontWingC = Math.Abs(currentFrontWing - wingFront);
                if (carId == "Dallara IR18")
                {
                    currentFrontWingC = currentFrontWingC * 10;
                }

                if (currentFrontWingC > 0)
                {
                    frontWingTime = 2.6 + (currentFrontWingC - 1) * 0.2;
                }

                //Rear wing
                double currentRearWingC = Math.Abs(currentRearWing - wingRear);
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
                int currentTapeC = Math.Abs(currentTape - tape);

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

                    if (fuelTog && totalTireNumber > 0)
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
            if (iRIdle)
            {
                findLapRecord = true;
                csvIndex = 0;
                currentFrontWing = 0;
                currentRearWing = 0;
                currentPWS = 0;
                currentTape = 0;
                pitBox = 0.5;
                hasPitted = false;
                validStintLaps = 0;
                invalidStintLaps = 0;
                fuelTargetDeltaCumulative = 0;
                raceFinished = false;
                jokerThisLap = false;
                jokerLapChecker = false;
                finishedCars = new List<string> { };
                fuelTargetCheck = false;
                oldFuelValue = 0;
                NBactive = false;
                NBvalue = false;
                NBspeedLim = false;
                ERSlapCounter = currentLap;
                ERSstartingLap = true;
                TCon = false;
                TCduration = 0;
                offTrack = false;
                commandMinFuel = 0;
                commandMaxFuel = 500;
                LEDwarningActive = false;
                fuelSaveDelta = 0;
                tcBump = false;
                tcBumpCounter = 0;

                //Props that need refresh
                Base.SetProp("TCActive", false);

                //Session or car or track change
                if (carModelHolder != carModel || trackHolder != track || sessionHolder != session)
                {
                    findLapRecord = true;
                    csvIndex = 0;
                    IRchange = 0;
                    ERSChangeCount = 4;
                    savePitTimerLock = false;
                    savePitTimerSnap = new TimeSpan(0);
                    slowestLapTimeSpanCopy = new TimeSpan(0);
                    lapTimeList = new List<TimeSpan> { listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller, listFiller }; //Reset lap and status lists
                    lapStatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    sector1TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    sector2TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    sector3TimeList = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    sector1StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    sector2StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    sector3StatusList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    fuelTargetDeltas = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0 };
                    sessionBestSector1 = 0;
                    sessionBestSector2 = 0;
                    sessionBestSector3 = 0;
                    sessionBestLap = new TimeSpan(0);
                    qLap1Status = 0;
                    qLap2Status = 0;
                    qLap1Time = new TimeSpan(0);
                    qLap2Time = new TimeSpan(0);
                    lapRaceFinished = false;
                    timeRaceFinished = false;
                    timedOut = false;
                    leaderDecimal = 0;
                    isRaceLeader = false;
                    isLapLimited = false;
                    isTimeLimited = false;
                    jokerLapCount = 0;
                    Base.SetProp("P1Finished", false);
                    minFuelPush = 0;
                    maxFuelPush = 0;
                    qLapStarted2 = false;

                    //Props that need refresh
                    Base.SetProp("TCActive", false);

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

            if (!iRIdle)
            {
                carModelHolder = carModel; //Updating choice of car, track and session
                trackHolder = track;
                sessionHolder = session;
            }

            //-----------------------------------------------------------------------------
            //----------------------SETTING GLOBAL PROPERTY VALUES-------------------------
            //-----------------------------------------------------------------------------

            Base.SetProp("TestProperty", TCreleaseCD != 0);
            Base.SetProp("Idle", iRIdle);
            Base.SetProp("SmoothGear", smoothGear);
            Base.SetProp("TrackEntry", offTrack);
            Base.SetProp("FuelSaveDelta", fuelSaveDelta);
            Base.SetProp("LEDWarnings", LEDwarningActive);
            Base.SetProp("SpotterMode", spotMode);
            Base.SetProp("PitSavePaceLock", savePitTimerLock);
            Base.SetProp("OvertakeMode", overtakeMode);
            Base.AddProp("FuelPerLapOffset", Math.Round(fuelPerLapOffset, 2));

            Base.SetProp("LapStatus", lapStatus);
            Base.SetProp("StintValidLaps", validStintLaps);
            Base.SetProp("StintInvalidLaps", invalidStintLaps);
            Base.SetProp("SessionBestLap", sessionBestLap);
            Base.SetProp("LapRecord", lapRecord);
            Base.SetProp("SessionBestSector1", TimeSpan.FromSeconds(sessionBestSector1));
            Base.SetProp("SessionBestSector2", TimeSpan.FromSeconds(sessionBestSector2));
            Base.SetProp("SessionBestSector3", TimeSpan.FromSeconds(sessionBestSector3));

            if (sessionBestSector1 > 0 && sessionBestSector2 > 0 && sessionBestSector3 > 0)
            {
                Base.SetProp("OptimalLapTime", TimeSpan.FromSeconds(sessionBestSector1 + sessionBestSector2 + sessionBestSector3));
            }
            else
            {
                Base.SetProp("OptimalLapTime", new TimeSpan(0));
            }

            Base.SetProp("JokerThisLap", jokerThisLap);
            Base.SetProp("JokerCount", jokerLapCount);

            Base.SetProp("PitBoxPosition", pitBox);
            Base.SetProp("PitBoxApproach", boxApproach);

            Base.SetProp("PitToggleLF", LFTog);
            Base.SetProp("PitToggleRF", RFTog);
            Base.SetProp("PitToggleLR", LRTog);
            Base.SetProp("PitToggleRR", RRTog);
            Base.SetProp("PitToggleFuel", fuelTog);
            Base.SetProp("PitToggleWindscreen", WSTog);
            Base.SetProp("PitToggleRepair", repairTog);

            Base.SetProp("PitServiceLFPSet", plannedLFPressure);
            Base.SetProp("PitServiceRFPSet", plannedRFPressure);
            Base.SetProp("PitServiceLRPSet", plannedLRPressure);
            Base.SetProp("PitServiceRRPSet", plannedRRPressure);

            if (Base.counter == 6 || Base.counter == 36) //General lap times refreshed only twice per second
            {


                Base.SetProp("Lap01Time", lapTimeList[0]);
                Base.SetProp("Lap02Time", lapTimeList[1]);
                Base.SetProp("Lap03Time", lapTimeList[2]);
                Base.SetProp("Lap04Time", lapTimeList[3]);
                Base.SetProp("Lap05Time", lapTimeList[4]);
                Base.SetProp("Lap06Time", lapTimeList[5]);
                Base.SetProp("Lap07Time", lapTimeList[6]);
                Base.SetProp("Lap08Time", lapTimeList[7]);

                Base.SetProp("Lap01Status", lapStatusList[0]);
                Base.SetProp("Lap02Status", lapStatusList[1]);
                Base.SetProp("Lap03Status", lapStatusList[2]);
                Base.SetProp("Lap04Status", lapStatusList[3]);
                Base.SetProp("Lap05Status", lapStatusList[4]);
                Base.SetProp("Lap06Status", lapStatusList[5]);
                Base.SetProp("Lap07Status", lapStatusList[6]);
                Base.SetProp("Lap08Status", lapStatusList[7]);

                Base.SetProp("Lap01FuelTargetDelta", fuelTargetDeltas[0]);
                Base.SetProp("Lap02FuelTargetDelta", fuelTargetDeltas[1]);
                Base.SetProp("Lap03FuelTargetDelta", fuelTargetDeltas[2]);
                Base.SetProp("Lap04FuelTargetDelta", fuelTargetDeltas[3]);
                Base.SetProp("Lap05FuelTargetDelta", fuelTargetDeltas[4]);
                Base.SetProp("Lap06FuelTargetDelta", fuelTargetDeltas[5]);
                Base.SetProp("Lap07FuelTargetDelta", fuelTargetDeltas[6]);
                Base.SetProp("Lap08FuelTargetDelta", fuelTargetDeltas[7]);

                Base.SetProp("Lap01Sector1Time", TimeSpan.FromSeconds(sector1TimeList[0]));
                Base.SetProp("Lap01Sector2Time", TimeSpan.FromSeconds(sector2TimeList[0]));
                Base.SetProp("Lap01Sector3Time", TimeSpan.FromSeconds(sector3TimeList[0]));
                Base.SetProp("Lap01Sector1Status", sector1StatusList[0]);
                Base.SetProp("Lap01Sector2Status", sector2StatusList[0]);
                Base.SetProp("Lap01Sector3Status", sector3StatusList[0]);

                Base.SetProp("Lap02Sector1Time", TimeSpan.FromSeconds(sector1TimeList[1]));
                Base.SetProp("Lap02Sector2Time", TimeSpan.FromSeconds(sector2TimeList[1]));
                Base.SetProp("Lap02Sector3Time", TimeSpan.FromSeconds(sector3TimeList[1]));
                Base.SetProp("Lap02Sector1Status", sector1StatusList[1]);
                Base.SetProp("Lap02Sector2Status", sector2StatusList[1]);
                Base.SetProp("Lap02Sector3Status", sector3StatusList[1]);

                Base.SetProp("Lap03Sector1Time", TimeSpan.FromSeconds(sector1TimeList[2]));
                Base.SetProp("Lap03Sector2Time", TimeSpan.FromSeconds(sector2TimeList[2]));
                Base.SetProp("Lap03Sector3Time", TimeSpan.FromSeconds(sector3TimeList[2]));
                Base.SetProp("Lap03Sector1Status", sector1StatusList[2]);
                Base.SetProp("Lap03Sector2Status", sector2StatusList[2]);
                Base.SetProp("Lap03Sector3Status", sector3StatusList[2]);

                Base.SetProp("Lap04Sector1Time", TimeSpan.FromSeconds(sector1TimeList[3]));
                Base.SetProp("Lap04Sector2Time", TimeSpan.FromSeconds(sector2TimeList[3]));
                Base.SetProp("Lap04Sector3Time", TimeSpan.FromSeconds(sector3TimeList[3]));
                Base.SetProp("Lap04Sector1Status", sector1StatusList[3]);
                Base.SetProp("Lap04Sector2Status", sector2StatusList[3]);
                Base.SetProp("Lap04Sector3Status", sector3StatusList[3]);

                Base.SetProp("Lap05Sector1Time", TimeSpan.FromSeconds(sector1TimeList[4]));
                Base.SetProp("Lap05Sector2Time", TimeSpan.FromSeconds(sector2TimeList[4]));
                Base.SetProp("Lap05Sector3Time", TimeSpan.FromSeconds(sector3TimeList[4]));
                Base.SetProp("Lap05Sector1Status", sector1StatusList[4]);
                Base.SetProp("Lap05Sector2Status", sector2StatusList[4]);
                Base.SetProp("Lap05Sector3Status", sector3StatusList[4]);

                Base.SetProp("Lap06Sector1Time", TimeSpan.FromSeconds(sector1TimeList[5]));
                Base.SetProp("Lap06Sector2Time", TimeSpan.FromSeconds(sector2TimeList[5]));
                Base.SetProp("Lap06Sector3Time", TimeSpan.FromSeconds(sector3TimeList[5]));
                Base.SetProp("Lap06Sector1Status", sector1StatusList[5]);
                Base.SetProp("Lap06Sector2Status", sector2StatusList[5]);
                Base.SetProp("Lap06Sector3Status", sector3StatusList[5]);

                Base.SetProp("Lap07Sector1Time", TimeSpan.FromSeconds(sector1TimeList[6]));
                Base.SetProp("Lap07Sector2Time", TimeSpan.FromSeconds(sector2TimeList[6]));
                Base.SetProp("Lap07Sector3Time", TimeSpan.FromSeconds(sector3TimeList[6]));
                Base.SetProp("Lap07Sector1Status", sector1StatusList[6]);
                Base.SetProp("Lap07Sector2Status", sector2StatusList[6]);
                Base.SetProp("Lap07Sector3Status", sector3StatusList[6]);

                Base.SetProp("Lap08Sector1Time", TimeSpan.FromSeconds(sector1TimeList[7]));
                Base.SetProp("Lap08Sector2Time", TimeSpan.FromSeconds(sector2TimeList[7]));
                Base.SetProp("Lap08Sector3Time", TimeSpan.FromSeconds(sector3TimeList[7]));
                Base.SetProp("Lap08Sector1Status", sector1StatusList[7]);
                Base.SetProp("Lap08Sector2Status", sector2StatusList[7]);
                Base.SetProp("Lap08Sector3Status", sector3StatusList[7]);

                Base.SetProp("TrackType", trackType);

                Base.SetProp("CurrentFrontWing", currentFrontWing);
                Base.SetProp("CurrentRearWing", currentRearWing);
                Base.SetProp("CurrentPowersteer", currentPWS);
                Base.SetProp("CurrentTape", currentTape);

            }
        }
    }
}