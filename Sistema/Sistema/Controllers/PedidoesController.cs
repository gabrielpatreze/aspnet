using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema.DAL;
using Sistema.Models;

namespace Sistema.Controllers
{
    public class PedidoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedidos = db.Pedidoes
                .Include(x => x.Cliente)
                .ToList();
            return View(pedidos);
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes
                .Include(x => x.PedidoItems) //Incluir todos itens do pedido
                .FirstOrDefault(x => x.PedidoId == id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = pedido.PedidoId });
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes
                .Include(x => x.PedidoItems) //Incluir todos itens do pedido
                .FirstOrDefault(x => x.PedidoId == id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Itens do Pedido

        //Novo Item do Pedido
        public ActionResult NovoItem(int pedidoId)
        {
            return View(new PedidoItem(pedidoId));
        }

        //Post Adiconar novo item ao pedido
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoItem([Bind(Include = "PedidoItemId,Quantidade,Valor,Data,PedidoId")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                db.PedidoItems.Add(pedidoItem);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = pedidoItem.PedidoId });
            }
            return View(pedidoItem);
        }

        //Editar telefone Get
        public ActionResult EditarItem(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var item = db.PedidoItems.Find(id);
            return View(item);
        }

        //Post Editar telefone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarItem([Bind(Include = "PedidoItemId,Quantidade,Valor,Data,PedidoId")] PedidoItem pedidoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = pedidoItem.PedidoId });
            }
            return View(pedidoItem);
        }

        //Get Delete telefone
        public ActionResult DeleteItem(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var item = db.PedidoItems.Find(id);
            return View(item);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItemConfirmed(int id)
        {
            var item = db.PedidoItems.Find(id);
            db.PedidoItems.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = item.PedidoId });
        }

        #endregion
    }
}
