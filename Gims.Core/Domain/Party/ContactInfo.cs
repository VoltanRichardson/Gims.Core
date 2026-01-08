namespace Gims.Core.Domain.Party;

public record ContactInfo(
    string Email,
    string? Phone = null
);