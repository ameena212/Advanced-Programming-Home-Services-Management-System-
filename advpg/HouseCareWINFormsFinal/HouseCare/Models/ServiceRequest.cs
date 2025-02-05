﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HouseCare.Models
{
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            Comments = new HashSet<Comment>();
            Payments = new HashSet<Payment>();
        }

        public int ServiceRequestId { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public DateTime DateNeeded { get; set; }
        public double Price { get; set; }
        public int? ServiceStatusId { get; set; }
        public int? DocumentId { get; set; }
        public int UserId { get; set; }

        public virtual Document Document { get; set; }
        public virtual AppService Service { get; set; }
        public virtual ServiceStatus ServiceStatus { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}