using Canos.OfficeAutomatic.Contract.Request;
using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Contract.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Convertor
{
    public interface IMetaNoticeCategoryConvertor
    {

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        MetaNoticeCategoryVo toVo(MetaNoticeCategoryEntity entity);

        /// <summary>
        /// 获取所有的选项
        /// </summary>
        List<MetaNoticeCategoryVo> toVoList(List<MetaNoticeCategoryEntity> entityList);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        MetaNoticeCategoryVo toVo(List<MetaNoticeCategoryEntity> entityList, string key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<MetaNoticeCategoryVo> toVoList(List<MetaNoticeCategoryEntity> entityList, List<string> keys);
    }
}
