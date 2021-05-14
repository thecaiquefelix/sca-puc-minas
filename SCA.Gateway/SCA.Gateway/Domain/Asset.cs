using System;
namespace SCA.Gateway.Domain
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Serial { get; set; }
        public bool Active { get; set; }
    }

    public enum Manufacturer
    {
        Cat,
        Vaisala,
        Volkswagen,
        Tratorparts,
        Domaq
    }

    public enum Category
    {
        Machine,
        Tool
    }
}
