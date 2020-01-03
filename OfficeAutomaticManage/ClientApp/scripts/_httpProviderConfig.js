function httpProviderConfig($httpProvider) {

    $httpProvider.interceptors.push(httpInterceptor);
}