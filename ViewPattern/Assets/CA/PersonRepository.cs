using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class PersonRepository : IRepository<PersonEntity> {
        public PersonEntity GetEntity() { return new PersonEntity(); }
        public void SetEntity(PersonEntity entity) { /* Do Nothing */ }
    }
}
