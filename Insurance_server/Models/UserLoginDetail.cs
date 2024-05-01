﻿using System;
using System.Collections.Generic;

namespace Insurance_server.Models;

public partial class UserLoginDetail
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; } = new List<EmployeeDetail>();

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<PolicyDetail> PolicyDetails { get; set; } = new List<PolicyDetail>();
}