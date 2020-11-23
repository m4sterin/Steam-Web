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
using Steam.Jogos.Web.ViewModels.Dlcc;
using Steam.Jogos.Web.ViewModels.Jogo;

namespace Steam.Jogos.Web.Controllers
{
    public class DlcsController : Controller
    {
        private IRepositorioGenerico<Dlc, int>
            repositorioDlc = new DlcsRepositorio(new JogoDbContext());

        private IRepositorioGenerico<Jogo, int>
            repositorioJogo = new JogosRepositorio(new JogoDbContext());

        // GET: Dlcs
        public ActionResult Index()
        {
            //var dlc = db.Dlc.Include(d => d.Jogo);
            return View(Mapper.Map<List<Dlc>, List<DlcIndexViewModel>>(repositorioDlc.Selecionar()));
        }

        // GET: Dlcs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dlc dlc = repositorioDlc.SelecionarPorId((int)id.Value);
            if (dlc == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Dlc, DlcIndexViewModel>(dlc));
        }

        // GET: Dlcs/Create
        public ActionResult Create()
        {
            //ViewBag.IdJogo = new SelectList(db.Jogo, "Id", "Nome");
            List<JogoIndexViewModel> jogos = Mapper.Map<List<Jogo>,
                List<JogoIndexViewModel>>(repositorioJogo.Selecionar());

            SelectList dropDownJogos = new SelectList(jogos, "Id", "Nome");
            ViewBag.DropDownJogos = dropDownJogos;
            return View();
        }

        // POST: Dlcs/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDlc,NomeDlc,DescricaoDlc,PrecoDlc,IdJogo")] DlcViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Dlc dlc = Mapper.Map<DlcViewModel, Dlc>(viewModel);
                repositorioDlc.Inserir(dlc);
                return RedirectToAction("Index");
            }

            //ViewBag.IdJogo = new SelectList(db.Jogo, "Id", "Nome", dlc.IdJogo);
            return View(viewModel);
        }

        // GET: Dlcs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dlc dlc = repositorioDlc.SelecionarPorId((int)id.Value);
            if (dlc == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdJogo = new SelectList(db.Jogo, "Id", "Nome", dlc.IdJogo);
            List<JogoIndexViewModel> jogos = Mapper.Map<List<Jogo>,
                List<JogoIndexViewModel>>(repositorioJogo.Selecionar());

            SelectList dropDownJogos = new SelectList(jogos, "Id", "Nome");
            ViewBag.DropDownJogos = dropDownJogos;
            return View(Mapper.Map<Dlc, DlcViewModel>(dlc));
        }

        // POST: Dlcs/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDlc,NomeDlc,DescricaoDlc,PrecoDlc,IdJogo")] DlcViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Dlc dlc = Mapper.Map<DlcViewModel, Dlc>(viewModel);
                repositorioDlc.Alterar(dlc);
                return RedirectToAction("Index");
            }
            //ViewBag.IdJogo = new SelectList(db.Jogo, "Id", "Nome", dlc.IdJogo);
            return View(viewModel);
        }

        // GET: Dlcs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dlc dlc = repositorioDlc.SelecionarPorId((int)id.Value);
            if (dlc == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Dlc, DlcIndexViewModel>(dlc));
        }

        // POST: Dlcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioDlc.ExcluirPorId((int)id);
            return RedirectToAction("Index");
        }
    }
}
