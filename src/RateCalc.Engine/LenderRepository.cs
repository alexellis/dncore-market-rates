using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace RateCalc.Engine
{
  public class Lender {
    public string Name {get;set;}
    public decimal Rate {get;set;}
    public decimal Available {get;set;}
  }

  public class LenderTable {
    private readonly List<Lender> _lenders;

    public LenderTable() {
      _lenders = new List<Lender>();
    }

    public void Add(string name, decimal rate, decimal available) {
      _lenders.Add(new Lender {
        Name = name,
        Rate = rate,
        Available = available
      });
    }

    public Lender GetLender(string name) {
      return _lenders.Where(l=>l.Name == name).FirstOrDefault();
    }
  }

  public class LenderRepository {
      private readonly List<CsvLine> _entries;

      public LenderRepository(List<CsvLine> entries) {
        _entries = entries;
      }
      
      public LenderTable Read() {
        var table = new LenderTable();
        foreach(var entry in _entries) {
          table.Add(entry.Parts[0], Convert.ToDecimal(entry.Parts[1]),  Convert.ToDecimal(entry.Parts[2]));
        }
        
        return table;
      }
  }
} 