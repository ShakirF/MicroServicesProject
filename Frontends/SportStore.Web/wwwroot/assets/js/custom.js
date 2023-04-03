
	$(document).ready(function () {

		$(document).on("click", ".inc", function (e) {
            e.preventDefault();
            let value = parseInt($(this).prev("input").val());
            let tr = $(this).closest('tr');
            let table = $(this).closest('table');
            var totalPrice = $("#total-price");
            let productId = $(this).prev("input").data("productid");
            let QtyData = {
                qty: value,
                productId : productId
            };

            $.ajax({
                url: window.location.origin + "/Basket/QuantityUpdate",
                cache: false,
                type: "post",
                dataType: "json",
                data: QtyData,
                async: true,
                beforeSend: function () {
                },
                success: function (data) {

                    let currentPrice = parseFloat(tr.find('span.current-price').text());
                
                    tr.find("span.total-each-product").text(currentPrice * value);  

                    let sum = 0;
                    table.find("span.total-each-product").each(function () {
                        sum += +$(this).text() || 0;
                    });
                    totalPrice.text(sum);
                }
            });
		});
        $(document).on("click", ".dec", function (e) {
            e.preventDefault();
            let value = parseInt($(this).next("input").val());
            let tr = $(this).closest('tr');
            let table = $(this).closest('table');
            var totalPrice = $("#total-price");
            let productId = $(this).next("input").data("productid");
            let QtyData = {
                qty: value,
                productId: productId
            };

            $.ajax({
                url: window.location.origin + "/Basket/QuantityUpdate",
                cache: false,
                type: "post",
                dataType: "json",
                data: QtyData,
                async: true,
                beforeSend: function () {
                },
                success: function (data) {

                    let currentPrice = parseFloat(tr.find('span.current-price').text());

                    tr.find("span.total-each-product").text(currentPrice * value);

                    let sum = 0;
                    table.find("span.total-each-product").each(function () {
                        sum += +$(this).text() || 0;
                    });
                    totalPrice.text(sum);

                }
            });
        });
	});




