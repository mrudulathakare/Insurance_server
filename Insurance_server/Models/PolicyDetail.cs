using System;
using System.Collections.Generic;

namespace Insurance_server.Models;

public partial class PolicyDetail
{
    public int PolicyId { get; set; }

    public string? PolicyName { get; set; }

    public string? PolicyDescription { get; set; }

    public int? UserId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual UserLoginDetail? User { get; set; }
}
