public class DocumentType
{
    public Guid DocumentTypeId { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }
    public string? Description { get; private set; }

    private DocumentType() { } // EF Core

    public DocumentType(string name, string? description = null)
    {
        Name = name;
        Description = description;
    }
}