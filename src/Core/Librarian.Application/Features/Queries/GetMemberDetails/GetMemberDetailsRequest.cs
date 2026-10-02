using MediatR;

namespace Librarian.Application.Features.Member.Queries.GetMemberDetails;

public record GetMemberDetailsRequest(int Id) : IRequest<MemberDetailsDto>;
