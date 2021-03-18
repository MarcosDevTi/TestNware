namespace TestNware.Domain.Pagination
{
    public class Paging<T>
    {
        public Paging() : this(0, int.MaxValue) { }

        public Paging(int skip, int top)
        {
            Skip = skip;
            Top = top;
        }

        public int Skip { get; set; }

        public int Top { get; set; }
    }
}
