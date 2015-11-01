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
        vm.suspiciousQuestionaries = [];

        vm.getFullName = function(questionary) {
            return questionary.lastName + " " + questionary.firstName + " " + questionary.patronymic;
        }

        activate();

        function activate() {
            $http.get("api/questionary").then(function(response) {
                vm.questionaries = response.data;
                return vm.questionaries;
            });
            $http.get("api/questionary/suspicious").then(function(response) {
                vm.suspiciousQuestionaries = response.data;
                return vm.suspiciousQuestionaries;
            });
        }
    }
})();
