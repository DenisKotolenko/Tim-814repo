/// <reference path="Shop/Index.cshtml" />
/// <reference path="../PartialViews/Proba.html" />
/// <reference path="../PartialViews/Proba.html" />
/// <reference path="../PartialViews/Proba.html" />
/// <reference path="../PartialViews/Proba.html" />
angular
  .module('app', [
    'ui.router'
  ])
  .config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
      $urlRouterProvider.otherwise('/');
      $stateProvider
         .state('home', {
          url: '/',
          templateUrl: '../PartialViews/UserPartial/UserPartial.html'

        })

        .state('shop', {
            url: '/shop',
            templateUrl: '../PartialViews/ShopPartial/ShopPartial.html',
            controller: 'GetItemsCtrl'
        })


  }])


angular
.module('app')
.controller('GetItemsCtrl', function ($scope, $http) {
   
    $http.get('/api/ShopApi').success(function (data) {
        $scope.Items = data;
    });

    $scope.BuyItem = function (Price) {
        var i = $scope.names.indexOf(Price);
        $scope.names.splice(i, 1);
    };
});


/*
angular
  .module('app')
  .controller('homeCtrl', ['$scope', 'Friends', function ($scope, Friends) {
      $scope.title = "Home";
      Friends.get().then(function (data) {
          $scope.friends = data;
      });
      $scope.items = ['home', 'about', 'contact'];
      $scope.selectedValue = 'home';

      $scope.save = function () {
          $http.post('/api/friends', friends);
      };
  }]);

*/