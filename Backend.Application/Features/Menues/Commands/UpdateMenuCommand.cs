using Backend.Application.Data;
using MediatR;

namespace Backend.Application.Features.Menues.Commands;

public record class UpdateMenuCommand : IRequest
{
    public Guid UpdatedBy { get; set; }
    public string NewName { get; set; } = string.Empty;
    public Guid MenuId { get; set; }
}

public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMenuCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = _context.Menues.FirstOrDefault(e => e.Id == request.MenuId)
            ?? throw new NullReferenceException("Menu not found");

        await menu.Rename(request.NewName, request.UpdatedBy);

        await _context.SaveChangesAsync(cancellationToken);
    }
}