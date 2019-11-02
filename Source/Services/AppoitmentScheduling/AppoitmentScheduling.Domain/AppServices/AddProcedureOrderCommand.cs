using CommonDomain.CQRS;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppoitmentScheduling.Domain.AppServices
{
    public sealed class AddProcedureOrderCommand : ICommand
    {
        public Guid StoreId { get;}
        public Guid ProcedureId { get; }
        public Guid StaffId { get; }
        public Guid ClientId { get; }
        public DateTime Start { get; }

        public AddProcedureOrderCommand(Guid storeId, Guid procedureId, Guid staffId, Guid clientId, DateTime start)
        {
            StoreId = storeId;
            ProcedureId = procedureId;
            StaffId = staffId;
            ClientId = clientId;
            Start = start;
        }

        internal sealed class AddProcedureCommandHandler : ICommandHandler<AddProcedureOrderCommand>
        {
            public AddProcedureCommandHandler(IProcedureScheduleRepository procedureScheduleRepository)
            {

            }
            
            public Task<Result> Handle(AddProcedureOrderCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
