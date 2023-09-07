// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const operatieMultipla = document.getElementById("multiplu");
const operatieSimpla = document.getElementById("simplu");
const butonMultipla = document.getElementById("multiplubutton");
const butonSimpla = document.getElementById("simplubutton");
const numberOfOperations = document.getElementById("number_of_operations")

// Select increment and decrement buttons
const incrementCount = document.getElementById("increment");
const decrementCount = document.getElementById("decrement");

// Select total count
const totalCount = document.getElementById("total-count");

// Variable to track count
let count = 1;

// Display initial count value
totalCount.value = count;

// Function to increment count
const handleIncrement = () => {
    if(count < 10)
    count++;
    totalCount.value = count;
};

// Function to decrement count
const handleDecrement = () => {
    if(count > 1)
        count--;
    totalCount.value = count;
};

const showNumberOfOperations = () => {
    numberOfOperations.classList.remove("invisible");

    butonMultipla.classList.remove("btn-secondary");
    butonMultipla.classList.add("btn-success");
    butonSimpla.classList.add("btn-secondary");
    butonSimpla.classList.remove("btn-success");
}
const hideNumberOfOperations = () => {
    numberOfOperations.classList.add("invisible");

    butonMultipla.classList.add("btn-secondary");
    butonMultipla.classList.remove("btn-success");
    butonSimpla.classList.remove("btn-secondary");
    butonSimpla.classList.add("btn-success");
}

// Add click event to buttons
incrementCount.addEventListener("click", handleIncrement);
decrementCount.addEventListener("click", handleDecrement);

operatieMultipla.addEventListener("change", showNumberOfOperations)
operatieSimpla.addEventListener("change", hideNumberOfOperations)