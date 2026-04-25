using Gims.UI.Registry;

namespace Gims.UI.Services
{
    public class ModuleResolver : IModuleResolver
    {
        public ModuleRegistration Resolve(Guid id)
            => ModuleRegistry.Resolve(id);
    }
}