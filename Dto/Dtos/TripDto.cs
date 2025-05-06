using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public enum eType {מסלול,אטרקציה,מוזיאון }
    public enum eArea {צפון, דרום, מרכז, יהודה_ושומרון}
    public enum eSeason { חורף, קיץ, אביב,סתיו }
    public enum eDryOrWet { רטוב, יבש, משולב}
    public enum eHardLevel { קל, בינוני, קשה }



    public class TripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public eType Type { get; set; }
        public int Age { get; set; }
        public eHardLevel HardLevel { get; set; }
        public int HowLongTime  { get; set; }
        public eSeason Season { get; set; }
        public eArea Area { get; set; }
        public string Adress  { get; set; }
        public int Rating   { get; set; }
        public int Price { get; set; }
        public eDryOrWet DryOrWet { get; set; }
       
        public ICollection<CommendDto> Commends { get; set; }
        public byte[]? ImageArr { get; set; }

        public IFormFile? file { get; set; }
    }
}
