
namespace UpWorkTask.BL
{
    public  interface IDataChangeListner
    {
        public void Attach(IDbChangeObserver dbChangeObserver);
        public void Detach(IDbChangeObserver dbChangeObserver);
    }
}
