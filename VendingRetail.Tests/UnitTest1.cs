using NUnit.Framework;
using System.Reflection;

namespace VendingRetail.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void ConstructornitializesCorrectly()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            Assert.AreEqual(1000, coffeeMat.WaterCapacity);
            Assert.AreEqual(5, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);
        }

        [Test]
        public void WaterCapacityGetterWorksCorrectly()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            Assert.AreEqual(1000, coffeeMat.WaterCapacity);
        }
        [Test]
        public void FillWaterTankReturnsCorrectMessage()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            string result = coffeeMat.FillWaterTank();
            Assert.AreEqual($"Water tank is filled with {1000}ml", result);
        }
        [Test]
        public void FillWaterTankReturnsCorrectMessageWhenFull()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            coffeeMat.FillWaterTank();
            string result = coffeeMat.FillWaterTank();
            Assert.AreEqual($"Water tank is already full!", result);
        }
        [Test]
        public void AddDrinkReturnsCorrectMessage()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            bool result = coffeeMat.AddDrink("Espresso", 1.50);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void AddDrinkReturnsCorrectMessageWhenDrinkExists()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            coffeeMat.AddDrink("Espresso", 1.50);
            bool result = coffeeMat.AddDrink("Espresso", 1.50);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void BuyDrinkReturnsCorrectMessageWhenOutOfWater()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            string result = coffeeMat.BuyDrink("Espresso");
            Assert.AreEqual($"CoffeeMat is out of water!", result);
        }
        [Test]
        public void BuyDrinkReturnsCorrectMessageWhenDrinkExists()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            coffeeMat.AddDrink("Espresso", 1.50);
            coffeeMat.FillWaterTank();
            string result = coffeeMat.BuyDrink("Espresso");
            Assert.AreEqual($"Your bill is {1.50:f2}$", result);

        }
        [Test]
        public void BuyDrinkReturnsCorrectMessageWhenDrinkDoesNotExist()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            coffeeMat.AddDrink("Espresso", 1.50);
            coffeeMat.FillWaterTank();
            string result = coffeeMat.BuyDrink("Cappuccino");
            Assert.AreEqual($"Cappuccino is not available!", result);

        }
        [Test]
        public void FillWaterTankReturnsCorrectMessageWhenFull2()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            coffeeMat.FillWaterTank();
            string result = coffeeMat.FillWaterTank();
            Assert.AreEqual($"Water tank is already full!", result);
        }

        [Test]
        public void CollectIncomeReturnsCorrectMessage()
        {
            CoffeeMat coffeeMat = new CoffeeMat(1000, 5);
            coffeeMat.AddDrink("Espresso", 1.50);
            coffeeMat.FillWaterTank();
            coffeeMat.BuyDrink("Espresso");
            double result = coffeeMat.CollectIncome();
            Assert.AreEqual(1.50, result);
        }
        [Test]
        public void DrinksDictionary_NotNull()
        {

            CoffeeMat coffeeMachine = new CoffeeMat(1000, 5); 
            FieldInfo drinksField = coffeeMachine.GetType().GetField("drinks", BindingFlags.NonPublic | BindingFlags.Instance);
            var drinksDictionary = drinksField.GetValue(coffeeMachine);

            Assert.NotNull(drinksDictionary);
        }
        [Test]
        public void FillWaterTankReturnsMessage()
        {
            CoffeeMat coffeeMachine = new CoffeeMat(1000, 5);
            int initialWaterLevel = 0;
            int waterCapacity = 1000;

            string result = coffeeMachine.FillWaterTank();

            FieldInfo waterTankLevelField = coffeeMachine.GetType().GetField("waterTankLevel", BindingFlags.NonPublic | BindingFlags.Instance);
            int newWaterLevel = (int)waterTankLevelField.GetValue(coffeeMachine);

            Assert.AreEqual($"Water tank is filled with {waterCapacity - initialWaterLevel}ml", result);
            Assert.AreEqual(waterCapacity, newWaterLevel);
        }
        [Test]
        public void AddingDrinkBeforeInitialization_ReturnsFalse()
        {
            CoffeeMat coffeeMachine = new CoffeeMat(1000, 5);
            bool result = coffeeMachine.AddDrink("Espresso", 1.50); 
            Assert.IsTrue(result);
        }
        [Test]
        public void IncomeProperty_ReturnsCorrectValue()
        {
            CoffeeMat coffeeMachine = new CoffeeMat(1000, 5);
            coffeeMachine.AddDrink("Espresso", 1.50);
            coffeeMachine.FillWaterTank();
            coffeeMachine.BuyDrink("Espresso");
            double result = coffeeMachine.Income;
            Assert.AreEqual(1.50, result);
        }
        [Test]
        public void CollectIncomeReturnsCorrectValue()
        {
            CoffeeMat coffeeMachine = new CoffeeMat(1000, 5);
            coffeeMachine.AddDrink("Espresso", 1.50);
            coffeeMachine.FillWaterTank();
            coffeeMachine.BuyDrink("Espresso");
            double result = coffeeMachine.CollectIncome();
            Assert.AreEqual(1.50, result);
        }
        [Test]
        public void ButtonsCountGetterReturnsCorrectValue()
        {
            CoffeeMat coffeeMachine = new CoffeeMat(1000, 5);
            int result = coffeeMachine.ButtonsCount;
            Assert.AreEqual(5, result);
        }


    }
}