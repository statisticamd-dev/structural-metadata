using System;
using Presentation.Application.Common.Interfaces;

namespace Presentation.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public int CurrentYear => DateTime.Now.Year;
    }
}