using Raven.Client;
using Raven.Client.Embedded;

namespace RavenDBSpike
{
    public class RavenFactory
    {
        private readonly EmbeddableDocumentStore _docStore;

        public RavenFactory()
        {
            _docStore = new EmbeddableDocumentStore { RunInMemory = true };
            _docStore.Configuration.Port = 7777;
            _docStore.Initialize();
        }

        public IDocumentSession CreateSession()
        {
            return _docStore.OpenSession();
        }

        public IDocumentStore GetStore()
        {
            return _docStore;
        }
    }
}