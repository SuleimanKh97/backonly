# 🗄️ Database Debugging Guide

## External Database Connection

**Connection URL:** `postgresql://royallibrary_user:j659IZBu6nFOPfvJdAo7Fj06fKgX82Bv@dpg-d2mdog0dl3ps73avkq30-a.frankfurt-postgres.render.com/royallibrary`

## 🔧 Debugging Tools

### 1. SQL Queries (`debug_queries.sql`)
Run these queries directly in your database client (pgAdmin, DBeaver, etc.) or command line:

```bash
# Using psql command line
psql "postgresql://royallibrary_user:j659IZBu6nFOPfvJdAo7Fj06fKgX82Bv@dpg-d2mdog0dl3ps73avkq30-a.frankfurt-postgres.render.com/royallibrary" -f debug_queries.sql
```

### 2. Python Script (`test_connection.py`)
```bash
# Install dependencies
pip install psycopg2-binary

# Run the test
python test_connection.py
```

### 3. Node.js Script (`test_db.js`)
```bash
# Install dependencies
npm install pg

# Run the test
node test_db.js
```

---

## 🔍 Step-by-Step Debugging Process

### Step 1: Test Database Connection
```bash
# Python
python test_connection.py

# Node.js
node test_db.js

# Manual SQL
psql "postgresql://royallibrary_user:j659IZBu6nFOPfvJdAo7Fj06fKgX82Bv@dpg-d2mdog0dl3ps73avkq30-a.frankfurt-postgres.render.com/royallibrary" -c "SELECT version();"
```

**Expected Result:** ✅ Database connection successful!

### Step 2: Check Table Existence
Run this query to verify all required tables exist:
```sql
SELECT table_name
FROM information_schema.tables
WHERE table_schema = 'public'
ORDER BY table_name;
```

**Must Have Tables:**
- ✅ Authors
- ✅ Publishers
- ✅ Categories
- ✅ Books
- ✅ Products
- ✅ ProductImages

### Step 3: Check Reference Data
```sql
-- Check counts
SELECT 'Authors' as table_name, COUNT(*) as count FROM "Authors"
UNION ALL
SELECT 'Publishers', COUNT(*) FROM "Publishers"
UNION ALL
SELECT 'Categories', COUNT(*) FROM "Categories";
```

**Expected:** At least 1 record in each table for testing.

### Step 4: Test Simple Product Creation
```sql
-- Test without foreign keys first
INSERT INTO "Products" (
    "Title", "TitleArabic", "SKU", "ProductType",
    "IsAvailable", "IsFeatured", "IsNewRelease",
    "StockQuantity", "Rating", "RatingCount", "ViewCount",
    "CreatedAt", "UpdatedAt"
) VALUES (
    'Test Product', 'منتج تجريبي', '', 'Book',
    true, false, false,
    0, 0.0, 0, 0,
    CURRENT_TIMESTAMP, CURRENT_TIMESTAMP
);
```

**If this fails:** Database schema issue
**If this succeeds:** Proceed to test with foreign keys

### Step 5: Test Product Creation with Foreign Keys
```sql
-- First get valid IDs
SELECT id FROM "Authors" LIMIT 1;
SELECT id FROM "Publishers" LIMIT 1;
SELECT id FROM "Categories" LIMIT 1;

-- Then create product with FKs (replace 1,2,3 with actual IDs)
INSERT INTO "Products" (
    "Title", "TitleArabic", "SKU", "ProductType",
    "AuthorId", "PublisherId", "CategoryId",
    "IsAvailable", "IsFeatured", "IsNewRelease",
    "StockQuantity", "Rating", "RatingCount", "ViewCount",
    "CreatedAt", "UpdatedAt"
) VALUES (
    'Test Product with FK', 'منتج تجريبي مع مفتاح خارجي', 'TEST001', 'Book',
    1, 2, 3,  -- Replace with actual IDs
    true, false, false,
    10, 0.0, 0, 0,
    CURRENT_TIMESTAMP, CURRENT_TIMESTAMP
);
```

---

## 🚨 Common Issues & Solutions

### Issue 1: "Products table doesn't exist"
**Symptoms:** 400 Bad Request, "relation Products does not exist"
**Solution:** Run the migration scripts or check if EF migrations ran properly

### Issue 2: Foreign Key Constraint Violation
**Symptoms:** "violates foreign key constraint"
**Solution:** Use valid AuthorId/PublisherId/CategoryId values

### Issue 3: Null Value in Required Field
**Symptoms:** "null value in column X violates not-null constraint"
**Solution:** Ensure all required fields are provided (Title, ProductType, etc.)

### Issue 4: Duplicate SKU
**Symptoms:** "duplicate key value violates unique constraint"
**Solution:** Use unique SKU values or leave empty

---

## 📊 Database Schema Verification

### Check Products Table Structure:
```sql
SELECT column_name, data_type, is_nullable, column_default
FROM information_schema.columns
WHERE table_name = 'Products'
ORDER BY ordinal_position;
```

### Required Columns:
- `Id` (integer, not null, auto-increment)
- `Title` (varchar(200), not null)
- `TitleArabic` (varchar(200), nullable)
- `SKU` (varchar(20), nullable)
- `ProductType` (varchar(50), not null, default 'Book')
- `AuthorId` (integer, nullable) - Foreign Key
- `PublisherId` (integer, nullable) - Foreign Key
- `CategoryId` (integer, nullable) - Foreign Key
- Plus other nullable columns...

### Check Foreign Key Constraints:
```sql
SELECT
    tc.constraint_name,
    tc.constraint_type,
    kcu.column_name,
    ccu.table_name AS foreign_table_name,
    ccu.column_name AS foreign_column_name
FROM information_schema.table_constraints AS tc
    JOIN information_schema.key_column_usage AS kcu
      ON tc.constraint_name = kcu.constraint_name
    JOIN information_schema.constraint_column_usage AS ccu
      ON ccu.constraint_name = tc.constraint_name
WHERE tc.table_name = 'Products'
  AND constraint_type = 'FOREIGN KEY';
```

---

## 🧪 Frontend Testing

After confirming database works, test the API endpoints:

### 1. Get Reference Data
```javascript
// Get valid IDs for product creation
fetch('/api/Products/reference-data')
  .then(res => res.json())
  .then(data => console.log('Reference data:', data));
```

### 2. Validate Product Data
```javascript
// Test validation before creating
const testData = {
  title: "Test Product",
  productType: "Book",
  authorId: null,
  publisherId: null,
  categoryId: null
};

fetch('/api/Products/validate', {
  method: 'POST',
  headers: {'Content-Type': 'application/json'},
  body: JSON.stringify(testData)
})
.then(res => res.json())
.then(result => console.log('Validation result:', result));
```

### 3. Create Product
```javascript
// Create the actual product
fetch('/api/Products', {
  method: 'POST',
  headers: {'Content-Type': 'application/json'},
  body: JSON.stringify(testData)
})
.then(res => res.json())
.then(result => console.log('Creation result:', result))
.catch(error => console.error('Error:', error));
```

---

## 📞 Support

If you encounter issues:

1. **Run the database tests** to isolate the problem
2. **Check the API logs** in Render dashboard
3. **Use the validation endpoint** to test data before creation
4. **Share the exact error message** for specific troubleshooting

---

## 🧹 Cleanup

After testing, clean up test data:
```sql
DELETE FROM "Products" WHERE "Title" LIKE 'Test Product%';
```

This will help identify whether the issue is with the database schema, foreign key constraints, or the API implementation.
