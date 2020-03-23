using LunchAndLearn.Application.Common.Enum;
using LunchAndLearn.Domain.Enum;

namespace LunchAndLearn.Application.Common.Abstract
{
    public abstract class Pagination
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public PageSize CurrentPageSize { get; set; }
    }
}