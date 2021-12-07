﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function RefreshProducts()
{
    let category = document.getElementById("categories").value;
    await fetch(`/getProducts?category=${category}`)
        .then(response => response.json())
        .then(data => DisplayContent(data));
}

async function RefreshProductsBySuplier() {
    let suplier = document.getElementById("supliers").value;
    await fetch(`/getProductsBySuplier?suplier=${suplier}`)
        .then(response => response.json())
        .then(data => DisplayContent(data));
}




async function DisplayContent(data)
{
    document.getElementById("productContainer").innerHTML = "";
    console.log(data);
    for (item in data)
    {
        console.log(data[item]);
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
                    <p class="card-text text-center"><strong>Price: ${data[item].DefaultPrice}</strong></p>
                    <a href="" type="button" class="btn btn-primary" style="float: bottom">Add To Cart</a>
                </div>
            </div>
        </div>`;
    }
}

