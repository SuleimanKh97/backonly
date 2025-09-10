const { Client } = require('pg');

// Database connection configuration
const client = new Client({
  host: 'dpg-d2mdog0dl3ps73avkq30-a.frankfurt-postgres.render.com',
  database: 'royallibrary',
  user: 'royallibrary_user',
  password: 'j659IZBu6nFOPfvJdAo7Fj06fKgX82Bv',
  port: 5432,
  ssl: { rejectUnauthorized: false }
});

async function testConnection() {
  console.log('🔄 Testing database connection...');

  try {
    await client.connect();
    console.log('✅ Database connection successful!');

    // Test basic query
    const result = await client.query('SELECT version()');
    console.log('📊 PostgreSQL version:', result.rows[0].version);

  } catch (error) {
    console.error('❌ Database connection failed:', error.message);
    return false;
  }

  return true;
}

async function checkTables() {
  console.log('\n📋 Checking database tables...');

  try {
    // Check Products table
    const productsResult = await client.query(`
      SELECT EXISTS (
        SELECT FROM information_schema.tables
        WHERE table_schema = 'public'
        AND table_name = 'Products'
      );
    `);
    console.log('📋 Products table exists:', productsResult.rows[0].exists);

    // Check other tables
    const tables = ['Authors', 'Publishers', 'Categories', 'Books'];
    for (const table of tables) {
      const result = await client.query(`
        SELECT EXISTS (
          SELECT FROM information_schema.tables
          WHERE table_schema = 'public'
          AND table_name = '${table}'
        );
      `);
      console.log(`📋 ${table} table exists:`, result.rows[0].exists);
    }

  } catch (error) {
    console.error('❌ Table check failed:', error.message);
  }
}

async function checkReferenceData() {
  console.log('\n📊 Checking reference data...');

  try {
    const tables = ['Authors', 'Publishers', 'Categories', 'Books', 'Products'];

    for (const table of tables) {
      const result = await client.query(`SELECT COUNT(*) FROM "${table}"`);
      console.log(`📊 ${table}: ${result.rows[0].count} records`);
    }

  } catch (error) {
    console.error('❌ Reference data check failed:', error.message);
  }
}

async function testProductCreation() {
  console.log('\n🧪 Testing product creation...');

  try {
    // Test simple product creation
    const insertResult = await client.query(`
      INSERT INTO "Products" (
        "Title", "TitleArabic", "SKU", "ProductType",
        "IsAvailable", "IsFeatured", "IsNewRelease",
        "StockQuantity", "Rating", "RatingCount", "ViewCount",
        "CreatedAt", "UpdatedAt"
      ) VALUES (
        'Test Product - Node.js', 'منتج تجريبي من Node.js', 'TESTJS001', 'Book',
        true, false, false,
        3, 4.2, 5, 15,
        CURRENT_TIMESTAMP, CURRENT_TIMESTAMP
      ) RETURNING "Id"
    `);

    const productId = insertResult.rows[0].Id;
    console.log('✅ Test product created with ID:', productId);

    // Verify creation
    const verifyResult = await client.query(
      'SELECT * FROM "Products" WHERE "Title" = $1',
      ['Test Product - Node.js']
    );

    console.log('📋 Product verification:', verifyResult.rows.length > 0 ? 'Success' : 'Failed');

  } catch (error) {
    console.error('❌ Product creation test failed:', error.message);
    console.error('❌ Error details:', error);
  }
}

async function getSampleData() {
  console.log('\n📋 Getting sample reference data...');

  try {
    // Get sample authors
    const authors = await client.query(`
      SELECT id, name, namearabic, isactive
      FROM "Authors"
      WHERE isactive = true
      ORDER BY name
      LIMIT 3
    `);
    console.log('👤 Sample Authors:', authors.rows);

    // Get sample publishers
    const publishers = await client.query(`
      SELECT id, name, namearabic
      FROM "Publishers"
      ORDER BY name
      LIMIT 3
    `);
    console.log('🏢 Sample Publishers:', publishers.rows);

    // Get sample categories
    const categories = await client.query(`
      SELECT id, name, namearabic, isactive
      FROM "Categories"
      WHERE isactive = true
      ORDER BY name
      LIMIT 3
    `);
    console.log('📂 Sample Categories:', categories.rows);

  } catch (error) {
    console.error('❌ Sample data retrieval failed:', error.message);
  }
}

async function cleanup() {
  console.log('\n🧹 Cleaning up test data...');

  try {
    const result = await client.query(`
      DELETE FROM "Products"
      WHERE "Title" LIKE 'Test Product%'
    `);

    console.log(`🗑️  Cleaned up ${result.rowCount} test products`);

  } catch (error) {
    console.error('❌ Cleanup failed:', error.message);
  }
}

async function main() {
  console.log('🚀 Database Connection Test Script (Node.js)');
  console.log('=' .repeat(50));

  try {
    // Test connection
    if (!(await testConnection())) {
      process.exit(1);
    }

    // Check tables
    await checkTables();

    // Check reference data
    await checkReferenceData();

    // Get sample data
    await getSampleData();

    // Test product creation
    await testProductCreation();

    // Cleanup
    await cleanup();

  } finally {
    await client.end();
  }

  console.log('\n' + '='.repeat(50));
  console.log('🎉 Database tests completed!');
}

// Run if called directly
if (require.main === module) {
  main().catch(console.error);
}

module.exports = { testConnection, checkTables, checkReferenceData, testProductCreation };
