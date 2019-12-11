using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Api
    {
        public void Print(IList<Item> items)
        {
            var gildedRose = new GildedRose(items);
            
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");
                gildedRose.UpdateQuality();
            }
        }
    }
}