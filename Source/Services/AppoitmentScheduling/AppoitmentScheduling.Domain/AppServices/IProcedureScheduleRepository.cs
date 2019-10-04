using AppoitmentScheduling.Domain.Schedules;
using CommonInfrastructure;
using System;

namespace AppoitmentScheduling.Domain.AppServices
{
    public interface IProcedureScheduleRepository : IRepository<ProcedureSchedule, Guid>
    {
    }
}