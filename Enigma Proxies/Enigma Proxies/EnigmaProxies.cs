using System.Collections.Generic;

namespace Enigma_Proxies
{
    public static class EnigmaProxies
    {
        private static List<Rotator> _rotators = new List<Rotator>();


        public static ProxyBase GetProxy()
        {
            return _rotators.Count == 0 ? new ProxyBase("") : _rotators[0].GetProxy();
        }
        
        public static Rotator GetRotator(int id)
        {
            return _rotators[id];
        }
        
        public static Rotator CreateRotator(List<ProxyBase> proxies)
        {
            if (_rotators.Count == 0) return CreateRotator(0, proxies);
            return CreateRotator(_rotators.Count+1, proxies);
        }

        public static Rotator CreateRotator(List<ProxyBase> proxies, int maxProxies)
        {
            if (_rotators.Count == 0) return CreateRotator(0, proxies, maxProxies);
            return CreateRotator(_rotators.Count+1, proxies, maxProxies);
        }

        public static Rotator CreateRotator(int id, List<ProxyBase> proxies)
        {
            var rotator = new Rotator(id, proxies);
            _rotators[id] = rotator;
            return rotator;
        }
        
        public static Rotator CreateRotator(int id, List<ProxyBase> proxies, int maxProxies)
        {
            var rotator = new Rotator(id, proxies, maxProxies);
            _rotators[id] = rotator;
            return rotator;
        }
    }
}