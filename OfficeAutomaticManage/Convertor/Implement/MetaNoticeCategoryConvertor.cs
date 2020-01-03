using Canos.OfficeAutomatic.Contract.Request;
using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Contract.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canos.OfficeAutomatic.Convertor.Implement
{
    public class MetaNoticeCategoryConvertor : IMetaNoticeCategoryConvertor
    {
        public MetaNoticeCategoryVo toVo(MetaNoticeCategoryEntity entity)
        {
            MetaNoticeCategoryVo vo = new MetaNoticeCategoryVo();

            vo.Name = entity.Name;
            vo.Title = entity.Title;

            return vo;
        }

        public List<MetaNoticeCategoryVo> toVoList(List<MetaNoticeCategoryEntity> entityList)
        {
            if (entityList == null) {
                return null;
            }

            List<MetaNoticeCategoryVo> voList = new List<MetaNoticeCategoryVo>();
            foreach (MetaNoticeCategoryEntity entity in entityList)
            {

                MetaNoticeCategoryVo vo = toVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public MetaNoticeCategoryVo toVo(List<MetaNoticeCategoryEntity> entityList, string key)
        {
            if (entityList == null) {
                return null;
            }

            foreach (MetaNoticeCategoryEntity entity in entityList)
            {
                if (entity.Name == key)
                {
                    return toVo(entity);
                }
            }

            return null;
        }

        public List<MetaNoticeCategoryVo> toVoList(List<MetaNoticeCategoryEntity> entityList, List<string> keys)
        {
            if (entityList == null)
            {
                return null;
            }

            List<MetaNoticeCategoryVo> voList = new List<MetaNoticeCategoryVo>();
            foreach (MetaNoticeCategoryEntity entity in entityList)
            {
                if (!keys.Contains(entity.Name))
                {
                    continue;
                }

                MetaNoticeCategoryVo vo = toVo(entity);
                voList.Add(vo);

                if(voList.Count == keys.Count)
                {
                    break;
                }
            }

            return voList;
        }
    }
}
