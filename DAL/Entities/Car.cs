﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }
        public CarState CurrentCarState { get; set; }
        public Car(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
    }
}
