using System.Collections.Generic;
using System.Collections;
using System.Linq;

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

      private static void AddParts(string line, CsvLine csvLine) {
          var parts = line.Split(',');
          foreach(var part in parts) {
            csvLine.Parts.Add(part);
          }
      }

      public IEnumerable<CsvLine> Read(string uri) {
        var text = _fileSource.Read(uri);

        var lines = text.Split('\n');

        var list = new List<CsvLine>();
        for(int i = 1; i < lines.Count(); i++) {
          if(lines[i].Length > 0) {
            var csvLine = new CsvLine();
            var line = lines[i];
            AddParts(line, csvLine);
            list.Add(csvLine);
          }
        }

        return list;
      }
  }

  public class CsvLine {
    public CsvLine() {
      this.Parts = new List<string>();
    }

    public List<string> Parts {
      get;
      set;
    }
  }
}