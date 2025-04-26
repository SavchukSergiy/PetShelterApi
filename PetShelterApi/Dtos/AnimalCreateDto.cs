using System.ComponentModel.DataAnnotations;

namespace PetShelterApi.Dtos
{
    public class AnimalCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }
        public string Breed { get; set; }
    }
}
