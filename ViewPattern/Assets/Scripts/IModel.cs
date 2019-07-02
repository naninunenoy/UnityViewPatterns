using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns {
    public interface IModel<TEntity, TResult> {
        bool TryApply(TEntity data, out TResult result);
    }
}
