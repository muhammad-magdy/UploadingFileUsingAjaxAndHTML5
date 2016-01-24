using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UploadingFileUsingAjaxAndHTML5.Models;

namespace UploadingFileUsingAjaxAndHTML5.DAL
{
    public class AttachmentContext :DbContext
    {
        public AttachmentContext() 
        : base("AttachmentContext") 
        {
             Database.Initialize(true);
        }
        public DbSet<Attachment> Attachments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
