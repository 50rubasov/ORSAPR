using System;
using NUnit.Framework;
using KompasAPIModel;

namespace ParamsUnitTests
{
    /// <summary>
    /// �����, ���������� �� ������������ ������� ���������� ���������.
    /// </summary>
    [TestFixture]
    public class BodyParamsTests
    {
        [Test]
        [TestCase(14, TestName = "���������� ���� ��������� �������� ��������� ��������� �� ��������� 14")]
        [TestCase(46, TestName = "���������� ���� ��������� �������� ��������� ��������� �� ��������� 46")]
        public void SetSubDiameter_NegativeTest
            (int SubDiameter)
        {
            var bodyParams = new BodyParams();
            Assert.Throws<ArgumentException>(() =>
                bodyParams.SubDiameter = SubDiameter);
        }
        [TestCase(15, TestName = "���������� ���� ��������� �������� ��������� ��������� �� ��������� 15")]
        [TestCase(45, TestName = "���������� ���� ��������� �������� ��������� ��������� �� ��������� 45")]
        public void SetSubDiameter_PositiveTest(int SubDiameter)
        {
            var bodyParams = new BodyParams();
            bodyParams.SubDiameter = SubDiameter;
        }

        [TestCase(0, TestName = "���������� ���� ��������� ���������� ��������� ��������� �� ��������� 0")]
        [TestCase(3, TestName = "���������� ���� ��������� ���������� ��������� ��������� �� ��������� 3")]
        public void SetNumberOfHoles_NegativeTest
            (int NumberOfHoles)
        {
            var bodyParams = new BodyParams();
            Assert.Throws<ArgumentException>(() =>
                bodyParams.NumberOfHoles = NumberOfHoles);
        }
        [TestCase(1, TestName = "���������� ���� ��������� ���������� ��������� ��������� �� ��������� 1")]
        [TestCase(2, TestName = "���������� ���� ��������� ���������� ��������� ��������� �� ��������� 2")]
        public void SetNumberOfHoles_PositiveTest(int NumberOfHoles)
        {
            var bodyParams = new BodyParams();
            bodyParams.NumberOfHoles = NumberOfHoles;
        }

        [TestCase(4, 15, 1, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 4")]
        [TestCase(110, 15, 1, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 110")]
        public void SetLenght_NegativeTest
            (int Lenght, int SubDiameter, int NumberOfHoles)
        {
            var bodyParams = new BodyParams();
            bodyParams.NumberOfHoles = NumberOfHoles;
            bodyParams.SubDiameter = SubDiameter;
            Assert.Throws<ArgumentException>(() =>
                bodyParams.Lenght = Lenght);
        }
        [TestCase(16, 15, 1, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 16")]
        [TestCase(89, 15, 1, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 89")]
        public void SetLenght_PositiveTest(int Lenght, int SubDiameter, int NumberOfHoles)
        {
            var bodyParams = new BodyParams();
            bodyParams.NumberOfHoles = NumberOfHoles;
            bodyParams.SubDiameter = SubDiameter;
            bodyParams.Lenght = Lenght;
        }
        [TestCase(14, 15, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 14")]
        [TestCase(56, 15, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 56")]
        public void SetHeight_NegativeTest
            (int Height, int SubDiameter)
        {
            var bodyParams = new BodyParams();
            bodyParams.SubDiameter = SubDiameter;
            Assert.Throws<ArgumentException>(() =>
                bodyParams.Height = Height);
        }
        [TestCase(16, 15, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 16")]
        [TestCase(54, 15, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 54")]
        public void SetHeigh_PositiveTest(int Height, int SubDiameter)
        {
            var bodyParams = new BodyParams();
            bodyParams.SubDiameter = SubDiameter;
            bodyParams.Height = Height;
        }
        [TestCase(14, 15,45, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 14")]
        [TestCase(56, 15,45, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 56")]
        public void SetWidth_NegativeTest
            (int Width, int SubDiameter, int Lenght)
        {
            var bodyParams = new BodyParams();
            bodyParams.SubDiameter = SubDiameter;
            bodyParams.Lenght = Lenght;
            Assert.Throws<ArgumentException>(() =>
                bodyParams.Width = Width);
        }
        [TestCase(16, 15,45, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 16")]
        [TestCase(44, 15,45, TestName = "���������� ���� ��������� ������ ��������� �� ��������� 44")]
        public void SetWidth_PositiveTest(int Height, int SubDiameter, int Lenght)
        {
            var bodyParams = new BodyParams();
            bodyParams.Lenght = Lenght;
            bodyParams.SubDiameter = SubDiameter;
            bodyParams.Height = Height;
        }

        [TestCase(1, TestName = "���������� ���� ��������� ������� ��������� �� ��������� 1")]
        [TestCase(5, TestName = "���������� ���� ��������� ������� ��������� �� ��������� 5")]
        public void SetThickness_NegativeTest
            (int Thickness)
        {
            var bodyParams = new BodyParams();
            Assert.Throws<ArgumentException>(() =>
                bodyParams.Thickness = Thickness);
        }
        [TestCase(2, TestName = "���������� ���� ��������� ������� ��������� �� ��������� 2")]
        [TestCase(4, TestName = "���������� ���� ��������� ������� ��������� �� ��������� 4")]
        public void SetThickness_PositiveTest(int Thickness)
        {
            var bodyParams = new BodyParams();
            bodyParams.Thickness = Thickness;
        }

        [TestCase(3,15, TestName = "���������� ���� ��������� �������� ����� �� ��������� 3")]
        [TestCase(8,15,TestName = "���������� ���� ��������� �������� ����� �� ��������� 8")]
        public void SetPortDiameter_NegativeTest
            (int PortDiameter, int SubDiameter)
        {
            var bodyParams = new BodyParams();
            bodyParams.SubDiameter = SubDiameter;
            Assert.Throws<ArgumentException>(() =>
                bodyParams.PortDiameter = PortDiameter);
        }
        [TestCase(5,15, TestName = "���������� ���� ��������� �������� ����� �� ��������� 5")]
        [TestCase(7,15, TestName = "���������� ���� ��������� �������� ����� �� ��������� 7")]
        public void SetPortDiameter_PositiveTest(int PortDiameter, int SubDiameter)
        {
            var bodyParams = new BodyParams();
            bodyParams.SubDiameter = SubDiameter;
            bodyParams.PortDiameter = PortDiameter;
        }
    }
}