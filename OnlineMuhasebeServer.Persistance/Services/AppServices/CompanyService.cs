using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppDbContext.CompanyRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;
using System.Runtime.CompilerServices;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly ICompanyCommandRepository _companyCommandRepository;
        private readonly ICompanyQueryRepository _companyQueryRepository;
        private readonly IAppUnitOfWork _appUnitOfWork;
        private readonly IMapper _mapper;        
        public CompanyService(IMapper mapper, ICompanyCommandRepository companyCommandRepository, ICompanyQueryRepository companyQueryRepository, IAppUnitOfWork appUnitOfWork)
        {
            _mapper = mapper;
            _companyCommandRepository = companyCommandRepository;
            _companyQueryRepository = companyQueryRepository;
            _appUnitOfWork = appUnitOfWork;            
        }

        public async Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _companyCommandRepository.AddAsync(company, cancellationToken);
            await _appUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Company> GetAll()
        {
            return _companyQueryRepository.GetAll();
        }

        public async Task<Company?> GetCompanyByName(string name, CancellationToken cancellationToken)
        {
            return await _companyQueryRepository.GetFirstByExpiression(p => p.Name == name, cancellationToken, false); 
        }       

        public async Task MigrateCompanyDatabases()
        {
            var companies = await _companyQueryRepository.GetAll().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
