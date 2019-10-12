using System;
using System.Collections.Generic;

namespace Kabunga.Models
{
  public class Order
  {
    public Order() => Items = new List<OrderItem>();
        
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }
    public ICollection<OrderItem> Items { get; set; }
  }
}
