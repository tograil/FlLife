(function (app) {
    'use strict';

    app.controllers.controller('sidebar', sidebar);

    sidebar.$inject = ['$location', '$route', 'routes'];

    function sidebar($location, $route, routes) {
        
        var vm = this;
        vm.title = 'sidebar';

        activate();

        function activate() {
            getRoutes();
        }

        function getRoutes() {
            vm.routes = routes.filter(
                function (r) {
                    return r.config.settings.type === 'sidebar';
                }).sort(function (r1, r2) {
                    return r1.config.settings.nav > r2.config.settings.nav;
                });
        }
    }
})(flLifeApp);
