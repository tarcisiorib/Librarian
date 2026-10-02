using Librarian.Application.Contracts.Persistence;
using Librarian.Application.Exceptions;
using MediatR;

namespace Librarian.Application.Features.Member.Commands.DeleteMember;

public class DeleteMemberRequestHandler : IRequestHandler<DeleteMemberRequest, Unit>
{
    private readonly IMemberRepository _repository;

    public DeleteMemberRequestHandler(IMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteMemberRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.id);

        if (item == null)
            throw new NotFoundException(nameof(item), request.id.ToString());

        await _repository.DeleteAsync(item);

        return Unit.Value;
    }
}
