$(function () {
    $('#selectPageSize select').change(function () {
        var actionUrl = $('#selectPageSize').data("action");
        $.post(actionUrl, { PageSize: $(this).val() }, function (result) { $('#resultGrid').html(result); });
    });
   
    $(document).on('click', "#export", function () {
        var actionUrl = $(this).data("action");
        var data = $("#statiscticsForm").serialize();
        $.fileDownload(actionUrl, { httpMethod: 'post', data: data });
    });
});