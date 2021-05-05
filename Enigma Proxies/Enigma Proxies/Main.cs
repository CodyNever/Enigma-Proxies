using System;
using System.Collections.Generic;
using Enigma_Proxies.ProxyRoot;

namespace Enigma_Proxies
{
    public class Program
    {
        public static void Main()
        {
            var proxies = new List<ProxyBase>()
            {
                new ProxyBase("0.001.001", ProxyType.FTP, ProxyAnonymity.Elite),
                new ProxyBase("0.001.002", ProxyAnonymity.Transparent),
                new ProxyBase("0.001.003", ProxyType.SSL, ProxyAnonymity.Transparent),
                new ProxyBase("0.001.004")
            };
            var rotator = new Rotator(0, proxies, 10);

            for (var i = 0; i < 15; i++)
            {
                Console.WriteLine(rotator.GetProxy().Proxy);
            }
            Console.ReadKey();
        }
    }
}