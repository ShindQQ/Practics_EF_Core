using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Practic1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BuildingCompanyDBContext db = new BuildingCompanyDBContext())
            {
                var brigades = db.Brigades.ToList();

                Console.WriteLine("Brigades:");
                foreach (var item in brigades)
                {
                    Console.WriteLine($"{item.BrigadeId}, {item.BuildingCompanyId}, {item.WorkersAmmount}");
                }
            }
        }
    }
}