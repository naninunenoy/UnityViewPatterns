using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class PersonRepository : IPersonRepository {
        public PersonEntity GetPerson() { return new PersonEntity(); }
        public void SetPerson(PersonEntity entity) { Debug.Log(JsonUtility.ToJson(entity)); }
    }
}
