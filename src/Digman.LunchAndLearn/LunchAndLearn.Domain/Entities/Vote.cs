using LunchAndLearn.Domain.Abstract;
using LunchAndLearn.Domain.Enum;

namespace LunchAndLearn.Domain.Entities
{
    public class Vote : Auditable
    {
        public int Id { get; set; }
        public VoteType Type { get; set; }
    }
}