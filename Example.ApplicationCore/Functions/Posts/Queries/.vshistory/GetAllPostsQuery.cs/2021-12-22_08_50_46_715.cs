using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Functions.Posts.Queries
{
    public record GetAllPostsQuery(OrderByPostOptions OrderBy)
    {

    }
}
