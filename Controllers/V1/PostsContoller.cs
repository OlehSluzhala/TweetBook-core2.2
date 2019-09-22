﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TweetBook.Contracts.V1;
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
    }
}