//var working = false;
//$('.login').on('submit', function(e) {
//    e.preventDefault();



  //var username = $('#usernameInput').val();
  //var password = $('#passwordInput').val();
//  console.log(username, password);

//  if (username.trim().length == 0 || password.trim().length == 0) {
//      $('#errorMessage').html('<p style="color: red;">Username or password are empty.</p>');
//  } else {
//      if (working) return;
//      working = true;

//      var $this = $(this);
//      var $state = $this.find('button > .state');

//      $this.addClass('loading');
//      $state.html('Authenticating');

//      $.post('Login/Login', { Username: username, Password: password })
//          .success(function (resp) {
//              console.log(resp);
//          })
//          .fail(function (err) {
//              $('#errorMessage').html('<p style="color: red;">User does not exist.</p>');
//              console.log(err)
//              $state.html('Log in');
//              $this.removeClass('ok loading');
//              working = false;
//          });
//  }
//});

$(document).ready(function () {
    var $submit = $("button[type=submit]")
    var $inputs = $('input[type=text], input[type=password]');

    function checkEmpty() {

        // filter over the empty inputs

        return $inputs.filter(function () {
            return !$.trim(this.value);
        }).length === 0;
    }

    $inputs.on('blur', function () {
        $submit.prop("disabled", !checkEmpty());
    }).blur(); // trigger an initial blur
});