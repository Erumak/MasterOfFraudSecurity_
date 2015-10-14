(function () {
    'use strict';

    angular
        .module('MasterOfFraudSecurity')
        .controller('addQuestionaryController', addQuestionaryController);

    addQuestionaryController.$inject = ['$http'];

    function addQuestionaryController($http) {
        /* jshint validthis:true */
        var vm = this;
        vm.questionary = {};

        vm.questionaryFields = [
            {
                key: "firstName",
                type: "input",
                templateOptions: {
                    label: "First name",
                    placeholder: "Enter first name",
                    required: true
                }
            },
            {
                key: "lastName",
                type: "input",
                templateOptions: {
                    label: "Last name",
                    placeholder: "Enter last name",
                    required: true
                }
            },
            {
                key: "patronymic",
                type: "input",
                templateOptions: {
                    label: "Patronymic",
                    placeholder: "Enter patronymic",
                    required: true
                }
            },
            {
                key: "birthDate",
                type: "input",
                templateOptions: {
                    type: "date",
                    label: "Birth date",
                    required: true
                }
            },
            {
                key: "mobilePhone",
                type: "input",
                templateOptions: {
                    label: "Mobile phone",
                    placeholder: "Enter mobile phone",
                    required: true
                }
            },
            {
                key: "email",
                type: "input",
                templateOptions: {
                    type: "email",
                    label: "Email address",
                    placeholder: "Enter email",
                    required: true
                }
            },
            {
                key: "passportSeries",
                type: "input",
                templateOptions: {
                    label: "Passport series",
                    placeholder: "Enter series",
                    required: true
                }
            },
            {
                key: "passportNumber",
                type: "input",
                templateOptions: {
                    label: "Passport number",
                    placeholder: "Enter number",
                    required: true
                }
            },
            {
                key: "passportIssued",
                type: "input",
                templateOptions: {
                    label: "Passport issued",
                    placeholder: "Enter where and when the password was issued"
                }
            },
            {
                key: "iinPhysic",
                type: "input",
                templateOptions: {
                    label: "IIN",
                    placeholder: "Enter IIN (10 digits)",
                    required: true
                }
            },
            {
                key: "addressLocation",
                type: "input",
                templateOptions: {
                    label: "Address",
                    placeholder: "Enter address location"
                }
            }
        ];

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
