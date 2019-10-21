using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.BLogic.Library
{
    public class Location
    {

        /* private string _street;
        private string _city;
        private int _zipcode;
        private string _state;*/
        public int Id { get; set; }
        public string Address { get; set; }

        public List<InventoryItem> Inventory { get; set; } = new List<InventoryItem>();
        public List<Order> OrderHistory { get; set; } = new List<Order>();


        /*public string Street
        {
            get => _street;
            set
            {
                _street = value;
            }
        }
        public string City
        {
            get => _city;
            set
            {
                _city = value;
            }
        }
        public int Zipcode
        {
            get => _zipcode;
            set
            {
                _zipcode = value;
            }
        }
        public string State
        {
            get => _state;
            set
            {
                _state = value;
            }
        }*/

        // public List<Order> Orders { get; set; } = new List<Order>();
    }
}

