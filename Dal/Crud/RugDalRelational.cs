using Dal.Abstracts;
using Dal.Interfaces;
using Marten;
using Models.Models.Products;

namespace Dal
{
    public class RugDalDocumentDb : BasicDalDocumentDbAbstract<Rug>, IRugDal
    {
        private readonly DocumentStore _documentStore;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="documentStore"></param>
        public RugDalDocumentDb(DocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        protected override DocumentStore ResolveStore()
        {
            return _documentStore;
        }
    }
}