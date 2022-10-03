using System;

namespace MouseShop.Domain.Models;

public class Mouse
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public float Weight { get; set; }
    
    public int DPI { get; set; }
    
    public int CountMouseButtons { get; set; }
    
    public string Backlight { get; set; }
    
    public string Producer { get; set; }
    
    public bool isAvailable { get; set; }
    
    public decimal Price { get; set; }
}