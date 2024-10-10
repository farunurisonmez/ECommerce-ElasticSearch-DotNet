using ECommerce.API.Models.ECommerceModel;
using ECommerce.WEB.ViewModels;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;


namespace ECommerce.WEB.Repositories
{
    public class ECommerceRepository
    {
        private readonly ElasticsearchClient _elasticsearchClient;

        public ECommerceRepository(ElasticsearchClient elasticsearchClient)
        {
            this._elasticsearchClient = elasticsearchClient;
        }

        private const string IndexName = "kibana_sample_data_ecommerce";
        public async Task<(List<ECommerceModel> list, long count)> SearchAsync(ECommerceSearchViewModel searchViewModel, int page, int pageSize)
        {
            //Total Count


            List<Action<QueryDescriptor<ECommerceModel>>> listQuery = new();

            if (!string.IsNullOrEmpty(searchViewModel.Category))
            {
                listQuery.Add((q) => q.Match(m => m.
                Field(f => f.Category)
                .Query(searchViewModel.Category)
                ));
            }

            var pageForm = (page - 1) * pageSize;

            var result = await _elasticsearchClient.SearchAsync<ECommerceModel>(s => s.Index(IndexName)
            .Size(pageSize).From(pageForm).Query(q => q
            .Bool(b => b
            .Must(listQuery.ToArray()))));

            foreach (var hit in result.Hits) hit.Source.Id = hit.Id;
            return (list: result.Documents.ToList(), result.Total);
        }
    }
}

