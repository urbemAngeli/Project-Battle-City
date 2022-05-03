using Code.Infrastructure.Services;

namespace Code.Services.Map
{
    public interface IMapProvider : IService
    {
        void CreateMap();
    }
}