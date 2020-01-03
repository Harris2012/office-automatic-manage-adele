using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Canos.OfficeAutomatic.Contract.Request;
using Canos.OfficeAutomatic.Contract.Vo;
using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Repository.Request;
using Canos.OfficeAutomatic.Utility;

namespace Canos.OfficeAutomatic.Convertor.Implement
{
    public class NoticeCategoryConvertor : INoticeCategoryConvertor
    {

        public NoticeCategoryEntity ToEntity(NoticeCategoryCreateRequest request)
        {
            NoticeCategoryEntity entity = new NoticeCategoryEntity();

            var item = request.Item;

            entity.Name = item.Name;
            entity.Title = item.Title;
            entity.Remark = item.Remark;
            entity.DataStatus = 1;
            entity.CreateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        public NoticeCategoryEntity ToEntity(NoticeCategoryUpdateRequest request, NoticeCategoryEntity oldEntity)
        {
            NoticeCategoryEntity entity = new NoticeCategoryEntity();

            var item = request.Item;

            entity.Id = request.Id;
            entity.Name = item.Name;
            entity.Title = item.Title;
            entity.Remark = item.Remark;
            entity.DataStatus = oldEntity.DataStatus;
            entity.CreateTime = oldEntity.CreateTime;
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public NoticeCategoryBasicVo ToBasicVo(NoticeCategoryEntity entity)
        {
            NoticeCategoryBasicVo vo = new NoticeCategoryBasicVo();

            CopyToVo(vo, entity);


            return vo;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public NoticeCategoryExtendedVo ToExtendedVo(NoticeCategoryEntity entity)
        {
            NoticeCategoryExtendedVo vo = new NoticeCategoryExtendedVo();

            CopyToVo(vo, entity);

            return vo;
        }

        public List<NoticeCategoryBasicVo> ToBasicVoList(List<NoticeCategoryEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<NoticeCategoryBasicVo> voList = new List<NoticeCategoryBasicVo>();
            foreach (NoticeCategoryEntity entity in entityList)
            {
                NoticeCategoryBasicVo vo = ToBasicVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<NoticeCategoryExtendedVo> ToExtendedVoList(List<NoticeCategoryEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<NoticeCategoryExtendedVo> voList = new List<NoticeCategoryExtendedVo>();
            foreach (NoticeCategoryEntity entity in entityList)
            {
                NoticeCategoryExtendedVo vo = ToExtendedVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private void CopyToVo(NoticeCategoryVo vo, NoticeCategoryEntity entity)
        {
            vo.Id = entity.Id;
            vo.Name = entity.Name;
            vo.Title = entity.Title;
            vo.Remark = entity.Remark;
            vo.DataStatus = entity.DataStatus;
            vo.CreateTime = entity.CreateTime;
            vo.LastUpdateTime = entity.LastUpdateTime;
        }


        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NoticeCategoryGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeCategoryItemRequest request)
        {
            NoticeCategoryGetEntityByPrimaryPropertyRequest returnValue = new NoticeCategoryGetEntityByPrimaryPropertyRequest();

            returnValue.Name = request.Name;

            return returnValue;
        }

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NoticeCategoryGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeCategoryBasicRequest request)
        {
            NoticeCategoryGetEntityByPrimaryPropertyRequest returnValue = new NoticeCategoryGetEntityByPrimaryPropertyRequest();

            returnValue.Name = request.Name;

            return returnValue;
        }

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NoticeCategoryGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeCategoryUpdateRequest request)
        {
            NoticeCategoryGetEntityByPrimaryPropertyRequest returnValue = new NoticeCategoryGetEntityByPrimaryPropertyRequest();

            returnValue.Name = request.Name;

            return returnValue;
        }
    }
}
