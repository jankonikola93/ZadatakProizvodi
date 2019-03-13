using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCandMongoDB.Repository
{
    public interface IGenericReposiroty<TDocument> where TDocument : class
    {
        IEnumerable<TDocument> GetAll();
        IEnumerable<TDocument> Find(Expression<Func<TDocument, bool>> filter);
        TDocument FindOne(Expression<Func<TDocument, bool>> filter);
        void Insert(TDocument document);
        void InsertMany(IEnumerable<TDocument> documents);
        void Update(TDocument document, Expression<Func<TDocument, bool>> filter);
        void UpdateMany(IEnumerable<TDocument> documents, Expression<Func<TDocument, bool>> filter);
        void Delete(Expression<Func<TDocument, bool>> filter);
        void DeleteMany(Expression<Func<TDocument, bool>> filter);
    }
}
