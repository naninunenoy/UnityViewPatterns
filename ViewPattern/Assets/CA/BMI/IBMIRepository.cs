using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public interface IPersonRepository : IRepository<PersonEntity> {
        PersonEntity GetPerson();
        void SetPerson(PersonEntity entity);
    }
}
