function NoticeItemModule(OfficeAutomaticManageService) {

    return {
        restrict: 'E',
        templateUrl: 'scripts/module/NoticeItemModule.html?v=' + window.releaseNo,
        replace: true,
        scope: {},
        link: function (scope, element, attrs) {

            scope.id = Number(attrs.id);


            //#region 【callback】

            function notice_item_callback(response) {

                scope.loaded = true;
                if (response.status != 1) {
                    return;
                }

                scope.item = response.item;
            }

            //#endregion 【callback】

            {
                var request = {};
                request.id = scope.id;

                OfficeAutomaticManageService.notice_item(request).then(notice_item_callback);
            }
        }
    }
}
