// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpeisekarteController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Controllers
{
    using System;
    using System.IO;
    using System.Web.Mvc;

    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Web.Extensions;
    using Lbk.MobileApp.Web.Models;

    /// <summary>
    /// The speisekarte controller.
    /// </summary>
    public partial class SpeisekarteController : AuthorizedController
    {
        #region Public Methods and Operators

        public virtual ActionResult Detail()
        {
            var @model = new SpeisekarteFormModel();

            return this.View(@model);
        }

        public virtual FilePathResult DisplayPdf(string fileName)
        {
            var @model = new SpeisekarteFormModel();
            @model.FileName = fileName;

            return this.File(@model.FilePath, "application/pdf", fileName);
        }

        public virtual ActionResult Edit()
        {
            var @model = new SpeisekarteFormModel();

            return this.View(@model);
        }
        
        [HttpPost]
        public virtual ActionResult Edit(SpeisekarteFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                if (model.File.HasFile())
                {
                    this.Validate(model);
                    this.DeleteFile(model);
                    this.Upload(model);
                }

                if (this.ModelState.IsValid)
                {
                    return this.View("Detail", model);
                }
            }

            return this.View(model);
        }

        #endregion

        #region Methods

     private bool DeleteFile(SpeisekarteFormModel model)
        {
            if (!string.IsNullOrEmpty(model.FileName))
            {
                try
                {
                    var filePath = Path.Combine(model.BasePath, model.FileName);
                    if (System.IO.File.Exists(filePath))
                    {
                         System.IO.File.Delete(filePath);
                    }
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return this.ModelState.IsValid;
        }

        private bool Upload(SpeisekarteFormModel model)
        {
            try
            {
                string filename = Path.GetFileName(model.File.FileName);
                if (filename != null)
                {
                    // model.FileName = filename;
                    model.File.SaveAs(Path.Combine(model.BasePath, model.FileName));
                }
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("File", ex.Message);
            }
           
            return this.ModelState.IsValid;
        }

        private bool Validate(SpeisekarteFormModel model)
        {
            if (Path.GetExtension(model.File.FileName) != ".pdf")
            {
                this.ModelState.AddModelError(string.Empty, Messages.OnlyPdfFileAllowed);
            }

            return this.ModelState.IsValid;
        }

        #endregion
    }
}