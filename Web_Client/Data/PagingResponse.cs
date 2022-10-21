

using Model.PageIndex;

namespace Web_Client.Data
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public MetaDataIndex MetaData { get; set; }
    }
}
