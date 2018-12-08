using R3EData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TelemetryReader.src.protocol.games.race
{
    class Race07Data
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct SharedMemory
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            internal float[] userInput; // This structure allows for a number of parameters to be
                             // passed from the user to the exteral application via control input
                             // in the game. The ISIInputType enum describes which element of this
                             // array corresponds to which in-game control. Note that this data
                             // is floating point, and can be configured in the game to be driven
                             // by an analog input device (joystick). The user may also map the
                             // control to a keyboard key, or a digital controller button. This
                             // means that the value may be anywhere between 0.0 and 1.0. Also note
                             // that these values will not be debounced; if the user
                             // maps the "External Signal Up" control to a key on the keyboard,
                             // the coresponding value in this array will remain 1.0 for as long
                             // as the user holds the key down.

            internal float rps; // Engine speed, Radians Per Second.
            internal float maxEngineRPS; // For use with an "analog" rpm display.
            internal float fuelPressure; // KPa
            internal float fuel; // Current liters of fuel in the tank(s).
            internal float fuelCapacityLiters; // Maximum capacity of fuel tank(s).
            internal float engineWaterTemp; //
            internal float engineOilTemp; //
            internal float engineOilPressure; //

            internal float carSpeed; // meters per second
            internal int numberOfLaps; // # of laps in race, or -1 if player is not in
                               // race mode (player is in practice or test mode).

            internal int completedLaps; // How many laps the player has completed. If this
                                // value is 6, the player is on his 7th lap. -1 = n/a

            internal float lapTimeBest; // Seconds. -1.0 = none
            internal float lapTimePrevious; // Seconds. -1.0 = none
            internal float lapTimeCurrent; // Seconds. -1.0 = none
            internal int position; // Current position. 1 = first place.
            internal int numCars; // Number of cars (including the player) in the race.
            internal int gear; // -2 = no data available, -1 = reverse, 0 = neutral,
                       // 1 = first gear... (valid range -1 to 7).

            //float tireTemp[ TIRE_LOC_MAX ][ TREAD_LOC_MAX ]; // Temperature of three points
            internal Vector3<float> tirefrontleft; //tire values from [0]=left to [2]=right
            internal Vector3<float> tirefrontright; //tire values from [0]=left to [2]=right
            internal Vector3<float> tirerearleft; //tire values from [0]=left to [2]=right
            internal Vector3<float> tirerearright; //tire values from [0]=left to [2]=right
                                          // across the tread of each tire.
            internal int numPenalties; // Number of penalties pending for the player.

            internal Vector3<float> carCGLoc; // Physical location of car's Center of Gravity in world space, X,Y,Z... Y=up.
                                     //float carOri[ ORI_MAXIMUM ]; // Pitch, Yaw, Roll. Electronic compass, perhaps?
            internal Vector3<float> orientation;
            //float pitch;
            //float yaw;
            //float roll;

            internal Vector3<float> acceleration;
            //float localAcceleration[3]; // Acceleration in three axes (X, Y, Z) of car body (divide by
            // 9.81 to get G-force). From car center, +X=left, +Y=up, +Z=back.            
        }
    }
}
