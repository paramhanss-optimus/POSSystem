﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POSSystem.Application.DTO;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderEntity, OrderDTO>().ReverseMap();
        }
    }
}