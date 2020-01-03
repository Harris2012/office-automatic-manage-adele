function httpInterceptor() {

    return {
        request: function (config) {
            if (localStorage["token"]) {
                config.headers['authorization'] = 'Bearer ' + localStorage['token'];
            }
            return config;
        }
    }
}