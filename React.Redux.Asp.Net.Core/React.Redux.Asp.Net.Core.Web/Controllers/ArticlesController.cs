using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace React.Redux.Asp.Net.Core.Web.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : Controller
    {
        static IList<Article> articles;
        public ArticlesController()
        {
            articles = new List<Article>
            {
                new Article{Id = Guid.NewGuid(), Title="title one"},
                new Article{Id = Guid.NewGuid(), Title="title two"},
                new Article{Id = Guid.NewGuid(), Title="title three"},
            };
        }
        // GET: api/Articles
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(articles);
        }

        // GET: api/Articles/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Articles
        [HttpPost]
        public void Post([FromBody] string title)
        {
            articles.Add(new Article {
                Id = Guid.NewGuid(),
                Title = title
            });
        }

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            articles = articles.Where(x => x.Id != id).ToList();
            return Ok(articles);
        }
    }
}
