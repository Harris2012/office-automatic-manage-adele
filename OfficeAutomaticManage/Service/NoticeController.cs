using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Canos.OfficeAutomatic.Contract.Request;
using Canos.OfficeAutomatic.Contract.Response;
using Canos.OfficeAutomatic.Convertor;
using Canos.OfficeAutomatic.Lookup;
using Canos.OfficeAutomatic.Metadata;
using Canos.OfficeAutomatic.Repository;
using Canos.OfficeAutomatic.Repository.Entity;

namespace Canos.OfficeAutomatic.Service
{
    [Route("api/notice")]
    public class NoticeController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private INoticeRepository noticeRepository;

        private INoticeConvertor noticeConvertor;

        private INoticeLookupProvider noticeLookupProvider;

        private IMetaNoticeCategoryProvider metaNoticeCategoryProvider;

        public NoticeController(
            IMetaNoticeCategoryProvider metaNoticeCategoryProvider,
            INoticeRepository noticeRepository,
            INoticeConvertor noticeConvertor,
            INoticeLookupProvider noticeLookupProvider)
        {
            this.noticeRepository = noticeRepository;
            this.noticeConvertor = noticeConvertor;
            this.noticeLookupProvider = noticeLookupProvider;
            this.metaNoticeCategoryProvider = metaNoticeCategoryProvider;
        }

        [HttpPost]
        [Route("items")]
        public NoticeItemsResponse Items([FromBody]NoticeItemsRequest request)
        {
            NoticeItemsResponse response = new NoticeItemsResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            int pageIndex = request.PageIndex != null && request.PageIndex >= 0 ? request.PageIndex.Value : 1;

            List<NoticeEntity> entityList = noticeRepository.GetPagedEntityList(pageIndex, PAGE_SIZE);

            response.Items = noticeConvertor.ToExtendedVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("data")]
        public NoticeDataResponse Data([FromBody]NoticeDataRequest request)
        {
            NoticeDataResponse response = new NoticeDataResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            int pageIndex = request.PageIndex != null && request.PageIndex >= 0 ? request.PageIndex.Value : 1;

            List<NoticeEntity> entityList = noticeRepository.GetPagedEntityList(pageIndex, PAGE_SIZE);

            response.Items = noticeConvertor.ToExtendedVoList(entityList);
            response.Headers = noticeLookupProvider.Headers;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public NoticeCountResponse Count([FromBody]NoticeCountRequest request)
        {
            NoticeCountResponse response = new NoticeCountResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            int count = noticeRepository.GetTotalCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public NoticeItemResponse Item([FromBody]NoticeItemRequest request)
        {
            NoticeItemResponse response = new NoticeItemResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            NoticeEntity entity = null;
            if (request.Id > 0)
            {
                entity = noticeRepository.GetEntityById(request.Id);
            }

            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = noticeConvertor.ToExtendedVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public NoticeCreateResponse Create([FromBody]NoticeCreateRequest request)
        {
            NoticeCreateResponse response = new NoticeCreateResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            noticeRepository.Create(noticeConvertor.ToEntity(request));

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("empty")]
        public NoticeEmptyResponse Empty([FromBody]NoticeEmptyRequest request)
        {
            NoticeEmptyResponse response = new NoticeEmptyResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            response.Category = metaNoticeCategoryProvider.GetMetadataList();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("basic")]
        public NoticeBasicResponse Basic([FromBody]NoticeBasicRequest request)
        {
            NoticeBasicResponse response = new NoticeBasicResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            NoticeEntity entity = null;
            if (request.Id > 0)
            {
                entity = noticeRepository.GetEntityById(request.Id);
            }

            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = noticeConvertor.ToBasicVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public NoticeUpdateResponse Update([FromBody]NoticeUpdateRequest request)
        {
            NoticeUpdateResponse response = new NoticeUpdateResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            if (request.Id > 0)
            {
                NoticeEntity entity = noticeRepository.GetEntityById(request.Id);
                if(entity != null)
                {
                    noticeRepository.UpdateById(noticeConvertor.ToEntity(request, entity));
                    response.Status = 1;
                }
            }

            if (response.Status == 0)
            {
                response.Status = 404;
                return response;
            }

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("enable")]
        public NoticeEnableResponse Enable([FromBody]NoticeEnableRequest request)
        {
            NoticeEnableResponse response = new NoticeEnableResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            noticeRepository.Enable(request.Id);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("disable")]
        public NoticeDisableResponse Disable([FromBody]NoticeDisableRequest request)
        {
            NoticeDisableResponse response = new NoticeDisableResponse();

            if (request == null)
            {
                response.Status = -1;
                return response;
            }

            noticeRepository.Disable(request.Id);

            response.Status = 1;
            return response;
        }
    }
}
