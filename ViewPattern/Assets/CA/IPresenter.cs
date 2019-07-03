using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public interface IPresenter {
    }
    public interface IPresenter<TView> : IPresenter where TView : IView {
    }
}
