//Module
var app = angular.module('app', ['ngResource', 'ui.router', 'ui.bootstrap', 'ui.sortable', 'ngCanos']);

//Config
app.factory(httpInterceptor);
app.config(httpProviderConfig);
app.config(stateProviderConfig);
app.config(urlRouterProviderConfig);

//Directive
app.directive('noticeListModule', NoticeListModule);
app.directive('noticeItemModule', NoticeItemModule);
app.directive('noticeCreateModule', NoticeCreateModule);
app.directive('noticeUpdateModule', NoticeUpdateModule);
app.directive('noticeCategoryListModule', NoticeCategoryListModule);
app.directive('noticeCategoryItemModule', NoticeCategoryItemModule);
app.directive('noticeCategoryCreateModule', NoticeCategoryCreateModule);
app.directive('noticeCategoryUpdateModule', NoticeCategoryUpdateModule);

//service
app.service('OfficeAutomaticManageService', ['$resource', '$q', '$state', OfficeAutomaticManageService]);
