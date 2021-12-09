// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



/*window.onload = function() {
    ChangeCartContent(data)
}*/


async function addToCart(id){
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


async function ChangeCartContent(data) 
{
    let cartItemsCounter = document.getElementById("shoppingCart");
    let addItemToCart = document.getElementById(`${data[1]}`)
    cartItemsCounter.innerHTML = `<img src="img/ShoppingCartIcon.png" style="width: 20px; height: 20px"/> ${data[0]}`
    addItemToCart.innerHTML = `<button type="button" class="btn btn-outline-primary">Added To Cart</button>`
}

function PaymentSelectChange() {
    console.log(document.getElementById("paymentOption").value);
}
