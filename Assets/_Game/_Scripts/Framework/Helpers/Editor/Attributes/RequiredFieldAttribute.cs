using System;
using UnityEngine;

namespace _Game._Scripts.Framework.Helpers.Editor.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RequiredFieldAttribute : PropertyAttribute
    {
    }
}
