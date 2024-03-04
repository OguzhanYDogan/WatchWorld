using Web.Models;

namespace Web.Interfaces
{
    public interface IHomeViewModelServise
    {
        Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId);
    }
}
