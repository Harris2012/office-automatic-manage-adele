using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Canos.OfficeAutomatic.Contract.Request;
using Canos.OfficeAutomatic.Contract.Response;
using Canos.OfficeAutomatic.Metadata;

namespace Canos.OfficeAutomatic.Service
{
    [Route("api/meta-notice-category")]
    public class MetaNoticeCategoryController : BaseController
    {
        private IMetaNoticeCategoryProvider metaNoticeCategoryProvider;

        public MetaNoticeCategoryController(IMetaNoticeCategoryProvider metaNoticeCategoryProvider)
        {
            this.metaNoticeCategoryProvider = metaNoticeCategoryProvider;
        }

        [HttpPost]
        [Route("items")]
        public MetaNoticeCategoryItemsResponse Items([FromBody]MetaNoticeCategoryItemsRequest request)
        {
            MetaNoticeCategoryItemsResponse response = new MetaNoticeCategoryItemsResponse();

            response.Items = metaNoticeCategoryProvider.GetMetadataList();

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("selected-item")]
        public MetaNoticeCategorySelectedItemResponse SelectedItem([FromBody]MetaNoticeCategorySelectedItemRequest request)
        {
            MetaNoticeCategorySelectedItemResponse response = new MetaNoticeCategorySelectedItemResponse();

            if (request == null)
            {
                response.Status = 1;
                return response;
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                response.Status = 1;
                return response;
            }

            response.Item = metaNoticeCategoryProvider.ToMetadata(request.Name);

            response.Status = 1;
            return response;
        }

        [HttpPost]
        [Route("selected-items")]
        public MetaNoticeCategorySelectedItemsResponse SelectedItems([FromBody]MetaNoticeCategorySelectedItemsRequest request)
        {
            MetaNoticeCategorySelectedItemsResponse response = new MetaNoticeCategorySelectedItemsResponse();

            if (request == null)
            {
                response.Status = 1;
                return response;
            }

            if (request.Name == null || request.Name.Count == 0)
            {
                response.Status = 1;
                return response;
            }

            response.Items = metaNoticeCategoryProvider.ToMetadataList(request.Name);

            response.Status = 1;
            return response;
        }
    }
}
