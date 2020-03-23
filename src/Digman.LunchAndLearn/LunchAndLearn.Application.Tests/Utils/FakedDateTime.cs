using System;
using LunchAndLearn.Application.Common.Services;

namespace LunchAndLearn.Application.Tests.Utils
{
    public class FakedDateTime : IDateTime
    {
        public FakedDateTime(DateTime fakeTime)
        {
            Now = fakeTime;
        }

        public DateTime Now { get; }
    }
}