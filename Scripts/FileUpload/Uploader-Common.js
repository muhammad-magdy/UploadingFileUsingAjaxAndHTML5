function progressHandlingFunction(e) {
    if (e.lengthComputable) {
        var percentComplete = Math.round(e.loaded * 100 / e.total);
        $("#FileProgress").css("width", percentComplete + '%').attr('aria-valuenow', percentComplete);
        $('#FileProgress span').text(percentComplete + "%");
    }
    else {
        $('#FileProgress span').text('unable to compute');
    }
}

function completeHandler() {
    $('#createView').empty();
    $('.CreateLink').show();
    $.unblockUI();
}


function successHandler(data) {
    if (data.statusCode == 200) {
        $('#FilesList tr:last').after(data.NewRow);
        alert(data.status);
    }
    else {
        alert(data.status);
    }
}

function errorHandler(xhr, ajaxOptions, thrownError) {
    alert("There was an error attempting to upload the file. (" + thrownError + ")");
}

function OnDeleteAttachmentSuccess(data) {

    if (data.ID && data.ID != "") {
        $('#Attachment_' + data.ID).fadeOut('slow');
    }
    else {
        alter("Unable to Delete");
        console.log(data.message);
    }
}

function Cancel_btn_handler() {
    $('#createView').empty();
    $('.CreateLink').show();
    $.unblockUI();
}