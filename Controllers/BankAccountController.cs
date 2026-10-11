using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_akushevich.Models;

namespace wt_lab4_4mvc_akushevich.Controllers;

public class BankAccountController : Controller
{
    private static readonly List<BankAccount> accounts = new()
    {
        new BankAccount
        {
            Id = 1,
            OwnerName = "Акушевич Андрей Сергеевич",
            AccountNumber = "BY01SAV0001",
            Balance = 2000m,
            IsActive = true
        },
        new BankAccount
        {
            Id = 2,
            OwnerName = "Петрова Анна Сергеевна",
            AccountNumber = "BY02CRD0002",
            Balance = 0m,
            IsActive = true
        },
        new BankAccount
        {
            Id = 3,
            OwnerName = "Сидоров Пётр Петрович",
            AccountNumber = "BY03DEP0003",
            Balance = 5000m,
            IsActive = false
        },
        new BankAccount
        {
            Id = 4,
            OwnerName = "Морозова Елена Викторовна",
            AccountNumber = "BY04DEP0004",
            Balance = 12000m,
            IsActive = true
        },
        new BankAccount
        {
            Id = 5,
            OwnerName = "Кузнецов Андрей Игоревич",
            AccountNumber = "BY05SAV0005",
            Balance = 750m,
            IsActive = false
        }
    };

    public IActionResult Index()
    {
        return View(accounts);
    }
        public IActionResult Details(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);

        if (account == null)
        {
            return NotFound();
        }

        return View(account);
    }
        public IActionResult Create()
    {
        return View();
    }
            [HttpPost]
    public IActionResult Create(BankAccount account)
    {
        if (!ModelState.IsValid)
        {
            return View(account);
        }

        int newId = accounts.Count > 0 ? accounts.Max(a => a.Id) + 1 : 1;
        account.Id = newId;
        account.IsActive = true;

        accounts.Add(account);

        return RedirectToAction("Index");
    }
        public IActionResult Delete(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);

        if (account == null)
        {
            return NotFound();
        }

        return View(account);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);

        if (account != null)
        {
            accounts.Remove(account);
        }

        return RedirectToAction("Index");
    }
}