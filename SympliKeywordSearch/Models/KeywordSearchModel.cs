using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SympliKeywordSearch.Models
{
    public class KeywordSearchModel
    {
        [Required(ErrorMessage = "The field Keyword is required")]
        public string Keywords { get; set; }
        [Required(ErrorMessage = "The field URL is required")]
        public string URL { get; set; }
        public string Result { get; set; }

        [DefaultValue(false)]
        public bool IsShowResult { get; set; }
    }
}