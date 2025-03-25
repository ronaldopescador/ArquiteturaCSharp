using SistemaContatos.Data;
using SistemaContatos.Models;

namespace SistemaContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;            
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel model = Get(contato.Id);
            if (model == null)
                throw new Exception($"Contato {contato.Id} não encontrado!");
            model.Nome = contato.Nome;
            model.Email = contato.Email;
            model.Celular = contato.Celular;
            _bancoContext.Contatos.Update(model);
            _bancoContext.SaveChanges();
            return model;
        }

        public ContatoModel Inserir(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Get(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> GetAll()
        {
            return _bancoContext.Contatos.ToList();
        }

        public void Excluir(int id)
        {
            ContatoModel model = Get(id);
            if (model == null)
                throw new Exception($"Contato {id} não encontrado!");
            _bancoContext.Contatos.Remove(model);
            _bancoContext.SaveChanges();

        }
    }
}
