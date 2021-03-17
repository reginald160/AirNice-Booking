using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AirNice.Utility.CoreHelpers
{
    //[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    //public class CrudActionAttribute : Attribute
    //{
    //    public CrudAction Action { get; private set; }

    //    public CrudActionAttribute(CrudAction action)
    //    {
    //        Action = action;
    //    }
    //}

    public class UserAction
    {
        [Display(Name = "View")]
        public const string View = "28e24d0b-770b-48e8-84b3-c762e6e312bf";


        [Display(Name = "Create")]
        public const string Create = "7cb36f74-b6ec-402b-aa0b-98cabcfdfbe9";


        [Display(Name = "Edit")]
        public const string Edit = "75da42bb-fb1e-4cc5-a7ca-5b11c49b7aa4";

        [Display(Name = "Delete")]
        public const string Delete = "5d76888c-f268-41cc-a2b8-0ab33d14037f";

    }
    public class AttributeExtention : ActionDescriptor, ICustomAttributeProvider
    {
        protected AttributeExtention()
        {

        }
        public object[] GetCustomAttributes(bool inherit)
        {
            throw new NotImplementedException();
        }
        private Type Attiribute;
        public virtual object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }
        //public virtual object[] GetCoreCustomAttributes(Type attributeType, bool inherit);

        public bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AclAuthorizationAttribute : Attribute
    {
        public Guid ActionId { get; private set; }
        public bool IgnoreAction { get { return ActionId == Guid.Empty; } }

        public AclAuthorizationAttribute(string actionGuidId = null)
        {
            ActionId = string.IsNullOrEmpty(actionGuidId) ? Guid.Empty : Guid.Parse(actionGuidId);
        }
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AddAclActionsAttribute : Attribute
    {
        public readonly Guid[] ActionIds;

        public AddAclActionsAttribute(params string[] actionGuidIds)
        {
            Guid actionId;
            ActionIds = new Guid[actionGuidIds.Count(str => Guid.TryParse(str, out actionId))];
            var i = 0;
            foreach (var actionGuidId in actionGuidIds)
                if (Guid.TryParse(actionGuidId, out actionId))
                    ActionIds[i++] = actionId;
        }
    }



}
