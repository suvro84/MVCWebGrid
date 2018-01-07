using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace MvcWebGrid.Models.Data
{
	public interface ICacheProvider
	{
       // object Get(string key);
       string Get(string key);
		void Set(string key, object data, int cacheTime);
		bool IsSet(string key);
		void Invalidate(string key);
	}

	public class DefaultCacheProvider : ICacheProvider
	{
		private ObjectCache Cache { get { return MemoryCache.Default; } }

        //public object Get(string key)
        //{
        //    return Cache[key];
        //}
        public string Get(string key)
        {

            //if (HttpContext.Current == null)
            //{
            //    return null;
            //}


            if (HttpContext.Current.Cache[key] == null)
            {
                return null;
            }
            else
            {

                return HttpContext.Current.Cache[key].ToString();
            }
        }

		public void Set(string key, object data, int cacheTime)
		{
			CacheItemPolicy policy = new CacheItemPolicy();
			policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);

			Cache.Add(new CacheItem(key, data), policy);
		}

		public bool IsSet(string key)
		{
			return (Cache[key] != null);
		}

		public void Invalidate(string key)
		{
			Cache.Remove(key);
		}
	}
}