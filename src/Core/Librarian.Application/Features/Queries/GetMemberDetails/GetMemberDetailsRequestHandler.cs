using AutoMapper;
using Librarian.Application.Contracts.Persistence;
using MediatR;

namespace Librarian.Application.Features.Member.Queries.GetMemberDetails;

public class GetMemberDetailsRequestHandler : IRequestHandler<GetMemberDetailsRequest, MemberDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _repository;

    public GetMemberDetailsRequestHandler(IMapper mapper, IMemberRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<MemberDetailsDto> Handle(GetMemberDetailsRequest request, CancellationToken cancellationToken)
    {
        var member = await _repository.GetByIdAsync(request.Id);

        var result = _mapper.Map<MemberDetailsDto>(member);

        return result;
    }
}
