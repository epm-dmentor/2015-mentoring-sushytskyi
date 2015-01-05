namespace Epam.NetMentoring.CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculationService nonCachedService = new CalculationService();
            ICalculationService cachedService = new CachedCalculationService(nonCachedService);
            cachedService.Calculate(10, 10);
           
        }
    }
}
