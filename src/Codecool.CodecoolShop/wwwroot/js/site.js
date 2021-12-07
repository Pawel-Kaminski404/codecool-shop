// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function addToCart(id){
    await fetch(`/addProduct?id=${id}`)
        .then(response => response.json())
        .then(data => ChangeCartContent(data));
}


async function ChangeCartContent(data) 
{
    let cartItemsCounter = document.getElementById("shoppingCart");
    let addItemToCart = document.getElementById(`${data[1]}`)
    cartItemsCounter.innerHTML = `<img src="img/ShoppingCartIcon.png" style="width: 20px; height: 20px"/> ${data[0]}`
    addItemToCart.innerHTML = `<button type="button" class="btn btn-outline-primary">Added To Cart</button>`
    
}
