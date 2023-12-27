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

    public RoomServiceDto GetByNumber(string employeeNumber)
    {
        var roomService = _roomServiceRepository.GetByNumber(employeeNumber);

        return new RoomServiceDto
        {
            EmployeeNumber = roomService.EmployeeNumber,
            FirstName = roomService.FirstName,
            MiddleName = roomService.MiddleName,
            LastName = roomService.LastName,
            OutsourcingCompany = roomService.OutsourcingCompany,
        };
    }

    public RoomServiceDto UpdateEmployee(string employeeNumber, RoomServiceDto dto)
    {
        var roomService = _roomServiceRepository.GetByNumber(employeeNumber);

        roomService.EmployeeNumber = dto.EmployeeNumber;
        roomService.FirstName = dto.FirstName;
        roomService.MiddleName = dto.MiddleName;
        roomService.LastName = dto.LastName;
        roomService.OutsourcingCompany = dto.OutsourcingCompany;

        var updated = _roomServiceRepository.UpdatedEmployee(roomService);

        return new RoomServiceDto
        {
            EmployeeNumber = updated.EmployeeNumber,
            FirstName = updated.FirstName,
            MiddleName = updated.MiddleName,
            LastName = updated.LastName,
            OutsourcingCompany = updated.OutsourcingCompany,
        };
    }

}

