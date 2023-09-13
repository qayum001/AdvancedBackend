using Backend.Application.Data;
using MediatR;

namespace Backend.Application.Features.Menues.Commands;
public record class DeleteMenuCommand : IRequest
{
    public Guid MenuId { get; set; }
}

public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteMenuCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = _context.Menues.FirstOrDefault(e => e.Id == request.MenuId)
            ?? throw new NullReferenceException("Menu not found");

        _context.Menues.Remove(menu);

        await _context.SaveChangesAsync(cancellationToken);
    }
}