using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices;

public class UserAndCompanyRelationshipService : IUserAndCompanyRelationshipService
{
    private readonly IUserAndCompanyRelationshipCommandRepository _commandRepository;
    private readonly IUserAndCompanyRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public UserAndCompanyRelationshipService(IUserAndCompanyRelationshipCommandRepository commandRepository, IAppUnitOfWork unitOfWork, IUserAndCompanyRelationshipQueryRepository queryRepository)
    {
        _commandRepository = commandRepository;
        _unitOfWork = unitOfWork;
        _queryRepository = queryRepository;
    }

    public async Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(userAndCompanyRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserAndCompanyRelationship> GetByIdAsync(string id)
    {
        return await _queryRepository.GetById(id);
    }

    public async Task<UserAndCompanyRelationship> GetByUserIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpiression(p=> p.AppUserId == userId && p.CompanyId == companyId, cancellationToken);
    }

    public async Task<IList<UserAndCompanyRelationship>> GetListByUserId(string userId)
    {
        return await _queryRepository.GetWhere(p=> p.AppUserId ==userId).Include("Company").ToListAsync();   
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _commandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
