using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Services;

public interface IRabbitMQService
{
    void SendQueue(ReportDto reportDto);
}
