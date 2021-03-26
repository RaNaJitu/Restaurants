using Repo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.DbContexts
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext() : base("RestrurantCrmConStr")
        {
            Database.SetInitializer<DefaultDbContext>(null);
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 3600;
        }
        public DbSet<ReleaseNotesModel> ReleaseNotesModels { get; set; }
        public DbSet<CredentialDbModel> CredentialDbModels { get; set; }
        public DbSet<DesignationDbModel> DesignationDbModels { get; set; }
        public DbSet<DesignationRoleMappingDbModel> DesignationRoleMappingDbModels { get; set; }
        public DbSet<PeopleDbModel> PeopleDbModels { get; set; }
        public DbSet<SystemConstantDbModel> SystemConstantDbModels { get; set; }
        public DbSet<BlockUser> BlockUsers { get; set; }
        public DbSet<ContactDbModel> ContactDbModels { get; set; }
        public DbSet<AddressDbModel> AddressDbModels { get; set; }
        public DbSet<BloggingDbModel> BloggingDbModels { get; set; }
        public DbSet<ProductDbModel> ProductDbModels { get; set; }
        public DbSet<CartItemDbModel> CartItemDbModels { get; set; }
        public DbSet<TransactionMasterDbModel> TransactionMasterDbModels { get; set; }
        public DbSet<MealTypeDbModel> MealTypeDbModels { get; set; }
        public DbSet<MealCategoryDbModel> MealCategoryDbModels { get; set; }
        public DbSet<ProductTypeDbModel> ProductTypeDbModels { get; set; }
        public DbSet<StatusDbModel> StatusDbModels { get; set; }
        public DbSet<PaymentTypeDbModel> PaymentTypeDbModels { get; set; }
        public DbSet<PaymentTransactionDbModel> PaymentTransactionDbModels { get; set; }
        public DbSet<EnquiryDbModel> EnquiryDbModels { get; set; }
        public DbSet<LogisticDbModel> LogisticDbModels { get; set; }
        public DbSet<SourceDbModel> SourceDbModels { get; set; }
        public DbSet<EmailTemplateMaster> EmailTemplateMasters { get; set; }
        public DbSet<MailConfigModel> MailConfigModels { get; set; }
        public DbSet<SmsConfigModel> SmsConfigModels { get; set; }
        public DbSet<SmsTemplateModel> SmsTemplateModels { get; set; }
        public DbSet<SenderMasterModel> SenderMasterModels { get; set; }

    }
}
