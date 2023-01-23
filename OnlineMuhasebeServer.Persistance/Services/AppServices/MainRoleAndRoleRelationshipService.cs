using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices;

public class MainRoleAndRoleRelationshipService : IMainRoleAndRoleRelationshipService
{
    private readonly IMainRoleAndRoleRelationshipCommandRepository _commandRepository;
    private readonly IMainRoleAndRoleRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleAndRoleRelationshipService(IMainRoleAndRoleRelationshipCommandRepository commandRepository, IMainRoleAndRoleRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRoleAndRoleRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRoleAndRoleRelationship> GetAll()
    {
        return _queryRepository.GetAll();
    }

    public async Task<MainRoleAndRoleRelationship> GetByIdAsync(string id)
    {
        return await _queryRepository.GetById(id);
    }    

    public async Task<MainRoleAndRoleRelationship> GetByRoleIdAndMainRoleId(string roleId, string mainRoleId, CancellationToken cancellationToken = default)
    {
        return await _queryRepository.GetFirstByExpiression(p => p.RoleId == roleId && p.MainRoleId == mainRoleId, cancellationToken);
    }

    public async Task<IList<MainRoleAndRoleRelationship>> GetListByMainRoleIdForGetRolesAsync(string id)
    {
        return await _queryRepository.GetWhere(p => p.MainRoleId == id).Include("AppRole").ToListAsync();
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();

    }

    public async Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship)
    {
        _commandRepository.Update(mainRoleAndRoleRelationship);
        await _unitOfWork.SaveChangesAsync();
    }
}
