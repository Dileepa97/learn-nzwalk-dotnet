using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadAsync(Image image);
    }
}
