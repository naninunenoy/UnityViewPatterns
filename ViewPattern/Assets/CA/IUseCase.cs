using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public interface IUseCase<TPresenter, TRepository> where TPresenter : IPresenter
                                                       where TRepository : IRepository {
        void Initialize();
    }
}
