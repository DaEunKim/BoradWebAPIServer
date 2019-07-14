using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace BoardWebAPIServer.Models
{
    public class CreatePostIn
    {
        public string Title { get; set; }

        public string Creator { get; set; } // @@TODO : Change to Class

        public string Text { get; set; }

        public Dictionary<string, object> PostExtInfo { get; set; }
        public Dictionary<string, object> ContentExtInfo { get; set; }
    }

    public class UpdatePostIn
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Dictionary<string, object> PostExtInfo { get; set; }
        public Dictionary<string, object> ContentExtInfo { get; set; }
    }

    public class Post
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("creator")]
        public string Creator { get; set; } // @@TODO : Change to Class
        
        [BsonElement("create_time")]
        public string CreateTime { get; set; }

        [IgnoreDataMember]
        [BsonElement("content_id")]
        public string ContentId { get; set; } // @@TODO : 외부에 숨길 Id

        [BsonElement("view_count")]
        public int ViewCount { get; set; }

        [BsonElement("like_count")]
        public int LikeCount { get; set; }

        [BsonElement("extra_info")]
        public Dictionary<string, object> ExtraInfo { get; set; }
    }
}
