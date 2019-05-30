using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Games
{
    namespace ProjectCars
    {
        public static class SharedMemory
        {
            public static readonly string Name = "$pcars$";
            public static readonly int Size = Marshal.SizeOf(typeof(Data.Structure));
        }

        public class Data
        {
            private const int STRING_LENGTH = 64;
            internal const int STORED_PARTICIPANTS_MAX = 64;

            public static uint CAR_HEADLIGHT = (1 << 0);
            public static uint CAR_ENGINE_ACTIVE = (1 << 1);
            public static uint CAR_ENGINE_WARNING = (1 << 2);
            public static uint CAR_SPEED_LIMITER = (1 << 3);
            public static uint CAR_ABS = (1 << 4);
            public static uint CAR_HANDBRAKE = (1 << 5);
            public static uint CAR_STABILITY = (1 << 6);
            public static uint CAR_TRACTION_CONTROL = (1 << 7);

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct ParticipantInfo
            {
                public bool IsActive;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
                public string name;
                //char mName[STRING_LENGTH_MAX];                   // [ string ]
                public Vector3<float> mWorldPosition;                   // [ UNITS = World Space  X  Y  Z ]
                public float CurrentLapDistance;                       // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]
                public uint RacePosition;                      // [ RANGE = 1->... ]   [ UNSET = 0 ]
                public uint LapsCompleted;                     // [ RANGE = 0->... ]   [ UNSET = 0 ]
                public uint CurrentLap;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
                public uint CurrentSector;                     // [ enum (Type#4) Current Sector ]
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct Structure
            {
                // Version Number
                public uint Version;                           // [ RANGE = 0->... ]
                public uint BuildVersionNumber;                // [ RANGE = 0->... ]   [ UNSET = 0 ]

                // Game States
                public uint GameState;                         // [ enum (Type#1) Game state ]
                public uint SessionState;                      // [ enum (Type#2) Session state ]
                public uint RaceState;                         // [ enum (Type#3) Race State ]

                // Participant Info
                public int ViewedParticipantIndex;                                  // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
                public int NumParticipants;                                         // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = STORED_PARTICIPANTS_MAX)]
                public ParticipantInfo[] Participants;    // [ struct (Type#13) ParticipantInfo struct ]

                // Unfiltered Input
                public float UnfilteredThrottle;                        // [ RANGE = 0.0f->1.0f ]
                public float UnfilteredBrake;                           // [ RANGE = 0.0f->1.0f ]
                public float UnfilteredSteering;                        // [ RANGE = -1.0f->1.0f ]
                public float UnfilteredClutch;                          // [ RANGE = 0.0f->1.0f ]

                // Vehicle information
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
                public string carName;
                //char mCarName[STRING_LENGTH_MAX];                 // [ string ]
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
                public string carClassName;
                //char mCarClassName[STRING_LENGTH_MAX];            // [ string ]

                // Event information
                public uint LapsInEvent;                        // [ RANGE = 0->... ]   [ UNSET = 0 ]
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
                public string TrackLocation;
                //char mTrackLocation[STRING_LENGTH_MAX];           // [ string ]
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_LENGTH)]
                public string TrackVariation;
                //char mTrackVariation[STRING_LENGTH_MAX];          // [ string ]
                public float TrackLength;                               // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]

                // Timings
                public bool LapInvalidated;                             // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
                public float BestLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float LastLapTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float CurrentTime;                               // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float SplitTimeAhead;                            // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float SplitTimeBehind;                           // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float SplitTime;                                 // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float EventTimeRemaining;                        // [ UNITS = milli-seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float PersonalFastestLapTime;                    // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float WorldFastestLapTime;                       // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float CurrentSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float CurrentSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float CurrentSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float FastestSector1Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float FastestSector2Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float FastestSector3Time;                        // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float PersonalFastestSector1Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float PersonalFastestSector2Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float PersonalFastestSector3Time;                // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float WorldFastestSector1Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float WorldFastestSector2Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public float WorldFastestSector3Time;                   // [ UNITS = seconds ]   [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]

                // Flags
                public uint HighestFlagColour;                 // [ enum (Type#5) Flag Colour ]
                public uint HighestFlagReason;                 // [ enum (Type#6) Flag Reason ]

                // Pit Info
                public uint PitMode;                           // [ enum (Type#7) Pit Mode ]
                public uint PitSchedule;                       // [ enum (Type#8) Pit Stop Schedule ]

                // Car State
                public uint CarFlags;                          // [ enum (Type#9) Car Flags ]
                public float OilTempCelsius;                           // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
                public float OilPressureKPa;                           // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float WaterTempCelsius;                         // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
                public float WaterPressureKPa;                         // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float FuelPressureKPa;                          // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float FuelLevel;                                // [ RANGE = 0.0f->1.0f ]
                public float FuelCapacity;                             // [ UNITS = Liters ]   [ RANGE = 0.0f->1.0f ]   [ UNSET = 0.0f ]
                public float Speed;                                    // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]
                public float Rpm;                                      // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float MaxRPM;                                   // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
                public float Brake;                                    // [ RANGE = 0.0f->1.0f ]
                public float Throttle;                                 // [ RANGE = 0.0f->1.0f ]
                public float Clutch;                                   // [ RANGE = 0.0f->1.0f ]
                public float Steering;                                 // [ RANGE = -1.0f->1.0f ]
                public int Gear;                                       // [ RANGE = -1 (Reverse)  0 (Neutral)  1 (Gear 1)  2 (Gear 2)  etc... ]   [ UNSET = 0 (Neutral) ]
                public int NumGears;                                   // [ RANGE = 0->... ]   [ UNSET = -1 ]
                public float OdometerKM;                               // [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
                public bool AntiLockActive;                            // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
                public int LastOpponentCollisionIndex;                 // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
                public float LastOpponentCollisionMagnitude;           // [ RANGE = 0.0f->... ]
                public bool BoostActive;                               // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
                public float BoostAmount;                              // [ RANGE = 0.0f->100.0f ] 

                // Motion & Device Related
                public Vector3<float> Orientation;                     // [ UNITS = Euler Angles ]
                public Vector3<float> LocalVelocity;                   // [ UNITS = Metres per-second ]
                public Vector3<float> WorldVelocity;                   // [ UNITS = Metres per-second ]
                public Vector3<float> AngularVelocity;                 // [ UNITS = Radians per-second ]
                public Vector3<float> LocalAcceleration;               // [ UNITS = Metres per-second ]
                public Vector3<float> WorldAcceleration;               // [ UNITS = Metres per-second ]
                public Vector3<float> ExtentsCentre;                   // [ UNITS = Local Space  X  Y  Z ]

                // Wheels / Tires
                public Vector4<uint> tireFlags;               // [ enum (Type#10) Tyre Flags ]
                public Vector4<uint> terrainFlags;                 // [ enum (Type#11) Terrain Materials ]
                public TireData<Single> TireY;                          // [ UNITS = Local Space  Y ]
                public TireData<Single> TireRPS;                        // [ UNITS = Revolutions per second ]
                public TireData<Single> TireSlipSpeed;                  // [ UNITS = Metres per-second ]
                public TireData<Single> TireTemp;                       // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
                public TireData<Single> TireGrip;                       // [ RANGE = 0.0f->1.0f ]
                public TireData<Single> TireHeightAboveGround;          // [ UNITS = Local Space  Y ]
                public TireData<Single> TireLateralStiffness;           // [ UNITS = Lateral stiffness coefficient used in tyre deformation ]
                public TireData<Single> TireWear;                       // [ RANGE = 0.0f->1.0f ]
                public TireData<Single> BrakeDamage;                    // [ RANGE = 0.0f->1.0f ]
                public TireData<Single> SuspensionDamage;               // [ RANGE = 0.0f->1.0f ]
                public TireData<Single> BrakeTempCelsius;               // [ UNITS = Celsius ]
                public TireData<Single> TireTreadTemp;                  // [ UNITS = Kelvin ]
                public TireData<Single> TireLayerTemp;                  // [ UNITS = Kelvin ]
                public TireData<Single> TireCarcassTemp;                // [ UNITS = Kelvin ]
                public TireData<Single> TireRimTemp;                    // [ UNITS = Kelvin ]
                public TireData<Single> TirepublicAirTemp;            // [ UNITS = Kelvin ]

                // Car Damage
                public uint CrashState;                        // [ enum (Type#12) Crash Damage State ]
                public float AeroDamage;                               // [ RANGE = 0.0f->1.0f ]
                public float EngineDamage;                             // [ RANGE = 0.0f->1.0f ]

                // Weather
                public float AmbientTemperature;                       // [ UNITS = Celsius ]   [ UNSET = 25.0f ]
                public float TrackTemperature;                         // [ UNITS = Celsius ]   [ UNSET = 30.0f ]
                public float RainDensity;                              // [ UNITS = How much rain will fall ]   [ RANGE = 0.0f->1.0f ]
                public float WindSpeed;                                // [ RANGE = 0.0f->100.0f ]   [ UNSET = 2.0f ]
                public float WindDirectionX;                           // [ UNITS = Normalised Vector X ]
                public float WindDirectionY;                           // [ UNITS = Normalised Vector Y ]
                public float CloudBrightness;                          // [ RANGE = 0.0f->... ]        
            }
        }
    }
}
