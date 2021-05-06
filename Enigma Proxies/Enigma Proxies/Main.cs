using System;
using System.Collections.Generic;

namespace Enigma_Proxies
{
    public class Program
    {
        static void Main()
        {
            var proxies = new List<ProxyBase>()
            {
                new ProxyBase("0.001.001", ProxyType.FTP, ProxyAnonymity.Elite),
                new ProxyBase("0.001.002", ProxyAnonymity.Transparent),
                new ProxyBase("0.001.003", ProxyType.SSL, ProxyAnonymity.Transparent),
                new ProxyBase("0.001.004")
            };

            EnigmaProxies.CreateRotator(proxies, 5);
            EnigmaProxies.CreateRotator(proxies, 4);

            Console.WriteLine(EnigmaProxies.GetRotator(-1).RotatorMaxUsages);
            Console.WriteLine(EnigmaProxies.GetRotator(0).RotatorMaxUsages);
            Console.WriteLine(EnigmaProxies.GetRotator(1).RotatorMaxUsages);
            Console.WriteLine(EnigmaProxies.GetRotator(2).RotatorMaxUsages);

            Console.ReadKey();
        }
    }
}