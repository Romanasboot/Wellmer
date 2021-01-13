using System.ComponentModel.DataAnnotations;

//puslapio komponentai.
namespace Wellmer.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Puslapio pavadinimas (Antrašte)")]
        public override string Title { get; set; } = "Informacinis puslapis";

        [Display(Name = "Puslapio turinys")]
        public override string Text { get; set; } = "Pildo administratorius";
    }
}
