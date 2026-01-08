namespace Gims.Core.Domain.Dms;

public interface IDocumentStorageProvider
{
    Task<string> SaveAsync(Stream fileStream, string fileName, string contentType);
    Task<Stream> GetAsync(string storagePath);
    Task DeleteAsync(string storagePath);
}