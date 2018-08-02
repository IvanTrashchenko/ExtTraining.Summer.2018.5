using System;

namespace No8.Solution.Service
{
    public class TimeEventArgs : EventArgs
    {
        public DateTime Time => DateTime.Now;
    }
}
