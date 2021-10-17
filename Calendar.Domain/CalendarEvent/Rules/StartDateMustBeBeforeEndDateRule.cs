using Domain.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.CalendarEvent.Rules
{
    public class StartDateMustBeBeforeEndDateRule : IBusinessRule
    {
        private readonly DateTime startDate;
        private readonly DateTime endDate;

        public StartDateMustBeBeforeEndDateRule(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public string Message => "Start date can't be after end date";

        public bool IsBroken()=>this.startDate<this.endDate;
        
    }
}
