(function () {
    'use strict';

    angular
        .module('app.currencyRates')
        .factory('currencyRatesResource', v);

    currencyRatesResource.$inject = ['$http'];

    function currencyRatesResource($http) {
        var service = {
            get: get
        };

        return service;

        function get() {
            //TODO: not implemented
        }
    }
})();