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
                var receivedIp = GetIp(proxy.Proxy);
                //Console.WriteLine($"my {myIp} : received {receivedIp}");
                if (receivedIp == "") return false;
                return receivedIp != myIp;
            }
            catch
            {
                return false;
            }
        }

        public static string GetIp(string proxy = null, int timeOut = 5000)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create("http://ip-api.com/json/");
            
                if(proxy != null) webRequest.Proxy = new WebProxy(proxy, true);
                webRequest.Timeout = timeOut;
                webRequest.ReadWriteTimeout = timeOut;

                var response = (HttpWebResponse) webRequest.GetResponse();
                var streamReader = new StreamReader(response.GetResponseStream());

                return Regex.Match(streamReader.ReadToEnd(), @"query"":""(.*?)""}").Groups[1].Value;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}