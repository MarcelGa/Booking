using CommonDomain.CQRS;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppoitmentScheduling.Domain.AppServices
{
    public sealed class CreateProcedureOrderCommand : ICommand
    {
        public Guid StoreId { get;}
        public Guid ProcedureId { get; }
        public Guid StaffId { get; }
        public Guid ClientId { get; }
        public DateTime Start { get; }

        public CreateProcedureOrderCommand(Guid storeId, Guid procedureId, Guid staffId, Guid clientId, DateTime start)
        {
            StoreId = storeId;
            ProcedureId = procedureId;
            StaffId = staffId;
            ClientId = clientId;
            Start = start;
        }

        internal sealed class CreateProcedureCommandHandler : ICommandHandler<CreateProcedureOrderCommand>
        {
            public CreateProcedureCommandHandler(IProcedureScheduleRepository procedureScheduleRepository)
            {

            }
            
            public Task<Result> Handle(CreateProcedureOrderCommand request, CancellationToken cancellationToken)
            {
                return Task.FromResult(Result.Ok());
            }
        }
    }
}
