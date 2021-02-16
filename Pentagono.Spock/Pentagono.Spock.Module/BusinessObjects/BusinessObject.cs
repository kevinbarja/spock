using DevExpress.ExpressApp;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using System;
using System.Runtime.CompilerServices;
using Caption = DevExpress.Xpo.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [NonPersistent]
    [OptimisticLocking(false)]
    public abstract class BusinessObject : XPBaseObject
    {
        public BusinessObject(Session session) : base(session) { }

        int id;
        bool isActive = true;
        //        string displayName = string.Empty;
        User user;
        DateTime createdDate;

        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Id
        {
            get => id;
            set => SetPropertyValue(ref id, value);
        }

        [MemberDesignTimeVisibility(false)]
        public bool IsActive
        {
            get => isActive;
            set => SetPropertyValue(ref isActive, value);
        }

/*
        [@DisplayName("Nombre")]
        [Size(255), Nullable(false), RequiredField]
        public string DisplayName
        {
            get => displayName;
            set => SetPropertyValue(ref displayName, value);
        }
*/

        [MemberDesignTimeVisibility(false)]
        public User User
        {
            get => user;
            set => SetPropertyValue(ref user, value);
        }

        [Caption("Fecha de creación")]
        [Nullable(false), MemberDesignTimeVisibility(false)]
        public DateTime CreatedDate
        {
            get => createdDate;
            set => SetPropertyValue(ref createdDate, value);
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork) && Session.IsNewObject(this))
                user = (User) SecuritySystem.CurrentUser;
        }

        protected new object GetPropertyValue([CallerMemberName]string propertyName = null)
            => base.GetPropertyValue(propertyName);

        protected new T GetPropertyValue<T>([CallerMemberName]string propertyName = null)
            => base.GetPropertyValue<T>(propertyName);

        protected bool SetPropertyValue<T>(ref T propertyValueHolder, T newValue, [CallerMemberName]string propertyName = null)
            => base.SetPropertyValue<T>(propertyName, ref propertyValueHolder, newValue);

        protected new XPCollection GetCollection([CallerMemberName] string propertyName = null)
            => base.GetCollection(propertyName);

        protected new XPCollection<T> GetCollection<T>([CallerMemberName] string propertyName = null)
            where T : class => base.GetCollection<T>(propertyName);

        protected new T GetDelayedPropertyValue<T>([CallerMemberName] string propertyName = null)
            => base.GetDelayedPropertyValue<T>(propertyName);

        protected bool SetDelayedPropertyValue<T>(T value, [CallerMemberName] string propertyName = null)
            => base.SetDelayedPropertyValue(propertyName, value);

        protected new object EvaluateAlias([CallerMemberName] string propertyName = null)
            => base.EvaluateAlias(propertyName);
    }
}
