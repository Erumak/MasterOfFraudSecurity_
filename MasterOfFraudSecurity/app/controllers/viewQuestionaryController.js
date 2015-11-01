(function() {
    'use strict';

    angular
        .module('MasterOfFraudSecurity')
        .controller('viewQuestionaryController', viewQuestionaryController);

    viewQuestionaryController.$inject = ['questionaryExtended'];

    function viewQuestionaryController(questionaryExtended) {
        /* jshint validthis:true */
        var vm = this;
        vm.questionaryExtended = questionaryExtended.data;
        vm.getMatches = function(fieldName) {
            var matching = _.find(vm.questionaryExtended.matchingFields, getFilterFunction(fieldName));
            if (matching) {
                return matching.questionaries;
            }
        };
        vm.hasMatches = function(fieldName) {
            return _.any(vm.questionaryExtended.matchingFields, getFilterFunction(fieldName));
        };

        function getFilterFunction(fieldName) {
            return function(f) {
                return f.fieldName === fieldName;
            }
        }
    }
})();
