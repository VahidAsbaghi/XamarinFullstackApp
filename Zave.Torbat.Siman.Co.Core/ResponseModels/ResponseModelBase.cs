namespace Zave.Torbat.Siman.Co.Core.ResponseModels
{
    public class ResponseModelBase
    {
        public bool IsSuccessful { get; set; }
        public string Description { get; set; }
        public int HtmlResult { get; set; }
    }
}
