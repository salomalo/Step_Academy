//references to CommonFunctionality.js

var XMLHttpFactories = [
            function () { return new XMLHttpRequest() },
            function () { return new ActiveXObject("Msxml2.XMLHTTP") },
            function () { return new ActiveXObject("Msxml3.XMLHTTP") },
            function () { return new ActiveXObject("Microsoft.XMLHTTP") }
];

function createXMLHTTPObject() {
    var xmlhttp = false;
    for (var i = 0; i < XMLHttpFactories.length; i++) {
        try {
            xmlhttp = XMLHttpFactories[i]();
        }
        catch (e) {
            continue;
        }
        break;
    }
    return xmlhttp;
}



function sendRequest(url, callback, postData) {
    var req = createXMLHTTPObject();
    if (!req) return;
    var method = "POST";
    req.open(method, url);
    req.onreadystatechange = function () {
        if (req.readyState != 4) return;
        if (req.status != 200 && req.status != 304) {
            alert('HTTP error ' + req.status);
            return;
        }
        callback(req);
    }
    if (req.readyState == 4) return;
    req.send(postData);
}

function MessageSentCallback(request) {
    alert(request.response);
}
function RecieveMessageList(request) {
    var messages = JSON.parse(request.response);
    DrawMessages(messages, "chat", true);
}

$(function () {
    $("#btnPostMsg").click(function () {
        var userName = $("#txtUserName").val();
        var login = $("#txtLogin").val();
        var msg = $("#txtMessage").val();

        var message = {
            Message: msg,
            UserName: userName,
            Login: login
        };

        var strObj = JSON.stringify(message);

        sendRequest(sendMsgUrl, MessageSentCallback, strObj);
    });

    $("#btnRefresh").click(function () {
        sendRequest(loadMsgsUrl, RecieveMessageList, null);

    });
});