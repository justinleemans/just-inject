using System;

namespace JustInject
{
    [AttributeUsage(
        AttributeTargets.Constructor |
        AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}
