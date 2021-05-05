namespace Enigma_Proxies.ProxyRoot
{
    public class ProxyBase
    {
        public ProxyBase(string proxy, ProxyType t) : this(proxy, t, ProxyAnonymity.Unknown)
        {
        }

        public ProxyBase(string proxy, ProxyAnonymity a) : this(proxy, ProxyType.Unknown, a)
        {
        }

        public ProxyBase(string proxy, ProxyType t = ProxyType.Unknown, ProxyAnonymity a = ProxyAnonymity.Unknown)
        {
            Proxy = proxy;
            Type = t;
            Anonymity = a;
        }


        public ProxyType Type;
        public ProxyAnonymity Anonymity;
        public string Proxy;
    }
}