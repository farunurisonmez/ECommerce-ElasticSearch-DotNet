namespace ECommerce.WEB.ViewModels
{
    public class SearchPageViewModel
    {
        public long TotalCount { get; set; }
        public int Page {  get; set; }
        public int PageSize { get; set; }
        public long PageLinkCount { get; set; }
        public List<ECommerceViewModel> List { get; set; }
        public ECommerceSearchViewModel SearchViewModel { get; set; }

        public string CreatePageUrl(HttpRequest request, int page, int pageSize)
        {
            var currentUrl = new Uri($"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}").AbsoluteUri;
            if(currentUrl.Contains("page", StringComparison.OrdinalIgnoreCase))
            {
                currentUrl = currentUrl.Replace($"Page={Page}", $"Page={page}", StringComparison.OrdinalIgnoreCase);
                currentUrl = currentUrl.Replace($"PageSize={PageSize}", $"Page={pageSize}", StringComparison.OrdinalIgnoreCase);
            
            } 
            else {
                currentUrl = $"{currentUrl}?Page={page}";
                currentUrl = $"{currentUrl}?PageSize={pageSize}";
            }

            return currentUrl;
        }
    }
}
