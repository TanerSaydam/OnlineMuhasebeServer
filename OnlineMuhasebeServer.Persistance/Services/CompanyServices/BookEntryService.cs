using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.BookEntryRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyServices;

public class BookEntryService : IBookEntryService
{
    private CompanyDbContext _context;
    private readonly IContextService _contextService;
    private readonly IBookEntryCommandRepository _commandRepository;
    private readonly IBookEntryQueryRepository _queryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;

    public BookEntryService(IContextService contextService, IBookEntryCommandRepository commandRepository, IBookEntryQueryRepository queryRepository, ICompanyDbUnitOfWork unitOfWork)
    {
        _contextService = contextService;
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(string companyId, BookEntry bookEntry, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);

        await _commandRepository.AddAsync(bookEntry,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<string> GetNewBookEntryNumber(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);        
        _queryRepository.SetDbContextInstance(_context);

        BookEntry lastBookEntry = await _queryRepository.GetAll().OrderByDescending(p => p.CreatedDate).FirstOrDefaultAsync();

        if (lastBookEntry is null)
            return "0000000000000001";

        long lastBookEntryNumber = Convert.ToInt64(lastBookEntry.BookEntryNumber);
        lastBookEntryNumber++;

        string newBookEntryNumber = lastBookEntryNumber.ToString();
        for (int i = newBookEntryNumber.Length; i < 16; i++)
        {
            newBookEntryNumber = "0" + newBookEntryNumber;
        }

        return newBookEntryNumber;
    }

    public async Task<PaginationResult<BookEntry>> GetAllAsync(string companyId, int pageNumber, int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetAll(false).OrderByDescending(p => p.Date).ToPagedListAsync(pageNumber,
            pageSize);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }
}
