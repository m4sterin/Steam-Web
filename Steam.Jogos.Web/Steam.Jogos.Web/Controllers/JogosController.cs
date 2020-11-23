using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Steam.Jogos.Dados.Entity.Context;
using Steam.Jogos.Dominio;
using Steam.Jogos.Repositorios.Comum;
using Steam.Jogos.Repositorios.Entity;
using Steam.Jogos.Web.ViewModels.Jogo;

namespace Steam.Jogos.Web.Controllers
{
    public class JogosController : Controller
    {
        private IRepositorioGenerico<Jogo, int>
            repositorioJogos = new JogosRepositorio(new JogoDbContext());

        // GET: Jogos
        public ActionResult Index()
        {
            return View(Mapper.Map <List<Jogo>, List<JogoIndexViewModel>>(repositorioJogos.Selecionar()));
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Jogo> jogos = repositorioJogos
                .Selecionar()
                .Where(a => a.Nome.Contains(pesquisa)).ToList();
            List<JogoIndexViewModel> viewModels = Mapper
                .Map<List<Jogo>, List<JogoIndexViewModel>>(jogos);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = repositorioJogos.SelecionarPorId(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Jogo, JogoIndexViewModel>(jogo));
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Preco,Desenvolvedora,EmailDev")] JogoViewModel viewModel )
        {
            if (ModelState.IsValid)
            {
                Jogo jogo = Mapper.Map<JogoViewModel, Jogo>(viewModel);
                repositorioJogos.Inserir(jogo);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = repositorioJogos.SelecionarPorId(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Jogo, JogoViewModel>(jogo));
        }

        // POST: Jogos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Preco,Desenvolvedora,EmailDev")] JogoViewModel viewModel )
        {
            if (ModelState.IsValid)
            {
                Jogo jogo = Mapper.Map<JogoViewModel, Jogo>(viewModel);
                repositorioJogos.Alterar(jogo);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = repositorioJogos.SelecionarPorId(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Jogo, JogoIndexViewModel>(jogo));
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioJogos.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
