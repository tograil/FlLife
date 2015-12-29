(function (app) {
    'use strict';

    app.services.factory('$news', news);

    news.$inject = ['$http', 'locale'];

    function news($http, locale) {
        var service = {
            getNews: getNews
        };

        return service;

        function getNews(resulting) {
            $http({
                method: 'POST',
                url: '/api/news/list',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: {
                    locale: locale.getLocale(),
                    type: 'news'
                }
            }).then(function (result) {
                resulting(result.data);
            }, function (error) {
                alert(error);
            });
        }
    }
})(flLifeApp);