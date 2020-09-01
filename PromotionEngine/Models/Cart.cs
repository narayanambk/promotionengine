﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Cart
    {
        private readonly List<Item> _items = new List<Item>();
        public IReadOnlyList<Item> Items => _items.AsReadOnly();

        public decimal Total { get; private set; }

        public Cart(List<Item> items, decimal total)
        {
            _items = items;
            Total = total;
        }
        public Cart(List<Item> items)
        {
            _items = items;
            Total = default;
        }
    }
}
