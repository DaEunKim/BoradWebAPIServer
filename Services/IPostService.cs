using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BoardWebAPIServer.Models;

namespace BoardWebAPIServer.Services
{
    public interface IPostService
    {
        bool Create(CreatePostIn postIn, out Post createdPost, out Content createdContent);
        bool Read(string postId, out Content found);
        bool Update(string postId, UpdatePostIn postIn, out Post updatedPost, out Content updatedContent);
        bool List(int page, out ICollection<Post> listed);
    }
}
