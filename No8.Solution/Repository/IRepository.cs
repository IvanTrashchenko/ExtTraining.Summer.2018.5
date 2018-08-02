using System.Collections.Generic;

namespace No8.Solution.Repository
{
    using No8.Solution.Printer;

    public interface IRepository
    {
        List<Printer> Printers
        {
            get;
        }

        int Count { get; }

        void Save(Printer printer);

        void Delete(Printer printer);

        bool Contains(Printer printer);
    }
}
