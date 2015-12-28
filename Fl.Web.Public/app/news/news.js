(function(app) {
    'use strict';

    app.controllers.controller('news', news);

    news.$inject = ['$scope'];

    function news($scope) {
        $scope.title = 'news';

        activate();

        function activate() {}
    }
})(flLifeApp);
