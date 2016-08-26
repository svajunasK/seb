(function () {
    'use strict';

    angular
        .module('app.currencyRates')
        .controller('CurrencyRatesCtrl', CurrencyRatesCtrl);

    CurrencyRatesCtrl.$inject = ['$scope', 'currencyRatesResource'];

    function CurrencyRatesCtrl($scope, currencyRatesResource) {
        var ctrl = this;

        ctrl.currencyRates = {}
        ctrl.initDate = '2015-01-01'

        ctrl.loadCurrencyRates = loadCurrencyRates;
        
        init();

        /////////////////////
        function init() {
            loadCurrencyRates(ctrl.initDate);
        }

        function loadCurrencyRates(date) {
            currencyRatesResource.get({ date: date }, function (success) {
                ctrl.currencyRates = success;
            });
        }
    }
})();
