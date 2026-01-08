namespace Gims.Core.Domain.Dms;

public class DocumentLink
{
    public Guid DocumentLinkId { get; private set; } = Guid.NewGuid();

    public Guid DocumentId { get; private set; }
    public Document Document { get; private set; }

    // Generic linking
    public string EntityType { get; private set; } // e.g., "Policy", "Claim"
    public Guid EntityId { get; private set; }

    private DocumentLink() { } // EF

    public DocumentLink(Document document, string entityType, Guid entityId)
    {
        Document = document;
        DocumentId = document.DocumentId;
        EntityType = entityType;
        EntityId = entityId;
    }
}