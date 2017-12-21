window.JsonClass = function (urlSearchByIngredient) {
    var _urlSearchByIngredient = urlSearchByIngredient;

    var _inProgress = false;

    function _makeCall(urlReq, reqData, callback) {
        if (!_inProgress) {
            $.ajax({
                type: "Get",
                url: urlReq,
                data: reqData,
                beforeSend: function () {
                    _inProgress = true;
                },
                success: function (result) {
                    callback(result);
                },
                error: function (e) {
                    console.log(e);
                },
                complete: function () {
                    _inProgress = false;
                }
            });
        }
    }

    function SearchByIngredient() {
        var callback = function (result) {
            var label = $("#search-result");
            label.html(result);
        }
        var name = $("#name").val();
        var data = "name=" + name;
        _makeCall(_urlSearchByIngredient, data, callback);
    }

    return {
        SearchByIngredient: SearchByIngredient
    };
}