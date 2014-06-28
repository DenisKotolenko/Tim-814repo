
angular.module('app', ['ui.router'])
  .config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
      $urlRouterProvider.otherwise('/');
      $stateProvider
         .state('home', {
             url: '/home',
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
          .state('login', {
              url: '/login',
              templateUrl: '../PartialViews/LoginPartial/Index.html'
          })
        .state('prazno', {
            url: '/',
            templateUrl: '../PartialViews/LoginPartial/prazno.html'
        })
      .state('mail', {
          url: '/mail',
          templateUrl: '../PartialViews/MailPartial/MailPartial.html'
      })

      .state('rank', {
          url: '/rank',
          templateUrl: '../PartialViews/RankPartial/RankPartial.html'
      })

         .state('fight', {
             url: '/fight/:attackId/:defendId',
             templateUrl: '../PartialViews/FightPartial/FightPartial.html'
         })

         .state('random', {
             url: '/random/:championId',
             templateUrl: '../PartialViews/FightPartial/RandomPartial.html'
         })

         .state('battles', {
             url: '/battles/:championId',
             templateUrl: '../PartialViews/BattlesPartial/BattlesPartial.html'
         })

  }])


angular.module('app').controller('rank', function ($scope, $http) {

    $http.get('../api/rank').success(function (data) {
        $scope.data = data;
    });
});

angular.module('app').controller('battles', function ($scope, $stateParams, $http) {

    $http.get('../api/battles?championId=' + $stateParams.championId).success(function (data) {
        $scope.data = data;
    });
});

angular.module('app').controller('fight', function ($scope, $stateParams, $http) {

    $http.put('../api/fight?attackId=' + $stateParams.attackId + '&defendId=' + $stateParams.defendId).success(function (data) {
        $scope.data = data;
    });
});

angular.module('app').controller('random', function ($scope, $stateParams, $http) {

    $http.get('../api/fight?championId=' + $stateParams.championId).success(function (data) {
        $scope.data = data;
    });
});

angular.module('app').controller('MailCtrl', function ($scope, $http) {

    $http.get('../api/mailAPI/GetMail/' + $scope.username).success(function (data) {
        $scope.data = data;

    });


    $scope.sendMail = function () {

        alert("Poslana poruka korisniku:" + $scope.reciverName);
        $http.get('../api/MailAPI/SendMail?username=' + $scope.username + "&reciverName=" + $scope.reciverName + "&text=" + $scope.text + "&title=" + $scope.title).success(function (data) {
            $scope.data = data;
        });

    };

});

angular.module('app').controller('getEverythingCtrl', function ($scope, $http) {

    $scope.showInventory = function () {

        alert("prikazuje se inventory:" + $scope.username);
        $http.get('../api/ChampionAPI/ShowInventory?username=' + $scope.username).success(function (data) {
            $scope.inventory = data;
        });

    };


    $http.get('../api/ChampionAPI?username=' + $scope.username).success(function (data) {
        $scope.data = data;

    });



});



angular.module('app').controller('farmingCtrl', function ($scope, $http) {

    $scope.PostFarming = function () {

        alert("Sucsessfull farming! May saint Teo save your soul!");
        $http.get('../api/FarmAPI?username=' + $scope.username).success(function (data) {
            $scope.status = data;
        });

    };


});

angular.module('app').controller('junglingCtrl', function ($scope, $http) {

    $scope.PostJungling = function () {

        alert("Uspješan odlazak u junglu! Neka vas sv.Teo cuva od zla!");
        $http.get('../api/JungleAPI?username=' + $scope.username + "&duration=" + $scope.duration).success(function (data) {
            $scope.status = data;
        });

    };

});




angular.module('app').controller('GetItemsCtrl', function ($scope, $http) {

    $http.get('/api/ShopApi').success(function (data) {
        $scope.Items = data;
    });


    $scope.BuyItem = function (idUser,idItem) {
        
        $http.get('../api/shopapi/buyitem?userid=' + idUser + '&iditem=' + idItem).success(function (data) {
            alert("radi");
            $scope.data = data;
        });

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
                window.location = '../../User#/home';
                AuthService.setUserAuthenticated(true);

                //location.path = '/home';
            }
            else {
                window.location = 'Login';
            }
        });
      

    }
})




angular.module('app').controller("Username", function ($scope, $window) {


    $scope.username = $window.sessionStorage.token;

});

angular.module('app').controller("id", function ($scope, $window, $http) {
    $http.get('../api/id?username=' + $window.sessionStorage.token).success(function (data) {
        $scope.userid = data;
    });
});

angular.module('app').controller("Logout", function ($scope, $window) {
    $scope.Logout = function () {
        $window.sessionStorage.token = "";
        $scope.username = "";

        window.location = '../../Home';
    };

})
angular.module('app').controller('Skill', function ($scope, $http) {
    $scope.AttackUp = function () {

        alert("Successfully added Attack Dmg");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "attack").success(function (data) {
            $scope.status = data;

        });

    };
    $scope.ArmorUp = function () {

        alert("Successfully added Armor");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "armor").success(function (data) {
            $scope.status = data;
        });

    };
    $scope.MagicResistUp = function () {

        alert("Successfully added MagicResistance");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "magicResist").success(function (data) {
            $scope.status = data;
        });

    };
    $scope.AttackSpeedUp = function () {

        alert("Successfully added Attack Speed");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "attackSpeed").success(function (data) {
            $scope.status = data;
        });

    };


    $scope.ArmorPeneUp = function () {

        alert("Successfully added Armor Penetration");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "armorpene").success(function (data) {
            $scope.status = data;
        });

    };
    $scope.MagicPeneUp = function () {

        alert("Successfully added Magic Penetration");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "magicpene").success(function (data) {
            $scope.status = data;
        });

    };
    $scope.HpUp = function () {

        alert("Successfully added Health Points");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "hp").success(function (data) {
            $scope.status = data;
        });

    };
    $scope.CritUp = function () {

        alert("Successfully added Critical Chance");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "crit").success(function (data) {
            $scope.status = data;
        });

    };
    $scope.AbilityUp = function () {

        alert("Successfully added Ability Dmg");
        $http.get('../api/SkillAPI?username=' + $scope.username + "&skillUp=" + "ability").success(function (data) {
            $scope.status = data;
        });

    };
});
angular.module.directive('eatClick', function () {
    return function (scope, element, attrs) {
        $(element).click(function (event) {
            event.preventDefault();
        });
    }
})
