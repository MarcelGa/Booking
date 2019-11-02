using AppoitmentScheduling.Domain.Dtos;
using CommonDomain.CQRS;
using CommonDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppoitmentScheduling.Domain.AppServices
{
    public sealed class GetStoreScheduleQuery : IQuery<ScheduleDto>
    {
        private readonly int storeId;
        private readonly DateTimeRange dateTimeRange;

        public GetStoreScheduleQuery(int storeId, DateTimeRange dateTimeRange)
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

            public async Task<Result<ScheduleDto>> Handle(GetStoreScheduleQuery request, CancellationToken cancellationToken)
            {
                await Task.Delay(500);
                //var schedule = await procedureScheduleRepository.GetSchedule(query.storeId, query.dateTimeRange);
                var schedule = new ScheduleDto()
                {
                    Schedule = new StaffDto[] {
                        new StaffDto() {
                            Orders = new OrderDto[] {
                                new OrderDto() {
                                    Status = "Created"
                                }
                            }
                        }
                    }
                };

                return Result<ScheduleDto>.Ok(schedule);
            }
        }
    }
}
