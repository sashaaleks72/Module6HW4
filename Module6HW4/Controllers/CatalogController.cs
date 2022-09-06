using Microsoft.AspNetCore.Mvc;
using Module6HW4.Exceptions;
using Module6HW4.Interfaces;
using Module6HW4.Models;
using Module6HW4.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW4.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ITeapotService _teapotService;

        public CatalogController(ITeapotService teapotService)
        {
            _teapotService = teapotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeapots()
        {
            List<Teapot> teapots = null;
            
            try
            {
                teapots = await _teapotService.GetTeapots();
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.ErrorMessage });
            }

            return View(teapots);
        }

        public async Task<IActionResult> GetTeapotById(Guid id)
        {
            Teapot teapot = null;

            try
            {
                teapot = await _teapotService.GetTeapotById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.ErrorMessage });
            }

            return View(teapot);
        }

        public IActionResult AddTeapot()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeapot(TeapotViewModel teapotFromBody)
        {
            await _teapotService.AddTeapot(teapotFromBody);

            return RedirectToAction("GetTeapots");
        }

        [HttpGet]
        public async Task<IActionResult> EditTeapotById(Guid id)
        {
            Teapot teapot = null;
            
            try
            {
                teapot = await _teapotService.GetTeapotById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.ErrorMessage });
            }

            return View(teapot);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeapotById(Teapot teapot)
        {
            var teapotFromView = new TeapotViewModel
            {
                ImgUrl = teapot.ImgUrl,
                Capacity = teapot.Capacity,
                Price = teapot.Price,
                Description = teapot.Description,
                ManufacturerCountry = teapot.ManufacturerCountry,
                Quantity = teapot.Quantity,
                Title = teapot.Title,
                WarrantyInMonths = teapot.WarrantyInMonths
            };

            try
            {
                await _teapotService.EditTeapotById(teapot.Id, teapotFromView);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.ErrorMessage });
            }

            return RedirectToAction("GetTeapots");
        }

        public async Task<IActionResult> DeleteTeapotById(Guid id)
        {
            try
            {
                await _teapotService.DeleteTeapotById(id);
            }
            catch (BusinessException ex)
            {
                return NotFound(new { ex.ErrorMessage });
            }

            return RedirectToAction("GetTeapots");
        }
    }
}
