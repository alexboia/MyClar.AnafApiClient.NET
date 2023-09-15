# MyClar.AnafApiClient.NET
A .NET C# client for accessing the ANAF (romanian revenue service) VAT payer sync web service data.
Conforms to version 8 of sync web service specification: https://static.anaf.ro/static/10/Anaf/Informatii_R/Servicii_web/doc_WS_V8.txt.

### About

Target platform: .NET 6.0.

Since the source JSON field names do not conform to regular C# naming conventions and since there is no single policy to map them to such convensions, each field is mapped individually using `[JsonProperty]`.
The entire data structure presented in the webservice documentation file is mapped.

### Usage

I believe the code speaks for itself, but here's a quick usage example:

```csharp
IHttpClientFactory httpClientFactory = 
	/* create http client factory instance */;
IAnafVatPayerDataLookupClientFactory clientFactory = 
	new DefaultAnafVatPayerDataLookupClientFactory(httpClientFactory);

IAnafVatPayerDataLookupClient client = 
	clientFactory.CreateClient();

AnafApiClientVatPayerLookupInput input = 
	new AnafApiClientVatPayerLookupInput("...VAT CODE...");

AnafApiClientVatPayerLookupResponse response = await client
	.LookupVatPayerDataAsync( input );
```

Specifying a reference date is as simple as specifying the `date` parameter when creating a `AnafApiClientVatPayerLookupInput` input:

```csharp
AnafApiClientVatPayerLookupInput inputAtJan12021 = 
	new AnafApiClientVatPayerLookupInput("...VAT CODE...", 
		new DateTime(2021, 1, 1));
```

You can also specify multiple inputs at a time:

```csharp
AnafApiClientVatPayerLookupInput input1 = 
	new AnafApiClientVatPayerLookupInput("...VAT CODE1...");

AnafApiClientVatPayerLookupInput input2 = 
	new AnafApiClientVatPayerLookupInput("...VAT CODE2...");

AnafApiClientVatPayerLookupResponse response = await client
	.LookupVatPayerDataAsync( new List<AnafApiClientVatPayerLookupInput>() 
	{
		input1, input2
	} );
```

Notes:
- Everything's injectable;
- The web-service accepts and returns dates using the `yyyy-MM-dd` format, but it can be configured to be something else [using the options object](https://github.com/alexboia/MyClar.AnafApiClient.NET/blob/main/MyClar.AnafApiClient.NET/DefaultAnafVatPayerDataLookupClientFactory.cs);
- There is no `IHttpClientFactory` implementation provided, but you can use the same library [used in the tests project](https://github.com/alexboia/MyClar.AnafApiClient.NET/blob/main/MyClar.AnafApiClient.NET.Tests/Support/StandaloneHttpClientWrapperFactory.cs);
- You can provide your own factory implementation or not use a factory at all;
- Options (`HttpClientAnafVatPayerDataLookupClientOptions`) are also injectable, provided using the `IOptions<>` interface;
- Do not pass the prefix to the VAT code (eg. the "RO" part), because the web service will yield an error, even if the code itself is vald.

Usage examples can also be found in the [tests project](https://github.com/alexboia/MyClar.AnafApiClient.NET/tree/main/MyClar.AnafApiClient.NET.Tests) (some values have been obfuscated, be sure to grab them first and replace them in the source code).

### Next?

I don't really intend to update the code unless there's something really wrong with it or if I need anything else on top of what's already here.
Feel free to fork and use as you please.
