using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Canos.OfficeAutomatic.Contract.Vo;

namespace Canos.OfficeAutomatic.Metadata
{
    public interface IMetaNoticeCategoryProvider
    {
        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <returns>元数据列表</returns>
        List<MetaNoticeCategoryVo> GetMetadataList();

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        MetaNoticeCategoryVo ToMetadata(string key);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        List<MetaNoticeCategoryVo> ToMetadataList(List<string> keys);

        /// <summary>
        /// 获取被标记为已经选择的。
        /// </summary>
        Dictionary<string, MetaNoticeCategoryVo> ToMetadataMap(List<string> keys);

        /// <summary>
        /// 加载缓存
        /// </summary>
        void Load();

        /// <summary>
        /// 刷新缓存
        /// </summary>
        void Reload();
    }
}