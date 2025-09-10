-- Database Debugging Queries for Product Creation Issues
-- Connect using: postgresql://royallibrary_user:j659IZBu6nFOPfvJdAo7Fj06fKgX82Bv@dpg-d2mdog0dl3ps73avkq30-a.frankfurt-postgres.render.com/royallibrary

-- =========================================
-- 1. CHECK DATABASE TABLES EXISTENCE
-- =========================================

-- Check if Products table exists
SELECT table_name
FROM information_schema.tables
WHERE table_schema = 'public'
  AND table_name = 'Products';

-- Check all tables in the database
SELECT table_name
FROM information_schema.tables
WHERE table_schema = 'public'
ORDER BY table_name;

-- =========================================
-- 2. CHECK TABLE STRUCTURES
-- =========================================

-- Check Products table structure
SELECT column_name, data_type, is_nullable, column_default
FROM information_schema.columns
WHERE table_name = 'Products'
ORDER BY ordinal_position;

-- Check foreign key constraints
SELECT
    tc.table_name,
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
WHERE constraint_type = 'FOREIGN KEY'
  AND tc.table_name = 'Products';

-- =========================================
-- 3. CHECK REFERENCE DATA
-- =========================================

-- Check Authors (should have active records)
SELECT id, name, namearabic, isactive
FROM "Authors"
WHERE isactive = true
ORDER BY name
LIMIT 10;

-- Check Publishers
SELECT id, name, namearabic
FROM "Publishers"
ORDER BY name
LIMIT 10;

-- Check Categories (should have active records)
SELECT id, name, namearabic, isactive
FROM "Categories"
WHERE isactive = true
ORDER BY name
LIMIT 10;

-- =========================================
-- 4. CHECK EXISTING PRODUCTS
-- =========================================

-- Count products
SELECT COUNT(*) as total_products FROM "Products";

-- Check recent products
SELECT id, title, sku, producttype, authorid, publisherid, categoryid, createdat
FROM "Products"
ORDER BY createdat DESC
LIMIT 5;

-- Check for duplicate SKUs
SELECT sku, COUNT(*) as count
FROM "Products"
WHERE sku IS NOT NULL AND sku != ''
GROUP BY sku
HAVING COUNT(*) > 1;

-- =========================================
-- 5. TEST PRODUCT INSERTION
-- =========================================

-- Test 1: Simple product without foreign keys
-- This should work if the table structure is correct
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

-- Check if the insert worked
SELECT * FROM "Products" WHERE title = 'Test Product';

-- Test 2: Product with foreign keys (replace with actual IDs)
-- First check what IDs exist:
-- SELECT id FROM "Authors" LIMIT 1;
-- SELECT id FROM "Publishers" LIMIT 1;
-- SELECT id FROM "Categories" LIMIT 1;

-- Then run this with actual IDs:
-- INSERT INTO "Products" (
--     "Title", "TitleArabic", "SKU", "ProductType",
--     "AuthorId", "PublisherId", "CategoryId",
--     "IsAvailable", "IsFeatured", "IsNewRelease",
--     "StockQuantity", "Rating", "RatingCount", "ViewCount",
--     "CreatedAt", "UpdatedAt"
-- ) VALUES (
--     'Test Product with FK', 'منتج تجريبي مع مفتاح خارجي', 'TEST001', 'Book',
--     1, 1, 1,  -- Replace with actual IDs
--     true, false, false,
--     10, 0.0, 0, 0,
--     CURRENT_TIMESTAMP, CURRENT_TIMESTAMP
-- );

-- =========================================
-- 6. CHECK DATABASE CONSTRAINTS
-- =========================================

-- Check all constraints on Products table
SELECT
    tc.constraint_name,
    tc.constraint_type,
    kcu.column_name
FROM information_schema.table_constraints tc
    JOIN information_schema.key_column_usage kcu
      ON tc.constraint_name = kcu.constraint_name
WHERE tc.table_name = 'Products';

-- =========================================
-- 7. CLEANUP TEST DATA
-- =========================================

-- Remove test products
DELETE FROM "Products" WHERE title LIKE 'Test Product%';

-- =========================================
-- 8. PERFORMANCE CHECKS
-- =========================================

-- Check database size
SELECT
    schemaname,
    tablename,
    pg_size_pretty(pg_total_relation_size(schemaname||'.'||tablename)) as size
FROM pg_tables
WHERE schemaname = 'public'
ORDER BY pg_total_relation_size(schemaname||'.'||tablename) DESC;

-- Check table row counts
SELECT
    schemaname,
    tablename,
    n_tup_ins as rows_inserted,
    n_tup_upd as rows_updated,
    n_tup_del as rows_deleted
FROM pg_stat_user_tables
WHERE schemaname = 'public'
ORDER BY n_tup_ins DESC;
