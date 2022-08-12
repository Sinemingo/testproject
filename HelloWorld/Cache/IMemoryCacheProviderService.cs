using HelloWorld.Business.Dtos;

namespace HelloWorld.Cache
{
    public interface IMemoryCacheProviderService
    {
        List<PersonDto> GetPersonList();
    }
}
