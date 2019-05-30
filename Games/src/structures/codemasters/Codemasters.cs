using System.Runtime.InteropServices;

namespace Games
{
    namespace Codemasters
    {
        public static class DataInfo
        {
            public static readonly int ExtraData3Size = Marshal.SizeOf(typeof(ExtraData3));
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct WheelData
        {
            public float FrontLeft;
            public float FrontRight;
            public float RearLeft;
            public float RearRight;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ExtraData3
        {
            public float m_time;
            public float m_lapTime;
            public float m_lapDistance;
            public float m_totalDistance;
            public float m_x;      // World space position
            public float m_y;      // World space position
            public float m_z;      // World space position
            public float m_speed;
            public float m_xv;      // Velocity in world space
            public float m_yv;      // Velocity in world space
            public float m_zv;      // Velocity in world space
            public float m_xr;      // World space right direction
            public float m_yr;      // World space right direction
            public float m_zr;      // World space right direction
            public float m_xd;      // World space forward direction
            public float m_yd;      // World space forward direction
            public float m_zd;      // World space forward direction
            public float m_susp_pos_bl;
            public float m_susp_pos_br;
            public float m_susp_pos_fl;
            public float m_susp_pos_fr;
            public float m_susp_vel_bl;
            public float m_susp_vel_br;
            public float m_susp_vel_fl;
            public float m_susp_vel_fr;
            public float m_wheel_speed_bl;
            public float m_wheel_speed_br;
            public float m_wheel_speed_fl;
            public float m_wheel_speed_fr;
            public float m_throttle;
            public float m_steer;
            public float m_brake;
            public float m_clutch;
            public float m_gear;
            public float m_gforce_lat;
            public float m_gforce_lon;
            public float m_lap;
            public float RPS;
            public float m_sli_pro_native_support; // SLI Pro support
            public float m_car_position;   // car race position
            public float m_kers_level;    // kers energy left
            public float m_kers_max_level;   // kers maximum energy
            public float m_drs;     // 0 = off, 1 = on
            public float m_traction_control;  // 0 (off) - 2 (high)
            public float m_anti_lock_brakes;  // 0 (off) - 1 (on)
            public float m_fuel_in_tank;   // current fuel mass
            public float m_fuel_capacity;   // fuel capacity
            public float m_in_pits;    // 0 = none, 1 = pitting, 2 = in pit area
            public float m_sector;     // 0 = sector1, 1 = sector2; 2 = sector3
            public float m_sector1_time;   // time of sector1 (or 0)
            public float m_sector2_time;   // time of sector2 (or 0)
            public WheelData brakes_temp;   // brakes temperature (centigrade)
            public WheelData wheels_pressure;  // wheels pressure PSI
            public float m_team_info;    // team ID 
            public float m_total_laps;    // total number of laps in this race
            public float m_track_size;    // track size meters
            public float m_last_lap_time;   // last lap time
            public float m_max_rps;    // cars max RPM, at which point the rev limiter will kick in
            public float m_idle_rps;    // cars idle RPM
            public float m_max_gears;    // maximum number of gears
            public float m_sessionType;   // 0 = unknown, 1 = practice, 2 = qualifying, 3 = race
            public float m_drsAllowed;    // 0 = not allowed, 1 = allowed, -1 = invalid / unknown
            public float m_track_number;   // -1 for unknown, 0-21 for tracks
            public float m_vehicleFIAFlags;  // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DirtRallyPacket
        {
            public float Time;
            public float TimeCurrentLap;
            public float DistanceDrivenCurrentLap;
            public float DistanceDrivenOverall;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public float VelocitySpeed;
            public float VelocityX;
            public float VelocityY;
            public float VelocityZ;
            public float RollVectorX;
            public float RollVectorY;
            public float RollVectorZ;
            public float PitchVectorX;
            public float PitchVectorY;
            public float PitchVectorZ;
            public float PositionSuspensionRearLeft;
            public float PositionSuspensionRearRight;
            public float PositionSuspensionFrontLeft;
            public float PositionSuspensionFrontRight;
            public float VelocitySuspensionRearLeft;
            public float VelocitySuspensionRearRight;
            public float VelocitySuspensionFrontLeft;
            public float VelocitySuspensionFrontRight;
            public float VelocityWheelRearLeft;
            public float VelocityWheelRearRight;
            public float VelocityWheelFrontLeft;
            public float VelocityWheelFrontRight;
            public float PositionThrottle;
            public float PositionSteer;
            public float PositionBrake;
            public float PositionClutch;
            public float Gear; // [0 = Neutral, 1 = 1, 2 = 2, ..., 10 = Reverse]
            public float GForceLateral;
            public float GForceLongitudinal;
            public float CurrentLap;
            public float RPS; //[rpm / 10]
            public float Unkown0;
            public float Unkown1;
            public float Unkown2;
            public float Unkown3;
            public float Unkown4;
            public float Unkown5;
            public float Unkown6;
            public float Unkown7;
            public float Unkown8;
            public float Unkown9;
            public float Unkown10;
            public float Unkown11;
            public float Unkown12;
            public float TemperatureBrakeRearLeft;
            public float TemperatureBrakeRearRight;
            public float TemperatureBrakeFrontLeft;
            public float TemperatureBrakeFrontRight;
            public float Unkown13;
            public float Unkown14;
            public float Unkown15;
            public float Unkown16;
            public float Unkown17;
            public float NumberLapsTotal;
            public float LengthTrackTotal;
            public float Unkmown18;
            public float MaximumRPS; // / 10
            public float Unknown19;
            public float Unknown20; // / 10
        }
    }
}
