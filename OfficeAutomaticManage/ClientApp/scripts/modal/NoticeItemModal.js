function NoticeItemModal($scope, $uibModalInstance, id) {

    $scope.id = id;


    $scope.closeModal = function () {
        $uibModalInstance.dismiss("cancel");
    }
}
