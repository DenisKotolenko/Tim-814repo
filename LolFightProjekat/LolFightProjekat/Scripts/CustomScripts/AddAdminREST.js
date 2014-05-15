$scope.save = function () {
    $.ajax({
        type: "POST",
        url: "WebService1.asmx/InsertAdminREST",
        data: "{'idAdmin':'" + $scope.idAdmin + "','Username':'" + 
        $scope.Username + "','Password':'" + $scope.Password +
        "','eMail':'" + $scope.eMail +"'}",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (msg) {
        alert(msg.d);
    },
    error: function (msg) {
        alert(msg.d);
    }
});
};