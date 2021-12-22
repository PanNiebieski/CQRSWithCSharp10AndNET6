using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Functions.Posts.Command
{
    public record AddPostCommand
        (int PostId, string Title, string Author, DateTime Date,
        string Description, int CategoryId, string ImageUrl, string Url,
        int Rate)
    {

    }
}
