using Phoenix.Business.Interfaces;
using Phoenix.DataAccess.Models;
using Phoenix.Presentation.Web.RoomServiceAPI;

namespace Phoenix.Presentation.Web.RoomServiceAPI;
public class RoomServiceAPIService
{
    private IRoomServiceRepository _roomServiceRepository;

    public RoomServiceAPIService(IRoomServiceRepository roomServiceRepository)
    {
        _roomServiceRepository = roomServiceRepository;
    }

    public List<RoomServiceDto> GetAllEmployee()
    {
        List<RoomServiceDto> result;

        result = _roomServiceRepository.GetAllEmployee()
                 .Select(c => new RoomServiceDto
                 {
                     EmployeeNumber = c.EmployeeNumber,
                     FirstName = c.FirstName,
                     MiddleName = c.MiddleName,
                     LastName = c.LastName,
                     OutsourcingCompany = c.OutsourcingCompany,
                 })
                 .ToList();

        return result;
    }


    public RoomService  InsertEmployee(RoomServiceDto dto)
    {
        RoomService result = new RoomService
        {
            EmployeeNumber = dto.EmployeeNumber,
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            OutsourcingCompany = dto.OutsourcingCompany,
        };

        var resulHasil = _roomServiceRepository.InsertEmployee(result);
        return resulHasil;
    }

}

