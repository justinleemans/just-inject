using System;

namespace JeeLee.UniInjection
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
