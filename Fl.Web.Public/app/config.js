(function (app) {
    'use strict';



    function getNavigationStrings($http) {
        $http({
            method: 'GET',
            url: '/content',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        }).then(function (result) {
            
        }, function (error) {
            
        });
    }

    app.root.run([
        '$http', getNavigationStrings
    ]);

})(flLifeApp);