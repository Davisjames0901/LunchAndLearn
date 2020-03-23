using System;

namespace LunchAndLearn.Application.Common.Services
{
    public class RealDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}