//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InvestNetwork.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectNewsComment
    {
        public int ProjectNewsCommentID { get; set; }
        public int FromUserID { get; set; }
        public int ProjectNewsID { get; set; }
        public string CommentText { get; set; }
        public System.DateTime CommentDate { get; set; }
    
        public virtual ProjectNew ProjectNew { get; set; }
    }
}
