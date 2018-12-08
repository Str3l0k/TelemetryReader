using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AssettoCorsaData
{
    //#pragma once


    //        typedef int AC_STATUS;

    //#define AC_OFF 0
    //#define AC_REPLAY 1
    //#define AC_LIVE 2
    //#define AC_PAUSE 3

    //        typedef int AC_SESSION_TYPE;

    //#define AC_UNKNOWN -1
    //#define AC_PRACTICE 0
    //#define AC_QUALIFY 1
    //#define AC_RACE 2
    //#define AC_HOTLAP 3
    //#define AC_TIME_ATTACK 4
    //#define AC_DRIFT 5
    //#define AC_DRAG 6

    //        typedef int AC_FLAG_TYPE;

    //#define AC_NO_FLAG 0
    //#define AC_BLUE_FLAG 1
    //#define AC_YELLOW_FLAG 2
    //#define AC_BLACK_FLAG 3
    //#define AC_WHITE_FLAG 4
    //#define AC_CHECKERED_FLAG 5
    //#define AC_PENALTY_FLAG 6


    //#pragma pack(push)
    //#pragma pack(4)
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct Vector3<T>
    {
        public T X;
        public T Y;
        public T Z;
    }

   
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct WheelData
    {
        public float FrontLeft;
        public float FrontRight;
        public float RearLeft;
        public float RearRight;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct CarDamage
    {
        public float Front;
        public float Right;
        public float Rear;
        public float Left;
        public float Center;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct RideHeight
    {
        public float Front;
        public float Rear;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    struct AssettoCorsa
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct SPageFilePhysics
        {
            internal int packetId;
            internal float gas;
            internal float brake;
            internal float fuel;
            internal int gear;
            internal int rpms;
            internal float steerAngle;
            internal float speedKmh;
            internal Vector3<float> velocity;
            internal Vector3<float> carAcceleration; // G-Force
            internal WheelData wheelSlip;
            internal WheelData wheelLoad;
            internal WheelData wheelsPressure;
            internal WheelData wheelAngularSpeed;
            internal WheelData tyreWear;
            internal WheelData tyreDirtyLevel;
            internal WheelData tyreCoreTemperature;
            internal WheelData camberRAD;
            internal WheelData suspensionTravel;
            internal float drs;
            internal float tc;
            internal float heading;
            internal float pitch;
            internal float roll;
            internal float cgHeight;
            internal CarDamage carDamage;
            internal int numberOfTyresOut;
            internal int pitLimiterOn;
            internal float abs;
            internal float kersCharge;
            internal float kersInput;
            internal int autoShifterOn;
            internal RideHeight rideHeight;
            internal float turboBoost;
            internal float ballast;
            internal float airDensity;
            internal float airTemp;
            internal float roadTemp;
            internal Vector3<float> localAngularVel;
            internal float finalFF;
            internal float performanceMeter;

            internal int engineBrake;
            internal int ersRecoveryLevel;
            internal int ersPowerLevel;
            internal int ersHeatCharging;
            internal int ersIsCharging;
            internal float kersCurrentKJ;

            internal int drsAvailable;
            internal int drsEnabled;

            internal WheelData brakeTemp;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
        internal struct SPageFileGraphic
        {
            internal int packetId;
            internal int status;
            internal int session;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            internal string currentTime;
            //wchar_T[] currentTime;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            internal string lastTime;
            //wchar_t lastTime[15];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            internal string bestTime;
            //wchar_t bestTime[15];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            internal string split;
            //wchar_t split[15];

            internal int completedLaps;
            internal int position;
            internal int iCurrentTime;
            internal int iLastTime;
            internal int iBestTime;
            internal float sessionTimeLeft;
            internal float distanceTraveled;
            internal int isInPit;
            internal int currentSectorIndex;
            internal int lastSectorTime;
            internal int numberOfLaps;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            internal string tyreCompound;

            internal float replayTimeMultiplier;
            internal float normalizedCarPosition;
            internal Vector3<float> carCoordinates;
            internal float penaltyTime;
            internal int flag;
            internal int idealLineOn;
            internal int isInPitLane;

            internal float surfaceGrip;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
        internal struct SPageFileStatic
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            internal string sharedMemoryVersion;
            //wchar_t smVersion[15];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            internal string acVersion;
            //wchar_t acVersion[15];

            // session static info
            internal int numberOfSessions;
            internal int numCars;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            internal string carModel;
            //wchar_t carModel[33];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            internal string track;
            //wchar_t track[33];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            internal string playerName;
            //wchar_t playerName[33];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            internal string playerSurname;
            //wchar_t playerSurname[33];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            internal string playerNick;
            //wchar_t playerNick[33];
            internal int sectorCount;

            // car static info
            internal float maxTorque;
            internal float maxPower;
            internal int maxRpm;
            internal float maxFuel;
            internal WheelData suspensionMaxTravel;
            internal WheelData tyreRadius;
            internal float maxTurboBoost;

            float deprecated_1;
            float deprecated_2;

            internal int penaltiesEnabled;

            internal float aidFuelRate;
            internal float aidTireRate;
            internal float aidMechanicalDamage;
            internal int aidAllowTyreBlankets;
            internal float aidStability;
            internal int aidAutoClutch;
            internal int aidAutoBlip;

            internal int hasDRS;
            internal int hasERS;
            internal int hasKERS;
            internal float kersMaxJ;
            internal int engineBrakeSettingsCount;
            internal int ersPowerControllerCount;
            internal float trackSPlineLength;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            internal string trackConfiguration;
            //wchar_t trackConfiguration[33];
        }
    }
}