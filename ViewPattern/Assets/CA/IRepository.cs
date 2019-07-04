using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public interface IRepository {
    }
    public interface IRepository<TEntity> : IRepository where TEntity : IEntity {
    }
}
