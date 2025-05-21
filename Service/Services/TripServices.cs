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
    public class TripServices : IService<TripDto>
    {
        private readonly IRepository<Trip> repository;
        private readonly IMapper mapper;
        
        public TripServices(IRepository<Trip> repository,IMapper map)
        {
            this.repository = repository;
            this.mapper = map;
        }
        public TripDto AddItem(TripDto item)
        {
            return mapper.Map<Trip, TripDto>(repository.AddItem(mapper.Map<TripDto, Trip>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<TripDto> GetAll()
        {
            return mapper.Map<List<Trip>, List<TripDto>>(repository.GetAll());
        }

        public TripDto GetById(int id)
        {
            return mapper.Map<Trip,TripDto>(repository.GetById(id));
        }

        public void Update(int id, TripDto item)
        {
            repository.Update(id, mapper.Map<TripDto, Trip>(item));
            
        }
    }
}
