using AutoMapper;
using Dto.dtos;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevice.Services
{
    public class MyMapper:Profile
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Images/");
        public MyMapper()
        {
            //כדי להמיר ממחרוזת למערך של ביטים
            CreateMap<Trip, TripDto>().ForMember("ImageArr", x => x.MapFrom(y =>File.ReadAllBytes(path+ y.ImgUrl)));
            CreateMap<TripDto, Trip>().ForMember("ImgUrl", x => x.MapFrom(y => y.file.FileName));
            CreateMap<Commend, CommendDto>().ReverseMap();
            CreateMap<Custumer, CustumerDto>().ReverseMap();
        }
    }
}
