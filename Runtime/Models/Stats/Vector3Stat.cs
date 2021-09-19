using System;
using UnityEngine;

namespace Mek.Models.Stats
{
    public class Vector3Stat : BaseStat
    {
        public Vector3 Min { get; protected set; }
        public Vector3 Max { get; protected set; }
        public Vector3 CurrentValue { get; protected set; }

        protected bool HasLimits;

        public Vector3Stat(Vector3 min, Vector3 max, Vector3 initial)
        {
            Min = min;
            Max = max;
            CurrentValue = initial;

            HasLimits = true;
        }

        public Vector3Stat(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;

            HasLimits = true;
        }

        public Vector3Stat(Vector3 initial)
        {
            CurrentValue = initial;

            HasLimits = false;
        }

        public override T Get<T>()
        {
            ValidateType(typeof(T));

            return (T)Convert.ChangeType(CurrentValue, typeof(Vector3));
        }

        public override bool Set<T>(T value)
        {
            ValidateType(typeof(T));

            var newValue = (Vector3)Convert.ChangeType(value, typeof(Vector3));

            if (HasLimits)
            {
                newValue.x = Mathf.Clamp(newValue.x, Min.x, Max.x);
                newValue.y = Mathf.Clamp(newValue.y, Min.y, Max.y);
                newValue.z = Mathf.Clamp(newValue.z, Min.z, Max.z);
            }

            if (newValue == CurrentValue)
            {
                return false;
            }

            CurrentValue = newValue;

            return base.Set(newValue);
        }

        public override Type GetStatType()
        {
            return typeof(Vector3);
        }
    }
}