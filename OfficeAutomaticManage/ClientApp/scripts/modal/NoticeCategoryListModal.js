function NoticeCategoryListModal($scope, $uibModalInstance) {

    $scope.closeModal = function () {
        $uibModalInstance.dismiss("cancel");
    }
}
