# NReco.Csv
Ultra-fast C# CSV parser: implements stream reader and writer. 
[![NuGet Release](https://img.shields.io/nuget/v/NReco.Csv.svg)](https://www.nuget.org/packages/NReco.Csv/)

* very fast: x2-x4 times faster than JoshClose's CSVHelper
* memory efficient: uses only single circular buffer, no allocations in heap for CSV of any size
* lightweight: bare csv parser with simple API
* tolerant to not-fully correct CSV files, you can control max length of CSV file (useful for processing end-user CSV uploads)
* can be used for stream processing of many-GB CSV files
* supports .NET Framework 4.5+ and .NET Core

## How to use
Parse CSV stream:
```
using (var streamRdr = new StreamReader(inputStream)) {
  var csvReader = new CsvReader(streamRdr, ",");
  while (csvReader.Read()) {
    for (int i=0; i&lt;csvReader.FieldsCount; i++) {
      string val = csvReader[i];
    }
  }
}
```
Generate CSV to stream:
```

using (var streamWr = new StreamWrite(outputStream)) {
  var csvWriter = new CsvWriter(streamWr);
  // write line
  csvWriter.WriteField("Value with double quote\"");
  csvWriter.WriteField("And with\nnew line");
  csvWriter.WriteField("Normal");
  csvWriter.NextRecord();
}
```

## Who is using this?
NReco.Csv is in production use at [SeekTable.com](https://www.seektable.com/) and [PivotData microservice](https://www.nrecosite.com/pivotdata_service.aspx).

## License
Copyright 2017-2018 Vitaliy Fedorchenko and contributors

Distributed under the MIT license
