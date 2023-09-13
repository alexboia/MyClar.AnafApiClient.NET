# MyClar.AnafApiClient.NET
A .NET C# client for accessing the ANAF (romanian revenue service) VAT payer sync web service data.
Conforms to version 8 of sync web service specification: https://static.anaf.ro/static/10/Anaf/Informatii_R/Servicii_web/doc_WS_V8.txt.

Target platform: .NET 6.0.

Since the source JSON field names do not conform to regular C# naming conventions and since there is no single policy to map them to such convensions, each field is mapped individually using `[JsonProperty]`.
The entire data structure presented in the webservice documentation file is mapped.

I believe the code speaks for itself. Usage information can be found in the tests project (some values have been obfuscated, be sure to grab them first and replace them in the source code).

I don't really intend to update the code unless there's something really wrong with it or if I need anything else on top of what's already here.
Feel free to fork and use as you please.