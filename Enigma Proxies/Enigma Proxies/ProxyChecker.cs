using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Enigma_Proxies
{
    public static class ProxyChecker
    {
        public static bool CheckProxy(ProxyBase proxy)
        {
            try
            {
                var myIp = GetIp();
                var receivedIp = GetIp(proxy);
                //Console.WriteLine($"my {myIp} : received {receivedIp}");
                if (receivedIp == "") return false;
                return receivedIp != myIp;
            }
            catch
            {
                return false;
            }
        }

        public static string GetIp(ProxyBase proxyBase = null, int timeOut = 5000)
        {
            return Regex.Match(GetIpInfo(proxyBase, timeOut), @"query"":""(.*?)""}").Groups[1].Value;
        }

        public static string GetCountry(ProxyBase proxyBase = null, int timeOut = 5000)
        {
            var c = Regex.Match(GetIpInfo(proxyBase, timeOut), @"country"":""(.*?)""").Groups[1].Value;
            return c == "" ? "Unknown" : c;
        }


        private static string GetIpInfo(ProxyBase proxyBase = null, int timeOut = 5000)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create("http://ip-api.com/json/");
            
                if(proxyBase != null) webRequest.Proxy = new WebProxy(proxyBase.Proxy, true);
                webRequest.Timeout = timeOut;
                webRequest.ReadWriteTimeout = timeOut;

                var response = (HttpWebResponse) webRequest.GetResponse();
                var streamReader = new StreamReader(response.GetResponseStream());

                return streamReader.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}