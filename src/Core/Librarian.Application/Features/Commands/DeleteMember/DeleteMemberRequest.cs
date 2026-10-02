using MediatR;

namespace Librarian.Application.Features.Member.Commands.DeleteMember;

public record DeleteMemberRequest(int id) : IRequest<Unit>;
