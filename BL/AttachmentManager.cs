using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UploadingFileUsingAjaxAndHTML5.Models;
using UploadingFileUsingAjaxAndHTML5.DAL;
using System.Data.Entity;

namespace UploadingFileUsingAjaxAndHTML5.BL
{
    public  class AttachmentManager
    {
        public List<Attachment> GetAllAttachments()
        {
            AttachmentContext db = new AttachmentContext();
            return db.Attachments.AsNoTracking().ToList();
        }
        public Attachment GetAttachment(int id)
        {
            AttachmentContext db = new AttachmentContext();
            return db.Attachments.FirstOrDefault(attachment => attachment.ID == id);
        }
        public OperationResult Delete(int id)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                Attachment attachment = GetAttachment(id);
                if (attachment != null)
                {
                    AttachmentContext db = new AttachmentContext();
                    db.Entry(attachment).State = EntityState.Deleted;
                    db.SaveChanges();
                    operationResult.Success = true;
                    operationResult.Message = "Attachment Deleted Successfully";
                }
                else
                {
                    operationResult.Success = false;
                    operationResult.Message = "Attachment not found";
                }

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "An Error Ocured During Deleting the Attachment";
            }
            return operationResult;
        }
        public OperationResult SaveAttachment(Attachment NewAttachment)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                AttachmentContext db = new AttachmentContext();
                db.Attachments.Add(NewAttachment);
                db.SaveChanges();
                operationResult.Success = true;
                operationResult.Message = "Attachment Added Successfully";

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "An Error Ocured During saving the new Attachment ";
            }
                return operationResult;
        }
        public OperationResult SaveAttachments(List<Attachment> NewAttachments)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                AttachmentContext db = new AttachmentContext();
                db.Attachments.AddRange(NewAttachments);
                db.SaveChanges();
                operationResult.Success = true;
                operationResult.Message = "Attachments Added Successfully";

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "An Error Ocured During saving the new Attachments ";
            }
            return operationResult;
        }
    }
    public class OperationResult
    {
        public bool Success;
        public string Message;
        public OperationResult()
        {
            Success = true;
            Message = string.Empty;
        }
        public OperationResult(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
        }
    }
}