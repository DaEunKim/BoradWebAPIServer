using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization.Attributes;

namespace BoardWebAPIServer.Models
{
    public class Comment
    {
        public Comment()
        {
            SubComments = new List<Comment>();
        }

        [BsonId]
        public string Id { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("creator")]
        public string Creator { get; set; }

        [BsonElement("create_time")]
        public string CreateTime { get; set; }

        [BsonElement("sub_comments")]
        public ICollection<Comment> SubComments { get; set; }

        [BsonElement("extra_info")]
        public Dictionary<string, object> ExtraInfo { get; set; }
    }

    public class Content
    {
        public Content()
        {
            Comments = new List<Comment>();
        }

        [IgnoreDataMember]
        [BsonId]
        public string Id { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("post_id")]
        public string PostId { get; set; }

        [BsonElement("comments")]
        public ICollection<Comment> Comments { get; set; }

        [BsonElement("extra_info")]
        public Dictionary<string, object> ExtraInfo { get; set; }
    }
}
