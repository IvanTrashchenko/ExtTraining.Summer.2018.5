using System;
using System.Collections.Generic;

namespace No8.Solution.Repository
{
    using No8.Solution.Printer;

    public class Repository : IRepository
    {
        private List<Printer> printers;

        public Repository()
        {
            this.Printers = new List<Printer>();
        }

        public Repository(IEnumerable<Printer> printers)
        {
            if (printers == null)
            {
                throw new ArgumentNullException($"{nameof(printers)} can not be null.");
            }

            this.Printers = new List<Printer>(printers);
        }

        public List<Printer> Printers
        {
            get => this.printers;
            private set => this.printers = value ?? throw new ArgumentException($"{nameof(value)} can not be null.");
        }

        public int Count => this.Printers.Count;

        public void Delete(Printer printer)
        {
            this.Printers.Remove(printer);
        }

        public bool Contains(Printer printer)
        {
            return this.Printers.Contains(printer);
        }

        public void Save(Printer printer)
        {
            this.Printers.Add(printer);
        }
    }

    // репозиторий как оболочка листа принетров
}
