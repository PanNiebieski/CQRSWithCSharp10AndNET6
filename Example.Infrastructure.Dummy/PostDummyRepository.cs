using Example.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infrastructure.Dummy
{
    public class PostDummyRepository : IPostRepository
    {
        public Post AddPost(Post post)
        {
            return DummyPosts.Add(post);
        }

        public IList<Post> GetAll()
        {
            return DummyPosts.Get();
        }
    }
}
