using Gims.UI.Registry;

namespace Gims.UI.Services;
public interface IModuleResolver
{
    ModuleRegistration Resolve(Guid id);
}