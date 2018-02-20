
function validate() {

   
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var emailReg = "^[\@]+[.]+$";
    if (name === '' || email === '') {
        alert("Please fill all fields...!!!!!!");
        return false;
    } else if (!(email).match(emailReg)) {
        alert("Invalid Email...!!!!!!");
        return false;
    } else {
        return true;
    }
}