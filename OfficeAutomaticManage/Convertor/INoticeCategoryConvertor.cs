using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Canos.OfficeAutomatic.Contract.Request;
using Canos.OfficeAutomatic.Contract.Vo;
using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Repository.Request;

namespace Canos.OfficeAutomatic.Convertor
{
    public interface INoticeCategoryConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        NoticeCategoryEntity ToEntity(NoticeCategoryCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        NoticeCategoryEntity ToEntity(NoticeCategoryUpdateRequest request, NoticeCategoryEntity oldEntity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        NoticeCategoryBasicVo ToBasicVo(NoticeCategoryEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<NoticeCategoryBasicVo> ToBasicVoList(List<NoticeCategoryEntity> entityList);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        NoticeCategoryExtendedVo ToExtendedVo(NoticeCategoryEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<NoticeCategoryExtendedVo> ToExtendedVoList(List<NoticeCategoryEntity> entityList);

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        NoticeCategoryGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeCategoryItemRequest request);

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        NoticeCategoryGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeCategoryBasicRequest request);

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        NoticeCategoryGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeCategoryUpdateRequest request);
    }
}
