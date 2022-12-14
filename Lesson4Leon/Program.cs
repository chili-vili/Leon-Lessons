namespace Lesson4Leon
{
    internal class SimpleGenericCache<T>
    {
        private readonly Dictionary<string, CachedValue<T?>> _cache = new();

        internal void Store(string key, T value, int timeout=30)
        {
            var cachedValue = new CachedValue<T?> { Value = value, CreationTime = DateTime.Now, Timeout=timeout };
            _cache[key] = cachedValue;
        }

        internal T? Fetch(string key)
        {
            if (_cache.TryGetValue(key, out var cachedValue))
            {
                if ((DateTime.Now - cachedValue.CreationTime).TotalSeconds < cachedValue.Timeout)
                {
                    return cachedValue.Value;
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }
    }

}