using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repo.Models
{
    [Table("tbl_release_notes")]
    public class ReleaseNotesModel
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Notes { get; set; }
        public bool is_active { get; set; } = true;
        public DateTime created_on { get; set; } = DateTime.Now;
    }
    [Table("tbl_credential")]
    public class CredentialDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int AuuthorizationChange { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_designation")]
    public class DesignationDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_designation_role_mapping")]
    public class DesignationRoleMappingDbModel
    {
        [Key]
        public long Id { get; set; }
        public long userid { get; set; }
        public long roleid { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_people_master")]
    public class PeopleDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Code { get; set; }
        public string Photo { get; set; }
        public string credential_code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_system_constant")]
    public class SystemConstantDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    [Table("tbl_block_user")]
    public class BlockUser
    {
        [Key]
        public long Id { get; set; }
        public string Mobile { get; set; }
        public string Remarks { get; set; }
    }
    [Table("tbl_contact")]
    public class ContactDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string PeopleCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsMobileVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_address")]
    public class AddressDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Code { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string PeopleCode { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string PIN { get; set; }
        public string Landmark { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string City { get; set; }


    }
    [Table("tbl_blogging")]
    public class BloggingDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Photo { get; set; }
        [AllowHtml]
        public string Caption { get; set; }
        public string Breif { get; set; }
        public string Title { get; set; }
        public string Taglines { get; set; }
        public string Category { get; set; }
        [AllowHtml]
        public string LongDetails { get; set; }
        public string AuthorName { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }

    }
    [Table("tbl_product_master")]
    public class ProductDbModel
    {
        [Key]
        public long Id { get; set; }
        public string name { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string Photo4 { get; set; }
        public string Photo5 { get; set; }
        public string Title { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public string MealTypeCode { get; set; }
        public string ProductTypeCod { get; set; }
        public string MealCategoryCode { get; set; }
        public string Detail { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string Add4 { get; set; }
        public string Add5 { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_cart_item_master")]
    public class CartItemDbModel
    {
        [Key]
        public long Id { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public string CouponCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsProcessed { get; set; }

    }
    [Table("tbl_tranaction_master")]
    public class TransactionMasterDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Txn_Ref_ID { get; set; }
        public string PeopleCode { get; set; }
        public string StatusCode { get; set; }
        public bool IsDisputed { get; set; }
        public string Payment_Ref_ID { get; set; }
        public string SourceCode { get; set; }
        public long CartID { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }

    }
    [Table("tbl_meal_type_master")]
    public class MealTypeDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_mean_category")]
    public class MealCategoryDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }

    }
    [Table("tbl_product_type_master")]
    public class ProductTypeDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }

    }
    [Table("tbl_status_code_master")]
    public class StatusDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_payment_type")]
    public class PaymentTypeDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_payment_transaction_master")]
    public class PaymentTransactionDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Payment_Ref_ID { get; set; }
        public string Txn_Ref_id { get; set; }
        public string PaymentTypeCode { get; set; }
        public string ThirdPartyRefID { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string StatusCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
    [Table("tbl_enquiries")]
    public class EnquiryDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string Remarks { get; set; }
        public string SourceCode { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
    [Table("tbl_logistics")]
    public class LogisticDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Txn_Ref_ID { get; set; }
        public string Address_Code { get; set; }
        public string DeliveryRemarks { get; set; }
        public string DeliveryPerson { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
    [Table("tbl_source_master")]
    public class SourceDbModel
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    [Table("tbl_email_template")]
    public class EmailTemplateMaster
    {
        [Key]
        public long Id { get; set; }
        public string TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public string TemplateTitle { get; set; }
        [AllowHtml]
        public string TemplateContent { get; set; }
        public string ParamCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
    [Table("tbl_mail_config")]
    public class MailConfigModel
    {
        public long Id { get; set; }
        public string ProviderName { get; set; }
        public string SmtpDomain { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpUserId { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpPort { get; set; }
        public bool SmtpHtml { get; set; }
        public bool SmtpSSL { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ApiKey { get; set; }
        public string ApiBaseUrl { get; set; }
        public bool IsAPI { get; set; }
    }
    [Table("tbl_sms_config")]
    public class SmsConfigModel
    {
        public long Id { get; set; }
        public string ProviderName { get; set; }
        public string ProviderBaseUrl { get; set; }
        public string ProviderUserName { get; set; }
        public string ProviderPassword { get; set; }
        public string ProviderSenderId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string Add4 { get; set; }
        public string Add5 { get; set; }
    }

    [Table("tbl_sms_template")]
    public class SmsTemplateModel
    {
        [Key]
        public long Id { get; set; }
        public string TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public string TemplateTitle { get; set; }
        [AllowHtml]
        public string TemplateContent { get; set; }
        public string ParamCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
    [Table("tbl_sender_master")]
    public class SenderMasterModel
    {
        [Key]
        public long Id { get; set; }
        [AllowHtml]
        public string Sender { get; set; }
        public string BCC { get; set; }
        public string CC { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Code { get; set; }
    }

}
