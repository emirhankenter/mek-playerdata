using System;
using UnityEngine;

namespace Mek.Models.Stats
{
    public class Vector2Stat : BaseStat
    {
        public Vector2 Min { get; protected set; }
        public Vector2 Max { get; protected set; }
        public Vector2 CurrentValue { get; protected set; }

        protected bool HasLimits;

        public Vector2Stat(Vector2 min, Vector2 max, Vector2 initial)
        {
            Min = min;
            Max = max;
            CurrentValue = initial;

            HasLimits = true;
        }

        public Vector2Stat(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;

            HasLimits = true;
        }

        public Vector2Stat(Vector2 initial)
        {
            CurrentValue = initial;

            HasLimits = false;
        }

        public override T Get<T>()
        {
            ValidateType(typeof(T));

            return (T)Convert.ChangeType(CurrentValue, typeof(Vector2));
        }

        public override bool Set<T>(T value)
        {
            ValidateType(typeof(T));

            var newValue = (Vector2)Convert.ChangeType(value, typeof(Vector2));

            if (HasLimits)
            {
                newValue.x = Mathf.Clamp(newValue.x, Min.x, Max.x);
                newValue.y = Mathf.Clamp(newValue.y, Min.y, Max.y);
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
            return typeof(Vector2);
        }
    }
}