function NoticeCategoryListModule(OfficeAutomaticManageService, $uibModal) {

    return {
        restrict: 'E',
        templateUrl: 'scripts/module/NoticeCategoryListModule.html?v=' + window.releaseNo,
        replace: true,
        scope: {},
        link: function (scope, element, attrs) {


            //#region 【callback】

            function noticeCategory_items_callback(response) {

                scope.items_loaded = true;
                if (response.status != 1) {
                    scope.items_message = response.message;
                    return;
                }

                scope.items = response.items;
            }

            function noticeCategory_count_callback(response) {

                scope.count_loaded = true;
                if (response.status != 1) {
                    scope.count_message = response.message;
                    return;
                }

                scope.totalCount = response.totalCount;
            }

            function noticeCategory_disable_callback(response) {

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
                    templateUrl: 'scripts/modal/NoticeCategoryCreateModal.html?v=' + window.releaseNo,
                    controller: NoticeCategoryCreateModal,
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
                    templateUrl: 'scripts/modal/noticeCategoryItemModal.html?v=' + window.releaseNo,
                    controller: NoticeCategoryItemModal,
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
                    templateUrl: 'scripts/modal/NoticeCategoryUpdateModal.html?v=' + window.releaseNo,
                    controller: NoticeCategoryUpdateModal,
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

                OfficeAutomaticManageService.noticeCategory_items(request).then(noticeCategory_items_callback);
            }

            scope.disable = function (id) {

                OfficeAutomaticManageService.noticeCategory_disable({ id: id }).then(noticeCategory_disable_callback);
            }

            scope.refresh = function () {

                {
                    var request = {};
                    OfficeAutomaticManageService.noticeCategory_count(request).then(noticeCategory_count_callback);
                }

                {
                    var request = {};
                    request.pageIndex = scope.currentPage;
                    OfficeAutomaticManageService.noticeCategory_items(request).then(noticeCategory_items_callback);
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
