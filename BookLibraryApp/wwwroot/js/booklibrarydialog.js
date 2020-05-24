$(function () {
    // this initializes the dialog (and uses some common options that I do)
    $("#dialog").dialog({
        autoOpen: false,
        maxWidth: 600,
        maxHeight: 600,
        width: 600,
        height: 600,
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