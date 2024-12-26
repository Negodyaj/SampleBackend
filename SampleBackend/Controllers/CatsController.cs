using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleBackend.Controllers
{
    [Route("api/cats")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        // GET: api/cats
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/cats/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/cats
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/cats/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/cats/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST api/cats/5/photo
        [HttpPost("{id}/photo")]
        public void AddPhotoToCat(int id, [FromBody] string photoLink)
        {
        }

        // POST api/cats/5/photo/12/comment
        [HttpPost("{id}/photo/{photoId}/comment")]
        public void AddCommentToPhotoOfCat(int id, int photoId, [FromBody] string photoLink)
        {
        }

        // POST api/cats/5/relocate
        [HttpPost("{id}/relocate")]
        public void RelocateCat(int id, [FromBody] string photoLink)
        {
        }
    }
}
