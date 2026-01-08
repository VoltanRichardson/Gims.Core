namespace Gims.Core.Domain.Dms;

public class Document
{
    public Guid DocumentId { get; private set; } = Guid.NewGuid();

    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Foreign key to DocumentType
    public Guid DocumentTypeId { get; private set; }
    public DocumentType Type { get; private set; }

    // Versions of this document
    private readonly List<DocumentVersion> _versions = new();
    public IReadOnlyCollection<DocumentVersion> Versions => _versions.AsReadOnly();

    // Tags for classification
    private readonly List<DocumentTag> _tags = new();
    public IReadOnlyCollection<DocumentTag> Tags => _tags.AsReadOnly();

    private Document() { } // EF Core

    public Document(string title, Guid documentTypeId)
    {
        Title = title;
        DocumentTypeId = documentTypeId;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddVersion(DocumentVersion version)
    {
        if (version == null) throw new ArgumentNullException(nameof(version));
        _versions.Add(version);
    }

    public void AddTag(DocumentTag tag)
    {
        if (tag == null) throw new ArgumentNullException(nameof(tag));
        _tags.Add(tag);
    }
}