using DoTask.Api.v1.Application.Queries.Users.UserSummaryQuery.ViewModels;
using DoTask.Domain.AggregatesModel.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Queries.Users.ListUserSummaryQuery
{
    public class ListUserSummaryQueryHandler : IRequestHandler<ListUserSummaryQuery, IList<UserSummary>>
    {
        private readonly IUserRepository _userRepository;
        public ListUserSummaryQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IList<UserSummary>> Handle(ListUserSummaryQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.ListUserSummaryAsync<UserSummary>();
            return users.ToList();
        }
    }
}
