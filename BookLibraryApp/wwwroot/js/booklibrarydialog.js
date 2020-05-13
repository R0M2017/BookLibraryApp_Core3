$(function () {
    // this initializes the dialog (and uses some common options that I do)
    $("#dialog").dialog({
        autoOpen: false, modal: true, show: "blind", hide: "blind"
    });

    // next add the onclick handler
    $("#scanbook").click(function () {
        $("#dialog").dialog("open");
        return false;
    });
});