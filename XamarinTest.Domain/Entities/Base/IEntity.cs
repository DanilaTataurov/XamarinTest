using System;

namespace XamarinTest.Domain.Entities.Base {
    public interface IEntity {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }

    public interface IEntity<T> : IEntity {
        T Id { get; set; }
    }
}
