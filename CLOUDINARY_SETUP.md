# Cloudinary Setup Guide

## Overview
This application now uses Cloudinary for persistent image storage instead of local filesystem storage. This ensures images are available even when the app restarts on Render.

## Why Cloudinary?
- **Persistent Storage**: Images survive app restarts
- **CDN**: Fast global delivery
- **Automatic Optimization**: Images are resized and optimized
- **Free Tier**: 25GB storage, 25GB monthly bandwidth

## Setup Steps

### 1. Create Cloudinary Account
1. Go to [cloudinary.com](https://cloudinary.com)
2. Sign up for a free account
3. Verify your email

### 2. Get Your Credentials
1. Log into your Cloudinary dashboard
2. Go to **Account** → **Settings** → **Access Keys**
3. Copy these values:
   - **Cloud Name**: Your cloud name (shown in dashboard URL)
   - **API Key**: Your API key
   - **API Secret**: Your API secret

### 3. Configure Environment Variables

#### For Render (Production)
1. Go to your Render dashboard
2. Open your service settings
3. Go to **Environment**
4. Add these environment variables:
   ```
   Cloudinary__CloudName=your-cloud-name
   Cloudinary__ApiKey=your-api-key
   Cloudinary__ApiSecret=your-api-secret
   ```

#### For Local Development
Update `appsettings.Development.json`:
```json
{
  "Cloudinary": {
    "CloudName": "your-cloud-name",
    "ApiKey": "your-api-key",
    "ApiSecret": "your-api-secret"
  }
}
```

### 4. Deploy Changes
1. Commit and push your changes to Git
2. Render will automatically redeploy
3. Test image upload functionality

## Features

### Automatic Image Optimization
Images are automatically:
- Resized to max 800x600 pixels
- Quality optimized
- Format converted for best compression

### Organized Storage
- Images stored in `library-products` folder
- Unique filenames prevent conflicts
- Public URLs for easy access

### Error Handling
- Graceful fallback if Cloudinary fails
- Detailed logging for troubleshooting
- User-friendly error messages

## Testing

### Upload Test
1. Go to admin products page
2. Try uploading an image
3. Check browser console for success logs
4. Verify image appears in product display

### URL Format
Images will have URLs like:
```
https://res.cloudinary.com/your-cloud-name/image/upload/v123456789/library-products/filename.jpg
```

## Troubleshooting

### Common Issues

#### 1. "Cloudinary configuration is missing"
- Check environment variables are set correctly
- Ensure variable names match exactly (case-sensitive)

#### 2. Upload fails with 400 error
- Check API credentials are correct
- Verify Cloudinary account is active

#### 3. Images don't load
- Check browser console for 404 errors
- Verify Cloudinary URLs are being generated

#### 4. Local development issues
- Ensure `appsettings.Development.json` has correct values
- Restart the application after config changes

### Debug Commands

#### Check Cloudinary Configuration
```bash
curl https://your-app-url/api/Products/upload-image \
  -X POST \
  -H "Authorization: Bearer YOUR_TOKEN"
```

#### Test Image Access
```bash
curl -I "https://res.cloudinary.com/your-cloud-name/image/upload/library-products/test.jpg"
```

## Migration from Local Files

If you have existing images in `wwwroot/uploads/`, you can:

1. **Manual Upload**: Upload them to Cloudinary dashboard
2. **Bulk Migration**: Use Cloudinary's upload API to migrate existing files
3. **Database Update**: Update image URLs in database to point to Cloudinary

## Cost Estimation

### Free Tier Limits
- 25GB storage
- 25GB monthly bandwidth
- 25,000 monthly image transformations

### Usage Monitoring
- Monitor usage in Cloudinary dashboard
- Set up alerts for approaching limits
- Upgrade plan if needed

## Security Notes

- API secrets should never be in client-side code
- Use environment variables for all credentials
- Regularly rotate API keys
- Enable 2FA on Cloudinary account

## Support

For Cloudinary-specific issues:
- [Cloudinary Documentation](https://cloudinary.com/documentation)
- [Cloudinary Support](https://support.cloudinary.com/)
- [Stack Overflow](https://stackoverflow.com/questions/tagged/cloudinary)
