using System;
using Scripts.Abstarct;

namespace Resource
{
    public class ResourcePresenter : PresenterBase<Resource, ResourceView>, IDisposable
    {
        public ResourcePresenter(Resource model, ResourceView view) : base(model, view)
        {
            View.PickedUp += Model.PickUp;
        }
        
        public void Dispose()
        {
            View.PickedUp -= Model.PickUp;
        }
    }
}