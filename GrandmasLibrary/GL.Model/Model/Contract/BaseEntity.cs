using System.ComponentModel.DataAnnotations;

namespace GL.Model.Model.Contract
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}