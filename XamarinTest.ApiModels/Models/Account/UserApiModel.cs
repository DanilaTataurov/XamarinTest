using System;

namespace XamarinTest.ApiModels.Models.Account {
    public class UserApiModel {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
