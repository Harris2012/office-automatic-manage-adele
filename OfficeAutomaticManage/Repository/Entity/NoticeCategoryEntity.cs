using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Repository.Entity
{

    public class NoticeCategoryEntity
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
