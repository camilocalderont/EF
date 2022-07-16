using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EF.Models
{
    [Table("Work")]
    public class Tarea
    {
        [Key]
        public Guid TareaId {get;set;}
        
        [ForeignKey("CategoriaId")]
        public Guid CategoriaId {get;set;}
                
        [Required]
        [MaxLength(200, ErrorMessage="El titulo debe tener maximo 200 caracteres"),MinLength(5)]
        public string Titulo {get; set;}
        
        [Column("WorkDescription", TypeName="ntext")]
        public string Descripcion {get;set;}  
        public Prioridad PrioridadTarea {get;set;}
        public DateTime FechaCreacion {get;set;}  
        public virtual Categoria Categoria {get;set;}  

        [NotMapped]
        public string Resumen {get;set;}        
    }
}
public enum Prioridad
{
    Baja,
    Media,
    Alta,
}