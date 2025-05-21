using AutoMapper;
using Dto.dtos;
using Entity.Model;
using Repository.interfaces;
using Service.Interfaces;
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
        private readonly IMapper mapper;
        public CustumerService(IRepository<Custumer> repository,IMapper map)
        {
            this.repository = repository;
            this.mapper = map;
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
            return mapper.Map<Custumer,CustumerDto>( repository.GetAll().FirstOrDefault(x => x.Name == username && x.Password == pass)); 
        }

        public void Update(int id, CustumerDto item)
        {
            repository.Update(id, mapper.Map<CustumerDto, Custumer>(item));
        }
    }
}
