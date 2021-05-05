function saveAsFile(fileName, byteBase64) {
    var link = document.createElement('a');
    link.download = fileName;
    //link.href = 'data:application/vnd.openxmlformats-ofiledocument.spreadsheettml.sheet;base64' + byteBase64;
    link.href = 'data:application/octet-stream;base64,' + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.getSelectedValues = function (sel) {
    var results = [];
    var i;
    for (i = 0; i < sel.options.length; i++) {
        if (sel.options[i].selected) {
            results[results.length] = sel.options[i].value;
        }
    }
    return results;
};

$(() => {
    console.log('load')
    $('#pag-tercero .form-control').attr('autocomplete', 'off');
})