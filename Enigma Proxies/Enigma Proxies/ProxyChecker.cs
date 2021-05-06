using System.Net.NetworkInformation;

namespace Enigma_Proxies
{
    public static class ProxyChecker
    {
        public static bool CheckProxy(ProxyBase proxy)
        {
            var ip = proxy.Proxy.Split(':')[0];
            var ping = new Ping();
            var reply = ping.Send(ip);

            return reply != null && reply.Status == IPStatus.Success;
        }
    }
}