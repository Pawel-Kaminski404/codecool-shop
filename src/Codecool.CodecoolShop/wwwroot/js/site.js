// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*document.addEventListener("load",()=> {*/

window.addEventListener("load", () => {
     navbarCounterDisplay();
})
    async function navbarCounterDisplay() {
        await fetch(`/GetCartAmount?userId=1`)
            .then(response => response.json())
            .then(data => ChangeNavbarContent(data));
    }

    async function ChangeNavbarContent(data) {
        let cartItemsCounter = document.getElementById("shoppingCart");
        cartItemsCounter.innerHTML = `<img src="/img/ShoppingCartIcon.png" style="width: 20px; height: 20px"/> ${data}`
    }
    
    
    async function RefreshProducts(filter) {
        let url = "";
        if (filter == 'category') {
            let category = document.getElementById("categories").value;
            url = `/getProducts?filter=${category}&filterBy=category`;
        } else {
            let suplier = document.getElementById("supliers").value;
            url = `/getProducts?filter=${suplier}&filterBy=supplier`;
        }
        await fetch(url)
            .then(response => response.json())
            .then(data => DisplayContent(data));
    }

    async function DisplayContent(data) {
        document.getElementById("productContainer").innerHTML = "";
        for (item in data) {
            document.getElementById("productContainer").innerHTML += `<div class="col-lg-3 col-lg-3" style="display: inline-block; max-width: 350px; height: 350px; margin-bottom: 200px;">
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
    

    async function addToCart(id) {
        await fetch(`/addProduct?id=${id}&userId=1`)
            .then(response => response.json())
            .then(data => ChangeCartContent(data));
    }

    async function deleteFromCart(id) {
        await fetch(`/deleteProduct?id=${id}&userId=1`)
            .then(response => response.json())
            .then(data => ChangeCartBagContent(data))
    }

    async function ChangeCartBagContent(data) {
        document.getElementById("ShoppingBag").innerHTML = "";
        await navbarCounterDisplay();
        for (let item in data[0]) {
            document.getElementById("ShoppingBag").innerHTML += `<div class="item">
    <div class="buttons">
      <svg onclick ="deleteFromCart(${data[0][item].Id})" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="delete-btn bi bi-x-lg" viewBox="0 0 16 16">
        <path fill-rule="evenodd" d="M13.854 2.146a.5.5 0 0 1 0 .708l-11 11a.5.5 0 0 1-.708-.708l11-11a.5.5 0 0 1 .708 0Z"/>
        <path fill-rule="evenodd" d="M2.146 2.146a.5.5 0 0 0 0 .708l11 11a.5.5 0 0 0 .708-.708l-11-11a.5.5 0 0 0-.708 0Z"/>
      </svg>
    </div>

    <div class="image">
      <img src="/img/${data[0][item].Name}.jpg" style="width: 60px; height: 60px" alt=""/>
    </div>

    <div class="description">
      <span>${data[0][item].Name}</span>
      <span>${data[0][item].Supplier.Name}</span>
    </div>

    <div class="quantity">
      <button class="plus-btn" type="button" name="button">
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
          <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
        </svg>
      </button>
      <input type="text" name="name" value="1">
      <button class="minus-btn" type="button" name="button">
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-dash" viewBox="0 0 16 16">
          <path d="M4 8a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7A.5.5 0 0 1 4 8z"/>
        </svg>
      </button>
    </div>

    <div class="total-price" style="font-weight: bold">${data[0][item].DefaultPrice.toFixed(2)} zł</div>
  </div>`
        }
        let TotalPrices = document.getElementsByClassName("total-Price")
        console.log(TotalPrices)
        for (let item in TotalPrices) {
            TotalPrices[item].innerHTML = data[1].toFixed(2) + " zł";
        }

    }


    async function ChangeCartContent(data) {
        let addItemToCart = document.getElementById(`${data[1]}`)
        await navbarCounterDisplay();
        addItemToCart.innerHTML = `<button type="button" class="btn btn-outline-primary">Added To Cart</button>`
    }

    function PaymentSelectChange() {
        console.log(document.getElementById("paymentOption").value);
    }
