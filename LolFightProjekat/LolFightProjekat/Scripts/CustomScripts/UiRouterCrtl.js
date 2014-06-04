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
            templateUrl: '../PartialViews/Proba.html',
           
        })

  }])



