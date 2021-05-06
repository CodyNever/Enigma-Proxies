using System;
using System.Collections.Generic;
using Enigma_Proxies.Utilities;

namespace Enigma_Proxies
{
    public static class EnigmaProxies
    { 
        private static List<Rotator> _rotators = new List<Rotator>();


        public static ProxyBase GetProxy()
        {
            return _rotators.Count == 0 ? new ProxyBase("") : _rotators[0].GetProxy();
        }

        public static Rotator GetRotator(int id = 0)
        {
            if (_rotators.Count == 0) return null;
            return _rotators[EMath.Clamp(id, 0, _rotators.Count-1)];
        }
        
        public static Rotator CreateRotator(List<ProxyBase> proxies, int maxProxies = 10)
        {
            var id = _rotators.Count == 0 ? 0 : _rotators.Count - 1;
            var r = new Rotator(id, proxies, maxProxies);
            _rotators.Add(r);
            return r;
        }
    }
}