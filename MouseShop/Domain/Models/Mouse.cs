using System;
using System.ComponentModel.DataAnnotations;

namespace MouseShop.Domain.Models;

public class Mouse
{
    [Key]
    public int ID_mouse { get; set; }
    
    public string Name { get; set; }
    
    public double Weight { get; set; }
    
    public int DPI { get; set; }
    
    public int CountMouseButtons { get; set; }
    
    public string Backlight { get; set; }
    
    public string Producer { get; set; }
    
    public bool isAvailable { get; set; }
    
    public decimal Price { get; set; }
}