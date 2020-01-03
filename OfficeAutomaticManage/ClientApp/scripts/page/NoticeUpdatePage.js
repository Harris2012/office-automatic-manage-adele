function NoticeUpdatePage($scope, $state, $stateParams) {

    $scope.id = $stateParams.id;

    $scope.closeModal = function () {
        $uibModalInstance.dismiss("cancel");
    }

    $scope.confirmUpdate = function () {
        if ($scope.api == null) {
            return;
        }
        if ($scope.api.confirmUpdate == null) {
            return;
        }
        $scope.api.confirmUpdate(function () {
            $state.go('app.layout.default.notice-list');
        });
    }
}