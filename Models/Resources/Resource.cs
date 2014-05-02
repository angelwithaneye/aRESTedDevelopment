namespace ArestedDevelopment.Models.Resources
{
    public abstract class Resource : IResource
    {
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }

        public virtual bool Init(IArDeveloper instance)
        {
            return true;
        }
    }
}