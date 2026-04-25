namespace Gims.App.Modules;

public static class BusinessToUiMap
{
    private static readonly Dictionary<Guid, string> _map = new()
    {
        { Guid.Parse("44444444-4444-4444-4444-444444444444"), "billing" },
        { Guid.Parse("22222222-2222-2222-2222-222222222222"), "customer" },
        { Guid.Parse("33333333-3333-3333-3333-333333333333"), "policy" },
        { Guid.Parse("55555555-5555-5555-5555-555555555555"), "claims" },
        { Guid.Parse("66666666-6666-6666-6666-666666666666"), "docman" },
        { Guid.Parse("77777777-7777-7777-7777-777777777777"), "report" },
        { Guid.Parse("11111111-1111-1111-1111-111111111111"), "sysman" }
    };

    public static string? ToUiCode(Guid businessModuleId)
        => _map.TryGetValue(businessModuleId, out var code) ? code : null;
}