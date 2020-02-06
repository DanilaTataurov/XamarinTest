using System;
using System.Collections.Generic;
using SQLite;

namespace XamarinTest.Data.Entities {
    public class User {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}
