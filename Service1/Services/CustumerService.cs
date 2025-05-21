using AutoMapper;
using Dto.dtos;
using Entity.Model;
using Repository1.Interfaces;
using Service1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustumerService : IService<CustumerDto>,IUserLogin 
    {
        private readonly IRepository<Custumer> repository;
        private readonly Ilogin ilogin;
        private readonly IMapper mapper;
        public CustumerService(IRepository<Custumer> repository,IMapper map, Ilogin ilogin)
        {
            this.repository = repository;
            this.mapper = map;
            this.ilogin = ilogin;
        }
        public CustumerDto AddItem(CustumerDto item)
        {
           return mapper.Map< Custumer, CustumerDto>(repository.AddItem( mapper.Map<CustumerDto,Custumer>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<CustumerDto> GetAll()
        {
            return mapper.Map< List<Custumer>, List < CustumerDto >> (repository.GetAll());
        }

        public CustumerDto GetById(int id)
        {
           return mapper.Map<Custumer,CustumerDto>(repository.GetById(id));
        }

        public CustumerDto getUserBy(string username, string pass)
        {
            return mapper.Map<Custumer, CustumerDto>(ilogin.getUserByPassAndUser(username, pass));
        }

        public void Update(int id, CustumerDto item)
        {
            repository.Update(id, mapper.Map<CustumerDto, Custumer>(item));
        }
    }
}
