function NoticeUpdateModule(OfficeAutomaticManageService, $convertor) {

    return {
        restrict: 'E',
        templateUrl: 'scripts/module/NoticeUpdateModule.html?v=' + window.releaseNo,
        replace: true,
        scope: {
            api: '='
        },
        link: function (scope, element, attrs) {

            scope.id = Number(attrs.id);

            function notice_empty_callback(response, callback) {

                if (response.status != 1) {
                    return;
                }
                scope.category_selection = response.category;

                if (callback != null) {
                    callback();
                }
            }

            function notice_basic_callback(response, callback) {

                scope.loaded = true;
                if (response.status != 1) {
                    return;
                }

                scope.item = response.item;
                scope.category_key = scope.item.category;

                if (callback != null) {
                    callback();
                }
            }

            function notice_basic() {
                OfficeAutomaticManageService.notice_basic({ id: scope.id }).then(function (response) {
                    notice_basic_callback(response, notice_assign)
                });
            }

            function notice_assign() {
                $convertor.setCurrent(scope, 'category_current', 'category_selection', 'category_key', 'name');
            }

            OfficeAutomaticManageService.notice_empty({}).then(function (response) {
                notice_empty_callback(response, notice_basic);
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
                requestItem.title = $scope.item.title;
                requestItem.body = $scope.item.body;
                if ($scope.category_current != null) {
                    requestItem.category = $scope.category_current.name;
                }

                OfficeAutomaticManageService.notice_update(request).then(function (response) {
                    notice_update_callback(response, updateSuccessCallback);
                });
            }

            function notice_update_callback(response, updateSuccessCallback) {

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
