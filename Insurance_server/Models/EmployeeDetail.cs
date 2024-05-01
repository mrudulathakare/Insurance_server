using System;
using System.Collections.Generic;

namespace Insurance_server.Models;

public partial class EmployeeDetail
{
    public int Id { get; set; }

    public string? EmpName { get; set; }

    public string? EmailId { get; set; }

    public string? CompanyName { get; set; }

    public int? UserId { get; set; }

    public virtual UserLoginDetail? User { get; set; }
}
