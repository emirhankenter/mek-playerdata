using System;
using System.Collections.Generic;
using Mek.Models.Stats;
using UnityEngine;

namespace Mek.Models
{
    public abstract class BasePlayerData
    {
        protected void Init()
        {
            PrefsManager.InitializeData(GetPrefs());
        }

        public abstract Dictionary<string, BaseStat> GetPrefs();

        public DateTime LastActive
        {
            get => PrefsManager.GetDate(MekPrefKeys.LastActive);
            set => PrefsManager.SetDate(MekPrefKeys.LastActive, value);
        }
    }
}
