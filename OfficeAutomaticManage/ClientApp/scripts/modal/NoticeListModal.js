function NoticeListModal($scope, $uibModalInstance) {

    $scope.closeModal = function () {
        $uibModalInstance.dismiss("cancel");
    }
}
