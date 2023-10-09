using System.ComponentModel.DataAnnotations;

namespace NZWalksApi.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be minimum of 3 chatacters")]
        [MaxLength(3, ErrorMessage = "Code has to be maximum of 3 chatacters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 chatacters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
