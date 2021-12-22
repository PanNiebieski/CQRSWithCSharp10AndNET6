using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Interfaces
{
    public interface IPostRepository
    {
        public IList<Post> GetAll();

        public Post AddPost(Post post);
    }
}
