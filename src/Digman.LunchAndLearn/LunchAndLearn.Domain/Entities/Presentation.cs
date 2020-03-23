using System.Collections.Generic;
using LunchAndLearn.Domain.Abstract;
using LunchAndLearn.Domain.Enum;

namespace LunchAndLearn.Domain.Entities
{
    public class Presentation : Auditable
    {
        public Presentation()
        {
            Comments = new List<Comment>();
            Votes = new List<Vote>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public List<Vote> Votes { get; set; }

        public List<Comment> Comments { get; set; }
        public PresentationState State { get; set; }
    }
}