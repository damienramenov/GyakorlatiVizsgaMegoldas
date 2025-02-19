using DataAccess.Model;
using DataAccess.Service;
using System.ComponentModel.DataAnnotations;

namespace autok
{
    internal class Program
    {
        class Auto
        {
            public string? Marka { get; set; }

            public string? Modell { get; set; }

            public string? Szin { get; set; }

            public string? Tipus { get; set; }

            public Auto(string? line)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    throw new ArgumentNullException();
                }

                var splitted = line.Split(';');
                Marka = splitted[0];
                Modell = splitted[1];
                Szin = splitted[2];
                Tipus = splitted[3];
            }

            public Auto() { }

            public static bool operator ==(Auto lhs, Auto rhs)
            {
                if (lhs is null)
                {
                    return rhs is null;
                }

                if (rhs is null)
                {
                    return lhs is null;
                }

                return lhs.Marka == rhs.Marka
                        && lhs.Modell == rhs.Modell
                        && lhs.Szin == rhs.Szin
                        && lhs.Tipus == rhs.Tipus;
            }

            public static bool operator !=(Auto lhs, Auto rhs) => !(lhs == rhs);
        }

        static void Main(string[] args)
        {
            var filePath = @"autok.txt";
            using var sr = new StreamReader(filePath);

            var autok = new List<Auto>();
            var fejlec = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var auto = new Auto(line);

                autok.Add(auto);
            }


            //
            Console.WriteLine(autok.Count);
            //

            //
            var autoModellekByMarka = GetAutokByMarka(ref autok);
            Console.WriteLine(string.Join(", ", autoModellekByMarka.Select(a => a.Modell)));
            //

            //
            var percentage = ((double)autok.Count(a => a.Tipus == "SUV") / autok.Count) * 100;
            Console.WriteLine($"Az állományban szereplő autók {percentage}%-a SUV");

            //
            var markak = autok.Select(a => a.Marka).Distinct();
            List<string> markakWithCount = markak
                                            .Select(m => $"[{m}, {autok.Count(a => a.Marka==m)}]")
                                            .ToList();
            Console.WriteLine(string.Join(' ', markakWithCount));
            //

            //
            var colorWithTheMostCount = autok.OrderByDescending(a => autok.Count(b => b.Szin == a.Szin)).First();
            Console.WriteLine(colorWithTheMostCount.Szin);
            //


            var auto2 = new Auto()
            {
                Marka = "BMW",
                Modell = "e46"
            };

            var auto3 = new Auto()
            {
                Marka = "BMW",
                Modell = "e46"
            };


            var auto4 = auto2;

            var fasz = auto2 == auto3;
            var fasz2 = auto4 == auto2;

            LoadDataBase(ref autok);
        }

        private static List<Auto> GetAutokByMarka(ref List<Auto> autok)
        {
            string? marka;
            List<Auto> autokByMarka;

            while ((autokByMarka = GetAutokByMarka(marka = Console.ReadLine(), ref autok)).Count == 0)
            { }

            return autokByMarka;
        }

        private static List<Auto> GetAutokByMarka(string? marka, ref List<Auto> autok)
            => autok.Where(a => a.Marka == marka).ToList();

        private static void LoadDataBase(ref List<Auto> autok)
        {
            var service = new AutoService();

            try
            {
                var markak = autok.Select(a => a.Marka).Distinct().Select(m => new AutoMarka() { Marka = m });
                var tipusok = autok.Select(a => a.Tipus).Distinct().Select(m => new AutoTipus() { Tipus = m });
                var szinek = autok.Select(a => a.Szin).Distinct().Select(m => new AutoSzin() { Szin = m });

                service.AddMarka(markak);
                service.AddTipus(tipusok);
                service.AddSzin(szinek);

                foreach (var auto in autok)
                {
                    var marka = service.FindMarkaByValue(auto.Marka);
                    var tipus = service.FindTipusByValue(auto.Tipus);
                    var szin = service.FindSzinByValue(auto.Szin);

                    var flotta = new Flotta()
                    {
                        Marka = marka,
                        MarkaId = marka.Id,
                        Tipus = tipus,
                        TipusId = tipus.Id,
                        Szin = szin,
                        SzinId = szin.Id
                    };

                    service.AddFlotta(flotta);
                }

                Console.WriteLine("Adatbázis feltöltése sikeres volt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Az adatbázis feltöltése sikertelen volt! Hibaüzenet: {ex.Message}");
            }

        }
    }
}
