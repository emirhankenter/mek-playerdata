using System;
using System.Collections.Generic;
using System.Reflection;
using Mek.Models.Stats;
using UnityEngine;

namespace Mek.Models
{
    public interface IPlayerData
    {
        Dictionary<string, BaseStat> Prefs { get; }
    }
    public abstract class BasePlayerData<T> where T : class, IPlayerData, new ()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new T();
                return _instance;
            }
        }

        private static bool _isInitialized;
        
        public static void Initialize()
        {
            if(_isInitialized) return;
            PrefsManager.InitializeData(Instance.Prefs);
            _isInitialized = true;
        }
        
        public abstract Dictionary<string, BaseStat> Prefs { get; }
    }
}