using Web.Models;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetBasketViewModelAsync();

        Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity);

        Task EmptyBasketAsync();

        Task RemoveItemAsync(int productId);

        Task<BasketViewModel> SetQuantitesAsync(Dictionary<int, int> quantites);

        Task TransferBasketAsync();

        Task CheckOutAsync(string street, string city, string? state, string country, string zipCode);
    }
}
