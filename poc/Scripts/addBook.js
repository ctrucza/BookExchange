(function () {
    var button = document.getElementById("addBookButton");
    button.onclick = function () {
        var authorBox = document.getElementById("author");
        var titleBox = document.getElementById("title");

        var formData = new FormData();
        formData.append("Author", authorBox.value);
        formData.append("Title", titleBox.value);

        var xmlhttp = new window.XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            console.log("readystate: " + xmlhttp.readyState + " status: " + xmlhttp.status);
            var status = document.getElementById("status");
            status.innerText = xmlhttp.statusText;
            var result = document.getElementById("result");
            result.innerText = xmlhttp.responseText;
        };

        xmlhttp.open("POST", "/Home/AddBook", true);
        xmlhttp.send(formData);

    };
}());