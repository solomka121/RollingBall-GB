using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace RollingBall
{
    public static class Extensions
    {
        public static bool TryBool(this string self)
        {
            return Boolean.TryParse(self, out var res) && res;
        }

        public static float TrySingle(this string self)
        {
            return Single.Parse(self);
        }
    }
}