using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BoardWebAPIServer.Models;
using MongoDB.Driver;

namespace BoardWebAPIServer.Services
{
    public static class ConnectionString
    {
        public static string GetConnectionString()
        {
            return "mongodb://localhost:27017";
        }
    }

    public class PostService : IPostService
    {
        private readonly int POSTS_PER_PAGE = 30;

        private readonly IMongoCollection<Post> _posts;
        private readonly IMongoCollection<Content> _contents;

        public PostService()
        {
            var connStr = ConnectionString.GetConnectionString();
            var client = new MongoClient(connStr);
            var postsDb = client.GetDatabase("PostsDb");
            var contentsDb = client.GetDatabase("ContentsDb");

            _posts = postsDb.GetCollection<Post>("Posts");
            _contents = contentsDb.GetCollection<Content>("Contents");
        }

        public bool Create(CreatePostIn postIn, out Post createdPost, out Content createdContent)
        {
            createdPost = null;
            createdContent = null;

            if (postIn == null)
            {
                return false;
            }

            var postId = Guid.NewGuid().ToString();
            var contentId = Guid.NewGuid().ToString();

            Post post = new Post
            {
                Id = postId,
                Title = postIn.Title,
                Creator = postIn.Creator,
                CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ContentId = contentId,
                ViewCount = 0,
                LikeCount = 0,
                ExtraInfo = postIn.PostExtInfo,
            };

            Content content = new Content
            {
                Id = contentId,
                Text = postIn.Text,
                PostId = postId,
                ExtraInfo = postIn.ContentExtInfo,
            };

            _contents.InsertOne(content);
            _posts.InsertOne(post);

            createdPost = post;
            createdContent = content;

            return true;
        }

        public bool Read(string postId, out Content found)
        {
            found = null;

            if (string.IsNullOrWhiteSpace(postId))
            {
                return false;
            }

            var post = _posts
                        .Find(p => p.Id == postId)
                        .SingleOrDefault();

            if (post == null)
            {
                return false;
            }

            found = _contents
                        .Find(c => c.Id == post.ContentId)
                        .SingleOrDefault();

            return (found != null);
        }

        public bool Update(string postId, UpdatePostIn postIn, out Post updatedPost, out Content updatedContent)
        {
            updatedPost = null;
            updatedContent = null;

            if (string.IsNullOrWhiteSpace(postId))
            {
                return false;
            }

            if (postIn == null)
            {
                return false;
            }

            if (postId == postIn.Id)
            {
                return false;
            }

            var post = _posts
                            .Find(p => p.Id == postId)
                            .SingleOrDefault();
            if (post == null)
            {
                return false;
            }

            var content = _contents
                            .Find(c => c.Id == post.ContentId)
                            .SingleOrDefault();
            if (content == null)
            {
                return false;
            }

            post.Title = postIn.Title;
            post.ExtraInfo = postIn.PostExtInfo;

            content.Text = postIn.Text;
            content.ExtraInfo = postIn.ContentExtInfo;

            _posts.ReplaceOne(p => p.Id == post.Id, post);
            _contents.ReplaceOne(c => c.Id == content.Id, content);

            return true;
        }

        public bool List(int page, out ICollection<Post> listed)
        {
            if (page < 0)
            {
                page = 0;
            }

            listed = _posts
                        .Find(_ => true)
                        .Skip(POSTS_PER_PAGE * page)
                        .Limit(POSTS_PER_PAGE)
                        .ToList();

            return true;
        }
    }
}
