using Microsoft.AspNetCore.Components.Web;
using SistemaContatos.Models;

namespace SistemaContatos.Repository
{
    public interface IContatoRepository
    {
        ContatoModel Inserir(ContatoModel contato);
        List<ContatoModel> GetAll();
        ContatoModel Get(int id);
        ContatoModel Editar(ContatoModel contato);

        void Excluir(int id);

    }
}
