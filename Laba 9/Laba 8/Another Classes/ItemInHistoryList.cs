using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_8.Another_Classes
{
    public class ItemInHistoryList
    {
        public string NameOfStock { get; set; }
        public string TimeOfTrade { get; set; }

        public bool Equals(ItemInHistoryList other)
        {
            return other.NameOfStock.Contains(this.NameOfStock) && other.TimeOfTrade.Contains(this.TimeOfTrade);
        }
    }
}
