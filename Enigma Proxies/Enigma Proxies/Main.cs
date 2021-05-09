using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Enigma_Proxies
{
    public class Program
    {
        static void Main()
        {
            var s = new Stopwatch();
            s.Start();
            var proxies = GetProxies().Result;
            s.Stop();
            set = s.Elapsed;
          
            ParallelTask(proxies);
            ForeachTask(proxies);

            Console.WriteLine($"Benchmark of {proxies.Count} proxies end!");
            Console.WriteLine($"Proxies setup {set}");
            Console.WriteLine($"Parallel {par}");
            Console.WriteLine($"Non parallel {non}");
            
            Console.ReadKey();
        }

        private static TimeSpan set;
        private static TimeSpan par;
        private static TimeSpan non;
        private static void ParallelTask(List<ProxyBase> proxies)
        {
            var s = new Stopwatch();
            s.Start();
            Parallel.ForEach(proxies, proxy =>
            {
                Console.WriteLine($"Parallel {proxy.Working}");
            });
            s.Stop();
            par = s.Elapsed;
        }

        private static void ForeachTask(List<ProxyBase> proxies)
        {
            var s = new Stopwatch();
            s.Start();
            foreach (var proxy in proxies)
            {
                Console.WriteLine($"foreach {proxy.Working}");
            }
            s.Stop();
            non = s.Elapsed;
        }


        private static async Task<List<ProxyBase>> GetProxies()
        {
            const string path = @"C:\Users\PC\Documents\GitHub\Enigma-Proxies\Enigma Proxies\proxies.txt";
            var proxies = new List<ProxyBase>();
            using (var sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    proxies.Add(new ProxyBase(line));
                }
            }

            return proxies;
        }
    }
}