(function (app) {
'use strict';

app.services.service("webApi", webApi);

function webApi($q, SweetAlert, $http) {
    return {
        get: get,
        post: post,
        put: put,
        "delete": remove
    };

    function get(url, data) {
        var deffer = $q.defer();
        $http.get(url + getDataString(data))
            .success(function(response) {
                success(response, deffer);
            })
            .error(function(response, code) {
                error(response, deffer, code);
            });
        return deffer.promise;
    }

    function post(url, data) {
        var deffer = $q.defer();
        $http.post(url, data)
            .success(function(response) {
                success(response, deffer);
            })
            .error(function(response, code) {
                error(response, deffer, code);
            });
        return deffer.promise;
    }

    function put(url, data) {
        var deffer = $q.defer();
        $http.put(url, data)
            .success(function(response) {
                success(response, deffer);
            })
            .error(function(response, code) {
                error(response, deffer, code);
            });
        return deffer.promise;
    }

    function remove(url, data) {
        var deffer = $q.defer();
        $http.delete(url, data)
            .success(function(response) {
                success(response, deffer);
            })
            .error(function(response, code) {
                error(response, deffer, code);
            });
        return deffer.promise;
    }

    function getDataString(data) {
        if (!data)
            return "";
        var dataString = "?";
        for (var key in data) {
            if (data.hasOwnProperty(key)) {
                dataString += key + "=" + data[key] + "&";
            }
        }
        return dataString;
    }

    function success(response, deffer) {
        if (!response) {
            SweetAlert.swal({
                title: "Error!",
                text: "Unexpected server error",
                type: "error",
                confirmButtonColor: "#FF0000"
            });
        }
        else {
            deffer.resolve(response);
        }
        /*else if (response.State == "404") {
            deffer.reject(response);
            SweetAlert.swal({
                title: "Message!",
                text: response.Message,
                type: "info",
                confirmButtonColor: "#007aff"
            });
        }
        else {
            deffer.reject(response);
            SweetAlert.swal({
                title: "Error!",
                text: response.Message,
                type: "error",
                confirmButtonColor: "#FF0000"
            });
        }*/
    }

    function error(response, deffer, code) {
        if (!response) {
            SweetAlert.swal({
                title: "Error!",
                text: "Unexpected server error",
                type: "error",
                confirmButtonColor: "#FF0000"
            });
        }
        else if (code == 401) {
            SweetAlert.swal({
                title: "Error!",
                text: response.Message,
                type: "error",
                confirmButtonColor: "#FF0000"
            }, function () {
                
            });
        }
        else {
            deffer.reject(response);
            SweetAlert.swal({
                title: "Error!",
                text: response.Message,
                type: "error",
                confirmButtonColor: "#FF0000"
            });
        }
    }
}

webApi.$inject = ['$q', 'SweetAlert', '$http'];

})(flLifeApp);