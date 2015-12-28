(function (app) {
    'use strict';

    app.controllers.controller('navbar', navbar);

    navbar.$inject = ['$location', '$route', 'routes'];

    function navbar($location, $route, routes) {
        /* jshint validthis:true */
        var vm = this;
        vm.routes = routes;
        vm.isCurrent = isCurrent;

        activate();

        function activate() {
            getRoutes();
        }

        function isCurrent(route) {
            if (!route.config.title || !$route.current || !$route.current.title) {
                return '';
            }
            var menuName = route.config.title;
            return $route.current.title.substr(0, menuName.length) === menuName ? 'cd-navbar-btn-active' : '';
        }
        
        function getRoutes() {
            vm.routes = routes.filter(
                function(r) {
                    return r.config.settings.type === 'topbar';
                }).sort(function (r1, r2) {
                    return r1.config.settings.nav > r2.config.settings.nav;
                });
        }
    }
})(flLifeApp);
