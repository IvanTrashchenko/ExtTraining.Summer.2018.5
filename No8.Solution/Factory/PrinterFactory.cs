namespace No8.Solution.Factory
{
    using No8.Solution.Printer;

    public static class PrinterFactory
    {
        public static Printer CreatePrinter(string name, string model) =>
            new Printer(name, model);

        public static CanonPrinter CreateCanonPrinter() => new CanonPrinter();

        public static EpsonPrinter CreateEpsonPrinter() => new EpsonPrinter();
    }
}
