(function(app) {
    'use strict';

    app.root.constant('routes', getRoutes());

    // Configure the routes and route resolvers
    app.root.config(['$routeProvider', 'routes', routeConfigurator]);

    app.root.run([
        '$route', function ($route) {
            // nothing
        }
    ]);

    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });

        $routeProvider.otherwise({ redirectTo: '/news' });
    }

    function getRoutes() {
        return [
            {
                url: '/about',
                config: {
                    templateUrl: 'app/about/about.html',
                    title: 'About',
                    settings: {
                        nav: 1,
                        content: 'О Нас',
                        type: 'topbar'
                    }
                }
            },
            {
                url: '/autism',
                config: {
                    templateUrl: 'app/autism/autism.html',
                    title: 'Autism',
                    settings: {
                        nav: 2,
                        content: 'Аутизм',
                        type: 'topbar'
                    }
                }
            },
            {
                url: '/news',
                config: {
                    templateUrl: 'app/news/news.html',
                    title: 'News',
                    settings: {
                        nav: 3,
                        content: 'Новости',
                        type: 'topbar'
                    }
                }
            },
            {
                url: '/donate',
                config: {
                    templateUrl: 'app/payment/payment.html',
                    title: 'Donate',
                    settings: {
                        nav: 4,
                        content: 'Помочь нам',
                        type: 'topbar'
                    }
                }
            },
            {
                url: '/irc',
                config: {
                    templateUrl: 'app/payment/irc.html',
                    title: 'Irc',
                    settings: {
                        nav: 1,
                        content: 'ИРЦ',
                        type: 'sidebar',
                        button_class: 'cd-btn-1'
                    }
                }
            },
            {
                url: '/school',
                config: {
                    templateUrl: 'app/payment/payment.html',
                    title: 'School',
                    settings: {
                        nav: 2,
                        content: 'Школа',
                        type: 'sidebar',
                        button_class: 'cd-btn-2'
                    }
                }
            },
            {
                url: '/diagnostics',
                config: {
                    templateUrl: 'app/payment/payment.html',
                    title: 'Diagnostics',
                    settings: {
                        nav: 3,
                        content: 'Диагностика',
                        type: 'sidebar',
                        button_class: 'cd-btn-3'
                    }
                }
            },
            {
                url: '/parents',
                config: {
                    templateUrl: 'app/payment/payment.html',
                    title: 'Parents',
                    settings: {
                        nav: 4,
                        content: 'Родителям',
                        type: 'sidebar',
                        button_class: 'cd-btn-4'
                    }
                }
            }
        ];
    }

})(flLifeApp);