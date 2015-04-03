namespace Epam.NetMentoring.CalculationService
{
    public class ImprovedCalcService : ICalculationService
    {
        private readonly ICalculationService _calcService;
        private const int Addition = 10;
        public ImprovedCalcService(ICalculationService calcService)
        {
            _calcService = calcService;
        }
        public decimal Calculate(decimal a, decimal b)
        {
            return _calcService.Calculate(a, b) + Addition;
        }
    }
}
