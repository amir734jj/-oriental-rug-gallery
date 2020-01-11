using System;
using System.ComponentModel.DataAnnotations;
using Models.Interfaces;
using Models.Models.Products.Specifications;
using Models.Models.Products.Specifications.Enums;

namespace Models.Models.Products
{
    public class Rug : IEntity, IEntityUpdatable<Rug>
    {
        [Key]
        public int Id { get; set; }
        
        public string Description { get; set; }

        public ColorEnum[] Color { get; set; }
        
        public string RugNumber { get; set; }
        
        public Dimension RugSize { get; set; }
        
        public RugCountryEnum RugCountryOfOrigin { get; set; }
        
        public RugDesignEnum RugDesign { get; set; }
        
        public RugTypeEnum RugType { get; set; }
        
        public decimal RugPrice { get; set; }
        
        public RugAgeEnum RugAge { get; set; } 
        
        public bool Available { get; set; }

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