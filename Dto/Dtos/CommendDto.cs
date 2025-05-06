using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.dtos
{
    public class CommendDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int IdCustumer { get; set; }
        [ForeignKey("IdCustumer")]
        public virtual CustumerDto Custumer { get; set; }
        public int IdTrip { get; set; }
        [ForeignKey("IdTrip")]
        public virtual TripDto Trip { get; set; }


    }
}
