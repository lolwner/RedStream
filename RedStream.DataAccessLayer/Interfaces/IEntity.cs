using System;
using System.ComponentModel.DataAnnotations;

namespace RedStream.DataAccessLayer.Interfaces
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
        DateTime CreationDate { get; set; }
    }
}
