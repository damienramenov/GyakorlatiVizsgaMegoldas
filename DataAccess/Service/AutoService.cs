using DataAccess.Context;
using DataAccess.Model;

namespace DataAccess.Service
{
    public class AutoService
    {
        private AppDbContext _context = new();

        public void ClearDatabase()
        {
            var markak = GetMarkas();
            markak.ForEach(m => _context.AutoMarkas.Remove(m));
        }

        public void AddMarka(AutoMarka marka)
        {
            _context.AutoMarkas.Add(marka);

            _context.SaveChanges();
        }
        
        public void AddMarka(IEnumerable<AutoMarka> markas)
        {
            _context.AutoMarkas.AddRange(markas);

            _context.SaveChanges();
        }

        public AutoMarka FindMarkaByValue(string t)
            => _context.AutoMarkas.First(m => m.Marka == t);

        public AutoSzin FindSzinByValue(string t)
            => _context.AutoSzins.First(m => m.Szin == t);

        public AutoTipus FindTipusByValue(string t)
            => _context.AutoTipuses.First(m => m.Tipus == t);


        public void AddSzin(AutoSzin autoSzin)
        {
            _context.AutoSzins.Add(autoSzin);

            _context.SaveChanges();
        }

        public void AddSzin(IEnumerable<AutoSzin> autoSzin)
        {
            _context.AutoSzins.AddRange(autoSzin);

            _context.SaveChanges();
        }


        public void AddTipus(AutoTipus autoTipus)
        {
            _context.AutoTipuses.Add(autoTipus);

            _context.SaveChanges();
        }

        public void AddTipus(IEnumerable<AutoTipus> autoTipus)
        {
            _context.AutoTipuses.AddRange(autoTipus);

            _context.SaveChanges();
        }

        public void AddFlotta(Flotta flotta)
        {
            _context.Flottas.Add(flotta);

            _context.SaveChanges();
        }

        public void AddFlotta(List<Flotta> flottas)
        {
            _context.Flottas.AddRange(flottas);

            _context.SaveChanges();
        }

        public List<AutoMarka> GetMarkas() => _context.AutoMarkas.ToList();
        public List<AutoSzin> GetSzins() => _context.AutoSzins.ToList();
        public List<AutoTipus> GetTipuses() => _context.AutoTipuses.ToList();
        public List<Flotta> GetFlottas() => _context.Flottas.ToList();
    }
}
