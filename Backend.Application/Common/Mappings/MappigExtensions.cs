using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backend.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Common.Mappings;

public static class MappigExtensions
{
    public static Task<PaginatedList<IDestination>> PaginatedListAsync<IDestination>(this IQueryable<IDestination> queryeble, int pageNumber, int pageSize) 
        where IDestination : class => PaginatedList<IDestination>.CreateAsync(queryeble, pageNumber, pageSize);

    public static Task<List<IDestination>> ProjectToListAsync<IDestination>(this IQueryable<IDestination> queryeble, IConfigurationProvider configurationProvider)
        where IDestination : class => queryeble.ProjectTo<IDestination>(configurationProvider).AsNoTracking().ToListAsync();
}