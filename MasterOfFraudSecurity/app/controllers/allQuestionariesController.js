(function() {
    'use strict';

    angular
        .module('MasterOfFraudSecurity')
        .controller('allQuestionariesController', allQuestionariesController);

    allQuestionariesController.$inject = ['$http'];

    function allQuestionariesController($http) {
        /* jshint validthis:true */
        var vm = this;
        vm.questionaries = [];

        vm.getFullName = function(questionary) {
            return questionary.lastName + " " + questionary.firstName + " " + questionary.patronymic;
        }

        activate();

        function activate() {
            $http.get("api/questionary").then(function(response) {
                vm.questionaries = response.data;
                return vm.questionaries;
            });
        }
    }
})();
