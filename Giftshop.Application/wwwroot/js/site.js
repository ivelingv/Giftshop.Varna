setShoppingCart()

function rejectOrder() {
    deleteCookie('cart');
    window.location = '/Catalogue'
}

function navigateCheckout() {
    var products = $('#shoppingCart').attr('data-items')
    if (products !== undefined && products.length > 0) {
        var list = products.split(',')
        var query = '';
        list.forEach((value) => {
            query += 'products=' + value + '&';
        })
        window.location = '/Catalogue/Checkout?' + query;
    } 
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function handleOrderButton(e) {
    let cart = undefined;
    let cartCookie = getCookie('cart');
    let product = e.parent().find('input').val();

    if (cartCookie == '' || cartCookie === undefined) {
        cart = JSON.stringify({
            products: [],
            productCount: 0,
        })
    }
    else {
        cart = cartCookie;
    }

    cart = JSON.parse(cart)
    cart.productCount++
    cart.products.push(product)
    setCookie('cart', JSON.stringify(cart), 1)
    setShoppingCart()
}

function setShoppingCart() {
    $(document).ready(() => {
        var cart = getCookie('cart');
        if (cart != '' && cart !== undefined) {
            cart = JSON.parse(cart)
            console.log(cart);
            $('#shoppingCart').attr('data-items', cart.products.join())
            $('#shoppingCart').html(cart.productCount)
        }
    })
}

function deleteCookie(cname) {
    setCookie(cname, '', -1)
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');

    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }

    return "";
}