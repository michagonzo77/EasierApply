#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace EasierApply.Models;

public class PythonPath
{
    [Key]
    public int PythonPathId {get;set;}
    [Required(ErrorMessage ="Path is required")]
    public string Path {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}