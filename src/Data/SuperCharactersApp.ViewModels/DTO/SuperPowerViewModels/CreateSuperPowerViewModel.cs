namespace SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class CreateSuperPowerViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
