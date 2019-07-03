using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMIUseCase : IUseCase<IPresenter<BMIView>, IRepository<PersonEntity>> {

        public BMIUseCase(BMIPresenter presenter, PersonRepository repository) {

        }
    }
}
