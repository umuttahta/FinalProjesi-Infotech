﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Shared.Dtos
{
    public class CartDto
    {
        public int Id { get; set;}
        public DateTime CreatedDate { get; set;}
        public string UserId { get; set;}
        public List<CartItemDto> CartItems { get; set;}
    }
}

