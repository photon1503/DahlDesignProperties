# ⏱ Lap timing

Propertes based on recodering, storing and tracking info about your laps. Built into the plugin is a system for storing your **lap records in a .csv file**. This file is automatically generated in your SimHub main folder, and you can view you lap times there. The reasoning for this is that the _PersistantTrackerPlugin.AllTimeBest_ lap times will include corner cutting/off-track lap times, as well as joker laps for rally cross, making it useless in many cases. Also, the .csv store additional information on these lap times, used for other calculations.&#x20;

The plugin also features a **lap time delta system**, completely indenpentent from iRacing or SimHub delta telemetry. It is based on recodring your lap time at 60 checkpoints around the track, for previous lap, session best land and lap record -> and then comparing your current lap on each checkpoint. The motivation to build this system is that the delta from telemetry was often confusing and not matching session best and lap record laps. It was hard to tell what the delta was referring to. Also, last lap delta was not availble.&#x20;

The downside of this delta system is that the 60 Hz data flow limits the resolution of lap timing. So the delta values produced are not accurate to the 0.001s. They are very accurate to 0.1s, and fairly accurate to the 0.01s.&#x20;

The **delta change** properties are strings of several values that represent delta changes over a given number of mini sectors (20). This is to avoid having to make 60 properties for delta change. You can extract the sector you want using the the javascript split() command in the dashboard editor; see how I did it in Dashboard.

| Name                   | Description                                                                                                                                                   | Type     |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------- |
| Pace                   | Dynamic estimation of race pace, adjusts to sudden changes in pace (damage, new tires) and excludes outlaps, inlaps and laps with time lost to crash/road-off | timespan |
| SessionBestLap         | Session best valid lap time.                                                                                                                                  | timespan |
| LapRecord              | All time best valid lap time. Stored in the LapRecords.csv file in SimHub folder                                                                              | timespan |
| OptimalLapTime         | Fastest lap this session based on your fastest valid sector times                                                                                             | timespan |
| QualyWarmUpLap         | Whether you're on warmup lap or not                                                                                                                           | boolean  |
| QualyLap1Status        | Lone qualify lap 1 status: 1 - Waiting, 2 - Lap started, 3 - Lap ruined, 4 - Lap finished and valid                                                           | 1-4      |
| QualyLap2Status        | Lone qualify lap 2 status: 1 - Waiting, 2 - Lap started, 3 - Lap ruined, 4 - Lap finished and valid                                                           | 1-4      |
| QualyLap1Time          | Lap time on 1st qualy lap, will show live lap time when you're on lap 1                                                                                       | timespan |
| QualyLap2Time          | Lap time on 2nd qualy lap, will show live lap time when you're on lap 2                                                                                       | timespan |
| DeltaLastLap           | Delta to last lap time                                                                                                                                        | seconds  |
| DeltaSessionBest       | Delta to session best lap time                                                                                                                                | seconds  |
| DeltaLapRecord         | Delta to record lap time                                                                                                                                      | seconds  |
| DeltaLastLapChange     | String containing the change in delta to last lap time over 20 mini sectors, separated by a comma.                                                            | string   |
| DeltaSessionBestChange | String containing the change in delta to session best lap time over 20 mini sectors, separated by a comma.                                                    | string   |
| DeltaLapRecordChange   | String containing the change in delta to the record lap time over 20 mini sectors, separated by a comma.                                                      | string   |
