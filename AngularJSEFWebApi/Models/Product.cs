using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSEFWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        //public DateTime Modified
        //{
        //    get
        //    {
        //        return (this.modified == default(DateTime)) ? this.modified = DateTime.Now : this.modified;
        //    }

        //    set { this.modified = value; }
        //}

        //private DateTime modified;

        public DateTime Modified
        {
            get
            {
                return this.modified.HasValue ? this.modified.Value : DateTime.Now;
            }
            set
            {
                this.modified = value;
            }
        }

        private DateTime? modified = null;
    }
}