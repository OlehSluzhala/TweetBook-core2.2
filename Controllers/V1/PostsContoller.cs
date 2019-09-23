using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TweetBook.Contracts.V1;
using TweetBook.Contracts.V1.Requests;
using TweetBook.Contracts.V1.Responses;
using TweetBook.Domain;

namespace TweetBook.Controllers.V1
{
    public class PostsContoller : Controller
    {
        private List<Post> _posts;

        public PostsContoller()
        {
            _posts = new List<Post>();
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }
        [HttpGet(ApiRoutes.Posts.GetAll)]

        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post{ Id = postRequest.Id};

            if (string.IsNullOrEmpty(post.Id))
                post.Id = Guid.NewGuid().ToString();

            _posts.Add(post);

            var baseurl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseurl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id);

            var responce = new PostResponse {Id = post.Id};
            return Created(locationUri, post);
        }
    }
}