using ECommerce.WEB.Repositories;
using ECommerce.WEB.ViewModels;

namespace ECommerce.WEB.Services
{
    public class ECommerceService
    {
        private readonly ECommerceRepository _repository;

        public ECommerceService(ECommerceRepository repository)
        {
            _repository = repository;
        }

        public async Task<(List<ECommerceViewModel>, long totalCount, long pageLinkCount)> SearchAsync(ECommerceSearchViewModel searchModel, int page, int pageSize)
        {
            var (eCommerceList, totalCount) = await _repository.SearchAsync(searchModel, page, pageSize);

            var pageLinkCountCalc = totalCount % pageSize;
            long pageLinkCount = pageLinkCountCalc == 0 ? totalCount / pageSize : (totalCount / pageSize) + 1;

            var eCommerceListViewModel = eCommerceList.Select(x => new ECommerceViewModel()
            {
                Id = x.Id,
                Category = String.Join(",",x.Category),

            }).ToList();

            return (eCommerceListViewModel, totalCount, pageLinkCount);
        } 
    }
}
