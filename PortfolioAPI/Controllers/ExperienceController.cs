using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Entities;
using PortfolioAPI.Models;
using PortfolioAPI.Repositories;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool includeDeleted = false)
        {
            if(!includeDeleted)
                return Ok(ExperienceRepository.Experiences);

            return Ok(ExperienceRepository.Experiences.Where(e => e.State == "Active"));

        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetByTitle([FromRoute]string title)
        {
            var algo = ExperienceRepository.Experiences.Where(e => e.Title.ToLower().Contains(title.ToLower()));
            return Ok(algo);
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience([FromBody] ExperienceCreateUpdateDTO dto)
        {
            Experience experience = new Experience()
            {
                Title = dto.Title,
                Description = dto.Description,
                ImagePath = dto.ImagePath,
                Summary = "En proceso"
            };

            ExperienceRepository.Experiences.Add(experience);
            return Ok(ExperienceRepository.Experiences);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]ExperienceCreateUpdateDTO dto)
        {
            var index = ExperienceRepository.Experiences.FindIndex(e => e.Id == id);

            if(index == -1)
                return NotFound();

            Experience experience = new Experience()
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,
                ImagePath = dto.ImagePath,
                Summary = ExperienceRepository.Experiences[index].Summary
            };

            ExperienceRepository.Experiences[index] = experience;
            return NoContent();

        }

        [HttpDelete("hard/{idHard}")]
        public async Task<IActionResult> DeleteHard([FromRoute]int idHard)
        {
            var index = ExperienceRepository.Experiences.FindIndex(e => e.Id == idHard);

            if(index == -1)
                return NotFound();

            ExperienceRepository.Experiences.RemoveAt(index);
            return NoContent();
        }    

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoft([FromRoute]int id)
        {
            var index = ExperienceRepository.Experiences.FindIndex(e => e.Id == id);

            if (index == -1)
                return NotFound();

            Experience experience = new Experience()
            {
                Id = id,
                Title = ExperienceRepository.Experiences[index].Title,
                Description = ExperienceRepository.Experiences[index].Description,
                ImagePath = ExperienceRepository.Experiences[index].ImagePath,
                Summary = ExperienceRepository.Experiences[index].Summary,
                State = "Deleted"
            };

            ExperienceRepository.Experiences[index] = experience;
            return NoContent();
        }
    }
}
