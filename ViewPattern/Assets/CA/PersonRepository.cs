using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns.CA {
    public class PersonRepository : IPersonRepository {
        public PersonEntity GetEntity() { return new PersonEntity(); }
        public void SetEntity(PersonEntity entity) { Debug.Log(JsonUtility.ToJson(entity)); }
    }
}
