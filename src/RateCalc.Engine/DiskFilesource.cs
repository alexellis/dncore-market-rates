using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;

namespace RateCalc.Engine
{
  public class DiskFileSource : IFileSource {
    public string Read(string uri) {
      return File.ReadAllText(uri);
    }    
  }
}