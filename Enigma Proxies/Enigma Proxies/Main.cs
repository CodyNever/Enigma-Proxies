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
                new ProxyBase("0.001.001", ProxyType.HTTP, ProxyAnonymity.Elite),
                new ProxyBase("0.001.002", ProxyAnonymity.Transparent),
                new ProxyBase("0.001.003", ProxyType.Socks5, ProxyAnonymity.Transparent),
                new ProxyBase("0.001.004")
            };

            EnigmaProxies.CreateRotator(proxies);
            
            var p = EnigmaProxies.GetProxy();
            
            //Console.WriteLine(ProxyChecker.CheckProxy(new ProxyBase("132.248.196.2:8080")));
            Console.WriteLine(ProxyChecker.CheckProxy(new ProxyBase("6.2:8080")));
            Console.ReadKey();
        }
    }
}