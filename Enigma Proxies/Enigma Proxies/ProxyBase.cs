﻿namespace Enigma_Proxies
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
        public readonly string Proxy;
        
        public  string Country => ProxyChecker.GetCountry(this);
        public bool Working => ProxyChecker.CheckProxy(this);
    }
}