var flLifeApp = (function () {
    'use strict';

    angular.module('app', [
        //Submodules
        'app.services',
        'app.controllers',
        'app.directives',

        // Angular modules 
        'ngRoute'

        // Custom modules 

        // 3rd Party Modules
        
    ]);

    angular.module('app.services', []);
    angular.module('app.controllers', []);
    angular.module('app.directives', []);

    return {
        root: angular.module('app'),
        services: angular.module('app.services'),
        controllers: angular.module('app.controllers'),
        directives: angular.module('app.directives')
    }

})();