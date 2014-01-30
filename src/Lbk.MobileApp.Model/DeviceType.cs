// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceType.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Model
{
    using System.ComponentModel.DataAnnotations;

    public enum DeviceType
    {
        [Display(Name = "Alle")]
        All,

        [Display(Name = "IPhone")]
        Iphone,

        [Display(Name = "Android")]
        Android
    }
}