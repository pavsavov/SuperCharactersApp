using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCharacters.Services.Mapping.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
