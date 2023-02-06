using OnlineMuhasebeServer.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMuhasebeServer.Domain.CompanyEntities
{
    public sealed class UniformChartOfAccount : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; }        
    }
}
