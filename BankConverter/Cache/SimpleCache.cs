using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConverter.Cache
{
    public class SimpleCache<T>
    {
        Dictionary<DateTime, T> _cache = new Dictionary<DateTime, T>();


        public bool HasIt(DateTime key)
        {
            return _cache.ContainsKey(key);
        }

        public T Get(DateTime key)
        {
            
            return _cache[key]; 
        }

        public void Set(DateTime key,T value)
        {
            _cache[key] = value;
        }

        //Для отладки 
        public void GetAll()
        {
            foreach(KeyValuePair<DateTime,T> s in _cache)
            {
                System.Diagnostics.Debug.WriteLine(s.Key);
                
            }
            System.Diagnostics.Debug.WriteLine("-----");
        }
    }
}
