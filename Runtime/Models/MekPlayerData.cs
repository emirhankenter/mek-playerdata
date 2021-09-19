using System;

namespace Mek.Models
{
    public abstract class MekPlayerData
    {

        public DateTime LastActive
        {
            get => PrefsManager.GetDate(MekPrefKeys.LastActive);
            set => PrefsManager.SetDate(MekPrefKeys.LastActive, value);
        }
    }
}
