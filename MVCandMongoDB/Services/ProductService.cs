using MongoDB.Bson;
using MVCandMongoDB.Models;
using MVCandMongoDB.Models.ViewModels;
using MVCandMongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Services
{
    public class ProductService
    {
        private GenericRepository<ProductBSON> productRepository;
        private GenericRepository<OrderBSON> orderRepository;
        public ProductService()
        {
            this.productRepository = new GenericRepository<ProductBSON>("Products");
            this.orderRepository = new GenericRepository<OrderBSON>("Orders");
        }

        public bool Create(ProductViewModel viewModel)
        {
            var bson = new ProductBSON
            {
                Cena = viewModel.Cena,
                NaStanju = viewModel.NaStanju,
                Naziv = viewModel.Naziv
            };
            try
            {
                productRepository.Insert(bson);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = productRepository.GetAll();
            var viewModel = from p in products
                            select (new ProductViewModel
                            {
                                Cena = (double)p.Cena,
                                ID = p.ID.ToString(),
                                NaStanju = (bool)p.NaStanju,
                                Naziv = p.Naziv
                            });
            return viewModel;
        }
        public bool Poruci(OrderViewModel viewModel)
        {
            var product = productRepository.FindOne(p => p.ID == new ObjectId(viewModel.Product_ID));
            var order = new OrderBSON
            {
                Kolicina = viewModel.Kolicina,
                Product_ID = new ObjectId(viewModel.Product_ID),
                UkupnaCena = viewModel.Kolicina * (double)product.Cena,
                User_ID = new ObjectId(viewModel.User_ID),
                Placeno = false,
                Isporuceno = false
            };
            try
            {
                orderRepository.Insert(order);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}