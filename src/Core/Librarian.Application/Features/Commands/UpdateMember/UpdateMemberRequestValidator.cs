using FluentValidation;
using Librarian.Application.Features.Member.Commands._Shared;
using Librarian.Application.Features.Member.Commands.UpdateMember;

namespace Librarian.Application.Features.Commands.UpdateMember;

public class UpdateMemberRequestValidator : AbstractValidator<UpdateMemberRequest>
{
    public UpdateMemberRequestValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(1);

        Include(new BaseMemberRequestValidator());
    }
}
