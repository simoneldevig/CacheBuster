[![Build status](https://dev.azure.com/simonnorlundeldevig/CacheBuster/_apis/build/status/CacheBuster-ASP.NET-CI)](https://dev.azure.com/simonnorlundeldevig/CacheBuster/_build/latest?definitionId=1)

# CacheBuster

A small helper for cache busting static assets in .NET

## How it works
The helper looks at the file's last modified date and sets the timestamp as a queryparamter on the path to the static file. This means that everytime you change the file, the browser cache will update as well.

It's inspired by this [article](https://www.madskristensen.net/blog/cache-busting-in-aspnet) from 2014


## How to use
1. Install the Nuget package
2. Wrap your static assset paths in the CacheBuster method :arrow_right:

**Example**
```csharp
@using CacheBuster;

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    <link href="@CacheBuster.GetFullPath("/Content/Site.css")" rel="stylesheet">

    <script src="@CacheBuster.GetFullPath("/Scripts/modernizr-2.8.3.js")"></script>
</head>
<body>
</body>
</html>
```

**Result**
```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home Page - My ASP.NET Application</title>
    <link href="/Content/Site.css?v=637351943954662093" rel="stylesheet">

    <script src="/Scripts/modernizr-2.8.3.js?v=637351943957222104"></script>
</head>
<body>
</body>
</html>
```

## Contributing To This Project

Anyone and everyone is welcome to contribute. Just create a PR with your changes and I will have a look at it.

## License

Copyright &copy; 2020 Simon Eldevig

Licensed under the [MIT License](LICENSE)
