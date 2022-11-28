using System;
using System.Collections.Generic;
using Mek.Interfaces;
using Mek.Models;
using Mek.Models.Stats;
using UnityEngine;

namespace Mek.Examples
{
    public sealed class ExamplePlayerData : BasePlayerData<ExamplePlayerData>, IPlayerData
    {
        public Dictionary<string, BaseStat> Prefs => new Dictionary<string, BaseStat> {
            
            { ExamplePrefKeys.ExampleInteger, new IntStat(0)},
            { ExamplePrefKeys.ExampleFloat, new FloatStat(0f)},
            { ExamplePrefKeys.ExampleString, new StringStat("HelloWorld")},
            { ExamplePrefKeys.ExampleBoolean, new BoolStat(true)},
            { ExamplePrefKeys.ExampleDate, new DateStat(DateTime.Now)},
            { ExamplePrefKeys.ExampleVector2, new Vector2Stat(Vector2.one)},
            { ExamplePrefKeys.ExampleVector3, new Vector3Stat(Vector3.one)},
            { ExamplePrefKeys.ExampleClass, new ObjectStat<ExampleClass>(new ExampleClass {Number = 100})},
            //.. All default values must be here
            //..
            //..
        };
        
        public static int ExampleInteger
        {
            get => PrefsManager.GetInt(ExamplePrefKeys.ExampleInteger);
            set => PrefsManager.SetInt(ExamplePrefKeys.ExampleInteger, value);
        }
        public static float ExampleFloat
        {
            get => PrefsManager.GetFloat(ExamplePrefKeys.ExampleFloat);
            set => PrefsManager.SetFloat(ExamplePrefKeys.ExampleFloat, value);
        }
        public static string ExampleString
        {
            get => PrefsManager.GetString(ExamplePrefKeys.ExampleString);
            set => PrefsManager.SetString(ExamplePrefKeys.ExampleString, value);
        }
        public static bool ExampleBoolean
        {
            get => PrefsManager.GetBool(ExamplePrefKeys.ExampleBoolean);
            set => PrefsManager.SetBool(ExamplePrefKeys.ExampleBoolean, value);
        }
        public static DateTime ExampleDate
        {
            get => PrefsManager.GetDate(ExamplePrefKeys.ExampleDate);
            set => PrefsManager.SetDate(ExamplePrefKeys.ExampleDate, value);
        }
        public static Vector2 ExampleVector2
        {
            get => PrefsManager.GetVector2(ExamplePrefKeys.ExampleVector2);
            set => PrefsManager.SetVector2(ExamplePrefKeys.ExampleVector2, value);
        }
        public static Vector3 ExampleVector3
        {
            get => PrefsManager.GetVector3(ExamplePrefKeys.ExampleVector3);
            set => PrefsManager.SetVector3(ExamplePrefKeys.ExampleVector3, value);
        }
        public static ExampleClass ExampleClass
        {
            get => PrefsManager.GetObject<ExampleClass>(ExamplePrefKeys.ExampleClass);
            set => PrefsManager.SetObject(ExamplePrefKeys.ExampleClass, value);
        }
    }
    
    public static class ExamplePrefKeys
    {
        public static readonly string ExampleInteger = nameof(ExampleInteger);
        public static readonly string ExampleFloat = nameof(ExampleFloat);
        public static readonly string ExampleString = nameof(ExampleString);
        public static readonly string ExampleBoolean = nameof(ExampleBoolean);
        public static readonly string ExampleDate = nameof(ExampleDate);
        public static readonly string ExampleVector2 = nameof(ExampleVector2);
        public static readonly string ExampleVector3 = nameof(ExampleVector3);
        public static readonly string ExampleClass = nameof(ExampleClass);
    }
    
    [Serializable]
    public class ExampleClass : IObservableModel
    {
        public event Action PropertyChanged;
        public int Number;
    }
}