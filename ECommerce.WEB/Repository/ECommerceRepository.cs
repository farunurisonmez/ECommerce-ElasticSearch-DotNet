using ECommerce.API.Models.ECommerceModel;
using ECommerce.WEB.ViewModels;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;


namespace ECommerce.WEB.Repositories
{
    public class ECommerceRepository
    {
        private readonly ElasticsearchClient _elasticSearchClient;

        public ECommerceRepository(ElasticsearchClient elasticSearchClient)
        {
            _elasticSearchClient = elasticSearchClient;
        }

        private const string IndexName = "kibana_sample_data_ecommerce";

        public async Task<(List<ECommerceModel> list, long count)> SearchAsync(ECommerceSearchViewModel searchViewModel, int page, int pageSize)
        {
            //Total Count


            List<Action<QueryDescriptor<ECommerceModel>>> listQuery = new();

            if (searchViewModel is null)
            {

                listQuery.Add(q => q.MatchAll(_ => {}));
                return await CalculateResultSet(page, pageSize, listQuery);

            }


            if (!string.IsNullOrEmpty(searchViewModel.Category))
            {
                listQuery.Add((q) => q.Match(m => m.
                Field(f => f.Category)
                .Query(searchViewModel.Category)
                ));
            }

            if (!string.IsNullOrEmpty(searchViewModel.CustomerFullName))
            {
                listQuery.Add((q) => q.Match(m => m.
                Field(f => f.CustomerFullName)
                .Query(searchViewModel.CustomerFullName)
                ));
            }

            if (searchViewModel.OrderDateStart.HasValue)
            {

                listQuery.Add((q) => q
                    .Range(r => r
                        .DateRange(dr => dr
                            .Field(f => f.OrderDate)
                            .Gte(searchViewModel.OrderDateStart.Value))));
            }

            if (searchViewModel.OrderDateEnd.HasValue)
            {

                listQuery.Add((q) => q
                    .Range(r => r
                        .DateRange(dr => dr
                            .Field(f => f.OrderDate)
                            .Lte(searchViewModel.OrderDateEnd.Value))));
            }

            if (!string.IsNullOrEmpty(searchViewModel.Gender))
            {
                listQuery.Add(q => q.Term(t => t.Field(f => f.Gender).Value(searchViewModel.Gender).CaseInsensitive()));
            }

            if (listQuery.Any())
            {
                listQuery.Add(q => q.MatchAll(_ => {}));  // Correct MatchAll syntax
            }

            return await CalculateResultSet(page, pageSize, listQuery);

        }

        private async Task<(List<ECommerceModel> list, long count)> CalculateResultSet(int page, int pageSize, List<Action<QueryDescriptor<ECommerceModel>>> listQuery)
        {

            var pageForm = (page - 1) * pageSize;

            var result = await _elasticSearchClient.SearchAsync<ECommerceModel>(s => s.Index(IndexName)
            .Size(pageSize).From(pageForm).Query(q => q
            .Bool(b => b
            .Must(listQuery.ToArray()))));

            foreach (var hit in result.Hits) hit.Source.Id = hit.Id;

            return (list: result.Documents.ToList(), result.Total);
        }
    }
}

