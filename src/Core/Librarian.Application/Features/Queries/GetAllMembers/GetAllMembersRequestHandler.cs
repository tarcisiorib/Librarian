using AutoMapper;
using Librarian.Application.Contracts.Persistence;
using MediatR;

namespace Librarian.Application.Features.Member.Queries.GetAllMembers;

public class GetAllMembersRequestHandler : IRequestHandler<GetAllMembersRequest, IList<MemberDto>>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _repository;

    public GetAllMembersRequestHandler(IMapper mapper, IMemberRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<MemberDto>> Handle(GetAllMembersRequest request, CancellationToken cancellationToken)
    {
        var members = await _repository.GetAllAsync();

        var result = _mapper.Map<IList<MemberDto>>(members);

        return result;
    }
}
