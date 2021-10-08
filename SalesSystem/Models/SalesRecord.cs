﻿using SalesSystem.Models.Enums;
using System;
namespace SalesSystem.Models {
    public class SalesRecord {
        public int Id { get; set; }
        public DateTime Date{ get; set; }
        public double Amount{ get; set; }
        public SalesStatus Status { get; set; }
        public Seller Seller{ get; set; }
    }
}