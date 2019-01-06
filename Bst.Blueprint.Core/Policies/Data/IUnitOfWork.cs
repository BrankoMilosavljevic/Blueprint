namespace Bst.Blueprint.Core.Policies.Data
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void CancelSaving();
    }
}
