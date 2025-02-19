using DataAccess.Service;

namespace DataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var newService = new AutoService();
            Console.WriteLine(newService.GetMarkas().Count);
        }
    }
}
