using System;

namespace LunchAndLearn.Application.Common.Services
{
    public interface IDateTime
    {
        public DateTime Now { get; }
    }
}