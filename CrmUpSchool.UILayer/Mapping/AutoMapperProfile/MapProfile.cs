using AutoMapper;
using Crm.UpSchool.EntityLayer.Concrete;
using CrmUpSchool.DTOLayer.ContactDTOs;
using CrmUpSchool.DTOLayer.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ContactAddDto, Contact>();
            CreateMap<Contact, ContactAddDto>();

            CreateMap<ContactListDto, Contact>();
            CreateMap<Contact, ContactListDto>();

            CreateMap<ContactUpdateDto, Contact>();
            CreateMap<Contact, ContactUpdateDto>();

            CreateMap<Customer, CustomerAddDTO>();
            CreateMap<CustomerAddDTO, Customer>();

        }
    }
}
