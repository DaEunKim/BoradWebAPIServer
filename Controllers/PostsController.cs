using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BoardWebAPIServer.Services;
using BoardWebAPIServer.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BoardWebAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postSvc;

        public PostsController(IPostService postSvc)
        {
            _postSvc = postSvc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new
            {
                name = "김다은",
                남자친구 = "채한울",
                사랑해유 = "ㅋㅋㅋㅋ",
            });
        }

        [HttpPost("create")]
        public IActionResult Create(CreatePostIn postIn)
        {
            { }

            if (_postSvc.Create(postIn, out var post, out var content) == false)
            {
                return Ok(new
                {
                    success = false,
                    reason = "Failed to Create Post",
                });
            }

            return Ok(new
            {
                success = true,
                post,
                content,
            });
        }

        [HttpGet("read/{id}")]
        public IActionResult Read(string id)
        {
            { }

            if (_postSvc.Read(id, out var content) == false)
            {
                return Ok(new
                {
                    success = false,
                    reason = "Failed to Read Post",
                });
            }

            return Ok(new
            {
                success = true,
                content,
            });
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(string id, UpdatePostIn postIn)
        {
            { }

            if (_postSvc.Update(id, postIn, out var post, out var content) == false)
            {
                return Ok(new
                {
                    success = false,
                    reason = "Failed to Update Post",
                });
            }

            return Ok(new
            {
                success = true,
                post,
                content,
            });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(new
            {
                success = false,
                reason = "not implemented yet >.<",
            });
        }

        [HttpGet("list")]
        public IActionResult List(int page)
        {
            { }

            if (_postSvc.List(page, out var posts) == false)
            {
                return Ok(new
                {
                    success = false,
                    reason = "Failed to List Post",
                });
            }

            return Ok(new
            {
                success = true,
                posts,
            });
        }
    }
}
