
var list = JSON.parse(localStorage.getItem("order"));;
var FurnitureId, Quantity;
debugger;

function AddToCart(id){
    FurnitureId = $(elem).data("prod-id");

    if (!containsObject(FurnitureId, list)) {
        list.Push({ FurnitureId: FurnitureId, Quantity: 1 })
        sessionStorage.setItem("order", JSON.stringify(list));
        alert("Added product with id of {0}", FurnitureId);
    }
    else
    {
        for (var i = 0; i < list.length; i++)
        {
            if (list[i].FurnitureId === FurnitureId)
            {
                list[i].Quantity++;
                sessionStorage.setItem("order", JSON.stringify(list));
            }
            alert("Increased quantity by 1 of product with ID {0}", FurnitureId);
        }
    }
    alert(list);
}

function containsObject(obj, list) {
    var i;
    for (i = 0; i < list.length; i++) {
        if (list[i].FurnitureId === obj) {
            return true;
        }
    }
    return false;
}
