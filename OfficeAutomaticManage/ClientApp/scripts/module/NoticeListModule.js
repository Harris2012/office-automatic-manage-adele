function NoticeListModule(OfficeAutomaticManageService, $uibModal) {

    return {
        restrict: 'E',
        templateUrl: 'scripts/module/NoticeListModule.html?v=' + window.releaseNo,
        replace: true,
        scope: {},
        link: function (scope, element, attrs) {


            //#region 【callback】

            function notice_items_callback(response) {

                scope.items_loaded = true;
                if (response.status != 1) {
                    scope.items_message = response.message;
                    return;
                }

                scope.items = response.items;
            }

            function notice_count_callback(response) {

                scope.count_loaded = true;
                if (response.status != 1) {
                    scope.count_message = response.message;
                    return;
                }

                scope.totalCount = response.totalCount;
            }

            function notice_disable_callback(response) {

                if (response.status != 1) {
                    return;
                }

                scope.pageChanged();
            }

            //#endregion 【callback】

            scope.openCreate = function () {

                var modalInstance = $uibModal.open({
                    size: 'lg',
                    animation: true,
                    backdrop: 'static',
                    templateUrl: 'scripts/modal/NoticeCreateModal.html?v=' + window.releaseNo,
                    controller: NoticeCreateModal,
                    resolve: {
                    }
                });

                modalInstance.result.then(function (response) {
                    scope.refresh();
                }, function () {
                });
            }

            scope.openItem = function (id) {

                var modalInstance = $uibModal.open({
                    size: 'lg',
                    animation: true,
                    backdrop: 'static',
                    templateUrl: 'scripts/modal/noticeItemModal.html?v=' + window.releaseNo,
                    controller: NoticeItemModal,
                    resolve: {
                        id: function () { return id; }
                    }
                });

                modalInstance.result.then(function (response) { }, function () { });
            }

            scope.openUpdate = function (id) {

                var modalInstance = $uibModal.open({
                    size: 'lg',
                    animation: true,
                    backdrop: 'static',
                    templateUrl: 'scripts/modal/NoticeUpdateModal.html?v=' + window.releaseNo,
                    controller: NoticeUpdateModal,
                    resolve: {
                        id: function () { return id; }
                    }
                });

                modalInstance.result.then(function (response) {
                    scope.refresh();
                }, function () {
                });
            }

            scope.pageChanged = function () {

                scope.items_loaded = false;
                scope.items_message = null;

                var request = {};
                request.pageIndex = scope.currentPage;

                OfficeAutomaticManageService.notice_items(request).then(notice_items_callback);
            }

            scope.disable = function (id) {

                OfficeAutomaticManageService.notice_disable({ id: id }).then(notice_disable_callback);
            }

            scope.refresh = function () {

                {
                    var request = {};
                    OfficeAutomaticManageService.notice_count(request).then(notice_count_callback);
                }

                {
                    var request = {};
                    request.pageIndex = scope.currentPage;
                    OfficeAutomaticManageService.notice_items(request).then(notice_items_callback);
                }
            }

            {
                scope.maxSize = 10;
                scope.currentPage = 1;
                scope.pageSize = 20;

                scope.refresh();
            }
        }
    }
}
