namespace Code.Infrastructure.Services
{
    public class AllServices
    {
        public static AllServices Container => _instance ?? (_instance = new AllServices());
        
        
        private static AllServices _instance;

        
        public TService RegisterSingle<TService>(TService implementation) where TService : IService => 
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}