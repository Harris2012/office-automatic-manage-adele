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
    [Route("api/notice-category")]
    public class NoticeCategoryController : BaseController
    {
        /// <summary>
        /// 分页，每页个数
        /// </summary>
        private static readonly int PAGE_SIZE = 15;

        private INoticeCategoryRepository noticeCategoryRepository;

        private INoticeCategoryConvertor noticeCategoryConvertor;

        private INoticeCategoryLookupProvider noticeCategoryLookupProvider;

        private IMetaNoticeCategoryProvider metaNoticeCategoryProvider;

        public NoticeCategoryController(
            IMetaNoticeCategoryProvider metaNoticeCategoryProvider,
            INoticeCategoryRepository noticeCategoryRepository,
            INoticeCategoryConvertor noticeCategoryConvertor,
            INoticeCategoryLookupProvider noticeCategoryLookupProvider)
        {
            this.noticeCategoryRepository = noticeCategoryRepository;
            this.noticeCategoryConvertor = noticeCategoryConvertor;
            this.noticeCategoryLookupProvider = noticeCategoryLookupProvider;
            this.metaNoticeCategoryProvider = metaNoticeCategoryProvider;
        }

        [HttpPost]
        [Route("items")]
        public NoticeCategoryItemsResponse Items([FromBody]NoticeCategoryItemsRequest request)
        {
            NoticeCategoryItemsResponse response = new NoticeCategoryItemsResponse();

            int pageIndex = request.PageIndex != null && request.PageIndex >= 0 ? request.PageIndex.Value : 1;

            List<NoticeCategoryEntity> entityList = noticeCategoryRepository.GetPagedEntityList(pageIndex, PAGE_SIZE);

            response.Items = noticeCategoryConvertor.ToExtendedVoList(entityList);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("data")]
        public NoticeCategoryDataResponse Data([FromBody]NoticeCategoryDataRequest request)
        {
            NoticeCategoryDataResponse response = new NoticeCategoryDataResponse();

            int pageIndex = request.PageIndex != null && request.PageIndex >= 0 ? request.PageIndex.Value : 1;

            List<NoticeCategoryEntity> entityList = noticeCategoryRepository.GetPagedEntityList(pageIndex, PAGE_SIZE);

            response.Items = noticeCategoryConvertor.ToExtendedVoList(entityList);
            response.Headers = noticeCategoryLookupProvider.Headers;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("count")]
        public NoticeCategoryCountResponse Count([FromBody]NoticeCategoryCountRequest request)
        {
            NoticeCategoryCountResponse response = new NoticeCategoryCountResponse();

            int count = noticeCategoryRepository.GetTotalCount();

            response.TotalCount = count;

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("item")]
        public NoticeCategoryItemResponse Item([FromBody]NoticeCategoryItemRequest request)
        {
            NoticeCategoryItemResponse response = new NoticeCategoryItemResponse();

            NoticeCategoryEntity entity = null;
            if (request.Id > 0)
            {
                entity = noticeCategoryRepository.GetEntityById(request.Id);
            }

            if (entity == null)
            {
                var repositoryRequest = noticeCategoryConvertor.ToGetEntityByPrimaryProperty(request);
                entity = noticeCategoryRepository.GetEntityByPrimaryProperty(repositoryRequest);
            }

            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = noticeCategoryConvertor.ToExtendedVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("create")]
        public NoticeCategoryCreateResponse Create([FromBody]NoticeCategoryCreateRequest request)
        {
            NoticeCategoryCreateResponse response = new NoticeCategoryCreateResponse();

            noticeCategoryRepository.Create(noticeCategoryConvertor.ToEntity(request));

            metaNoticeCategoryProvider.Reload();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("empty")]
        public NoticeCategoryEmptyResponse Empty([FromBody]NoticeCategoryEmptyRequest request)
        {
            NoticeCategoryEmptyResponse response = new NoticeCategoryEmptyResponse();


            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("basic")]
        public NoticeCategoryBasicResponse Basic([FromBody]NoticeCategoryBasicRequest request)
        {

            NoticeCategoryBasicResponse response = new NoticeCategoryBasicResponse();

            NoticeCategoryEntity entity = null;
            if (request.Id > 0)
            {
                entity = noticeCategoryRepository.GetEntityById(request.Id);
            }

            if (entity == null)
            {
                var repositoryRequest = noticeCategoryConvertor.ToGetEntityByPrimaryProperty(request);
                entity = noticeCategoryRepository.GetEntityByPrimaryProperty(repositoryRequest);
            }

            if (entity == null)
            {
                response.Status = 404;
                return response;
            }

            response.Item = noticeCategoryConvertor.ToBasicVo(entity);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("update")]
        public NoticeCategoryUpdateResponse Update([FromBody]NoticeCategoryUpdateRequest request)
        {

            NoticeCategoryUpdateResponse response = new NoticeCategoryUpdateResponse();

            if (request.Id > 0)
            {
                NoticeCategoryEntity entity = noticeCategoryRepository.GetEntityById(request.Id);
                if(entity != null)
                {
                    noticeCategoryRepository.UpdateById(noticeCategoryConvertor.ToEntity(request, entity));
                    response.Status = 1;
                }
            }

            if (response.Status == 0)
            {
                var repositoryRequest = noticeCategoryConvertor.ToGetEntityByPrimaryProperty(request);
                NoticeCategoryEntity entity = noticeCategoryRepository.GetEntityByPrimaryProperty(repositoryRequest);
                if(entity != null)
                {
                    noticeCategoryRepository.UpdateByPrimaryProperty(noticeCategoryConvertor.ToEntity(request, entity));
                    response.Status = 1;
                }
            }

            if (response.Status == 0)
            {
                response.Status = 404;
                return response;
            }

            metaNoticeCategoryProvider.Reload();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("enable")]
        public NoticeCategoryEnableResponse Enable([FromBody]NoticeCategoryEnableRequest request)
        {
            NoticeCategoryEnableResponse response = new NoticeCategoryEnableResponse();

            noticeCategoryRepository.Enable(request.Id);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("disable")]
        public NoticeCategoryDisableResponse Disable([FromBody]NoticeCategoryDisableRequest request)
        {
            NoticeCategoryDisableResponse response = new NoticeCategoryDisableResponse();

            noticeCategoryRepository.Disable(request.Id);

            response.Status = 1;
            return response;
        }
    }
}
