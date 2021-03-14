using System.Net.Http;
using System.Text.RegularExpressions;

namespace SympliKeywordSearch.Service
{
    public static class KeywordSearchService
    {
        private const string URL_PATTERN = @"q=https://.*?><h3";
        private const string GOOGLE_API_SEARCH_LINK = "https://www.google.com/search?q={0}&start={1}";
        private const int GOOGLE_DEFAULT_RESULT_COUNT_PER_PAGE = 10;
        public const string ZERO_RESULT = "0";

        public static string Search(string keyword, string URL)
        {
            var searchIndexResult = string.Empty;

            var formattedKeyword = FormatKeyword(keyword);

            using (var client = new HttpClient())
            {
                for (int page = 0; page < GOOGLE_DEFAULT_RESULT_COUNT_PER_PAGE; page++)
                {
                    var response = client.GetStringAsync(string.Format(GOOGLE_API_SEARCH_LINK, formattedKeyword, page)).Result;

                    var responseMatches = Regex.Matches(response, URL_PATTERN);
                    if (responseMatches == null)
                        continue;

                    for (int i = 0; i < (responseMatches.Count); i++)
                    {
                        if (!responseMatches[i].ToString().Contains(URL))
                            continue;

                        searchIndexResult = searchIndexResult + ((GOOGLE_DEFAULT_RESULT_COUNT_PER_PAGE * page) + i + 1) + ", ";
                    }
                }
            }

            return searchIndexResult.Length > 0 ? searchIndexResult.Trim().Substring(0, searchIndexResult.Trim().Length - 1) : ZERO_RESULT;
        }

        private static string FormatKeyword(string keyword)
        {
            return keyword.Trim().Replace(" ", "+");
        }
    }
}