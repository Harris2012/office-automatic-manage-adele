function NoticeCategoryUpdateModule(OfficeAutomaticManageService, $convertor) {

    return {
        restrict: 'E',
        templateUrl: 'scripts/module/NoticeCategoryUpdateModule.html?v=' + window.releaseNo,
        replace: true,
        scope: {
            api: '='
        },
        link: function (scope, element, attrs) {

            scope.id = Number(attrs.id);

            function noticeCategory_empty_callback(response, callback) {

                if (response.status != 1) {
                    return;
                }

                if (callback != null) {
                    callback();
                }
            }

            function noticeCategory_basic_callback(response, callback) {

                scope.loaded = true;
                if (response.status != 1) {
                    return;
                }

                scope.item = response.item;

                if (callback != null) {
                    callback();
                }
            }

            function noticeCategory_basic() {
                OfficeAutomaticManageService.noticeCategory_basic({ id: scope.id }).then(function (response) {
                    noticeCategory_basic_callback(response, noticeCategory_assign)
                });
            }

            function noticeCategory_assign() {
            }

            OfficeAutomaticManageService.noticeCategory_empty({}).then(function (response) {
                noticeCategory_empty_callback(response, noticeCategory_basic);
            });

        },
        controller: function ($scope) {

            $scope.api = {};

            $scope.api.confirmUpdate = function (updateSuccessCallback) {

                $scope.waiting = true;
                $scope.message = null;

                var request = {};
                request.id = $scope.item.id;
                var requestItem = request.item = {};
                requestItem.name = $scope.item.name;
                requestItem.title = $scope.item.title;
                requestItem.remark = $scope.item.remark;

                OfficeAutomaticManageService.noticeCategory_update(request).then(function (response) {
                    noticeCategory_update_callback(response, updateSuccessCallback);
                });
            }

            function noticeCategory_update_callback(response, updateSuccessCallback) {

                $scope.waiting = false;

                if (response.status != 1) {
                    $scope.message = response.message;
                    return;
                }

                if (updateSuccessCallback != null) {
                    updateSuccessCallback();
                }
            }
        }
    }
}
