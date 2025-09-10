#!/usr/bin/env python3
"""
Database Connection Test Script
Test the external database connection and run basic queries
"""

import psycopg2
import sys

# Database connection details
DB_CONFIG = {
    'host': 'dpg-d2mdog0dl3ps73avkq30-a.frankfurt-postgres.render.com',
    'database': 'royallibrary',
    'user': 'royallibrary_user',
    'password': 'j659IZBu6nFOPfvJdAo7Fj06fKgX82Bv',
    'port': '5432'
}

def test_connection():
    """Test basic database connection"""
    try:
        print("🔄 Testing database connection...")
        conn = psycopg2.connect(**DB_CONFIG)
        print("✅ Database connection successful!")

        # Get basic info
        cursor = conn.cursor()
        cursor.execute("SELECT version();")
        version = cursor.fetchone()
        print(f"📊 PostgreSQL version: {version[0]}")

        cursor.close()
        conn.close()
        return True

    except Exception as e:
        print(f"❌ Database connection failed: {e}")
        return False

def check_tables():
    """Check if required tables exist"""
    try:
        conn = psycopg2.connect(**DB_CONFIG)
        cursor = conn.cursor()

        # Check Products table
        cursor.execute("""
            SELECT EXISTS (
                SELECT FROM information_schema.tables
                WHERE table_schema = 'public'
                AND table_name = 'Products'
            );
        """)
        products_exists = cursor.fetchone()[0]
        print(f"📋 Products table exists: {products_exists}")

        # Check other tables
        tables_to_check = ['Authors', 'Publishers', 'Categories', 'Books']
        for table in tables_to_check:
            cursor.execute(f"""
                SELECT EXISTS (
                    SELECT FROM information_schema.tables
                    WHERE table_schema = 'public'
                    AND table_name = '{table}'
                );
            """)
            exists = cursor.fetchone()[0]
            print(f"📋 {table} table exists: {exists}")

        cursor.close()
        conn.close()

    except Exception as e:
        print(f"❌ Table check failed: {e}")

def check_reference_data():
    """Check reference data counts"""
    try:
        conn = psycopg2.connect(**DB_CONFIG)
        cursor = conn.cursor()

        # Check counts
        tables = ['Authors', 'Publishers', 'Categories', 'Books', 'Products']
        for table in tables:
            cursor.execute(f'SELECT COUNT(*) FROM "{table}";')
            count = cursor.fetchone()[0]
            print(f"📊 {table}: {count} records")

        cursor.close()
        conn.close()

    except Exception as e:
        print(f"❌ Reference data check failed: {e}")

def test_product_creation():
    """Test creating a simple product"""
    try:
        conn = psycopg2.connect(**DB_CONFIG)
        cursor = conn.cursor()

        # Test insert
        cursor.execute("""
            INSERT INTO "Products" (
                "Title", "TitleArabic", "SKU", "ProductType",
                "IsAvailable", "IsFeatured", "IsNewRelease",
                "StockQuantity", "Rating", "RatingCount", "ViewCount",
                "CreatedAt", "UpdatedAt"
            ) VALUES (
                'Test Product - Direct DB', 'منتج تجريبي من قاعدة البيانات', 'TESTDB001', 'Book',
                true, false, false,
                5, 4.5, 10, 25,
                CURRENT_TIMESTAMP, CURRENT_TIMESTAMP
            ) RETURNING "Id";
        """)

        product_id = cursor.fetchone()[0]
        print(f"✅ Test product created with ID: {product_id}")

        conn.commit()

        # Verify the product was created
        cursor.execute('SELECT * FROM "Products" WHERE "Title" = %s;', ('Test Product - Direct DB',))
        product = cursor.fetchone()
        print(f"📋 Product verification: {product is not None}")

        cursor.close()
        conn.close()

    except Exception as e:
        print(f"❌ Product creation test failed: {e}")

def main():
    print("🚀 Database Connection Test Script")
    print("=" * 50)

    # Test connection
    if not test_connection():
        sys.exit(1)

    print("\n" + "=" * 50)
    # Check tables
    check_tables()

    print("\n" + "=" * 50)
    # Check reference data
    check_reference_data()

    print("\n" + "=" * 50)
    # Test product creation
    test_product_creation()

    print("\n" + "=" * 50)
    print("🎉 Database tests completed!")

if __name__ == "__main__":
    main()
