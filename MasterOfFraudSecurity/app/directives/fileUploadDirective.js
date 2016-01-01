(function () {
    'use strict';

    angular.module('MasterOfFraudSecurity').directive('fileUpload', fileUpload);

    function fileUpload() {

        return {
            restrict: 'E',
            templateUrl: '/app/views/fileUpload.html',
            controller: fileUploadController,
            controllerAs: "vm"
        }
    }

    fileUploadController.$inject = ['Upload', '$timeout'];

    function fileUploadController(Upload, $timeout) {
        /* jshint validthis:true */
        var vm = this;

        vm.uploadFiles = function (file, errFiles) {
            vm.f = file;
            vm.errFile = errFiles && errFiles[0];
            if (file) {
                file.upload = Upload.upload({
                    url: 'api/questionary/import',
                    data: { file: file }
                });

                vm.loading = true;
                vm.success = false;
                vm.failure = false;

                file.upload.then(function (response) {
                    $timeout(function () {
                        file.result = response.data;
                        vm.loading = false;
                        vm.success = true;
                        vm.error = false;
                    });
                }, function (response) {
                    vm.loading = false;
                    vm.success = false;
                    vm.error = true;
                    vm.errorMsg = response.data.message;
                }, function (evt) {
                    file.progress = Math.min(100, parseInt(100.0 *
                                             evt.loaded / evt.total));
                });
            }
        }
    }
}());