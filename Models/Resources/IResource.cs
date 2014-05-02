namespace ArestedDevelopment.Models.Resources
{
    public interface IResource
    {
        string Name { get; }
        string Type { get; }
        bool Init(IArDeveloper instance);
    }
}
