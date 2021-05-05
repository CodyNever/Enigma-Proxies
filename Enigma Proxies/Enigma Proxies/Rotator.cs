using System;
using System.Collections.Generic;

namespace Enigma_Proxies
{
    public class Rotator
    {
        private readonly List<ProxyBase> _proxies;
        public Rotator(int id, List<ProxyBase> proxies, int maxUsages = 10)
        {
            Id = id;
            _proxies = proxies;
            RotatorMaxUsages = maxUsages;
        }

        public int Length => _proxies.Count;
        public int Id;
        public int RotatorMaxUsages;
        
        
        private int _currentProxyId = 0;
        private int _rotatorUsages;
        
        public ProxyBase GetProxy()
        {
            _rotatorUsages++;
            if (_rotatorUsages > RotatorMaxUsages)
            {
                UpdateRotator();
                _rotatorUsages = 1;
            }
            if (_proxies.Count == 0) return new ProxyBase("");

            var p = _proxies[_currentProxyId];
            _currentProxyId++;
            if (_currentProxyId >= _proxies.Count) _currentProxyId = 0;
            return p;
        }
        
        public ProxyBase[] GetProxies(int count)
        {
            var p = new List<ProxyBase>();
            for (var i = 0; i < count; i++) p.Add(GetProxy());
            return p.ToArray();
        }


        public void UpdateRotator()
        {
            // TODO Create rotator proxies updating
            Console.WriteLine("Update rotator!");
        }
    }
}