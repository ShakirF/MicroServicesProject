using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Orders;

public class CheckoutInfoInput
{

    [Display(Name = "şəhər")]
    public string Province { get; set; }

    [Display(Name = "rayon")]
    public string District { get; set; }

    [Display(Name = "küçə")]
    public string Street { get; set; }

    [Display(Name = "Post kodu")]
    public string ZipCode { get; set; }

    [Display(Name = "ünvan")]
    public string Line { get; set; }

    [Display(Name = "Kart sahibinin ad soyadı")]
    public string CardName { get; set; } = null!;

    [Display(Name = "Kart nömrəsi")]
    public string CardNumber { get; set; } = null!;

    [Display(Name = "son istifadə tarixi")]
    public string Expiration { get; set; } = null!;

    [Display(Name = "CVV/CVC2 nömrəsi ")]
    public string CVV { get; set; } = null!;

}

