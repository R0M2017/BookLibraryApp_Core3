$(function () {
    // this initializes the dialog (and uses some common options that I do)
    $("#dialog").dialog({
        autoOpen: false,
        maxWidth: 700,
        maxHeight: 500,
        width: 700,
        height: 500,
        modal: true,
        show: "blind",
        hide: "blind",
        closeOnEscape: false,
        dialogClass: "no-close"
    });

    // next add the onclick handler
    $("#scanbook").click(function () {
        $("#dialog").dialog("open");
        return false;
    });
});