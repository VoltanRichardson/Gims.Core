namespace Gims.Core.Domain.Reinsurance;

using Gims.Core.Domain.Party;

public class Treaty
{
    public Guid TreatyId { get; private set; } = Guid.NewGuid();

    public string TreatyNumber { get; private set; }
    public string Name { get; private set; }

    public TreatyType Type { get; private set; }

    // Capacity and retention depend on treaty type
    public decimal? Capacity { get; private set; }
    public decimal? Retention { get; private set; }
    public decimal? Participation { get; private set; } // % ceded

    public DateTime EffectiveFrom { get; private set; }
    public DateTime EffectiveTo { get; private set; }

    // Explicit join entity for reinsurers
    private readonly List<TreatyReinsurer> _treatyReinsurers = new();
    public IReadOnlyCollection<TreatyReinsurer> TreatyReinsurers => _treatyReinsurers.AsReadOnly();

    private Treaty() { } // EF Core

    public Treaty(
        string treatyNumber,
        string name,
        TreatyType type,
        DateTime effectiveFrom,
        DateTime effectiveTo,
        decimal? capacity = null,
        decimal? retention = null,
        decimal? participation = null)
    {
        TreatyNumber = treatyNumber;
        Name = name;
        Type = type;
        EffectiveFrom = effectiveFrom;
        EffectiveTo = effectiveTo;
        Capacity = capacity;
        Retention = retention;
        Participation = participation;
    }

    public void AddReinsurer(Reinsurer reinsurer, decimal? share = null, bool isLead = false)
    {
        if (reinsurer == null)
            throw new ArgumentNullException(nameof(reinsurer));

        _treatyReinsurers.Add(new TreatyReinsurer(TreatyId, reinsurer.ReinsurerId, share, isLead));
    }

    public void UpdateCapacity(decimal? capacity) => Capacity = capacity;
    public void UpdateRetention(decimal? retention) => Retention = retention;
    public void UpdateParticipation(decimal? participation) => Participation = participation;

    public bool IsActiveOn(DateTime date)
        => date >= EffectiveFrom && date <= EffectiveTo;
}