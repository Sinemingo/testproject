using HelloWorld.Business.Dtos;
using HelloWorld.Business.Services.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace HelloWorld.Cache
{
    public class MemoryCacheProviderService : IMemoryCacheProviderService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IPersonService _personService;

        public MemoryCacheProviderService(IMemoryCache memoryCache,IPersonService personService)
        {
            _personService = personService;
            _memoryCache = memoryCache;
        }
        public List<PersonDto> GetPersonList()
        {
            var cacheKey = "personList";
            if (_memoryCache.TryGetValue(cacheKey,out List<PersonDto> cachePersonList))
            {
                return cachePersonList;
            }
            else
            {
                var personList = _personService.GetPersonList();
                _memoryCache.Set(cacheKey, personList,TimeSpan.FromSeconds(30));
                return personList;

            }
        }
    }
}
