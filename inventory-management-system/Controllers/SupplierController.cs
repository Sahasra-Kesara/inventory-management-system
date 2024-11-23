using inventory_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SupplierController : Controller
{
    private readonly AppDbContext _context;

    public SupplierController(AppDbContext context)
    {
        _context = context;
    }

    // List all suppliers
    public async Task<IActionResult> Index()
    {
        var suppliers = await _context.Suppliers.ToListAsync();
        return View(suppliers);
    }

    // Add supplier
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Supplier supplier)
    {
        if (ModelState.IsValid)
        {
            _context.Add(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    // Edit supplier
    public async Task<IActionResult> Edit(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Supplier supplier)
    {
        if (id != supplier.SupplierId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(supplier);
    }

    // Delete supplier
    public async Task<IActionResult> Delete(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
