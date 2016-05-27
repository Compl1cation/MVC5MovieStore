//Sorting
$(document).ready(function () {
    $(".header").click(function (evt) {
        var sortfield = $(evt.target).data("sortfield");
        if ($("#SortField").val() == sortfield) {
            if ($("#SortDirection").val() == "ascending") {
                $("#SortDirection").val("descending");
            }
            else {
                $("#SortDirection").val("ascending");
            }
        }
        else {
            $("#SortField").val(sortfield);
            $("#SortDirection").val("ascending");
        }
        evt.preventDefault();
        $("form").submit();
    });

    $(".pager").click(function (evt) {
        var pageindex = $(evt.target).data("pageindex");
        $("#CurrentPageIndex").val(pageindex);
        evt.preventDefault();
        $("form").submit();
    });
});


//Shopping Cart
 $(function () {
        // Document.ready -> link up remove event handler
        $(".RemoveLink").click(function () {
            // Get the id from the link
            var recordToDelete = $(this).attr("data-id");
            if (recordToDelete != '') {
                // Perform the ajax post
                $.post("/ShoppingCart/RemoveFromCart", { "id": recordToDelete },
                    function (data) {
                        // Successful requests get here
                        // Update the page elements
                        if (data.ItemCount == 0) {
                            $('#row-' + data.DeleteId).fadeOut('slow');
                        } else {
                            $('#item-count-' + data.DeleteId).text(data.ItemCount);
                        }
                        $('#cart-total').text(data.CartTotal);
                        $('#update-message').text(data.Message);
                        $('#cart-status').text('Cart (' + data.CartCount + ')');
                    });
            }
        });
    });
