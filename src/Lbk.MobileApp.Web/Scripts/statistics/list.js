$(function () {
    $('#selectPageSize select').change(function () {
        $.post('@Url.Action(MVC.Statistics.Index())', { PageSize: $(this).val() }, function (result) { $('#resultGrid').html(result); });
    });
   
    $(document).on('click', "#export", function () {
        var actionUrl = $(this).data("action");
        var data = $("#statiscticsForm").serialize();
        $.fileDownload(actionUrl, { httpMethod: 'post', data: data });
    });
});