using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Canos.OfficeAutomatic.Repository.Entity;

namespace Canos.OfficeAutomatic.Repository
{
    public interface IMetaNoticeCategoryRepository
    {
        /// <summary>
        /// 获取所有实体
        /// </summary>
        List<MetaNoticeCategoryEntity> GetEntityList();

        /// <summary>
        /// 获取单个实体
        /// </summary>
        MetaNoticeCategoryEntity GetById(int id);
    }
}
