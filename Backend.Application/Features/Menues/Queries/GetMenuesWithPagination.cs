using MediatR;

namespace Backend.Application.Features.Menues.Queries;

public record class GetMenuesWithPagination : IRequest<>
{
    public Guid RestaurantId { get; }
    public int PageSize { get; }
    public int PageNumber { get; }
}

public class GetMenuWithPaginationHandler : IRequestHandler<GetMenuesWithPagination, >
{

}