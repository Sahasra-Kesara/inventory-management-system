using inventory_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ReportsController : Controller
{
    private readonly AppDbContext _context;

    public ReportsController(AppDbContext context)
    {
        _context = context;
    }

    // Index to display report options
    public IActionResult Index()
    {
        return View();
    }

    // Generate Inventory Audit Report
    public async Task<IActionResult> InventoryAuditReport()
    {
        var report = await _context.InventoryTransactions
            .Include(t => t.Item)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();

        return View(report);
    }

    // Generate Stock Movement Report
    public async Task<IActionResult> StockMovementReport()
    {
        var report = await _context.InventoryTransactions
            .Include(t => t.Item)
            .Where(t => t.TransactionType == "IN" || t.TransactionType == "OUT")
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();

        return View(report);
    }

    // Generate Inventory Value Report
    public async Task<IActionResult> InventoryValueReport()
    {
        var report = await _context.Items
            .Select(item => new
            {
                item.ItemId,
                item.ItemName,
                item.Quantity,
                item.UnitPrice,
                TotalValue = item.Quantity * item.UnitPrice
            })
            .ToListAsync();

        return View(report);
    }

    // Generate Supplier Transaction Report
    public async Task<IActionResult> SupplierTransactionReport()
    {
        var report = await _context.InventoryTransactions
            .Include(t => t.Supplier)
            .Include(t => t.Item)
            .Where(t => t.SupplierId != null)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();

        return View(report);
    }

    // Generate Stock Level Report
    public async Task<IActionResult> StockLevelReport()
    {
        var report = await _context.Items
            .Select(item => new
            {
                item.ItemId,
                item.ItemName,
                item.Quantity
            })
            .ToListAsync();

        return View(report);
    }

    // Generate Transaction Report
    public async Task<IActionResult> TransactionReport()
    {
        var report = await _context.InventoryTransactions
            .Include(t => t.Item)
            .Include(t => t.Supplier)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();

        return View(report);
    }
}
