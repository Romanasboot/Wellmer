using System;
using System.ComponentModel.DataAnnotations;

//cia baziniai komponentai, kurie bus naudojami visur (paveldimi).
namespace Wellmer.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.Now;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Pavadinimas (antrašte)" )]
        public virtual string Title { get; set; }

        [Display(Name = "Trumpas aprašymas")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Tekstas")]
        public virtual string Text { get; set; }

        [Display(Name = "Paveikslelis")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO Pavadinimas")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO Aprašymas")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO Raktažodis")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }


    }
}
