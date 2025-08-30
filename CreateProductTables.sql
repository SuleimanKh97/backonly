-- Create Product table
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
    "PublicationDate" TIMESTAMP,
    "Pages" INTEGER,
    "Language" VARCHAR(20) DEFAULT 'Arabic',
    "Price" DECIMAL(10,2),
    "OriginalPrice" DECIMAL(10,2),
    "StockQuantity" INTEGER DEFAULT 0,
    "CoverImageUrl" VARCHAR(500),
    "IsAvailable" BOOLEAN DEFAULT TRUE,
    "IsFeatured" BOOLEAN DEFAULT FALSE,
    "IsNewRelease" BOOLEAN DEFAULT FALSE,
    "Rating" DECIMAL(3,2) DEFAULT 0.0,
    "RatingCount" INTEGER DEFAULT 0,
    "ViewCount" INTEGER DEFAULT 0,
    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create ProductImage table
CREATE TABLE IF NOT EXISTS "ProductImages" (
    "Id" SERIAL PRIMARY KEY,
    "ProductId" INTEGER NOT NULL,
    "ImageUrl" VARCHAR(500) NOT NULL,
    "ImageType" VARCHAR(50) DEFAULT 'Gallery',
    "DisplayOrder" INTEGER DEFAULT 0,
    "IsActive" BOOLEAN DEFAULT TRUE,
    "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create indexes
CREATE INDEX IF NOT EXISTS "IX_Products_SKU" ON "Products" ("SKU");
CREATE INDEX IF NOT EXISTS "IX_Products_Title" ON "Products" ("Title");
CREATE INDEX IF NOT EXISTS "IX_Products_ProductType" ON "Products" ("ProductType");
CREATE INDEX IF NOT EXISTS "IX_Products_IsAvailable" ON "Products" ("IsAvailable");
CREATE INDEX IF NOT EXISTS "IX_Products_IsFeatured" ON "Products" ("IsFeatured");
CREATE INDEX IF NOT EXISTS "IX_Products_IsNewRelease" ON "Products" ("IsNewRelease");
CREATE INDEX IF NOT EXISTS "IX_ProductImages_ProductId" ON "ProductImages" ("ProductId");

-- Add foreign key constraints
ALTER TABLE "Products" 
ADD CONSTRAINT "FK_Products_Authors_AuthorId" 
FOREIGN KEY ("AuthorId") REFERENCES "Authors" ("Id") ON DELETE SET NULL;

ALTER TABLE "Products" 
ADD CONSTRAINT "FK_Products_Publishers_PublisherId" 
FOREIGN KEY ("PublisherId") REFERENCES "Publishers" ("Id") ON DELETE SET NULL;

ALTER TABLE "Products" 
ADD CONSTRAINT "FK_Products_Categories_CategoryId" 
FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE SET NULL;

ALTER TABLE "ProductImages" 
ADD CONSTRAINT "FK_ProductImages_Products_ProductId" 
FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE;

-- Add unique constraint for SKU
ALTER TABLE "Products" ADD CONSTRAINT "IX_Products_SKU_Unique" UNIQUE ("SKU");
