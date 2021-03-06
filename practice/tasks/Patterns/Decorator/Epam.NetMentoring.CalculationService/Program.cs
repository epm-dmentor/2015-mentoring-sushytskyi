﻿using System;

namespace Epam.NetMentoring.CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculationService nonCachedService = new CalculationService();
            ICalculationService cachedService = new CachedCalculationService(nonCachedService);
            ICalculationService improvedCalcService = new ImprovedCalcService(cachedService);

            
            Console.WriteLine(cachedService.Calculate(10, 10));
            Console.WriteLine(cachedService.Calculate(10, 10));
            Console.WriteLine(cachedService.Calculate(1, 10));
            Console.WriteLine(improvedCalcService.Calculate(10, 10));
            Console.ReadLine();

        }
    }
}
