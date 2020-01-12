angular.module('orientalRugGalleryApp', ["ngFileUpload"])
    .controller('imageManagementCtrl', ['$scope', 'Upload', '$timeout', "$window", "$http", function ($scope, Upload, $timeout, $window, $http) {
        $scope.images = [];

        $scope.resolveImages = function() {
            $http.get("/api/rug/" + $window.id).then(function (response) {
                var rug = response.data;
                $scope.images = rug.images.map(function (imageId) {
                    return { 
                        key: imageId,
                        url: "/api/image/" + imageId
                    };
                });
            });
        };

        $scope.resolveImages();
        
        $scope.deleteImage = function(key) {
            $http.delete("/rug/image/" + $window.id + "/delete/" + key).then(function () {
                $scope.resolveImages();
            });
        };
        
        $scope.$watch('files', function () {
            $scope.upload($scope.files);
        });
        $scope.$watch('file', function () {
            if ($scope.file != null) {
                $scope.files = [$scope.file];
            }
        });
        $scope.log = '';

        $scope.upload = function (files) {
            if (files && files.length) {
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    if (!file.$error) {
                        Upload.upload({
                            url: "/rug/image/" + $window.id + "/upload",
                            data: {
                                file: file
                            }
                        }).then(function (resp) {
                            $timeout(function () {
                                $scope.log = 'file: ' + resp.config.data.file.name + ', Response: ' + JSON.stringify(resp.data) +  '\n' + $scope.log;

                                $scope.resolveImages();
                            });
                        }, null, function (evt) {
                            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                            $scope.log = 'progress: ' + progressPercentage + '% ' + evt.config.data.file.name + '\n' + $scope.log;
                        });
                    }
                }
            }
        };
    }]);