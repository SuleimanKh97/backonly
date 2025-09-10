-- Simple Migration Script for Products Table
-- Copy and run this entire script in your database console

-- Create Products table if it doesn't exist
CREATE TABLE IF NOT EXISTS "Products" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(200) NOT NULL,
    "TitleArabic" VARCHAR(200),
    "SKU" VARCHAR(20),
    "Description" TEXT,
    "DescriptionArabic" TEXT,
    "ProductType" VARCHAR(50) NOT NULL DEFAULT 'Book',
    "AuthorId" INTEGER,
    "PublisherId" INTEGER,
    "CategoryId" INTEGER,
    "Grade" VARCHAR(50),
    "Subject" VARCHAR(50),
    "PublicationDate" TIMESTAMP WITH TIME ZONE,
    "Pages" INTEGER,
    "Language" VARCHAR(20) NOT NULL DEFAULT 'Arabic',
    "Price" DECIMAL(10,2),
    "OriginalPrice" DECIMAL(10,2),
    "StockQuantity" INTEGER NOT NULL DEFAULT 0,
    "CoverImageUrl" VARCHAR(500),
    "IsAvailable" BOOLEAN NOT NULL DEFAULT TRUE,
    "IsFeatured" BOOLEAN NOT NULL DEFAULT FALSE,
    "IsNewRelease" BOOLEAN NOT NULL DEFAULT FALSE,
    "Rating" DECIMAL(3,2) NOT NULL DEFAULT 0.0,
    "RatingCount" INTEGER NOT NULL DEFAULT 0,
    "ViewCount" INTEGER NOT NULL DEFAULT 0,
    "CreatedAt" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Create ProductImages table if it doesn't exist
CREATE TABLE IF NOT EXISTS "ProductImages" (
    "Id" SERIAL PRIMARY KEY,
    "ProductId" INTEGER NOT NULL,
    "ImageUrl" VARCHAR(500) NOT NULL,
    "ImageType" VARCHAR(50) NOT NULL DEFAULT 'Gallery',
    "DisplayOrder" INTEGER NOT NULL DEFAULT 0,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Add foreign key constraints
ALTER TABLE "Products" ADD CONSTRAINT IF NOT EXISTS "FK_Products_Authors_AuthorId"
    FOREIGN KEY ("AuthorId") REFERENCES "Authors" ("Id") ON DELETE SET NULL;

ALTER TABLE "Products" ADD CONSTRAINT IF NOT EXISTS "FK_Products_Categories_CategoryId"
    FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE SET NULL;

ALTER TABLE "Products" ADD CONSTRAINT IF NOT EXISTS "FK_Products_Publishers_PublisherId"
    FOREIGN KEY ("PublisherId") REFERENCES "Publishers" ("Id") ON DELETE SET NULL;

ALTER TABLE "ProductImages" ADD CONSTRAINT IF NOT EXISTS "FK_ProductImages_Products_ProductId"
    FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE;

-- Add indexes for better performance
CREATE INDEX IF NOT EXISTS "IX_Products_SKU" ON "Products" ("SKU");
CREATE INDEX IF NOT EXISTS "IX_Products_IsAvailable" ON "Products" ("IsAvailable");
CREATE INDEX IF NOT EXISTS "IX_Products_IsFeatured" ON "Products" ("IsFeatured");
CREATE INDEX IF NOT EXISTS "IX_Products_IsNewRelease" ON "Products" ("IsNewRelease");
CREATE INDEX IF NOT EXISTS "IX_ProductImages_ProductId" ON "ProductImages" ("ProductId");

-- Update migration history (optional, for EF tracking)
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250830125243_AddProductTables', '8.0.0')
ON CONFLICT ("MigrationId") DO NOTHING;

-- Success message
SELECT '✅ Products table migration completed successfully!' AS status;
