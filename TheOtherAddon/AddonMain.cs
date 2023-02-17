using TheAddon;

namespace TheOtherAddon
{
    public class AddonMain : TheCore.IAddon
    {
        public object? Action()
        {
            return null;
        }
        public System.Type GetSomeType()
        {
            return typeof(ClassUsingSomeClass);
        }
    }


    public class ClassUsingSomeClass
    {
        int Prop1 { get; set; } = 0;
        SomeClass? Prop2 { get; set; } = null;
    }
}