using AutoMapper;
using Librarian.Application.Contracts.Email;
using Librarian.Application.Contracts.Persistence;
using Librarian.Application.Exceptions;
using MediatR;

namespace Librarian.Application.Features.Member.Commands.CreateMember;

public class CreateMemberRequestHandler : IRequestHandler<CreateMemberRequest, int>
{
    private readonly IMapper _mapper;
    private readonly IMemberRepository _repository;
    private readonly IEmailSender _emailSender;

    public CreateMemberRequestHandler(IMapper mapper, IMemberRepository repository, IEmailSender emailSender)
    {
        _mapper = mapper;
        _repository = repository;
        _emailSender = emailSender;
    }

    public async Task<int> Handle(CreateMemberRequest request, CancellationToken cancellationToken)
    {
        var validation = await new CreateMemberRequestValidator(_mapper, _repository).ValidateAsync(request);
        if (!validation.IsValid)
            throw new BadRequestException("One or more validation errors occurred.", validation.ToDictionary());

        var entity = _mapper.Map<Domain.Member>(request);

        entity.CreatedAt = DateTime.Now;

        await _repository.CreateAsync(entity);
        try
        {
            await _emailSender.SendEmail(new Models.Email.EmailMessage()
            {
                To = entity.Email,
                Subject = "Welcome to the library",
                Body = $"Hello {entity.FirstName} {entity.LastName}, welcome to the library"
            });
        }
        catch (Exception ex)
        {
            new SmtpServerException(ex, entity.Email, "Welcome Message");
        }

        return entity.Id;
    }
}
