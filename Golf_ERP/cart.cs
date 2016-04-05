using System;
using System.Collections.Generic;
using System.Text;
using Parse;

namespace Golf_ERP
{
    public class Cart
    {
        public Cart()
        {

        }

        /*
        Object properties
        objectId
        User
        Fleet_No
        Barcode_String
        Serial_No
        Year
        Brand
        Model
        Photo
        Notes
        */
        public int Id { get; set; }
        public string ObjectID { get; set; }
        public ParseUser User { get; set; }
        public string Fleet_No { get; set; }
        public string Barcode_String { get; set; }
        public string Serial_No { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ParseFile Photo { get; set; } //need a real var type
        public string Notes { get; set; }
}
}
