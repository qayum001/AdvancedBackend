using Backend.Application.Data;
using MediatR;
using Backend.Domain.Entity.Delivery;

namespace Backend.Application.Features.Menues.Commands;

public record class CreateMenuCommand : IRequest
{
    public Guid CreatedBy { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid RestaurantId { get; set; }
}

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMenuCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var restaurant = _context.Restaurants.FirstOrDefault(e => e.Id == request.RestaurantId)
            ?? throw new NullReferenceException("Restaurant not found");

        var menu = new Menu(request.CreatedBy, request.Name, restaurant, restaurant.Id);

        await _context.Menues.AddAsync(menu, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}