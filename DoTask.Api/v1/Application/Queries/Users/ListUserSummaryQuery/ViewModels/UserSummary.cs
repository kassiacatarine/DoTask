using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Application.Queries.Users.UserSummaryQuery.ViewModels
{
    public class UserSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
