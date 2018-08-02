using System;
using System.IO;

namespace No8.Solution.Printer
{
    using No8.Solution.Service;

    public class Printer : IEquatable<Printer>
    {
        public Printer(string name, string model)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public string Model { get; set; }

        public string Name { get; set; }

        public bool Equals(Printer other)
        {
            return other != null &&
                   this.Model == other.Model &&
                   this.Name == other.Name;
        }

        public void Print(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }
        }

        public void GetTime(IPrinterManager manager)
        {
            manager.PrintTime += this.TimePrinted;
        }

        public void Unsubscribe(IPrinterManager manager)
        {
            manager.PrintTime -= this.TimePrinted;
        }

        public void TimePrinted(object sender, TimeEventArgs e)
        {
            Console.WriteLine(e.Time);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Model}";
        }
    }

    // базовый класс принтера реализующий IEquateble для возможности проверки его наличия в репозитории
}