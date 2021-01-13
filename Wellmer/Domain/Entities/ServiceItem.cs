using System.ComponentModel.DataAnnotations;

//paslaugos komponentai.
namespace Wellmer.Domain.Entities
{
    public class ServiceItem : EntityBase
    {
        [Required(ErrorMessage = "Irašykit paslaugos pavadinima")]
        [Display(Name = "Paslaugos pavadinimas")]
        public override string Title { get; set; }

        [Display(Name = "Paslaugos aprašymas trumpai")]
        public override string Subtitle { get; set; }

        [Display(Name = "Paslaugos pilnas aprašymas")]
        public override string Text { get; set; }
    }
}
