namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Common.Abstractions
{
    using System;

    using AutoMapper;

    public abstract class BaseDeletableViewModel<TKey> : BaseViewModel<TKey>
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
