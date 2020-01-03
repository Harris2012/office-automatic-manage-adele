function stateProviderConfig($stateProvider) {

    $stateProvider.state('app', { url: '/', template: '<ui-view></ui-view>' });

    $stateProvider.state('app.layout', {
        templateUrl: 'scripts/view/view_layout.html?v=' + window.releaseNo
    });

    $stateProvider.state('app.layout.default', {
        views: {
            'header': { templateUrl: 'scripts/view/view_header.html?v=' + window.releaseNo, controller: HeaderController },
            'main-menu': { templateUrl: 'scripts/view/view_menu.html?v=' + window.releaseNo },
            'main-body': { template: '<ui-view></ui-view>' }
        }
    });

    $stateProvider.state('app.layout.default.welcome', { url: 'welcome', templateUrl: 'scripts/view/view_welcome.html?v=' + window.releaseNo });

    $stateProvider.state('app.layout.default.notice-list', { url: 'notice-list', templateUrl: 'scripts/page/NoticeListPage.html?v=' + window.releaseNo, controller: NoticeListPage });

    $stateProvider.state('app.layout.default.notice-category-list', { url: 'notice-category-list', templateUrl: 'scripts/page/NoticeCategoryListPage.html?v=' + window.releaseNo, controller: NoticeCategoryListPage });

    $stateProvider.state('app.otherwise', {
        url: '*path',
        templateUrl: 'views/view_404.html?v=' + window.releaseNo
    });
}