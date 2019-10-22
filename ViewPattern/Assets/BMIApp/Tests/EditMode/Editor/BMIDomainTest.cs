using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BMIApp.BMI;

namespace BMIApp.Tests.EditMode {
    public class BMIDomainTest {
        [Test]
        public void BMIDataTransferObjectTest() {
            var dto = new BMIDataTransferObject();

            Assert.NotNull(dto);
            Assert.IsInstanceOf<IBMIDataTransferObject>(dto);

            Assert.IsEmpty(dto.Name);
            Assert.AreEqual(dto.Weight, 0.0F);
            Assert.AreEqual(dto.Height, 0.0F);
            Assert.AreEqual(dto.Age, 0);
            Assert.AreEqual(dto.Gender, Gender.None);
            Assert.AreEqual(dto.BMI, 0.0F);
            Assert.AreEqual(dto.CreatedAt, DateTime.MinValue);

            dto.Name = "test_name";
            dto.Weight = 11.1F;
            dto.Height = 22.2F;
            dto.Age = 33;
            dto.Gender = Gender.Male;
            dto.BMI = 44.4F;
            dto.CreatedAt = DateTime.Parse("2000-1-1 12:34:56");
            Assert.AreEqual(dto.Name, "test_name");
            Assert.AreEqual(dto.Weight, 11.1F);
            Assert.AreEqual(dto.Height, 22.2F);
            Assert.AreEqual(dto.Age, 33);
            Assert.AreEqual(dto.Gender, Gender.Male);
            Assert.AreEqual(dto.BMI, 44.4F);
            Assert.AreEqual(dto.CreatedAt, DateTime.Parse("2000-1-1 12:34:56"));
        }

        [Test]
        public void BMIDomainCalcTest() {
            var domain = new BMIDomain();
            var dto = new BMIDataTransferObject();

            Assert.IsInstanceOf<IBMIDomain>(domain);
            Assert.IsInstanceOf<IBMIDomainObject>(dto);

            dto.Weight = 100.0F;
            dto.Height = 100.0F;
            var bmi = domain.CalcBMI(dto);
            var msg = domain.EvaluateBMI(dto);
            Assert.AreEqual(bmi, 100.0F);
            Assert.AreEqual(msg, "肥満");

            dto.Weight = 100.0F;
            dto.Height = 0.0F;
            bmi = domain.CalcBMI(dto);
            msg = domain.EvaluateBMI(dto);
            Assert.AreEqual(bmi, 0.0F);
            Assert.AreEqual(msg, "やせすぎ");

            dto.Weight = 15.999F;
            dto.Height = 100.0F;
            bmi = domain.CalcBMI(dto);
            msg = domain.EvaluateBMI(dto);
            Assert.AreEqual(bmi, 15.999F);
            Assert.AreEqual(msg, "やせすぎ");


            dto.Weight = 16.999F;
            dto.Height = 100.0F;
            bmi = domain.CalcBMI(dto);
            msg = domain.EvaluateBMI(dto);
            Assert.AreEqual(bmi, 16.999F);
            Assert.AreEqual(msg, "やせ");

            dto.Weight = 18.499F;
            dto.Height = 100.0F;
            bmi = domain.CalcBMI(dto);
            msg = domain.EvaluateBMI(dto);
            Assert.AreEqual(bmi, 18.499F);
            Assert.AreEqual(msg, "やせ気味");

            dto.Weight = 24.999F;
            dto.Height = 100.0F;
            bmi = domain.CalcBMI(dto);
            msg = domain.EvaluateBMI(dto);
            Assert.AreEqual(bmi, 24.999F);
            Assert.AreEqual(msg, "普通");

            dto.Weight = 29.999F;
            dto.Height = 100.0F;
            bmi = domain.CalcBMI(dto);
            msg = domain.EvaluateBMI(dto);
            Assert.AreEqual(bmi, 29.999F);
            Assert.AreEqual(msg, "肥満気味");
        }
    }
}
