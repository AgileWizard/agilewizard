using StructureMap.Configuration.DSL;

namespace AgileWizard.Domain
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            Scan(x => 
            { 
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
        }
    }
}
