using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using System;
using System.Runtime.CompilerServices;
using Caption = DevExpress.Xpo.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    public interface IGridLookup { }

    [NonPersistent]
    [OptimisticLocking("Version")]
    [NullableBehavior(NullableBehavior.ByUnderlyingType)]
    [Appearance("RedInactiveRecords", TargetItems = "*", Criteria = nameof(IsActive) + "=FALSE", Context = "ListView", FontColor = "Red")]
    public abstract class BusinessObject : XPBaseObject, IGridLookup
    {

        #region String size
        protected const int LARGE_STRING_SIZE = 500;
        protected const int MEDIUM_STRING_SIZE = 255;
        protected const int SMALL_STRING_SIZE = 10;
        #endregion

        public BusinessObject(Session session) : base(session) { }

        int id;
        bool isActive = true;
        User user;
        DateTime createdDate;

        [Key(true)]
        [MemberDesignTimeVisibility(false)]
        public int Id
        {
            get => id;
            set => SetPropertyValue(ref id, value);
        }

        [Caption("Activo")]
        [MemberDesignTimeVisibility(false)]
        public bool IsActive
        {
            get => isActive;
            set => SetPropertyValue(ref isActive, value);
        }

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
            {
                user = (User)SecuritySystem.CurrentUser;
                createdDate = DateTime.Now;
            }
        }

        protected new object GetPropertyValue([CallerMemberName]string propertyName = null)
            => base.GetPropertyValue(propertyName);

        protected new T GetPropertyValue<T>([CallerMemberName]string propertyName = null)
            => base.GetPropertyValue<T>(propertyName);

        protected bool SetPropertyValue<T>(ref T propertyValueHolder, T newValue, [CallerMemberName]string propertyName = null)
            => SetPropertyValue(propertyName, ref propertyValueHolder, newValue);

        protected new XPCollection GetCollection([CallerMemberName] string propertyName = null)
            => base.GetCollection(propertyName);

        protected new XPCollection<T> GetCollection<T>([CallerMemberName] string propertyName = null)
            where T : class => base.GetCollection<T>(propertyName);

        protected new T GetDelayedPropertyValue<T>([CallerMemberName] string propertyName = null)
            => base.GetDelayedPropertyValue<T>(propertyName);

        protected bool SetDelayedPropertyValue<T>(T value, [CallerMemberName] string propertyName = null)
            => SetDelayedPropertyValue(propertyName, value);

        protected new object EvaluateAlias([CallerMemberName] string propertyName = null)
            => base.EvaluateAlias(propertyName);
    }
}
