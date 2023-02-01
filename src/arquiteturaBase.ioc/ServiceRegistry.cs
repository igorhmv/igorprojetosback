using StructureMap.Attributes;
using StructureMap.Configuration.DSL;

namespace arquiteturaBase.ioc
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            //ForRequestedType<IService>()
            //    .CacheBy(InstanceScope.PerRequest)
            //    .TheDefault.Is.OfConcreteType<Service>();
        }
    }
}
