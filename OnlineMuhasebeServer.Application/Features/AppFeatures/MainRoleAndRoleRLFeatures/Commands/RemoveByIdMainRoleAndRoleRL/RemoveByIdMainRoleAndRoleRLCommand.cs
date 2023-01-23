using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL
{
    public sealed record RemoveByIdMainRoleAndRoleRLCommand(
        string Id): ICommand<RemoveByIdMainRoleAndRoleRLCommandResponse>;
}
