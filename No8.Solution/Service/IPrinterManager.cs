using System;
using System.Collections.Generic;

namespace No8.Solution.Service
{
    using No8.Solution.Printer;

    public interface IPrinterManager
    {
        event EventHandler<TimeEventArgs> PrintTime;

        void Add();

        List<string> GetList();

        // void Remove()

        void Print(Printer p1);

        void StartMenu();
    }
}