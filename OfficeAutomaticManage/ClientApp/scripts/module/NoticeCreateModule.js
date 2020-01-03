function NoticeCreateModule(OfficeAutomaticManageService, $convertor) {

    return {
        restrict: 'E',
        templateUrl: 'scripts/module/NoticeCreateModule.html?v=' + window.releaseNo,
        replace: true,
        scope: {
            api: '='
        },
        link: function (scope, element, attrs) {


            function notice_empty_callback(response, callback) {

                if (response.status != 1) {
                    return;
                }
                scope.category_selection = response.category;

                if (callback != null) {
                    callback();
                }
            }

            //属性
            //_properties_event(builder, name, subject, subjectMap, metadataMap, cascadeMap, false);

            OfficeAutomaticManageService.notice_empty({}).then(notice_empty_callback);
        },
        controller: function ($scope) {

            //#region 【api】

            $scope.api = {};

            $scope.api.confirmCreate = function (createSuccessCallback) {

                $scope.waiting = true;
                $scope.message = null;

                var request = {};
                var requestItem = request.item = {};
                requestItem.title = $scope.item.title;
                requestItem.body = $scope.item.body;
                if ($scope.category_current != null) {
                    requestItem.category = $scope.category_current.name;
                }

                OfficeAutomaticManageService.notice_create(request).then(function (response) {
                    notice_create_callback(response, createSuccessCallback)
                });
            }

            //#endregion 【api】

            //#region 【callback】

            function notice_create_callback(response, createSuccessCallback) {

                $scope.waiting = false;

                if (response.status != 1) {
                    $scope.message = response.message;
                    return;
                }

                if (createSuccessCallback != null) {
                    createSuccessCallback();
                }
            }

            //#endregion 【callback】
        }
    }
}
