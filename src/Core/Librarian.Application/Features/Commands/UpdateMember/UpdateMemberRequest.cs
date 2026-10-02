using Librarian.Application.Features.Member.Commands._Shared;
using MediatR;

namespace Librarian.Application.Features.Member.Commands.UpdateMember;

public class UpdateMemberRequest : BaseMemberRequest, IRequest<Unit>
{
    public int Id { get; set; }
}
