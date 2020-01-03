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
    public interface INoticeConvertor
    {

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        NoticeEntity ToEntity(NoticeCreateRequest request);

        /// <summary>
        /// request 转换为 entity
        /// </summary>
        NoticeEntity ToEntity(NoticeUpdateRequest request, NoticeEntity oldEntity);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        NoticeBasicVo ToBasicVo(NoticeEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<NoticeBasicVo> ToBasicVoList(List<NoticeEntity> entityList);

        /// <summary>
        /// entity 转换为 vo
        /// </summary>
        NoticeExtendedVo ToExtendedVo(NoticeEntity entity);

        /// <summary>
        /// entityList 转换为 voList
        /// </summary>
        List<NoticeExtendedVo> ToExtendedVoList(List<NoticeEntity> entityList);

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        NoticeGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeItemRequest request);

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        NoticeGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeBasicRequest request);

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        NoticeGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeUpdateRequest request);
    }
}
