using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeTwo.Models
{
    /// <summary>
    /// Factory to create and maintain a cache singleton
    /// </summary>
    public static class OptionsCacheFactory
    {
        private static OptionsCache cache;
        public static OptionsCache GetCache()
        {
            if(cache != null)
            {
                return cache;
            }

            cache = new OptionsCache();
            return cache;
        }

        public static void ResetCache()
        {
            cache = new OptionsCache();
        }
    }
}