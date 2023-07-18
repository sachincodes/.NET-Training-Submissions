function AddCart(data) {
    let cart_count = $('.cart-count').html();
    $.ajax({
        type: "GET",
        url: "/Product/AddProductToCart",
        data: { "paramValue": data },
        success: function (result) {
            if (result == "Success") {
                let count = parseInt(cart_count);
                count = count + 1;
                $('.cart-count').html(count);
                console.log("kdjkdh");
                alert("Product Added To Cart");
            }
            else if (result == "Exists") {
                alert("Product added again");
            }

            else {
                alert("failed");
            }
        }
    })
}


    //function MinusQty(i)
    //{
    //    var qty = parseInt($('#qty_' + i).val());
    //    if(qty>1)
    //{
    //    qty = qty - 1;
    //$('#qty_' + i).val(qty);
    //Calculate("minus", i);
    //    }

    //else{
    //    alert("Quantity can not be 0");
    //return false;
    //   }

    //}

function MinProductQuantity(i) {
    var qtyInput = $('#qty_' + i);
    var qty = parseInt(qtyInput.val());

    if (qty > 1) {
        qty--;
        qtyInput.val(qty);
        Calculate("minus", i);
    } else {
        alert("Quantity can not be 0");
        return false;
    }
}

function AddPoductQuantity(i) {
        var qty = parseInt($('#qty_' + i).val());
        qty = qty + 1;
        $('#qty_' + i).val(qty);
        Calculate("plus",i)
    }


    function Calculate(type,i){
        var qty = parseInt($('#qty_' + i).val());
        var discountAmt = parseInt($('#disc_' + i).val());
        var price = parseInt($('#price_' + i).val());
        var allPrice = parseInt($('.all-price').html());
        var saveAmt = parseInt($('.save-amt').html());
        var netAmt = parseInt($('.net-amt').html());
        if (type == "plus") {
            let disc = (price * discountAmt) / 100;
            saveAmt = saveAmt + disc;
            allPrice=allPrice+price;
            netAmt = allPrice - saveAmt;
            $('.all-price').html(allPrice.toFixed(2));
            $('.save-amt').html(saveAmt.toFixed(2));
            $('.net-amt').html(netAmt.toFixed(2));
        }
        else{
            let disc = (price * discountAmt) / 100;
            saveAmt = saveAmt - disc;
            allPrice = allPrice- price;
            netAmt = allPrice - saveAmt;
            $('.all-price').html(allPrice.toFixed(2));
            $('.save-amt').html(saveAmt.toFixed(2));
            $('.net-amt').html(netAmt.toFixed(2));
        }
    }
