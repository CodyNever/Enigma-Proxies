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

            var rotator = EnigmaProxies.CreateRotator(proxies);

            for (var i = 0; i < 15; i++)
            {
                Console.WriteLine(rotator.GetProxy().Proxy);
            }
            
            Console.ReadKey();
        }
    }
}