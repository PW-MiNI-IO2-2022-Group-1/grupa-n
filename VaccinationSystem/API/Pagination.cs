namespace API
{
    public class Pagination<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int CurrentRecords { get; set; }
        public int TotalRecords { get; set; }

        public Pagination(int pageNumber, int totalRecords, int currentRecords, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalRecords = totalRecords;
            CurrentRecords = currentRecords;
            TotalPage = (int)Math.Ceiling(TotalRecords / (double)pageSize);
        }

        public static (List<T> items, Pagination<T> pagination) ShrinkList(List<T> _items, int pageNumber, int pageSize)
        {
            List<T> items = _items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            Pagination<T> pagination = new Pagination<T>(pageNumber, _items.Count, items.Count, pageSize);
            return (items, pagination);
        }
    }
}