
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

         .state('farmjungle', {
             url: '/farmjungle',
             templateUrl: '../PartialViews/FarmJunglePartial/FarmJunglePartial.html'
         })
      
  }])

angular.module('app').controller('getEverythingCtrl', function ($scope, $http) {

       

    
            $http.get('../api/ChampionAPI?username=' + $scope.username).success(function (data) {
            $scope.data = data;
            
        });

    

});



angular.module('app').controller('farmingCtrl', function ($scope, $http) {


    alert("radiFarmingCtrl");
});

angular.module('app').controller('junglingCtrl', function ($scope, $http) {

    $scope.PostJungling = function () {
        
        alert("Uspješan odlazak u junglu! Neka vas sv.Teo cuva od zla!");
    $http.get('../api/JungleAPI?username=' + $scope.username + "&duration="+$scope.duration).success(function (data) {
        $scope.status = data;
    });

    };

});



angular.module('app').controller('GetItemsCtrl', function ($scope, $http) {
   
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
angular.module('app').controller("Login", function ($scope, $http, $window) {

    $scope.login = {};

    $scope.login.submitTheForm = function (item, event) {
        console.log("--> Submitting form");


        var dataObject = {
            user: $scope.login.name,
            pass: $scope.login.pass
        };
     
        var responsePromise = $http.get("api/LoginApi/Login?username=" + dataObject.user + "&pass=" + dataObject.pass, {});

        responsePromise.success(function (data) {
            if (data != "null") {
                $scope.user = data;
                $window.sessionStorage.token = dataObject.user;
                window.location = '../../User/Index';
                AuthService.setUserAuthenticated(true);

                //location.path = '/home';
            }
            else {
                window.location = 'index.html#';
            }
        });

    }
})
angular.module('app').controller("Username", function ($scope, $window) {

   
    $scope.username = $window.sessionStorage.token;

});
angular.module('app').controller("Logout", function ($scope, $window) {
    $scope.Logout = function () {
        $window.sessionStorage.token = "";
        $scope.username = "";

        window.location = '../../Home';
    };

})
