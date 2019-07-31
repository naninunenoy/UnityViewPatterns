using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BMIApp {
    [Serializable]
    public class BMIEntity : IBMIEntity {
        [SerializeField] string name;
        [SerializeField] float height;
        [SerializeField] float weight;
        [SerializeField] int age;
        [SerializeField] Gender gender;
        [SerializeField] float bmi;
        [SerializeField] DateTime createdAt;

        public BMIEntity() {
            name = string.Empty;
            height = 0.0F;
            weight = 0.0F;
            age = 0;
            gender = Gender.None;
            bmi = 0.0F;
            createdAt = DateTime.MinValue;
        }

        public string Name { set { name = value; } get => name; }
        public float Height { set { height = value; } get => height; }
        public float Weight { set { weight = value; } get => weight; }
        public int Age { set { age = value; } get => age; }
        public Gender Gender { set { gender = value; } get => gender; }
        public float BMI { set { bmi = value; } get => bmi; }
        public DateTime CreatedAt { set { createdAt = value; } get => createdAt; }
    }
}
