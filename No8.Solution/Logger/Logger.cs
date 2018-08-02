namespace No8.Solution.Logger
{
    using System.IO;

    public class Logger : ILogger
    {
        public void Log(string s)
        {
            using (TextWriter writer = File.AppendText("log.txt"))
                writer.WriteLine(s);
        }
    }

    // класс для логирования процесса печати
}