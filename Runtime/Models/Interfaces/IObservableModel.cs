using System;

namespace Mek.Interfaces
{
    public interface IObservableModel
    {
        event Action PropertyChanged;
    }
}
