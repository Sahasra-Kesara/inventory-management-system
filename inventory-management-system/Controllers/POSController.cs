using inventory_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class POSController : Controller
{
    private readonly AppDbContext _context;

    public POSController(AppDbContext context)
    {
        _context = context;
    }

    // Display POS screen with item list and supplier options
    public async Task<IActionResult> Index()
    {
        var items = await _context.Items.ToListAsync();
        ViewBag.Items = items;
        return View();
    }

    // Process the POS transaction (Add to cart, Remove, Finalize transaction)
    [HttpPost]
    public async Task<IActionResult> ProcessTransaction(int itemId, int quantity, string transactionType)
    {
        var item = await _context.Items.FindAsync(itemId);
        if (item == null)
        {
            ModelState.AddModelError("", "Item not found.");
            return View("Index");
        }

        if (transactionType == "OUT" && item.Quantity < quantity)
        {
            ModelState.AddModelError("", "Not enough stock available.");
            return View("Index");
        }

        // Create the transaction entry
        var transaction = new InventoryTransaction
        {
            ItemId = itemId,
            Item = item,
            Quantity = quantity,
            TransactionType = transactionType,
            TransactionDate = DateTime.Now
        };

        using (var transactionScope = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                if (transactionType == "IN")
                {
                    item.Quantity += quantity; // Add stock
                }
                else if (transactionType == "OUT")
                {
                    item.Quantity -= quantity; // Remove stock
                }

                _context.InventoryTransactions.Add(transaction);
                _context.Update(item);
                await _context.SaveChangesAsync();

                await transactionScope.CommitAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                await transactionScope.RollbackAsync();
                ModelState.AddModelError("", "An error occurred while processing the transaction.");
                return View("Index");
            }
        }
    }

    // View Transaction History (for POS user to view completed transactions)
    public async Task<IActionResult> TransactionHistory()
    {
        var transactions = await _context.InventoryTransactions
            .Include(t => t.Item)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();
        return View(transactions);
    }
}
