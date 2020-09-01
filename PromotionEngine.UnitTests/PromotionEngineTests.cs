using PromotionEngine.CalculationEngine;
using PromotionEngine.CalculationEngine.Services;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.UnitTests
{
    public class PromotionEngineTests
    {
        private readonly Product _a;
        private readonly Product _b;
        private readonly Product _c;
        private readonly Product _d;
        private readonly ICalculationEngine _calculationService;
        private readonly IList<IPromotion> _promotions;

        public PromotionEngineTests()
        {
            _a = new Product("A", 50);
            _b = new Product("B", 30);
            _c = new Product("C", 20);
            _d = new Product("D", 15);

            _calculationService = new CalculationService();
            _promotions = new List<IPromotion>
            {
                new PromotionService(new Promotion("A", 3, 130)),
                new PromotionService(new Promotion("B", 2, 45)),
                new ComboPromotionService(new ComboPromotion( new List<string>{ "C","D" },30))
            };
        }
        [Fact(DisplayName = "Scenario A tests")]
        public void ScenarioATest()
        {
            //Arrange
            var items = new List<Item>() { new Item(_a, 1), new Item(_b, 1), new Item(_c, 1) };

            //Act
            var cart = new Cart(items, _calculationService.Calculate(items, _promotions));

            //Assert
            Assert.Equal(100, cart.Total);
        }
        [Fact(DisplayName = "Scenario B tests")]
        public void ScenarioBTest()
        {
            //Arrange
            var items = new List<Item>() { new Item(_a, 5), new Item(_b, 5), new Item(_c, 1) };

            //Act
            var cart = new Cart(items, _calculationService.Calculate(items, _promotions));

            //Assert
            Assert.Equal(370, cart.Total);
        }
        [Fact(DisplayName = "Scenario C tests")]
        public void ScenarioCTest()
        {
            //Arrange
            var items = new List<Item>() { new Item(_a, 3), new Item(_b, 5), new Item(_c, 1), new Item(_d, 1) };

            //Act
            var cart = new Cart(items, _calculationService.Calculate(items, _promotions));

            //Assert
            Assert.Equal(280, cart.Total);
        }
    }
}
