using System;

namespace JeeLee.JustInject
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
