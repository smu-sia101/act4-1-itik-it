using Microsoft.AspNetCore.Mvc;

namespace PetNameGenerator.Controllers
{
    [ApiController]
    [Route("api/petnameGenerator")]
    public class PetNameGeneratorController : ControllerBase
    {
        private static readonly string[] dogNames = { "Buddy", "Max", "Charlie", "Rocky", "Rex" };
        private static readonly string[] catNames = { "Whiskers", "Mittens", "Luna", "Simba", "Tiger" };
        private static readonly string[] birdNames = { "Tweety", "Sky", "Chirpy", "Raven", "Sunny" };

        private static readonly Random _random = new Random();

        [HttpPost("generate")]
        public IActionResult GeneratePetName([FromQuery] string animalType, [FromQuery] bool? twoPart)
        {
          
            if (string.IsNullOrEmpty(animalType))
            {
                return BadRequest(new { error = "The 'animalType' query parameter is required." });
            }

            string animal = animalType.ToLower();
            string[] names;

            if (animal == "dog")
            {
                names = dogNames;
            }
            else if (animal == "cat")
            {
                names = catNames;
            }
            else if (animal == "bird")
            {
                names = birdNames;
            }
            else
            {
                return BadRequest(new { error = "Invalid 'animalType'." });
            }


            string generatePetName;
            if (twoPart == true)
            {
                generatePetName = $"{names[_random.Next(names.Length)]} {names[_random.Next(names.Length)]}";
            }
            else
            {
                generatePetName = names[_random.Next(names.Length)];
            }

            return Ok(new { pet = generatePetName });
        }
    }
}

