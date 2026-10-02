using Librarian.Application.Features.Member.Commands._Shared;
using MediatR;

namespace Librarian.Application.Features.Member.Commands.CreateMember;

public class CreateMemberRequest : BaseMemberRequest, IRequest<int>
{
}