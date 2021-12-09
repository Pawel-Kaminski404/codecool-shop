// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function RefreshProducts(filter)
{
    let url = "";
    if (filter == 'category') {
        let category = document.getElementById("categories").value;
        url = `/getProducts?filter=${category}&filterBy=category`;
    }
    else {
        let suplier = document.getElementById("supliers").value;
        url = `/getProducts?filter=${suplier}&filterBy=supplier`;
    }
    await fetch(url)
        .then(response => response.json())
        .then(data => DisplayContent(data));
}

async function DisplayContent(data)
{
    document.getElementById("productContainer").innerHTML = "";
    for (item in data)
    {
        document.getElementById("productContainer").innerHTML += `<div class="col-lg-3 col-lg-3" style="display: inline-block; max-width: 350px; height: 350px">
            <div class="card">
                <img src="img/${data[item].Name}.jpg" style="height: 50%; width: 50%; align-self: center; padding-top: 10px">

                <div class="card-body">
                    <h5 class="card-title text-center">
                        Product
                        ${parseInt(item) + 1}
                    </h5>
                    <h5 class="card-title">${data[item].Name}</h5>
                    <p class="card-text">${data[item].Description}.</p>
                    <p class="card-text">Category: ${data[item].ProductCategory.Department}</p>
                    <p class="card-text">Supplier: ${data[item].Supplier.Name}</p>
                    <p class="card-text text-center"><strong>Price: ${data[item].DefaultPrice.toFixed(2) + ' zł'}</strong></p>
                    <span id="${data[item].Id}"><a onclick="addToCart(${data[item].Id})"  onload="addToCart(${data[item].Id})" type="button" class="btn btn-primary" style="float: bottom">Add To Cart</a></span>
                </div>
            </div>
        </div>`;
    }
}




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
