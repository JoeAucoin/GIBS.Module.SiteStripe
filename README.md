# GIBS.Module.SiteStripe

![.NET](https://img.shields.io/badge/.NET-10-512BD4)
![Oqtane](https://img.shields.io/badge/Oqtane-Module-0EA5E9)
![Blazor](https://img.shields.io/badge/Blazor-Server%20%26%20WASM-5C2D91)

SiteStripe is an Oqtane module for managing and displaying Amazon affiliate products in reusable, configurable layouts.

## Features

- Manage affiliate products (name, ASIN, affiliate URL, image URL, video URL, price, and status)
- Category management with hierarchy support and sort ordering
- Product assignment supports **both**:
  - `CategoryId` (managed category selection)
  - `ProductCategory` (text-based category value)
- Display template support (`SmallCard`, `TextOnly`, `Showcase`)
- Module settings for:
  - Default button text
  - Default disclosure statement
  - Store ID
  - Optional API credentials
- Paginated storefront display with disclosure text

## Tech Stack

- .NET 10
- Oqtane module architecture (Client / Server / Shared / Package)
- Blazor components

## Project Structure

- `Client/` - UI components, module views, and client services
- `Server/` - API controllers, repositories, migrations, and server services
- `Shared/` - shared models and interfaces
- `Package/` - packaging scripts and NuGet packaging assets

## Build

From the repository root:

```powershell
dotnet build GIBS.Module.SiteStripe.slnx
```

## Package

Package metadata is defined in:

- `Package/GIBS.Module.SiteStripe.nuspec`

Packaging scripts:

- `Package/debug.cmd`
- `Package/release.cmd`

## Installation (Oqtane)

1. Build/package the module.
2. Install the generated NuGet package in your Oqtane host.
3. Add the **SiteStripe** module to a page.
4. Use **Manage Records** and **Manage Category** actions to configure content.
5. Set module-level defaults in module settings.

## Screenshots

Add screenshots to a `/docs/images` folder and reference them here, for example:

```markdown
![SiteStripe - Index View](docs/images/sitestripe-index.png)
![SiteStripe - Edit View](docs/images/sitestripe-edit.png)
![SiteStripe - Category Management](docs/images/sitestripe-categories.png)
```

## Changelog

### 1.0.5

- .NET 10 target and package updates
- Current packaged release

### 1.0.4 and earlier

- Initial module releases and incremental feature updates

## License

MIT
