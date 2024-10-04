using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;

[Route("api/employee")]
[ApiController]
public class EmployeeController(IDistributedCache redisCache, ILogger<EmployeeController> logger) : ControllerBase
{

    private static List<Department> departments =
    [
        new Department(){Id =1, Name="department 1"},
        new Department(){Id =2, Name="department 2"},
        new Department(){Id =3, Name="department 3"}
    ];
    private static List<Employee> employees =
    [
        new Employee(){Id =1, Name ="Emp 1", DepartmentId=1},
        new Employee(){Id =2, Name ="Emp 2", DepartmentId=2},
        new Employee(){Id =3, Name ="Emp 3", DepartmentId=1}
    ];

    [HttpGet("get-all")]
    public async Task<IActionResult> Get()
    {
        string unique_key = "Employee_With_Department";
        var result = await redisCache.GetStringAsync(unique_key);

        if (result is not null)
        {
            var deserialize = JsonSerializer.Deserialize<List<EmployeeWithDepartment>>(result);
            logger.LogInformation("Data is being pulled from cache");
            return Ok(deserialize);
        }

        var final = from emp in employees
                    join dep in departments
                    on emp.DepartmentId equals dep.Id
                    select new EmployeeWithDepartment
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        DepartmentName = dep.Name
                    };
        await SaveToCache(final.ToList());
        logger.LogInformation("Data is saved into cache");
        return Ok(final.ToList());
    }

    private async Task<bool> SaveToCache(List<EmployeeWithDepartment> employeeWithDepartments)
    {
        string unique_key = "Employee_With_Department";
        var ser = JsonSerializer.Serialize(employeeWithDepartments);
        var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));

        await redisCache.SetStringAsync(unique_key, ser, options);
        return true;
    }
}


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class EmployeeWithDepartment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DepartmentName { get; set; }
}