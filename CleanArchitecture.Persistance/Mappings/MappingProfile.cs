﻿using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Mappings
{
   public sealed class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>();
            CreateMap<RegisterCommand, User>();

        }
    }
}
