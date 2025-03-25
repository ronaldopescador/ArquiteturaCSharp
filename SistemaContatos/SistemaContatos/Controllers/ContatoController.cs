using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Models;
using SistemaContatos.Repository;

namespace SistemaContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;            
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.GetAll();
            return View(contatos);
        }
        public IActionResult Inserir()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.Get(id);
            return View(contato);
        }
        public IActionResult ExcluirConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepository.Get(id);
            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
           _contatoRepository.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Inserir(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Inserir(contato);
                    TempData["MensagemSucesso"] = $"Contato incluído com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao inserir {e.Message}";
                return RedirectToAction("Index");
            }            
        }
        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepository.Editar(contato);
                return RedirectToAction("Index");
            }
            return View("Editar", contato);
        }

    }
}
