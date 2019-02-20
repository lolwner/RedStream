using RedStream.DataAccessLayer.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace RedStream.DataAccessLayer.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
