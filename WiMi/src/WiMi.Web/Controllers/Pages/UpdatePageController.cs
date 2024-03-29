﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WiMi.Domain;
using WiMi.Domain.Pages.Find;
using WiMi.Domain.Pages.Update;

namespace WiMi.Web.Controllers.Pages
{
    public class UpdatePageController : Controller
    {
        readonly IPageFinder pageFinder;
        readonly IPageUpdater pageUpdater;

        public UpdatePageController(
            IPageFinder pageFinder, 
            IPageUpdater pageUpdater)
        {
            this.pageFinder = pageFinder;
            this.pageUpdater = pageUpdater;
        }

        public IActionResult Edit(Guid id)
        {
            var viewModel = FindPageViewModelBy(id);
            return View("~/Views/Pages/Edit.cshtml", viewModel);
        }

        Models.UpdatePageViewModel FindPageViewModelBy(Guid id)
        {
            var page = pageFinder.FindBy(id);
            var result = new Models.UpdatePageViewModel
            {
                Id = page.Id.ToString(),
                Title = page.Title,
                Body = page.Body
            };
            return result;
        }

        [HttpPut]
        public IActionResult Update(
            [FromBody]Models.PageUpdatingRequest request)
        {
            if(request is null)
            {
                return BadRequest(new ReadOnlyCollection<Error>(new List<Error> { new Error(Error.ErrorCodes.RequestCanNotBeNull) }));
            }
            var result = pageUpdater.Update(new PageUpdatingRequest(
                id: request.Id,
                title: request.Title,
                body: request.Body));
            if(result.IsOk)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
    }
}