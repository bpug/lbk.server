// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpeisekarteFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.IO;
    using System.Web;

    using Lbk.MobileApp.Domain.Resources;

    #endregion

    /// <summary>
    /// The speisekarte form model.
    /// </summary>
    public class SpeisekarteFormModel
    {
        #region Fields

        /// <summary>
        /// The file name.
        /// </summary>
        private string fileName;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the base path.
        /// </summary>
        public string BasePath
        {
            get
            {
                return ConfigurationManager.AppSettings["SpeisekarteServerBasePath"];
            }
        }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        [Display(Name = "SpeisekarteFileLabelText", ResourceType = typeof(Messages))]
        public HttpPostedFileBase File { get; set; }

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(this.fileName))
                {
                    return "speisekarte.pdf";
                }

                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        public string FilePath
        {
            get
            {
                if (!this.IsFileExist())
                {
                    return string.Empty;
                }

                return Path.Combine(this.BasePath, this.FileName);
            }
        }

        public string FileUrl
        {
            get
            {
                if (!this.IsFileExist())
                {
                    return string.Empty;
                }

                var path = ConfigurationManager.AppSettings["SpeisekarteHttpBasePath"];
                return Path.Combine(path, this.FileName);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The is file exist.
        /// </summary>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool IsFileExist()
        {
            if (string.IsNullOrEmpty(this.FileName))
            {
                return false;
            }

            if (System.IO.File.Exists(Path.Combine(this.BasePath, this.FileName)))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}