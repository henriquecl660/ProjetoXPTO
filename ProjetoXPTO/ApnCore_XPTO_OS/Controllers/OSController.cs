using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApnCore_XPTO_OS.Data;
using ApnCore_XPTO_OS.Models;

namespace ApnCore_XPTO_OS.Controllers
{
    public class OSController : Controller
    {
        private readonly ApnCore_XPTO_OSContext _context;

        private readonly IOSDAL ordem_serv;


        public OSController(ApnCore_XPTO_OSContext context, IOSDAL os)
        {
            _context = context;
            ordem_serv = os;

        }



        // GET: OSController2
        public async Task<IActionResult> Index()
        {
       

            List<OS> listaOSs = new List<OS>();
            listaOSs = ordem_serv.GetAllOSs().ToList();

            return View(listaOSs);
        }

        // GET: OSController2/Details/5
        public IActionResult Details(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            OS os = ordem_serv.GetOS(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(os);
        }

        [HttpGet]
        public IActionResult Create()
        {
            OS os = ordem_serv.GetOS(-1);
            return View(os);
        }

        // POST: OSController2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NUM_OS,TITULO_SERV,CNPJ_CLI,NOME_CLI,CPF_PREST,NOME_PREST,DATA_SERV,VALOR_SERV")] OS os)
        {
            if (ModelState.IsValid)
            {
                ordem_serv.AddOS(os);
                return RedirectToAction("Index");
            }
            return View(os);
        }

        // GET: OSController2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            if (id == null)
            {
                return NotFound();
            }

            OS os = ordem_serv.GetOS(id);
            if (!ModelState.IsValid)
            {
               
                return RedirectToAction("Index");
            }
            return View(os);
        }

        // POST: OSController2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NUM_OS,TITULO_SERV,CNPJ_CLI,NOME_CLI,CPF_PREST,NOME_PREST,DATA_SERV,VALOR_SERV")] OS oS)
        {
            if (id != oS.NUM_OS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ordem_serv.UpdateOS(oS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OSExists(oS.NUM_OS))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(oS);
        }

        // GET: OSController2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            OS os = ordem_serv.GetOS(id);

            if (os == null)
            {
                return NotFound();
            }

            return View(os);

        }

        // POST: OSController2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ordem_serv.DeleteOS(id);
            return RedirectToAction(nameof(Index));
        }

        private bool OSExists(int id)
        {
            return _context.OS.Any(e => e.NUM_OS == id);
        }
    }
}
