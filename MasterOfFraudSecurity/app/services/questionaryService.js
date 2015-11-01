(function() {
    'use strict';

    angular
        .module('MasterOfFraudSecurity')
        .factory('questionaryService', questionaryService);


    function questionaryService() {
        var service = {
            getQuestionaryFields: getQuestionaryFields
        };

        return service;

        function getQuestionaryFields() {
            return [
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
                    key: "firstName",
                    type: "input",
                    templateOptions: {
                        label: "First name",
                        placeholder: "Enter first name",
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
        }
    }
})();