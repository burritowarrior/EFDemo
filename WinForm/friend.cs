//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinForm
{
    using System;
    using System.Collections.Generic;
    
    public partial class friend
    {
        public int FriendsID { get; set; }
        public int ContactID { get; set; }
        public string FriendlyName { get; set; }
    
        public virtual contact contact { get; set; }
    }
}