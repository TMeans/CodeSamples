(function () {
    var canSubmit = true;
    var app = angular.module('tellFriendApp', []);
    app.directive('match', function ($parse) {
        return {
            require: 'ngModel',
            link: function (scope, elem, attrs, ctrl) {                
                scope.$watch(function () {
                    return $parse(attrs.match)(scope) === ctrl.$modelValue;
                }, function (currentValue) {
                    ctrl.$setValidity('mismatch', currentValue);
                });
            }
        };
    });

    app.controller('tellFriendCtrl', ['$http', function ($http) {
	this.name_first_friend = "";
        this.name_last_friend = "";
        this.email_friend = "";
        this.email_friend_2 = "";
        this.phone_friend = "";
        this.name_first = "";
        this.name_last = "";
        this.email = "";
        this.notes = "";
        this.ria = "";

        this.submit = function () {
	    var valid = true;
            if ($("#email_friend").val().length < 1
                || $("#name_first_friend").val().length < 1
                || $("#name_last_friend").val().length < 1
                || $("#phone_friend").val().length < 1
                || $("#name_first").val().length < 1
                || $("#name_last").val().length < 1
                || $("#email").val().length < 1) 
	    {
                valid = false;
            }
          
            if (valid && canSubmit) 
	    {
		$.ajax({
			type: "POST",
			url: "OMITTED"
				+ "?email=" + $("#email_friend").val()
				+ "&first_name=" + $("#name_first_friend").val()
				+ "&last_name=" + $("#name_last_friend").val()
				+ "&phone=" + $("#phone_friend").val()
				+ "&advisor=" + $("#ria").val()
				+ "&referral=" + document.location.href					   
				+ "&notes=" + "first name:" + $("#name_first").val() + ", last name:" + $("#name_last").val() + ", email:" + $("#email").val() + ", notes:" + $("#notes").val(),
			success: function (msg) {
				alert("Thank you.");
			},
			error: function (msg) {
				if (console.log) { console.log(msg) };
			}
		});

		$("#tellFriendButton").html("Thank You");
		canSubmit = false;                
            }
            else 
	    {
                alert("Please complete the entire form.");
            }
        }
    }]);
})();
