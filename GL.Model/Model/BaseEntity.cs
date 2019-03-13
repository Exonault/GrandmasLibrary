using System;
using System.ComponentModel.DataAnnotations;

namespace GL.Model.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}