using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.TableModel
{
    public class TimeAndDate
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string? UpdateBy { get; set; }

    }
}
