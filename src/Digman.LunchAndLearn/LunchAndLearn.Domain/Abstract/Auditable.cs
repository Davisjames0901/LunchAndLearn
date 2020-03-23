using System;

namespace LunchAndLearn.Domain.Abstract
{
    public abstract class Auditable
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public int LastModifiedByUserId { get; set; }
    }
}