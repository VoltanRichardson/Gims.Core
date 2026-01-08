namespace Gims.Core.Domain.Dms;

public class DocumentTag
{
    public Guid DocumentTagId { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }

    private readonly List<Document> _documents = new();
    public IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();

    private DocumentTag() { } // EF Core

    public DocumentTag(string name)
    {
        Name = name;
    }
}