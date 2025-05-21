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
    public class CommendService : IService<CommendDto>
    {
        private readonly IRepository<Commend> repository;
        private readonly IMapper mapper;
        public CommendService(IRepository<Commend> repository,IMapper map)
        {
            this.repository = repository;
            this.mapper = map;
        }
        public CommendDto AddItem(CommendDto item)
        {
           return mapper.Map<Commend,CommendDto>(repository.AddItem(mapper.Map<CommendDto,Commend>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<CommendDto> GetAll()
        {
            return mapper.Map<List<Commend>,List<CommendDto>>(repository.GetAll());
        }

        public CommendDto GetById(int id)
        {
            return mapper.Map<Commend,CommendDto>(repository.GetById(id));
        }

        public void Update(int id, CommendDto item)
        {
            repository.Update(id, mapper.Map<CommendDto, Commend>(item));
        }
    }
}
