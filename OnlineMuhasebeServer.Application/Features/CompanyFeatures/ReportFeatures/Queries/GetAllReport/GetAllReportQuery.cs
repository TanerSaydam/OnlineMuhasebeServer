using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;

public sealed record GetAllReportQuery(
    string CompanyId): IQuery<GetAllReportQueryResponse>;
