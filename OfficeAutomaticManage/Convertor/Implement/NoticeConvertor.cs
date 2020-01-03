using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Canos.OfficeAutomatic.Contract.Request;
using Canos.OfficeAutomatic.Contract.Vo;
using Canos.OfficeAutomatic.Metadata;
using Canos.OfficeAutomatic.Repository.Entity;
using Canos.OfficeAutomatic.Repository.Request;
using Canos.OfficeAutomatic.Utility;

namespace Canos.OfficeAutomatic.Convertor.Implement
{
    public class NoticeConvertor : INoticeConvertor
    {

        private IMetaNoticeCategoryProvider metaNoticeCategoryProvider;

        public NoticeConvertor(
            IMetaNoticeCategoryProvider metaNoticeCategoryProvider
        )
        {
            this.metaNoticeCategoryProvider = metaNoticeCategoryProvider;
        }

        public NoticeEntity ToEntity(NoticeCreateRequest request)
        {
            NoticeEntity entity = new NoticeEntity();

            var item = request.Item;

            entity.Title = item.Title;
            entity.Body = item.Body;
            entity.Category = item.Category;
            entity.DataStatus = 1;
            entity.CreateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        public NoticeEntity ToEntity(NoticeUpdateRequest request, NoticeEntity oldEntity)
        {
            NoticeEntity entity = new NoticeEntity();

            var item = request.Item;

            entity.Id = request.Id;
            entity.Title = item.Title;
            entity.Body = item.Body;
            entity.Category = item.Category;
            entity.DataStatus = oldEntity.DataStatus;
            entity.CreateTime = oldEntity.CreateTime;
            entity.LastUpdateTime = TimeConvertor.FromMilliTicks(TimeConvertor.ToMilliTicks(DateTime.Now));

            return entity;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public NoticeBasicVo ToBasicVo(NoticeEntity entity)
        {
            NoticeBasicVo vo = new NoticeBasicVo();

            CopyToVo(vo, entity);

            vo.Category = entity.Category;

            return vo;
        }

        /// <summary>
        /// 将entity转换为vo
        /// </summary>
        public NoticeExtendedVo ToExtendedVo(NoticeEntity entity)
        {
            NoticeExtendedVo vo = new NoticeExtendedVo();

            CopyToVo(vo, entity);
            if (!string.IsNullOrEmpty(entity.Category))
            {
                vo.Category = metaNoticeCategoryProvider.ToMetadata(entity.Category);
            }

            return vo;
        }

        public List<NoticeBasicVo> ToBasicVoList(List<NoticeEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<NoticeBasicVo> voList = new List<NoticeBasicVo>();
            foreach (NoticeEntity entity in entityList)
            {
                NoticeBasicVo vo = ToBasicVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        public List<NoticeExtendedVo> ToExtendedVoList(List<NoticeEntity> entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            List<NoticeExtendedVo> voList = new List<NoticeExtendedVo>();
            foreach (NoticeEntity entity in entityList)
            {
                NoticeExtendedVo vo = ToExtendedVo(entity);
                voList.Add(vo);
            }

            return voList;
        }

        /// <summary>
        /// 将entity转换为vo。不包括来自元数据的属性
        /// </summary>
        private void CopyToVo(NoticeVo vo, NoticeEntity entity)
        {
            vo.Id = entity.Id;
            vo.Title = entity.Title;
            vo.Body = entity.Body;
            vo.DataStatus = entity.DataStatus;
            vo.CreateTime = entity.CreateTime;
            vo.LastUpdateTime = entity.LastUpdateTime;
        }


        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NoticeGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeItemRequest request)
        {
            NoticeGetEntityByPrimaryPropertyRequest returnValue = new NoticeGetEntityByPrimaryPropertyRequest();


            return returnValue;
        }

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NoticeGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeBasicRequest request)
        {
            NoticeGetEntityByPrimaryPropertyRequest returnValue = new NoticeGetEntityByPrimaryPropertyRequest();


            return returnValue;
        }

        /// <summary>
        /// 转换为数据库请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public NoticeGetEntityByPrimaryPropertyRequest ToGetEntityByPrimaryProperty(NoticeUpdateRequest request)
        {
            NoticeGetEntityByPrimaryPropertyRequest returnValue = new NoticeGetEntityByPrimaryPropertyRequest();


            return returnValue;
        }
    }
}
