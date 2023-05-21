using System.ComponentModel.DataAnnotations;

namespace Csharp_Task_3.Models.Dto
{
    public class PinDTO
    {

        [Required]
        public List<string> CalulatedPins { get; set; }
    }
}
