using System;
using System.IO;
using System.Windows.Forms;
using No8.Solution.Factory;
using No8.Solution.Logger;
using No8.Solution.Repository;

namespace No8.Solution.Service
{
    using System.Collections.Generic;

    using No8.Solution.Printer;

    public class PrinterManager : IPrinterManager
    {
        private readonly ILogger logger;

        private readonly IRepository repository;

        public PrinterManager(IRepository repository, ILogger logger)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            repository.Save(PrinterFactory.CreateCanonPrinter());
            repository.Save(PrinterFactory.CreateEpsonPrinter());
        }

        public event EventHandler<TimeEventArgs> PrintTime;

        public void Add()
        {
            Console.WriteLine("\nEnter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();

            var printer = PrinterFactory.CreatePrinter(name, model);

            if (!this.repository.Contains(printer))
            {
                this.repository.Save(printer);
                Console.WriteLine("Printer added.");
            }
            else
            {
                Console.WriteLine("\nPrinter already exists.");
            }
        }

        public List<string> GetList()
        {
            List<string> result = new List<string>();
            foreach (var item in this.repository.Printers)
            {
                result.Add(item.ToString());
            }

            return result;
        }

        /*public void Remove()
        {
             this.Repository.Delete(printer);
        }*/

        public void Print(Printer p1)
        {
            p1.GetTime(this);
            this.logger.Log("Print started");
            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);
            this.OnPrintTime(new TimeEventArgs());
            p1.Print(f);
            this.OnPrintTime(new TimeEventArgs());
            this.logger.Log("Print finished");
            this.logger.Log($"Printed on {p1.Name}");
            p1.Unsubscribe(this);
        }

        public void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("\nMENU");

                Console.WriteLine("\nSelect printer:");
                foreach (var item in this.GetList())
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Add new\n");
                Console.WriteLine("Enter any letter to exit\n");

                try
                {
                    var intTemp = Convert.ToInt32(Console.ReadLine());

                    if (intTemp == this.repository.Count + 1)
                    {
                        this.Add();
                    }
                    else if (intTemp <= this.repository.Count)
                    {
                        this.Print(this.repository.Printers[intTemp - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                catch (FormatException)
                {
                    return;
                }
            }
        }

        protected virtual void OnPrintTime(TimeEventArgs e)
        {
            this.PrintTime?.Invoke(this, e);
        }
    }

    // сервис для работы с репозиторием принтеров. не успел сделать remove
}