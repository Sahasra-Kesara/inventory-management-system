


https://github.com/user-attachments/assets/c23d9047-5f2f-47d6-88b1-059c7ef2be3b


# Inventory Management System - User Manual

## Overview

This system is designed for managing inventory, stock transactions, point of sale (POS), and supplier interactions. The system includes several controllers that handle different aspects of inventory management, including adding/removing stock, item management, transaction processing, and generating reports.

## Controllers and Actions

### 1. InventoryTransactionController
This controller manages inventory transactions such as adding and removing stock. It includes the following actions:

- **Index**: Displays a list of all inventory transactions, including item and supplier details.
- **AddStock**: Allows users to add stock items (IN transactions). It ensures that the item exists in the system and updates the stock accordingly.
- **RemoveStock**: Handles stock removal (OUT transactions) and checks that sufficient stock is available before processing the transaction.

### 2. ItemController
This controller manages inventory items with CRUD operations (Create, Read, Update, Delete). Actions include:

- **Index**: Displays a list of all inventory items.
- **Create**: Displays a form to add a new item to the inventory.
- **Edit**: Allows users to edit an existing item.
- **Delete**: Handles the deletion of an item from the inventory.

### 3. POSController
This controller handles point of sale (POS) operations, including displaying items and processing transactions. It includes the following actions:

- **Index**: Displays available items and allows users to interact with the POS system.
- **ProcessTransaction**: Handles adding and removing items from the cart, based on the transaction type (IN/OUT).
- **TransactionHistory**: Displays a list of all completed transactions for the user.

### 4. ReportsController
This controller generates various reports related to inventory, stock movements, and transactions. Reports include:

- **InventoryAuditReport**: Displays a detailed history of inventory transactions.
- **StockMovementReport**: Shows items that have been added or removed from stock.
- **InventoryValueReport**: Calculates the total value of items in inventory.
- **SupplierTransactionReport**: Displays transactions related to specific suppliers.
- **StockLevelReport**: Shows current stock levels for all items.
- **TransactionReport**: Provides a detailed report of all inventory transactions, including item and supplier details.

### 5. SupplierController
This controller manages suppliers with CRUD operations. Actions include:

- **Index**: Displays a list of all suppliers.
- **Create**: Displays a form to add a new supplier.
- **Edit**: Allows users to edit supplier details.
