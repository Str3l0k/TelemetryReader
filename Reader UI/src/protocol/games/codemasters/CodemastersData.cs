using AssettoCorsaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TelemetryReader.src.protocol.games.codemasters
{
    class CodemastersData
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct F12016Packet
        {
            internal float m_time;
            internal float m_lapTime;
            internal float m_lapDistance;
            internal float m_totalDistance;
            internal float m_x;      // World space position
            internal float m_y;      // World space position
            internal float m_z;      // World space position
            internal float m_speed;
            internal float m_xv;      // Velocity in world space
            internal float m_yv;      // Velocity in world space
            internal float m_zv;      // Velocity in world space
            internal float m_xr;      // World space right direction
            internal float m_yr;      // World space right direction
            internal float m_zr;      // World space right direction
            internal float m_xd;      // World space forward direction
            internal float m_yd;      // World space forward direction
            internal float m_zd;      // World space forward direction
            internal float m_susp_pos_bl;
            internal float m_susp_pos_br;
            internal float m_susp_pos_fl;
            internal float m_susp_pos_fr;
            internal float m_susp_vel_bl;
            internal float m_susp_vel_br;
            internal float m_susp_vel_fl;
            internal float m_susp_vel_fr;
            internal float m_wheel_speed_bl;
            internal float m_wheel_speed_br;
            internal float m_wheel_speed_fl;
            internal float m_wheel_speed_fr;
            internal float m_throttle;
            internal float m_steer;
            internal float m_brake;
            internal float m_clutch;
            internal float m_gear;
            internal float m_gforce_lat;
            internal float m_gforce_lon;
            internal float m_lap;
            internal float m_engineRate;
            internal float m_sli_pro_native_support; // SLI Pro support
            internal float m_car_position;   // car race position
            internal float m_kers_level;    // kers energy left
            internal float m_kers_max_level;   // kers maximum energy
            internal float m_drs;     // 0 = off, 1 = on
            internal float m_traction_control;  // 0 (off) - 2 (high)
            internal float m_anti_lock_brakes;  // 0 (off) - 1 (on)
            internal float m_fuel_in_tank;   // current fuel mass
            internal float m_fuel_capacity;   // fuel capacity
            internal float m_in_pits;    // 0 = none, 1 = pitting, 2 = in pit area
            internal float m_sector;     // 0 = sector1, 1 = sector2; 2 = sector3
            internal float m_sector1_time;   // time of sector1 (or 0)
            internal float m_sector2_time;   // time of sector2 (or 0)
            internal WheelData brakes_temp;   // brakes temperature (centigrade)
            internal WheelData wheels_pressure;  // wheels pressure PSI
            internal float m_team_info;    // team ID 
            internal float m_total_laps;    // total number of laps in this race
            internal float m_track_size;    // track size meters
            internal float m_last_lap_time;   // last lap time
            internal float m_max_rpm;    // cars max RPM, at which point the rev limiter will kick in
            internal float m_idle_rpm;    // cars idle RPM
            internal float m_max_gears;    // maximum number of gears
            internal float m_sessionType;   // 0 = unknown, 1 = practice, 2 = qualifying, 3 = race
            internal float m_drsAllowed;    // 0 = not allowed, 1 = allowed, -1 = invalid / unknown
            internal float m_track_number;   // -1 for unknown, 0-21 for tracks
            internal float m_vehicleFIAFlags;  // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DirtRallyPacket
        {
            internal float Time;
            internal float TimeCurrentLap;
            internal float DistanceDrivenCurrentLap;
            internal float DistanceDrivenOverall;
            internal float PositionX;
            internal float PositionY;
            internal float PositionZ;
            internal float VelocitySpeed;
            internal float VelocityX;
            internal float VelocityY;
            internal float VelocityZ;
            internal float RollVectorX;
            internal float RollVectorY;
            internal float RollVectorZ;
            internal float PitchVectorX;
            internal float PitchVectorY;
            internal float PitchVectorZ;
            internal float PositionSuspensionRearLeft;
            internal float PositionSuspensionRearRight;
            internal float PositionSuspensionFrontLeft;
            internal float PositionSuspensionFrontRight;
            internal float VelocitySuspensionRearLeft;
            internal float VelocitySuspensionRearRight;
            internal float VelocitySuspensionFrontLeft;
            internal float VelocitySuspensionFrontRight;
            internal float VelocityWheelRearLeft;
            internal float VelocityWheelRearRight;
            internal float VelocityWheelFrontLeft;
            internal float VelocityWheelFrontRight;
            internal float PositionThrottle;
            internal float PositionSteer;
            internal float PositionBrake;
            internal float PositionClutch;
            internal float Gear; // [0 = Neutral, 1 = 1, 2 = 2, ..., 10 = Reverse]
            internal float GForceLateral;
            internal float GForceLongitudinal;
            internal float CurrentLap;
            internal float RPM; //[rpm / 10]
            internal float Unkown0;
            internal float Unkown1;
            internal float Unkown2;
            internal float Unkown3;
            internal float Unkown4;
            internal float Unkown5;
            internal float Unkown6;
            internal float Unkown7;
            internal float Unkown8;
            internal float Unkown9;
            internal float Unkown10;
            internal float Unkown11;
            internal float Unkown12;
            internal float TemperatureBrakeRearLeft;
            internal float TemperatureBrakeRearRight;
            internal float TemperatureBrakeFrontLeft;
            internal float TemperatureBrakeFrontRight;
            internal float Unkown13;
            internal float Unkown14;
            internal float Unkown15;
            internal float Unkown16;
            internal float Unkown17;
            internal float NumberLapsTotal;
            internal float LengthTrackTotal;
            internal float Unkmown18;
            internal float MaximumRPM; // / 10
            internal float Unknown19;
            internal float Unknown20; // / 10
        }
    }
}
