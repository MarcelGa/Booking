using AppoitmentScheduling.Domain.Dtos;
using CommonDomain.CQRS;
using CommonDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppoitmentScheduling.Domain.AppServices
{
    public sealed class GetStoreScheduleQuery : IQuery<ScheduleDto>
    {
        private readonly Guid storeId;
        private readonly DateTimeRange dateTimeRange;

        public GetStoreScheduleQuery(Guid storeId, DateTimeRange dateTimeRange)
        {
            this.storeId = storeId;
            this.dateTimeRange = dateTimeRange;
        }

        internal sealed class GetStoreScheduleQueryHandler : IQueryHandler<GetStoreScheduleQuery, ScheduleDto>
        {
            private readonly IProcedureScheduleRepository procedureScheduleRepository;

            public GetStoreScheduleQueryHandler(IProcedureScheduleRepository procedureScheduleRepository)
            {
                this.procedureScheduleRepository = procedureScheduleRepository;
            }

            public async Task<Result<ScheduleDto>> Handle(GetStoreScheduleQuery query)
            {
                var schedule = await procedureScheduleRepository.GetSchedule(query.storeId, query.dateTimeRange);

                throw new NotImplementedException();
            }
        }
    }
}
