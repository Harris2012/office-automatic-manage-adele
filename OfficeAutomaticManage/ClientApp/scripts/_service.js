function OfficeAutomaticManageService($resource, $q, $state) {

    function process(result, d){
        if (result.status == 401) {
            localStorage["token"] = "";
            $state.go('app.login', {});
        } else {
            d.reject(result);
        }
    }

    var resource = $resource('api', {}, {

        notice_items: { method: 'POST', url: window.apihost + 'api/notice/items' },
        notice_item: { method: 'POST', url: window.apihost + 'api/notice/item' },
        notice_basic: { method: 'POST', url: window.apihost + 'api/notice/basic' },
        notice_count: { method: 'POST', url: window.apihost + 'api/notice/count' },
        notice_update: { method: 'POST', url: window.apihost + 'api/notice/update' },
        notice_create: { method: 'POST', url: window.apihost + 'api/notice/create' },
        notice_empty: { method: 'POST', url: window.apihost + 'api/notice/empty' },
        notice_enable: { method: 'POST', url: window.apihost + 'api/notice/enable' },
        notice_disable: { method: 'POST', url: window.apihost + 'api/notice/disable' },

        noticeCategory_items: { method: 'POST', url: window.apihost + 'api/notice-category/items' },
        noticeCategory_item: { method: 'POST', url: window.apihost + 'api/notice-category/item' },
        noticeCategory_basic: { method: 'POST', url: window.apihost + 'api/notice-category/basic' },
        noticeCategory_count: { method: 'POST', url: window.apihost + 'api/notice-category/count' },
        noticeCategory_update: { method: 'POST', url: window.apihost + 'api/notice-category/update' },
        noticeCategory_create: { method: 'POST', url: window.apihost + 'api/notice-category/create' },
        noticeCategory_empty: { method: 'POST', url: window.apihost + 'api/notice-category/empty' },
        noticeCategory_enable: { method: 'POST', url: window.apihost + 'api/notice-category/enable' },
        noticeCategory_disable: { method: 'POST', url: window.apihost + 'api/notice-category/disable' },

        metaNoticeCategory_items: { method: 'POST', url: window.apihost + 'api/meta-notice-category/items' },
        metaNoticeCategory_selected_item: { method: 'POST', url: window.apihost + 'api/meta-notice-category/selected-item' },
        metaNoticeCategory_selected_items: { method: 'POST', url: window.apihost + 'api/meta-notice-category/selected-items' },

        user_profile: { method: 'POST', url: window.apihost + 'api/user/profile' }
    });

    return {

        notice_items: function (request) { var d = $q.defer(); resource.notice_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_item: function (request) { var d = $q.defer(); resource.notice_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_basic: function (request) { var d = $q.defer(); resource.notice_basic({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_update: function (request) { var d = $q.defer(); resource.notice_update({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_count: function (request) { var d = $q.defer(); resource.notice_count({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_create: function (request) { var d = $q.defer(); resource.notice_create({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_empty: function (request) { var d = $q.defer(); resource.notice_empty({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_enable: function (request) { var d = $q.defer(); resource.notice_enable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        notice_disable: function (request) { var d = $q.defer(); resource.notice_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        noticeCategory_items: function (request) { var d = $q.defer(); resource.noticeCategory_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_item: function (request) { var d = $q.defer(); resource.noticeCategory_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_basic: function (request) { var d = $q.defer(); resource.noticeCategory_basic({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_update: function (request) { var d = $q.defer(); resource.noticeCategory_update({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_count: function (request) { var d = $q.defer(); resource.noticeCategory_count({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_create: function (request) { var d = $q.defer(); resource.noticeCategory_create({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_empty: function (request) { var d = $q.defer(); resource.noticeCategory_empty({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_enable: function (request) { var d = $q.defer(); resource.noticeCategory_enable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        noticeCategory_disable: function (request) { var d = $q.defer(); resource.noticeCategory_disable({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        metaNoticeCategory_items: function (request) { var d = $q.defer(); resource.metaNoticeCategory_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        metaNoticeCategory_selected_item: function (request) { var d = $q.defer(); resource.metaNoticeCategory_selected_item({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },
        metaNoticeCategory_selected_items: function (request) { var d = $q.defer(); resource.metaNoticeCategory_selected_items({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; },

        user_profile: function (request) { var d = $q.defer(); resource.user_profile({}, request, function (result) { d.resolve(result); }, function (result) { process(result, d); }); return d.promise; }
    }
}
