// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/*window.onload = function() {
    ChangeCartContent(data)
}*/


async function addToCart(id) {
    await fetch(`/addProduct?id=${id}&userId=1`)
        .then(response => response.json())
        .then(data => ChangeCartContent(data));
}

/*async function deleteFromCart(id) {
    await fetch(`/deleteProduct?id=${id}&userId=1`)
        .then(response => response.json())
        .then(data => ChangeCartBagContent(data))
}*/

async function ChangeCartBagContent(data) {

}


async function ChangeCartContent(data) {
    let cartItemsCounter = document.getElementById("shoppingCart");
    let addItemToCart = document.getElementById(`${data[1]}`)
    cartItemsCounter.innerHTML = `<img src="img/ShoppingCartIcon.png" style="width: 20px; height: 20px"/> ${data[0]}`
    addItemToCart.innerHTML = `<button type="button" class="btn btn-outline-primary">Added To Cart</button>`
}

async function SubmitCheckout() {
    let name = document.getElementById("name").value;
    let email = document.getElementById("email").value;
    let phoneNumber = document.getElementById("phoneNumber").value;
    let address = document.getElementById("address").value;
    let zipCode = document.getElementById("zipCode").value;
    let country = document.getElementById("country").value;
    let city = document.getElementById("city").value;

    let jsonData = {
        "Name": name,
        "Email": email,
        "PhoneNumber": phoneNumber,
        "Address": address,
        "ZipCode": zipCode,
        "Country": country,
        "City": city
    };

    fetch('/Checkout/SendCheckout', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(jsonData),
    }).then(response => {
        if (response.status) {

        }
    })
}

function NameValidate() {
    var nameInput = document.getElementById("name");
    var nameErrorSpan = document.getElementById("nameError");
    if (nameInput.value === "") {
        nameErrorSpan.innerHTML = "Name is empty";
        nameInput.classList.add("error");
    }
}

function NameValidateClear() {
    var nameErrorSpan = document.getElementById("nameError");
    var nameInput = document.getElementById("name");
    clearErrorNotes(nameInput, nameErrorSpan)
}

function EmailValidate() {
    var emailErrorSpan = document.getElementById("emailError");
    var emailInput = document.getElementById("email");
    var isValid = (emailInput.value).toLowerCase().match(
    /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    );
    
    if(isValid === null){
        emailErrorSpan.innerHTML = "With Email is something wrong";
        emailInput.classList.add("error");
    }
    
}

function EmailValidateClear() {
    var emailErrorSpan = document.getElementById("emailError");
    var emailInput = document.getElementById("email");
    clearErrorNotes(emailInput,emailErrorSpan);
}

function PhoneNumberValidate() {
    var phoneNumberErrorSpan = document.getElementById("phoneNumberError");
    var phoneNumberInput = document.getElementById("phoneNumber");
    var isValid = (phoneNumberInput.value).toLowerCase().match(
        /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/
    );
    
    if(isValid === null){
        phoneNumberErrorSpan.innerHTML = "With phone is something wrong";
        phoneNumberInput.classList.add("error");
    }
}

function PhoneNumberValidateClear() {
    var phoneNumberErrorSpan = document.getElementById("phoneNumberError");
    var phoneNumberInput = document.getElementById("phoneNumber");
    clearErrorNotes(phoneNumberInput, phoneNumberErrorSpan);
}

function AddressValidate() {
    var addressErrorSpan = document.getElementById("addressError");
    var addresInput = document.getElementById("address");
    if (addresInput.value === "") {
        addressErrorSpan.innerHTML = "Address is empty";
        addresInput.classList.add("error");
    }
}

function AddressValidateClear() {
    var addressErrorSpan = document.getElementById("addressError");
    var addresInput = document.getElementById("address");
    clearErrorNotes(addresInput, addressErrorSpan);
}

function ZipCodeValidate() {
    var zipCodeErrorSpan = document.getElementById("zipCodeError");
    var zipCodeInput = document.getElementById("zipCode");
    var isValid = (zipCodeInput.value).toLowerCase().match(
        /^\d{2,5}(?:[-\s]\d{3,4})?$/
    );

    if(isValid === null){
        zipCodeErrorSpan.innerHTML = "With Zip Code is something wrong";
        zipCodeInput.classList.add("error");
    }
}

function ZipCodeValidateClear() {
    var zipCodeErrorSpan = document.getElementById("zipCodeError");
    var zipCodeInput = document.getElementById("zipCode");
    clearErrorNotes(zipCodeInput, zipCodeErrorSpan);
}

function CountryValidate() {
    var countryInput = document.getElementById("country");
    var countryErrorSpan = document.getElementById("countryError");
    if (countryInput.value === "") {
        countryErrorSpan.innerHTML = "Country is empty";
        countryInput.classList.add("error");
    }
}

function CountryValidateClear() {
    var countryInput = document.getElementById("country");
    var countryErrorSpan = document.getElementById("countryError");
    clearErrorNotes(countryInput, countryErrorSpan);
    
}

function CityValidate() {
    var cityeInput = document.getElementById("city");
    var cityErrorSpan = document.getElementById("cityError");
    if (cityeInput.value === "") {
        cityErrorSpan.innerHTML = "City is empty";
        cityeInput.classList.add("error");
    }
}

function CityValidateClear() {
    var cityeInput = document.getElementById("city");
    var cityErrorSpan = document.getElementById("cityError");
    clearErrorNotes(cityeInput,cityErrorSpan);
    
}

function clearErrorNotes(input, errorSpan){
    errorSpan.innerHTML = "";
    input.classList.remove("error");
}

