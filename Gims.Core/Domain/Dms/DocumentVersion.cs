namespace Gims.Core.Domain.Dms;

public class DocumentVersion
{
    public Guid DocumentVersionId { get; private set; } = Guid.NewGuid();

    public Guid DocumentId { get; private set; }
    public Document Document { get; private set; }   // <-- navigation back

    public int VersionNumber { get; private set; }
    public string StoragePath { get; private set; }
    public long FileSize { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private DocumentVersion() { } // EF Core

    public DocumentVersion(Guid documentId, int versionNumber, string storagePath, long fileSize)
    {
        DocumentId = documentId;
        VersionNumber = versionNumber;
        StoragePath = storagePath;
        FileSize = fileSize;
    }
}