(function () {
    'use strict';

    angular
        .module('MasterOfFraudSecurity')
        .controller('addQuestionaryController', addQuestionaryController);

    addQuestionaryController.$inject = ['$http', 'questionaryService'];

    function addQuestionaryController($http, questionaryService) {
        /* jshint validthis:true */
        var vm = this;
        vm.questionary = {};

        vm.questionaryFields = questionaryService.getQuestionaryFields();

        vm.onSubmit = function () {
            vm.loading = true;
            vm.success = false;
            vm.failure = false;

            vm.questionary.birthDate = changeTimezoneToUTC(vm.questionary.birthDate);

            $http.post("api/Questionary", vm.questionary).then(function success() {
                vm.loading = false;
                vm.success = true;
            },
                function failure() {
                    vm.loading = false;
                    vm.failure = true;
                });
        };

        function changeTimezoneToUTC(date) {
            return new Date(Date.UTC(date.getYear(),
                date.getMonth(), date.getDate()));
        }
    }
})();
