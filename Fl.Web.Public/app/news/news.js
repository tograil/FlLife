(function () {
    'use strict';

    angular
        .module('app')
        .controller('News', news);

    news.$inject = ['$location', 'webApi', 'locale']; 

    function news($location, webApi, locale) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'News';
        vm.news = [];
       
        activate();

        function activate() {
            var url = "/api/news/list";
            var data = {
                locale: locale.getLocale(),
                type: 'news'
            };

            webApi.post(url, data).then(function (dt) {
                vm.news = dt;
            });
        }
    }
})();
