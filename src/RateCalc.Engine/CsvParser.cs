using System.Collections.Generic;
using System.Collections;

namespace RateCalc.Engine
{
  public interface IFileSource {
    string Read(string uri);    
  }

  public class CsvParser {
      private readonly IFileSource _fileSource;

      public CsvParser(IFileSource fileSource) {
        _fileSource = fileSource;
      }

      public IEnumerable<CsvLine> Read(string uri) {
        return new List<CsvLine>();
      } 
  }

  public class CsvLine {

  }
}