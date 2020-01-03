function NoticeUpdateModal($scope, $uibModalInstance, id) {

    $scope.id = id;


    $scope.closeModal = function () {
        $uibModalInstance.dismiss("cancel");
    }

    $scope.confirmModal = function () {
        if ($scope.api == null) {
            return;
        }
        if ($scope.api.confirmUpdate == null) {
            return;
        }
        $scope.api.confirmUpdate(function () {
            $uibModalInstance.close("success");
        });
    }
}
