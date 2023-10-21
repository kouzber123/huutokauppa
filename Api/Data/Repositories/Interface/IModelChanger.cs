using Api.Data.DTO;
using Api.Data.Models;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Models;

namespace Api.Data.Repositories.Interface
{
    public interface IModelChanger
    {
        List<BidDto> GetBidListDto(List<Bid> bids);
        List<MessageDto> GetMessageListDto(List<Message> messages);
        List<PhotoDto> GetPhotoListDto(List<Photo> photos);

        ProductDto GetProductDto(Product product);

    }
}
