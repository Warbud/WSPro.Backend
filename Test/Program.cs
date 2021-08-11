using System;
using WSPro.Backend.Infrastructure;
using WSPro.Backend.Model;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var _context = new WSProContext();

            _context.Worker.Add(new HouseWorker() {WarbudID = "AWD89123"});
            _context.SaveChanges();
        }
    }
}