$(document).ready(function () {
    $("#SubmitUserData").click(function() {
        $.ajax({
            url: "api/sitecore/GDPR/GetUserInteractionDetails",
            type: "POST",
            context: this,
            data: {
                identifier: $('#EmailId').val()
            },

            success: function(data) {
                alert("Please find the user data below.");
            },

            error: function(data) {
                console.log("error", data);
            }
        });
    });
});