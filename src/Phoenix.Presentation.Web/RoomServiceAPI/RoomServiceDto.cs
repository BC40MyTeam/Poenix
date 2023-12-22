using System.ComponentModel.DataAnnotations;

namespace Phoenix.Presentation.Web.RoomServiceAPI;
public class RoomServiceDto
{
    [Required]
    public string EmployeeNumber { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required] 
    public string OutsourcingCompany { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}

