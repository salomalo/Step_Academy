function DrawMessages(messages, tableId, shouldClean) {

    var $body = $("#" + tableId + ">tbody");
    if (shouldClean) {
        $body.empty();
    }

    $.each(messages, function (idx, obj) {
        var $tr = $("<tr>");
        $("<td>").text(obj.UserName).appendTo($tr);
        $("<td>").text(obj.Login).appendTo($tr);
        $("<td>").text(obj.Message).appendTo($tr);
        $body.append($tr);
    });
}