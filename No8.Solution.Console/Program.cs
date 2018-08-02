using System;

namespace No8.Solution.Console
{
    using No8.Solution.Logger;
    using No8.Solution.Repository;
    using No8.Solution.Service;

    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            IPrinterManager a = new PrinterManager(new Repository(), new Logger());

            a.StartMenu();
        }
    }
}
