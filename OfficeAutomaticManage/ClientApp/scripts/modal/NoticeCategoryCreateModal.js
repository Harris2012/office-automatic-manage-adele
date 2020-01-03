function NoticeCategoryCreateModal($scope, $uibModalInstance) {


    $scope.closeModal = function () {
        $uibModalInstance.dismiss("cancel");
    }

    $scope.confirmModal = function () {
        if ($scope.api == null) {
            return;
        }
        if ($scope.api.confirmCreate == null) {
            return;
        }
        $scope.api.confirmCreate(function () {
            $uibModalInstance.close("success");
        });
    }
}
