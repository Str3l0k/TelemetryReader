using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Telemetry.Protocol;
using Telemetry.Protocol.Values;

namespace Telemetry_Test
{
    [TestClass]
    public class TelemetryValueTest
    {
        [TestMethod]
        public void CheckCarClassNumber()
        {
            var type = typeof(TelemetryValues.Car);
            var classes = type.GetMembers().Where(m => m.MemberType == MemberTypes.NestedType).ToArray();

            Assert.AreEqual(9, classes.Length);
        }

        [TestMethod]
        public void CheckCarIDDuplicates()
        {
            var type = typeof(TelemetryValues.Car);
            var classes = type.GetMembers().Where(m => m.MemberType == System.Reflection.MemberTypes.NestedType).ToArray();

            Type[] types =
            {
                typeof(TelemetryValues.Car.Body),
                typeof(TelemetryValues.Car.Chassis),
                typeof(TelemetryValues.Car.Control),
                typeof(TelemetryValues.Car.Fuel),
                typeof(TelemetryValues.Car.Information),
                typeof(TelemetryValues.Car.Physics),
                typeof(TelemetryValues.Car.PowerTrain),
                typeof(TelemetryValues.Car.Settings),
                typeof(TelemetryValues.Car.Status)
            };

            // just for human error prevention
            Assert.AreEqual(classes.Length, types.Length);

            var ids = new List<UInt16>();

            foreach (Type t in types)
            {
                ids.AddRange(FetchIDs(t));
            }

            Console.WriteLine($"ID Count: {ids.Count}");

            Assert.AreEqual(true, ids.Count == ids.Distinct().Count());

            ids.Add(ids[0]);

            Assert.AreEqual(false, ids.Count == ids.Distinct().Count());
        }

        private List<UInt16> FetchIDs(Type t)
        {
            var fields = t.GetFields(BindingFlags.Public | BindingFlags.Static);

            var ids = new List<UInt16>();

            foreach (FieldInfo field in fields)
            {
                var fieldType = field.FieldType;
                var fieldInstance = field.GetValue(null);
                var valueInterface = fieldType.GetInterface(typeof(ITelemetryValue).Name);

                if (valueInterface != null)
                {
                    var idField = valueInterface.GetProperty("ID");
                    var id = (UInt16)idField.GetValue(fieldInstance);

                    ids.Add(id);
                }
            }

            return ids;
        }
    }
}
