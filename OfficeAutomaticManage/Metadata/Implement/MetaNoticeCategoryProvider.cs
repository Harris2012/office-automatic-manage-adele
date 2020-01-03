using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Canos.OfficeAutomatic.Convertor;
using Canos.OfficeAutomatic.Repository;
using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Metadata.Implement
{
    public class MetaNoticeCategoryProvider : IMetaNoticeCategoryProvider
    {
        private IMetaNoticeCategoryRepository metaNoticeCategoryRepository;
        private IMetaNoticeCategoryConvertor metaNoticeCategoryConvertor;

        private Dictionary<string, MetaNoticeCategoryVo> map = new Dictionary<string, MetaNoticeCategoryVo>();

        public MetaNoticeCategoryProvider(IMetaNoticeCategoryRepository metaNoticeCategoryRepository, IMetaNoticeCategoryConvertor metaNoticeCategoryConvertor)
        {
            this.metaNoticeCategoryRepository = metaNoticeCategoryRepository;
            this.metaNoticeCategoryConvertor = metaNoticeCategoryConvertor;
        }

        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        public List<MetaNoticeCategoryVo> GetMetadataList()
        {
            return map.Values.ToList();
        }

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        public MetaNoticeCategoryVo ToMetadata(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            if (!map.ContainsKey(key))
            {
                return null;
            }

            return map[key];
        }

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        public List<MetaNoticeCategoryVo> ToMetadataList(List<string> keys)
        {
            if (keys == null)
            {
                return null;
            }

            List<MetaNoticeCategoryVo> voList = new List<MetaNoticeCategoryVo>();
            foreach (var key in keys)
            {
                if (!map.ContainsKey(key))
                {
                    continue;
                }

                voList.Add(map[key]);
            }

            return voList;
        }

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        public Dictionary<string, MetaNoticeCategoryVo> ToMetadataMap(List<string> keys)
        {
            if (keys == null)
            {
                return null;
            }

            Dictionary<string, MetaNoticeCategoryVo> returnValue = new Dictionary<string, MetaNoticeCategoryVo>();
            foreach (var key in keys)
            {
                if (returnValue.ContainsKey(key))
                {
                    continue;
                }

                if (!map.ContainsKey(key))
                {
                    continue;
                }

                returnValue.Add(key, map[key]);
            }

            return returnValue;
        }

        /// <summary>
        /// 加载缓存
        /// </summary>
        public void Load()
        {
            var entityList = metaNoticeCategoryRepository.GetEntityList();
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            var voList = metaNoticeCategoryConvertor.toVoList(entityList);
            if (voList == null || voList.Count == 0)
            {
                return;
            }

            foreach (var vo in voList)
            {
                map.Add(vo.Name, vo);
            }
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        public void Reload()
        {
            var entityList = metaNoticeCategoryRepository.GetEntityList();
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            var voList = metaNoticeCategoryConvertor.toVoList(entityList);
            if (voList == null || voList.Count == 0)
            {
                return;
            }

            var newMap = new Dictionary<string, MetaNoticeCategoryVo>();
            foreach (var vo in voList)
            {
                newMap.Add(vo.Name, vo);
            }

            map = newMap;
        }
    }
}
