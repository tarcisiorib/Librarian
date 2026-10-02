using AutoMapper;
using Librarian.Application.Contracts.Persistence;
using Librarian.Application.Exceptions;
using Librarian.Application.Features.Commands.UpdateMember;
using MediatR;

namespace Librarian.Application.Features.Member.Commands.UpdateMember;

public class UpdateMemberRequestHandler : IRequestHandler<UpdateMemberRequest, Unit>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _repository;

    public UpdateMemberRequestHandler(IMapper mapper, IMemberRepository memberRepository)
    {
        _mapper = mapper;
        _repository = memberRepository;
    }

    public async Task<Unit> Handle(UpdateMemberRequest request, CancellationToken cancellationToken)
    {
        var validation = await new UpdateMemberRequestValidator().ValidateAsync(request);
        if (validation.Errors.Any())
            throw new BadRequestException("Something went wrong.", validation.ToDictionary());

        var existingMember = await _repository.GetByIdAsync(request.Id);

        if (existingMember == null)
            throw new NotFoundException(nameof(Domain.Member), request.Id.ToString());

        _mapper.Map(request, existingMember);

        await _repository.UpdateAsync(existingMember);

        return Unit.Value;
    }
}
