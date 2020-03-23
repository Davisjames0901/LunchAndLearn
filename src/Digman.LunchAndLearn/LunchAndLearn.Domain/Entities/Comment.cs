using System.Diagnostics;
using LunchAndLearn.Domain.Abstract;

namespace LunchAndLearn.Domain.Entities
{
    public class Comment : Auditable
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}