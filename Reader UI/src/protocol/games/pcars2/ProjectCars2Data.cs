using R3EData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TelemetryReader.src.protocol.games.pcars
{
    class ProjectCars2Data
    {
        internal const int STRING_LENGTH = 64;
        internal const int STORED_PARTICIPANTS_MAX = 64;

        internal static uint CAR_HEADLIGHT = (1 << 0);
        internal static uint CAR_ENGINE_ACTIVE = (1 << 1);
        internal static uint CAR_ENGINE_WARNING = (1 << 2);
        internal static uint CAR_SPEED_LIMITER = (1 << 3);
        internal static uint CAR_ABS = (1 << 4);
        internal static uint CAR_HANDBRAKE = (1 << 5);
        internal static uint CAR_STABILITY = (1 << 6);
        internal static uint CAR_TRACTION_CONTROL = (1 << 7);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Vector4<T>
        {
            internal T X;
            internal T Y;
            internal T Z;
            internal T I;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct ParticipantInfo
        {
            internal bool mIsActive;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
            internal string name;
            //char mName[STRING_LENGTH_MAX];                   // [ string ]
            internal Vector3<float> mWorldPosition;                   // [ UNITS = World Space  X  Y  Z ]
            internal float CurrentLapDistance;                       // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]
            internal uint mRacePosition;                      // [ RANGE = 1->... ]   [ UNSET = 0 ]
            internal uint LapsCompleted;                     // [ RANGE = 0->... ]   [ UNSET = 0 ]
            internal uint CurrentLap;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
            internal uint CurrentSector;                     // [ enum (Type#4) Current Sector ]
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct SharedMemory
        {
            // Version Number
            internal uint Version;                           // [ RANGE = 0->... ]
            internal uint BuildVersionNumber;                // [ RANGE = 0->... ]   [ UNSET = 0 ]

            // Game States
            internal uint GameState;                         // [ enum (Type#1) Game state ]
            internal uint SessionState;                      // [ enum (Type#2) Session state ]
            internal uint RaceState;                         // [ enum (Type#3) Race State ]

            // Participant Info
            internal int ViewedParticipantIndex;                                  // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
            internal int NumParticipants;                                         // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            internal ParticipantInfo[] Participants;    // [ struct (Type#13) ParticipantInfo struct ]

            // Unfiltered Input
            internal float UnfilteredThrottle;                        // [ RANGE = 0.0f->1.0f ]
            internal float UnfilteredBrake;                           // [ RANGE = 0.0f->1.0f ]
            internal float UnfilteredSteering;                        // [ RANGE = -1.0f->1.0f ]
            internal float UnfilteredClutch;                          // [ RANGE = 0.0f->1.0f ]

            // Vehicle information
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
            internal string carName;
            //char mCarName[STRING_LENGTH_MAX];                 // [ string ]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
            internal string carClassName;
            //char mCarClassName[STRING_LENGTH_MAX];            // [ string ]

            // Event information
            internal uint LapsInEvent;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
            internal string TrackLocation;
            //char mTrackLocation[STRING_LENGTH_MAX];           // [ string ]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
            internal string TrackVariation;
            //char mTrackVariation[STRING_LENGTH_MAX];          // [ string ]
            internal float TrackLength;                               // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]

            // Timings
            internal int SectorCount;                                 // [ RANGE = 0->... ]   [ UNSET = -1 ]
            internal bool LapInvalidated;                             // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
            internal float BestLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float LastLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float CurrentTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float SplitTimeAhead;                            // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float SplitTimeBehind;                           // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float SplitTime;                                 // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float EventTimeRemaining;                        // [ UNITS = milli-seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float PersonalFastestLapTime;                    // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float WorldFastestLapTime;                       // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float CurrentSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float CurrentSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float CurrentSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float FastestSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float FastestSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float FastestSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float PersonalFastestSector1Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float PersonalFastestSector2Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float PersonalFastestSector3Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float WorldFastestSector1Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float WorldFastestSector2Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal float WorldFastestSector3Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]

            // Flags
            internal uint HighestFlagColour;                 // [ enum (Type#5) Flag Colour ]
            internal uint HighestFlagReason;                 // [ enum (Type#6) Flag Reason ]

            // Pit Info
            internal uint PitMode;                           // [ enum (Type#7) Pit Mode ]
            internal uint PitSchedule;                       // [ enum (Type#8) Pit Stop Schedule ]

            // Car State
            internal uint CarFlags;                          // [ enum (Type#9) Car Flags ]
            internal float OilTempCelsius;                           // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
            internal float OilPressureKPa;                           // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float WaterTempCelsius;                         // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
            internal float WaterPressureKPa;                         // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float FuelPressureKPa;                          // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float FuelLevel;                                // [ RANGE = 0.0f->1.0f ]
            internal float FuelCapacity;                             // [ UNITS = Liters ]   [ RANGE = 0.0f->1.0f ]   [ UNSET = 0.0f ]
            internal float Speed;                                    // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]
            internal float Rpm;                                      // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float MaxRPM;                                   // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
            internal float Brake;                                    // [ RANGE = 0.0f->1.0f ]
            internal float Throttle;                                 // [ RANGE = 0.0f->1.0f ]
            internal float Clutch;                                   // [ RANGE = 0.0f->1.0f ]
            internal float Steering;                                 // [ RANGE = -1.0f->1.0f ]
            internal int Gear;                                       // [ RANGE = -1 (Reverse)  0 (Neutral)  1 (Gear 1)  2 (Gear 2)  etc... ]   [ UNSET = 0 (Neutral) ]
            internal int NumGears;                                   // [ RANGE = 0->... ]   [ UNSET = -1 ]
            internal float OdometerKM;                               // [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            internal bool AntiLockActive;                            // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
            internal int LastOpponentCollisionIndex;                 // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
            internal float LastOpponentCollisionMagnitude;           // [ RANGE = 0.0f->... ]
            internal bool BoostActive;                               // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
            internal float BoostAmount;                              // [ RANGE = 0.0f->100.0f ] 

            // Motion & Device Related
            internal Vector3<float> Orientation;                     // [ UNITS = Euler Angles ]
            internal Vector3<float> LocalVelocity;                   // [ UNITS = Metres per-second ]
            internal Vector3<float> WorldVelocity;                   // [ UNITS = Metres per-second ]
            internal Vector3<float> AngularVelocity;                 // [ UNITS = Radians per-second ]
            internal Vector3<float> LocalAcceleration;               // [ UNITS = Metres per-second ]
            internal Vector3<float> WorldAcceleration;               // [ UNITS = Metres per-second ]
            internal Vector3<float> ExtentsCentre;                   // [ UNITS = Local Space  X  Y  Z ]

            // Wheels / Tires
            internal Vector4<uint> tireFlags;               // [ enum (Type#10) Tyre Flags ]
            internal Vector4<uint> terrainFlags;                 // [ enum (Type#11) Terrain Materials ]
            internal TireData TireY;                          // [ UNITS = Local Space  Y ]
            internal TireData TireRPS;                        // [ UNITS = Revolutions per second ]
            internal TireData TireSlipSpeed;                  // [ UNITS = Metres per-second ]
            internal TireData TireTemp;                       // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
            internal TireData TireGrip;                       // [ RANGE = 0.0f->1.0f ]
            internal TireData TireHeightAboveGround;          // [ UNITS = Local Space  Y ]
            internal TireData TireLateralStiffness;           // [ UNITS = Lateral stiffness coefficient used in tyre deformation ]
            internal TireData TireWear;                       // [ RANGE = 0.0f->1.0f ]
            internal TireData BrakeDamage;                    // [ RANGE = 0.0f->1.0f ]
            internal TireData SuspensionDamage;               // [ RANGE = 0.0f->1.0f ]
            internal TireData BrakeTempCelsius;               // [ UNITS = Celsius ]
            internal TireData TireTreadTemp;                  // [ UNITS = Kelvin ]
            internal TireData TireLayerTemp;                  // [ UNITS = Kelvin ]
            internal TireData TireCarcassTemp;                // [ UNITS = Kelvin ]
            internal TireData TireRimTemp;                    // [ UNITS = Kelvin ]
            internal TireData TireInternalAirTemp;            // [ UNITS = Kelvin ]

            // Car Damage
            internal uint CrashState;                        // [ enum (Type#12) Crash Damage State ]
            internal float AeroDamage;                               // [ RANGE = 0.0f->1.0f ]
            internal float EngineDamage;                             // [ RANGE = 0.0f->1.0f ]

            // Weather
            internal float AmbientTemperature;                       // [ UNITS = Celsius ]   [ UNSET = 25.0f ]
            internal float TrackTemperature;                         // [ UNITS = Celsius ]   [ UNSET = 30.0f ]
            internal float RainDensity;                              // [ UNITS = How much rain will fall ]   [ RANGE = 0.0f->1.0f ]
            internal float WindSpeed;                                // [ RANGE = 0.0f->100.0f ]   [ UNSET = 2.0f ]
            internal float WindDirectionX;                           // [ UNITS = Normalised Vector X ]
            internal float WindDirectionY;                           // [ UNITS = Normalised Vector Y ]
            internal float CloudBrightness;                          // [ RANGE = 0.0f->... ]        

            // Sequence Number to help slightly with data integrity reads
            internal volatile uint mSequenceNumber;          // 0 at the start, incremented at start and end of writing, so odd when Shared Memory is being filled, even when the memory is not being touched

            //Additional car variables
            internal Vector3<float> mWheelLocalPositionY;           // [ UNITS = Local Space  Y ]
            internal Vector3<float> mSuspensionTravel;              // [ UNITS = meters ] [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
            internal Vector3<float> mSuspensionVelocity;            // [ UNITS = Rate of change of pushrod deflection ] [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
            internal Vector3<float> mAirPressure;                   // [ UNITS = PSI ]  [ RANGE 0.f =>... ]  [ UNSET =  0.0f ]
            float mEngineSpeed;                             // [ UNITS = Rad/s ] [UNSET = 0.f ]
            float mEngineTorque;                            // [ UNITS = Newton Meters] [UNSET = 0.f ] [ RANGE = 0.0f->... ]
            float mWingFront;                                // [ RANGE = 0.0f->1.0f ] [UNSET = 0.f ]
            float mWingRear;
            float mHandBrake;                               // [ RANGE = 0.0f->1.0f ] [UNSET = 0.f ]

            // additional race variables

            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mCurrentSector1Times;        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    //float mCurrentSector1Times[STORED_PARTICIPANTS_MAX];        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mCurrentSector2Times;        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mCurrentSector3Times;        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mFastestSector1Times;        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mFastestSector2Times;        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mFastestSector3Times;        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mFastestLapTimes;            // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mLastLapTimes;               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    bool mLapsInvalidated;            // [ UNITS = boolean for all participants ]   [ RANGE = false->true ]   [ UNSET = false ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    uint mRaceStates;         // [ enum (Type#3) Race State ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    uint mPitModes;           // [ enum (Type#7)  Pit Mode ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mOrientations;      // [ UNITS = Euler Angles ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    float mSpeeds;                     // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]

            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    carString[] mCarNames; // [ string ]
            //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    carString[] mCarClassNames; // [ string ]

            //    //additional race variables
            //    int mEnforcedPitStopLap;                          // [ UNITS = in which lap there will be a mandatory pitstop] [ RANGE = 0.0f->... ] [ UNSET = -1 ]

            //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    string mTranslatedTrackLocation;  // [ string ]
            //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STORED_PARTICIPANTS_MAX)]
            //    string mTranslatedTrackVariation; // [ string ]
        }
    }

    internal struct carString
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ProjectCars2Data.STRING_LENGTH)]
        string s;
    }
}
