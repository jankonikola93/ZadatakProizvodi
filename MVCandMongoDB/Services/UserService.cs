using MongoDB.Bson;
using MongoDB.Driver;
using MVCandMongoDB.Models;
using MVCandMongoDB.Models.ViewModels;
using MVCandMongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCandMongoDB.Services
{
    public class UserService
    {
        //private MongoDbContext context;
        private IGenericReposiroty<UserBSON> userRepository;
        public UserService()
        {
            //this.context = new MongoDbContext();
            this.userRepository = new GenericRepository<UserBSON>("Users");
        }
        public bool Create(UserViewModel viewModel)
        {
            var bsonModel = new UserBSON
            {
                Godine = viewModel.Godine,
                Ime = viewModel.Ime,
                JMBG = viewModel.JMBG,
                Prezime = viewModel.Prezime
            };
            try
            {
                userRepository.Insert(bsonModel);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<UserViewModel> GetAll()
        {

            //var collection = context.mongoDatabase.GetCollection<UserBSON>("Users");
            //var documents = collection.Find(new BsonDocument()).ToList();
            var documents = userRepository.GetAll();
            var viewModel = from d in documents
                            select (new UserViewModel
                            {
                                Godine = d.Godine,
                                ID = d.ID.ToString(),
                                Ime = d.Ime,
                                JMBG = d.JMBG,
                                Prezime = d.Prezime,
                                Grupe = d.Grupe
                            });
            
            return viewModel;
        }
        public UserViewModel GetById(string id)
        {
            //var collection = context.mongoDatabase.GetCollection<UserBSON>("Users");
            //var filter = Builders<UserBSON>.Filter.Eq("ID", id);
            //var user = collection.Find(filter).FirstOrDefault();
            //var user = collection.Find(u => u.ID == new ObjectId(id)).FirstOrDefault();
            var user = userRepository.FindOne(u => u.ID == new ObjectId(id));
            var viewModel = new UserViewModel
            {
                Godine = user.Godine,
                ID = user.ID.ToString(),
                Ime = user.Ime,
                JMBG = user.JMBG,
                Prezime = user.Prezime,
            };
            if(user.Adresa != null)
            {
                viewModel.Adresa = new AdresaViewModel
                {
                    Broj = user.Adresa.Broj,
                    Mesto = user.Adresa.Mesto,
                    Ulica = user.Adresa.Ulica,
                    ZIP = user.Adresa.ZIP,
                };

            }
            return viewModel;
        }

        public bool Edit(UserViewModel viewModel)
        {
            var userBson = new UserBSON
            {
                Godine = viewModel.Godine,
                ID = new ObjectId(viewModel.ID),
                Ime = viewModel.Ime,
                Prezime = viewModel.Prezime,
                JMBG = viewModel.JMBG,
                Adresa = new AdresaBSON
                {
                    ZIP = viewModel.Adresa.ZIP,
                    Ulica = viewModel.Adresa.Ulica,
                    Mesto = viewModel.Adresa.Mesto,
                    Broj = viewModel.Adresa.Broj
                }
            };
            //var collection = context.mongoDatabase.GetCollection<UserBSON>("Users");
            try
            {
                //collection.ReplaceOne(u => u.ID == userBson.ID, userBson);
                userRepository.Update(userBson, u => u.ID == userBson.ID);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool Delete(UserViewModel viewModel)
        { 
            //var collection = context.mongoDatabase.GetCollection<UserBSON>("Users");
            try
            {
                //collection.DeleteOne(u => u.ID == new ObjectId(viewModel.ID));
                userRepository.Delete(u => u.ID == new ObjectId(viewModel.ID));
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        
    }
}