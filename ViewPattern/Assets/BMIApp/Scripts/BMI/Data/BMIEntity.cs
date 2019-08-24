using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BMIApp.BMI {
    [Serializable]
    public class BMIEntity : IBMIEntity {
        const string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        [SerializeField] string name;
        [SerializeField] float height;
        [SerializeField] float weight;
        [SerializeField] int age;
        [SerializeField] string gender;
        [SerializeField] float bmi;
        [SerializeField] string createdAt;

        public BMIEntity() {
            name = string.Empty;
            height = 0.0F;
            weight = 0.0F;
            age = 0;
            gender = Gender.None.ToString();
            bmi = 0.0F;
            createdAt = DateTime.MinValue.ToString(dateTimeFormat);
        }

        public string Name { set { name = value; } get => name; }
        public float Height { set { height = value; } get => height; }
        public float Weight { set { weight = value; } get => weight; }
        public int Age { set { age = value; } get => age; }
        public Gender Gender { set { gender = value.ToString(); } get => (Gender)Enum.Parse(typeof(Gender), gender); }
        public float BMI { set { bmi = value; } get => bmi; }
        public DateTime CreatedAt { set { createdAt = value.ToString(dateTimeFormat); } get => DateTime.Parse(createdAt); }
    }

    [Serializable]
    public class BMIEntityArray {
        [SerializeField] BMIEntity[] items;
        public BMIEntityArray(BMIEntity[] items) { this.items = items; }
        public BMIEntityArray(IBMIEntity[] items) {
            this.items = items.Select(x => 
                new BMIEntity {
                    Name = x.Name,
                    Height = x.Height,
                    Weight = x.Weight,
                    Age = x.Age,
                    Gender = x.Gender,
                    BMI = x.BMI,
                    CreatedAt = x.CreatedAt
                }
            ).ToArray();
        }
        public IReadOnlyList<BMIEntity> Items { get => items; }
    }
}
