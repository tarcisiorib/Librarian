using AutoMapper;
using FluentValidation;
using Librarian.Application.Contracts.Persistence;
using Librarian.Application.Features.Member.Commands._Shared;

namespace Librarian.Application.Features.Member.Commands.CreateMember;

public class CreateMemberRequestValidator : AbstractValidator<CreateMemberRequest>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _repository;

    public CreateMemberRequestValidator(IMapper mapper, IMemberRepository repository)
    {
        _mapper = mapper;
        _repository = repository;

        Include(new BaseMemberRequestValidator());
        
        RuleFor(x => x)
            .MustAsync(UniqueMemeber).WithMessage("The member already exists.");
    }

    private async Task<bool> UniqueMemeber(CreateMemberRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Member>(request);
        return await _repository.IsUniqueMemberAsync(entity);
    }
}
