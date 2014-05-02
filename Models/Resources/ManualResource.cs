namespace ArestedDevelopment.Models.Resources
{
    public class ManualResource : Resource
    {
        public IStubDefinition Def { get; set; }

        //public override string Name {
        //    get { return "ManualResource"; }
        //}

        public override string Type {
            get { return "manual"; }
        }
    }
}