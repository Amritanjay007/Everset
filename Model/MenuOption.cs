using System;
using Microsoft.Extensions.DependencyInjection;

public class Option
{
    public string Name { get;set; }
    public Action Selected { get;set; }

}