using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_akushevich.Models;

public class BankAccount
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите владельца счёта")]
    [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов")]
    public string OwnerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите номер счёта")]
    public string AccountNumber { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "Баланс не может быть отрицательным")]
    public decimal Balance { get; set; }

    public bool IsActive { get; set; }
}