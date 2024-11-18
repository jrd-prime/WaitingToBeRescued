using System;
using UnityEngine;

namespace _Game._Scripts.Framework.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredFieldAttribute : PropertyAttribute
    {
    }
}
