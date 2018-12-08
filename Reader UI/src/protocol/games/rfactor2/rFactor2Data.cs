using AssettoCorsaData;
using R3EData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static TelemetryReader.src.protocol.games.pcars.ProjectCarsData;

namespace TelemetryReader.src.protocol.games.rfactor2
{
    class rFactor2Data
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct telemetry // whole = 596
        {
            //Transmission/engine
            int gear;
            int maxGears;
            int frontFlapActivated;
            int rearFlapActivated;

            int rearFlapLegalStatus;
            int overheating;
            int detached;
            int headlights;

            int speedLimiter;
            int speedLimiterAvailable;
            int ingitionStarter;
            int aligmentInteger;

            Vector4<int> tireIsFlat;
            Vector4<int> tireIsDetached;

            float engineRpm;
            float engineMaxRpm;
            float waterTemp;
            float oiltemp;

            float turboPressure;
            float throttleInput;
            float brakeInput;
            float clutchInput;

            float steeringInput;
            float frontWingHeight;
            float frontRideHeight;
            float rearRideHeight;

            float frontDownforce;
            float rearDownforce;
            float currentFuelLevelLiter;
            float maxFuelLevelLiter;

            // brakes
            float rearBrakeBias;
            float engineTorque;
            float alignmentFloat1;
            float alignmentFloat2;

            WheelData brakeTemp;
            WheelData brakePressure;

            // tires
            WheelData rideHeight;
            WheelData rotationSpeed;
            WheelData camber;
            WheelData tireLoad;
            WheelData gripFact;
            WheelData pressure;
            WheelData tireTemperatureLeft;
            WheelData tireTemperatureMid;
            WheelData tireTemperatureRight;
            WheelData wearLevel;
            WheelData toe;
            WheelData tireCarcassTemperature;
            WheelData tireTemperatureInnerLayerLeft;
            WheelData tireTemperatureInnerLayerMid;
            WheelData tireTemperatureInnerLayerRight;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            string vehiclename;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            string trackname;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            string frontCompound;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            string rearCompound;
        } 

        [StructLayout(LayoutKind.Sequential)]
        internal struct scoring // 232
        {
            // player
            int isPlayer;
            int isInControl;
            int gamePhase;
            int yellowFlagStatusOnCourse;

            int yellowFlagSector1Status;
            int yellowFlagSector2Status;
            int yellowFlagSector3Status;
            int currenStartLightNumber;

            int maxStartLightNumber;
            int flagForPlayer; // 0 for green and 6 for blue
            int pitState;
            int lapsCompleted;

            // session info
            int maxLaps;
            int finishStatus;
            int position;
            int maxPosition;

            int lapsBehindNext;
            int lapsBehindLeader;
            // pit stop info
            int numOfPitstops;
            int numOfPenalties;

            // track info
            int currentSectorIndex;
            int alignmentInteger0;
            int alignmentInteger1;
            int alignmentInteger2;

            // physics
            float worldPositionX;
            float worldPositionY;
            float worldPositionZ;
            float trackLength;

            float velocityX;
            float velocityY;
            float velocityZ;
            float lapDistance;

            float accelerationX;
            float accelerationY;
            float accelerationZ;
            float lapStartTimestamp;

            float bestSector1;
            float bestSector2;
            float bestLapTime;
            float lastSector1;

            float lastSector2;
            float lastLapTime;
            float currentSector1;
            float currentSector2;

            float timeBehindNext;
            float timeBehindLeader;
            float currentTime;
            float endTimeSession;

            float estimatedLapTime;
            float cloudDensity;
            float rainDensity;
            float ambientTemp;

            float trackTemp;
            float wetnessBesideTrack;
            float windSpeedX;
            float windSpeedY;

            float windSpeedZ;
            float wetnessTrack;
        };
    }
}
