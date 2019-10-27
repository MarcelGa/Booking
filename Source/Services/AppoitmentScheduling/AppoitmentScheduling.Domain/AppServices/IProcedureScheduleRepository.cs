using AppoitmentScheduling.Domain.Schedules;
using CommonDomain.ValueObjects;
using CommonInfrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppoitmentScheduling.Domain.AppServices
{
    internal interface IProcedureScheduleRepository : IRepository<ProcedureSchedule, Guid>
    {
        Task<ProcedureSchedule> GetSchedule(Guid storeId, DateTimeRange dateTimeRange);
    }
}