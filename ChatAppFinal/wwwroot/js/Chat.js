var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
const users = [];

document.getElementById("createRoomBtn").addEventListener("click", function (event) {
    connection.invoke("CreateRoom", document.getElementById("roomName").value).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("ReceiveMessage", function (user, message, date) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${date} - ${user}: ${message}`;
});

connection.on("RoomCreated", function (roomName) {
    var ul = document.getElementById("createdRooms");
    var li = document.createElement("li");
    var a = document.createElement("a");
    a.id = roomName;
    a.textContent = roomName;
    a.className = "btn btn-outline-light";
    li.appendChild(a);
    ul.appendChild(li);
});

connection.on("UserConnected", function (connectedUser) {
    users.push(connectedUser);
    var ul = document.getElementById("connectedUsers");
    var li = document.createElement("li");
    li.id = connectedUser;
    li.textContent = connectedUser;
    ul.innerHTML = users;
});

connection.on("UserDisconnected", function (connectedUser) {
    var index = users.indexOf(connectedUser);
    if (index > -1) {
        users.splice(index, 1)
    }
    var ul = document.getElementById("connectedUsers");
    var li = document.createElement("li");
    var a = document.createElement("a");
    li.id = connectedUser;
    li.textContent = connectedUser + " disconnected";
    ul.innerHTML = users;
});

// Get the modal
var modal = document.getElementById("myModal");
var btn = document.getElementById("newRoom");
var btna = document.getElementById("createRoomBtn");
var span = document.getElementsByClassName("close")[0];

btn.onclick = function () {
    modal.style.display = "block";
}
span.onclick = function () {
    modal.style.display = "none";
}
btn1.onclick = function () {
    modal.style.display = "none";
    var roomNameTXT = document.getElementById("roomName").value;

    mHeader.textContent = roomNameTXT + " Messages"
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        joinRoomModalOpen.style.display = "none";
    }
}


function openJoinRoomModal() {
    var joinRoomModal = document.getElementById("joinRoomModalWindow")
    var btn1 = document.getElementById("joinRoomBtn")
    joinRoomModal.style.display = "block";
}

