using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewPatterns {
    [System.Serializable]
    public class PersonEntity : IEntity {
        [SerializeField] string name;
        [SerializeField] int age;
        [SerializeField] float height;
        [SerializeField] float weight;
        [SerializeField] float bmi;

        public string Name { set { name = value; } get => name; }
        public int Age { set { age = value; } get => age; }
        public float Height { set { height = value; } get => height; }
        public float Weight { set { weight = value; } get => weight; }
        public float BMI { set { bmi = value; } get => bmi; }
    }
}
