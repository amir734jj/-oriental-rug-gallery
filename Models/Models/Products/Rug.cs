using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Enums;
using Models.Interfaces;
using Models.Models.Products.Specifications;
using Models.Models.Products.Specifications.Enums;

namespace Models.Models.Products
{
    public class Rug : IEntity, IEntityUpdatable<Rug>
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Color(s)")]
        public HashSet<ColorEnum> Color { get; set; } = new HashSet<ColorEnum>();
        
        [Display(Name = "Number")]
        public string RugNumber { get; set; }
        
        [Display(Name = "Size")]
        public Dimension RugSize { get; set; }
        
        [Display(Name = "Country of origin")]
        public RugCountryEnum RugCountryOfOrigin { get; set; }
        
        [Display(Name = "Design")]
        public RugDesignEnum RugDesign { get; set; }
        
        [Display(Name = "Type")]
        public RugTypeEnum RugType { get; set; }
        
        [Display(Name = "Price in $")]
        public decimal RugPrice { get; set; }
        
        [Display(Name = "Age")]
        public RugAgeEnum RugAge { get; set; } 
        
        [Display(Name = "Availability")]
        public bool Available { get; set; }

        public List<Guid> Images { get; set; } = new List<Guid>();

        public ProductTypeEnum ProductTypeType = ProductTypeEnum.Rug;

        /// <summary>
        ///     This class is intended to be used as a document
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Rug Update(Rug dto)
        {
            throw new NotImplementedException();
        }
    }
}