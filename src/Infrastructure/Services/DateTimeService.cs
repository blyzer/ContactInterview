using ContactInterview.Application.Common.Interfaces;
using System;

namespace ContactInterview.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
