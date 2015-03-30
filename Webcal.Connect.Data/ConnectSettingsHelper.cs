namespace Connect.Data
{
    using System;
    using System.Runtime.Caching;

    public static class ConnectSettingsHelper
    {
        private const string ConnectSettingsCacheKey = "ConnectSettingsCache";
        private static readonly ObjectCache _cache = new MemoryCache("ConnectSettingsCache");

        public static Settings GetSettings()
        {
            var cachedSettings = _cache.Get(ConnectSettingsCacheKey) as Settings;
            if (cachedSettings == null)
            {
                using (var context = new ConnectContext())
                {
                    cachedSettings = context.Settings.FirstOrDefault(c => c.Deleted == null) ?? new Settings();
                }

                _cache.Add(new CacheItem(ConnectSettingsCacheKey, cachedSettings), new CacheItemPolicy { SlidingExpiration = new TimeSpan(0, 30, 0) });
            }
            return cachedSettings;
        }
    }
}