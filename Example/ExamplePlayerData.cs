using Mek.Models.Stats;
using System;
using System.Collections.Generic;
using Mek.Interfaces;
using Mek.Models;

namespace Mek.Examples
{
    public sealed class ExamplePlayerData : BasePlayerData
    {
        public static void Construct()
        {
            if (_instance != null) return;
            _instance = new ExamplePlayerData();
            _instance.Init();
        }
        
        private static ExamplePlayerData _instance;
        
        private static readonly Dictionary<string, BaseStat> Prefs = new Dictionary<string, BaseStat> {
            
            { ExamplePrefKeys.ExampleInteger, new IntStat(-10, 10, 0)},
            { ExamplePrefKeys.ExampleBoolean, new BoolStat(true)},
            //.. All default values must be here
            //..
            //..
        };
        
        public override Dictionary<string, BaseStat> GetPrefs()
        {
            return Prefs;
        }
        
        public static int ExampleInteger
        {
            get => PrefsManager.GetInt(ExamplePrefKeys.ExampleInteger);
            set => PrefsManager.SetInt(ExamplePrefKeys.ExampleInteger, value);
        }
        public static bool ExampleBoolean
        {
            get => PrefsManager.GetBool(ExamplePrefKeys.ExampleBoolean);
            set => PrefsManager.SetBool(ExamplePrefKeys.ExampleBoolean, value);
        }
    }
    
    public static class ExamplePrefKeys
    {
        public static readonly string ExampleInteger = nameof(ExampleInteger);
        public static readonly string ExampleBoolean = nameof(ExampleBoolean);
    }

    [Serializable]
    public class TestClass : IObservableModel
    {
        public event Action PropertyChanged;
        public int Number;
    }
}