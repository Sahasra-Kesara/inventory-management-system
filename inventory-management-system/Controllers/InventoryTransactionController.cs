using inventory_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class InventoryTransactionController : Controller
{
    private readonly AppDbContext _context;

    public InventoryTransactionController(AppDbContext context)
    {
        _context = context;
    }

    // List all transactions
    public async Task<IActionResult> Index()
    {
        var transactions = await _context.InventoryTransactions
            .Include(t => t.Item)
            .Include(t => t.Supplier)
            .ToListAsync();
        return View(transactions);
    }

    // Add stock (IN)
    public IActionResult AddStock()
    {
        ViewBag.Items = _context.Items.ToList();
        ViewBag.Suppliers = _context.Suppliers.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddStock(InventoryTransaction transaction)
    {
        if (ModelState.IsValid)
        {
            transaction.TransactionType = "IN";
            transaction.TransactionDate = DateTime.Now;

            using (var transactionScope = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var item = await _context.Items.FindAsync(transaction.ItemId);
                    if (item == null)
                    {
                        ModelState.AddModelError("", "Item not found.");
                        return View(transaction);
                    }

                    item.Quantity += transaction.Quantity;
                    _context.Update(item);
                    _context.InventoryTransactions.Add(transaction);
                    await _context.SaveChangesAsync();

                    await transactionScope.CommitAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    await transactionScope.RollbackAsync();
                    ModelState.AddModelError("", "An error occurred while processing the transaction.");
                    return View(transaction);
                }
            }
        }

        ViewBag.Items = _context.Items.ToList();
        ViewBag.Suppliers = _context.Suppliers.ToList();
        return View(transaction);
    }

    // Remove stock (OUT)
    public IActionResult RemoveStock()
    {
        ViewBag.Items = _context.Items.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveStock(InventoryTransaction transaction)
    {
        if (ModelState.IsValid)
        {
            transaction.TransactionType = "OUT";
            transaction.TransactionDate = DateTime.Now;

            using (var transactionScope = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var item = await _context.Items.FindAsync(transaction.ItemId);
                    if (item == null)
                    {
                        ModelState.AddModelError("", "Item not found.");
                        return View(transaction);
                    }

                    if (item.Quantity < transaction.Quantity)
                    {
                        ModelState.AddModelError("", "Not enough stock available.");
                        ViewBag.Items = _context.Items.ToList();
                        return View(transaction);
                    }

                    item.Quantity -= transaction.Quantity;
                    _context.Update(item);
                    _context.InventoryTransactions.Add(transaction);
                    await _context.SaveChangesAsync();

                    await transactionScope.CommitAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    await transactionScope.RollbackAsync();
                    ModelState.AddModelError("", "An error occurred while processing the transaction.");
                    return View(transaction);
                }
            }
        }

        ViewBag.Items = _context.Items.ToList();
        return View(transaction);
    }
}
