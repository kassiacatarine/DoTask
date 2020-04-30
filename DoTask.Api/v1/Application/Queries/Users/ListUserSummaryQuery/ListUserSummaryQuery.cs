using DoTask.Api.v1.Application.Queries.Users.UserSummaryQuery.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DoTask.Api.v1.Application.Queries.Users.ListUserSummaryQuery
{
    public class ListUserSummaryQuery : IRequest<IList<UserSummary>>
    {
    }
}
