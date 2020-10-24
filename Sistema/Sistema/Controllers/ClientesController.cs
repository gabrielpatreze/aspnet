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
    public class ClientesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Categoria);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes
                .Include(x => x.Enderecos) //Incluir todos endereços do cliente
                .Include(x => x.Telefones) //Incluir todos telefones do cliente
                .FirstOrDefault(x => x.ClienteId == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Nome,Email,Cpf,CategoriaId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = cliente.ClienteId });
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao", cliente.CategoriaId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes
                .Include(x => x.Enderecos) //Incluir a lista de todos endereço do cliente
                .Include(x => x.Telefones) //Incluir a lista de telefones do cliente
                .FirstOrDefault(x => x.ClienteId == id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao", cliente.CategoriaId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Nome,Email,Cpf,CategoriaId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Descricao", cliente.CategoriaId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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

        #region Endereços

        //Novo endereço
        public ActionResult NovoEndereco(int clienteId)
        {
            return View(new Endereco(clienteId));
        }

        //Post Adiconar novo endereço
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoEndereco([Bind(Include = "EnderecoId,Rua,Numero,Bairro,ClienteId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Enderecoes.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = endereco.ClienteId });
            }
            return View(endereco);
        }

        //Editar endereço Get
        public ActionResult EditarEndereco(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var endereco = db.Enderecoes.Find(id);
            return View(endereco);
        }

        //Post Editar endereço
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEndereco([Bind(Include = "EnderecoId,Rua,Numero,Bairro,ClienteId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = endereco.ClienteId });
            }
            return View(endereco);
        }

        //Get Delete Endereco
        public ActionResult DeleteEndereco(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var endereco = db.Enderecoes.Find(id);
            return View(endereco);
        }

        [HttpPost, ActionName("DeleteEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEnderecoConfirmed(int id)
        {
            var endereco = db.Enderecoes.Find(id);
            db.Enderecoes.Remove(endereco);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = endereco.ClienteId });
        }

        #endregion
        
        #region Telefones

        //Novo Telefone
        public ActionResult NovoTelefone(int clienteId)
        {
            return View(new Telefone(clienteId));
        }

        //Post Adiconar novo telefone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoTelefone([Bind(Include = "TelefoneId,DDD,TelefoneNumero,ClienteId")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Telefones.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = telefone.ClienteId });
            }
            return View(telefone);
        }

        //Editar telefone Get
        public ActionResult EditarTelefone(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var telefone = db.Telefones.Find(id);
            return View(telefone);
        }

        //Post Editar telefone
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarTelefone([Bind(Include = "TelefoneId,DDD,TelefoneNumero,ClienteId")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = telefone.ClienteId });
            }
            return View(telefone);
        }

        //Get Delete telefone
        public ActionResult DeleteTelefone(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var telefone = db.Telefones.Find(id);
            return View(telefone);
        }

        [HttpPost, ActionName("DeleteTelefone")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTelefoneConfirmed(int id)
        {
            var telefone = db.Telefones.Find(id);
            db.Telefones.Remove(telefone);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = telefone.ClienteId });
        }

        #endregion


    }
}
