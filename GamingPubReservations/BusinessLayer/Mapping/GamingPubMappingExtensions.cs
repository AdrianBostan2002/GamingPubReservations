using BusinessLayer.Dtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public static class GamingPubMappingExtensions
    {
        public static GamingPub ToGamingPub(this AddGamingPubDto addGamingPubDto)
        {
            return new GamingPub
            {
                Name = addGamingPubDto.Name,
                Address = addGamingPubDto.AddAdressDto.ToAddress(),
                PhoneNumber = addGamingPubDto.PhoneNumber
            };
        }
    }
}