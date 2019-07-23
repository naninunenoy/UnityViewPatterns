using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public interface IPersonRepository : Core.IRepository {
        PersonEntity GetPerson();
        void SetPerson(PersonEntity person);
    }
}
