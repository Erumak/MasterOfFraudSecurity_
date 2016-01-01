(function() {
    'use strict';

    var app = angular.module('MasterOfFraudSecurity', [
        'ui.router', 'formly', 'formlyBootstrap', 'ngFileUpload']);

    app.config(configRoutes);
    app.run(appRun);

    appRun.$inject = ['$rootScope'];

    function appRun($rootScope) {
        //log all $stateChangeError events since ui-router silently swallows such errors
        $rootScope.$on("$stateChangeError", console.log.bind(console));
    }

    configRoutes.$inject = ["$stateProvider", "$urlRouterProvider"];

    function configRoutes($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise(function($injector) {
            var $state = $injector.get("$state");
            $state.go("home");
        });

        $stateProvider.state("questionary", {
            url: "/questionary",
            controller: "addQuestionaryController",
            controllerAs: "vm",
            templateUrl: "/app/views/questionary.html"
        });

        $stateProvider.state("allQuestionaries", {
            url: "/all",
            controller: "allQuestionariesController",
            controllerAs: "vm",
            templateUrl: "/app/views/allQuestionaries.html"
        });

        //TODO: add route with resolve with stateParams
        $stateProvider.state("viewQuestionary", {
            url: "/view/:id",
            controller: "viewQuestionaryController",
            controllerAs: "vm",
            templateUrl: "/app/views/viewQuestionary.html",
            resolve: {
                questionaryExtended: [
                    "$http", "$stateParams", function($http, $stateParams) {
                        return $http.get("api/questionary/" + $stateParams.id);
                    }
                ]
            }
        });

        $stateProvider.state("home", {
            url: "/home",
            templateUrl: "/app/views/home.html"
        });
    }
})();