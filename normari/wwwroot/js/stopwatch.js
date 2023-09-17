// Initialize variables

let isRunning = false;
let startTime = 0;
let stopTime = 0;
let previous = 0
let interval = setInterval(updateTime, 10);
let id = 0;
let col = 0;
let timpi = [];
for (let i = 0; i < 15; i++)
    timpi[i] = []


timpi[15] = [];
timpi[15][0] = nid;

function stringify(time) {
    const minutes = Math.floor(time / 60000);
    const seconds = Math.floor((time % 60000) / 1000);
    const milliseconds = Math.floor((time % 1000) / 10);
    return `${padTime(minutes)}:${padTime(seconds)}.${padTime(milliseconds)}`;
}

function padTime(value) {
    return value.toString().padStart(2, '0');
}

function updateTime() {
    if (!isRunning) return;
    const currentTime = Date.now() - startTime;
    const minutes = Math.floor(currentTime / 60000);
    const seconds = Math.floor((currentTime % 60000) / 1000);
    const milliseconds = Math.floor((currentTime % 1000) / 10);
    timpi[id][col] = currentTime;
    const timeString = `${padTime(minutes)}:${padTime(seconds)}.${padTime(milliseconds)}`;
    document.getElementById("display").textContent = timeString;
}


function clear() {
    //clearInterval(interval);
    isRunning = false;
    startTime = 0;
    previous = 0;
    document.getElementById("display").textContent = "00:00.00";
    document.getElementById("start").textContent = "Start";
}
function reset() {
    clear();
    id = 0;
    col = 0;
    for (let i = 0; i < 15; i++) {
        timpi[i] = []
        document.getElementById("timp" + (i + 1)).textContent = '';
    }

}

function lap() {
    let row = padTime(id + 1) + ". ";
    for (let i = 0; i <= col; i++)
        row += stringify(timpi[id][i]) + "    ";
    document.getElementById("timp" + (id + 1)).textContent = row;
    // document.getElementById("timp" + id).textContent = nrOperatii;
    col++;
    if (col >= nrOperatii) {
        col = 0;
        id++;
        if (id >= 15) {
            id--;
            clearInterval(interval);
        }
    }
}

//Functions for start and stop of stopwatch

function start() {
    if (isRunning) {
        //lap();
    } else {
        clear()
        startTime = Date.now() - previous;
        //interval = setInterval(updateTime, 10);
        //document.getElementById("start").textContent = "Lap";
    }
    document.getElementById("stop").textContent = "Stop";
    isRunning = true;
}

function stop() {
    if (isRunning) {
        //clearInterval(interval);
        previous = Date.now() - startTime;
        lap();
        document.getElementById("start").textContent = "Start";
        document.getElementById("stop").textContent = "Reset";
    }
    else {
        reset();
        document.getElementById("stop").textContent = "Stop";
    }
    isRunning = false;
}

function MyFunction() {
    //let data = timpi;
    let json = JSON.stringify(timpi);
    $.ajax({
        url: '@Url.Action("Send", "Timpis")',
        type: 'POST',
        contentType: "application/json;charset=UTF-8",
        data: json,
        dataType: 'json',
        // contentLength: 29,
        success: function () {
            window.location.href = '@Url.Action("Create", "Home")';
        },// This Code lets you to change url howyouwant
        error: function () {
            alert("Error!");
        }
    });
    return false;
}

// Event listeners for buttons

document.getElementById("start").addEventListener("click", start);
document.getElementById("stop").addEventListener("click", stop);
