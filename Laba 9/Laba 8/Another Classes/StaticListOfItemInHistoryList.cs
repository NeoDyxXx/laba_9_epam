using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_8.Another_Classes
{
    public static class StaticListOfItemInHistoryList
    {
        public static bool EqualListsOfItemInHistoryList(this List<ItemInHistoryList> anotherItem, List<ItemInHistoryList> currectItem)
        {
            if (anotherItem.Count != currectItem.Count) return false;

            for (int i = 0; i < anotherItem.Count; i++)
            {
                if (!anotherItem[i].Equals(currectItem[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
