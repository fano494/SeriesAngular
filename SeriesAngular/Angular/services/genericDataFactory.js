(function () {
    'use strict';

    angular.module("genericDataFactoryModule", []).factory('GenericDataFactory', GenericDataFactory);

    GenericDataFactory.$inject = ['$http', '$q'];

    function GenericDataFactory($http, $q) {
        return {
            get: function (urlGet) {
                var deferred = $q.defer();

                $http.get(urlGet).success(function (result) {
                    deferred.resolve(result);
                }).error(function (err) {
                    deferred.reject(err);
                });

                return deferred.promise;
            },

            post: function (url, objectToSave) {
                var deferred = $q.defer();

                var params = {
                    method: 'POST',
                    url: url
                };

                params.headers = {
                    'Content-Type': 'application/json'
                }

                if (objectToSave) {
                    params.data = angular.toJson(objectToSave);

                } else {
                    params.data = {};
                }

                $http(params).success(function (result) {
                    deferred.resolve(result);
                }).error(function (err) {
                    deferred.reject(err);
                });

                return deferred.promise;
            },

            remove: function (url) {
                var deferred = $q.defer();
                var params = {
                    method: 'DELETE',
                    url: url
                };

                $http(params).success(function (result) {
                    deferred.resolve(result);
                }).error(function (err) {
                    deferred.reject(err);
                });

                return deferred.promise;
            }
        };
    };
})();