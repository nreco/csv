using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace NReco.Csv.Tests {
	
	public class CsvWriterTests {

		private readonly ITestOutputHelper output;

		public CsvWriterTests(ITestOutputHelper output) {
			this.output = output;
		}

		[Fact]
		public void CsvWriterTest() {
			var strWr = new StringWriter();
			var csvWriter = new CsvWriter(strWr);
			csvWriter.WriteField("AAA");
			csvWriter.WriteField("A\"AA");
			csvWriter.WriteField(" AAA ");
			csvWriter.WriteField("Something, again");
			csvWriter.WriteField("Something\nonce more");
			csvWriter.NextRecord();
			csvWriter.WriteField("Just one value");
			csvWriter.NextRecord();

			var expected = "AAA,\"A\"\"AA\",\" AAA \",\"Something, again\",\"Something\nonce more\"\r\nJust one value\r\n";
			Assert.Equal(expected, strWr.ToString());
		}


	}
}
