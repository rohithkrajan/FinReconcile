namespace FinReconcile.Domain.Interfaces
{
    public interface IReconcileResult
    {
        ReconciledItem[] ReconciledSet { get; set; }
    }
}