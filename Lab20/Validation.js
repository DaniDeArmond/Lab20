
function validate() {

   
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var emailReg = new RegExp ("^[A-z\@.]+$");
    if (name === '' || email === '') {
        alert("Please fill all fields...!!!!!!");
        return false;
    } else if (!emailReg.test(email)) {
        alert("Invalid Email...!");
        return false;
    } else {
        return true;
    }
}