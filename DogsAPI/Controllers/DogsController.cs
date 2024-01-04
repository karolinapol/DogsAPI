using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private static List<Dogs> dogs = new List<Dogs>
            {
            };

        private readonly DataContext _context;
        public DogsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dogs>>> Get()
        {
            return Ok(await _context.Dogs.ToListAsync());
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Dogs>> Get(int id)
        {
            var dogData = await _context.Dogs.FindAsync(id);

            if (dogData == null)
                return BadRequest("Pies nieznaleziony.");
            return Ok(dogData);
        }


        [HttpPost]

        public async Task<ActionResult<List<Dogs>>> AddDog(Dogs dog)
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();
            return Ok(await _context.Dogs.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Dogs>>> UpdateDog(Dogs request)
        {
            

            var dogData = await _context.Dogs.FindAsync(request.Id);

            if (dogData == null)
                return BadRequest("Pies nieznaleziony.");

            dogData.Name = request.Name;
            dogData.Breed = request.Breed;
            dogData.FurColor = request.FurColor;
            dogData.Gender = request.Gender;
            dogData.Age = request.Age;
            dogData.Weight = request.Weight;
            dogData.Height = request.Height;

            await _context.SaveChangesAsync();
            return Ok(await _context.Dogs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Dogs>>> Delete(int id)
        {
            var dogData = await _context.Dogs.FindAsync(id);

            if (dogData == null)
                return BadRequest("Pies nieznaleziony.");

            _context.Dogs.Remove(dogData);
            await _context.SaveChangesAsync();
            return Ok(await _context.Dogs.ToListAsync());
        }
    }
}
