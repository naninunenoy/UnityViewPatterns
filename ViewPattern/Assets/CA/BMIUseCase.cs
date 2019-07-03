using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class BMIUseCase : IUseCase<BMIPresenter, PersonRepository> {

        public BMIUseCase(BMIPresenter presenter, PersonRepository repository) {

        }
    }
}
