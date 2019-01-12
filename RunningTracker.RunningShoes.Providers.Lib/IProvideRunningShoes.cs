using System;
using System.Collections;
using System.Collections.Generic;
using RunningTracker.WeatherConditions;
using RunningTracker.Running;
using RunningTracker.RunningShoes;

namespace RunningTracker.RunningShoes.Providers
{
    public interface IProvideRunningShoes
    {
         IEnumerable<Shoe> GetAllShoes();
         IEnumerable<Shoe> GetShoes(Brand b);
    }

    public class HardcodedRunningShoeProvider : IProvideRunningShoes
    {
        private readonly List<Shoe> _allShoes;
        private readonly Dictionary<Brand, List<Shoe>> _brandToShoes;

        public HardcodedRunningShoeProvider()
        {
            _allShoes = new List<Shoe>();
            _brandToShoes = new Dictionary<Brand, List<Shoe>>();
            Initialize();
        }

        public IEnumerable<Shoe> GetAllShoes()
        {
            return _allShoes;
        }   

        public IEnumerable<Shoe> GetShoes(Brand b)
        {
            List<Shoe> shoes;
            _brandToShoes.TryGetValue(b, out shoes);
            return shoes;
        }

        private void Initialize()
        {
            // TODO: this obviously shouldn't be hardcoded - store in a .csv or local database?
            AddShoe(new Shoe(Brand.Brooks, "x10", 10.5, DateTime.Parse("2017-01-05"), new ShoeTransaction(125.25m, DateTime.Parse("2018-01-05"), "Fleet Feet"), new Usage(200, 90)));
            AddShoe(new Shoe(Brand.Brooks, "x10", 10.5, DateTime.Parse("2017-03-05"), new ShoeTransaction(125.25m, DateTime.Parse("2018-03-05"), "Fleet Feet"), new Usage(300, 90)));
            AddShoe(new Shoe(Brand.Brooks, "x12", 10.5, DateTime.Parse("2018-01-01"), new ShoeTransaction(125.25m, DateTime.Parse("2018-05-05"), "Fleet Feet"), new Usage(400, 90)));
            AddShoe(new Shoe(Brand.Brooks, "x12", 10.5, DateTime.Parse("2018-01-01"), new ShoeTransaction(125.25m, DateTime.Parse("2018-07-05"), "Fleet Feet"), new Usage(150, 90)));
            AddShoe(new Shoe(Brand.Brooks, "x12", 10.5, DateTime.Parse("2018-01-01"), new ShoeTransaction(125.25m, DateTime.Parse("2018-09-05"), "Fleet Feet"), new Usage(250, 90)));
            AddShoe(new Shoe(Brand.Brooks, "x12", 10.5, DateTime.Parse("2018-01-01"), new ShoeTransaction(125.25m, DateTime.Parse("2018-11-05"), "Fleet Feet"), new Usage(350, 90)));
            AddShoe(new Shoe(Brand.Brooks, "x14", 10.5, DateTime.Parse("2019-01-05"), new ShoeTransaction(125.25m, DateTime.Parse("2019-01-05"), "Fleet Feet"), new Usage(195, 90)));
        }

        private void AddShoe(Shoe s)
        {
            _allShoes.Add(s);

            List<Shoe> shoesByBrand;
            if (!_brandToShoes.TryGetValue(s.Brand, out shoesByBrand))
            {
                shoesByBrand = new List<Shoe>();
                _brandToShoes[s.Brand] = shoesByBrand;
            }

            shoesByBrand.Add(s);
        }
    }
}